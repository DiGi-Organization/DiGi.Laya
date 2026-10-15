# Answers the requests of a JSONL file with a local Laya checkpoint and writes one response line per request.
#
# Usage: predict.py --model <checkpoint directory> --input <requests.jsonl> --output <responses.jsonl>
#                   [--device auto|cpu|cuda] [--batch-size <n>] [--calibration <calibration json>]
#
# A request line is DiGi.Laya's Convert.ToLaya_JsonObject(LayaRequest):
#   {"id": ..., "state": ..., "questions": {name: definition}, "max_len": ..., "head_max_len": ...}
# A response line is laya's result with the request id added, read by Convert.ToDiGi_LayaResponse:
#   {"id": ..., "model": ..., "answers": {name: answer}, "usage": {...}}
# or, when laya refused the request's group, {"id": ..., "error": "<type>: <message>"}.
# Lines are written in request order, through a temporary file, so the output either exists whole or not at all.
#
# laya.predict_batch asks one question set of many states, so requests are grouped by their questions and token
# budgets; the requests DiGi.Laya's classification workflow builds share their questions and form one group. A group
# is answered in chunks of --chunk-size states, one predict_batch call each, and a line
#   LAYA_PROGRESS <answered>/<requests>
# is printed after every chunk: laya prints nothing while it predicts, so without it a long batch would look like a
# stalled process to the caller's inactivity limit (DiGi.Python's ExecuteProcess).
#
# Also prints, between LAYA_PREDICT_JSON_BEGIN and LAYA_PREDICT_JSON_END, {"requests", "answered", "failed",
# "groups", "device", "load_seconds", "predict_seconds"}.
# Exit codes: 0 when the output was written (failed requests are error lines, not a failed run), 2 when an argument
# or the input is refused, 1 when the checkpoint did not load or the run crashed.
import argparse
import json
import os
import time

from utils import checkpoint_directory, device_argument, fail, print_marked_json, read_jsonl, write_jsonl

parser = argparse.ArgumentParser(description="DiGi.Laya prediction")
parser.add_argument("--model", type=str, required=True, help="Checkpoint directory")
parser.add_argument("--input", type=str, required=True, help="Requests JSONL")
parser.add_argument("--output", type=str, required=True, help="Responses JSONL to write")
parser.add_argument("--device", type=str, default="auto", help="auto, cpu or cuda")
parser.add_argument("--batch-size", type=int, default=16, help="States per forward pass")
parser.add_argument("--chunk-size", type=int, default=256, help="States per predict_batch call, and per progress line")
parser.add_argument("--calibration", type=str, default=None, help="Calibration JSON written by calibrate.py")
args = parser.parse_args()

model_path = checkpoint_directory(args.model)
if model_path is None:
    fail(f"Model directory does not exist or holds no rl_agent_config.json: {os.path.abspath(args.model)}")

if not os.path.isfile(args.input):
    fail(f"Input file does not exist: {args.input}")

if args.batch_size < 1:
    fail(f"--batch-size must be positive, got {args.batch_size}")

if args.chunk_size < 1:
    fail(f"--chunk-size must be positive, got {args.chunk_size}")

if args.calibration and not os.path.isfile(args.calibration):
    fail(f"Calibration file does not exist: {args.calibration}")

try:
    requests = read_jsonl(args.input)
except Exception as exception:
    fail(f"Input file is not valid JSONL: {exception}")

for index, request in enumerate(requests):
    if not isinstance(request, dict) or "state" not in request or not isinstance(request.get("questions"), dict) or not request["questions"]:
        fail(f"Request {index + 1} has no state or no questions")

import laya

start = time.perf_counter()
agent = laya.load(model_path, device=device_argument(args.device), calibration=os.path.abspath(args.calibration) if args.calibration else None)
load_seconds = time.perf_counter() - start

# Groups keep the order their first request appears in; json.dumps without sort_keys keeps the question order,
# which is the order laya answers in
groups = {}
for index, request in enumerate(requests):
    key = (json.dumps(request["questions"]), request.get("max_len"), request.get("head_max_len"))
    groups.setdefault(key, []).append(index)

responses = [None] * len(requests)
failed = 0
done = 0

start = time.perf_counter()
for (_, max_len, head_max_len), indexes_Group in groups.items():
    questions = requests[indexes_Group[0]]["questions"]
    for offset in range(0, len(indexes_Group), args.chunk_size):
        indexes = indexes_Group[offset:offset + args.chunk_size]
        states = [requests[index]["state"] for index in indexes]
        try:
            results = agent.predict_batch(states, questions, batch_size=args.batch_size, max_len=max_len, head_max_len=head_max_len)
        except Exception as exception:
            failed += len(indexes)
            for index in indexes:
                responses[index] = {"id": requests[index].get("id"), "error": f"{type(exception).__name__}: {exception}"}
        else:
            for index, result in zip(indexes, results):
                response = {"id": requests[index].get("id")}
                response.update(result)
                responses[index] = response
        done += len(indexes)
        print(f"LAYA_PROGRESS {done}/{len(requests)}", flush=True)
predict_seconds = time.perf_counter() - start

write_jsonl(args.output, responses)

print_marked_json("LAYA_PREDICT_JSON_BEGIN", "LAYA_PREDICT_JSON_END", {
    "requests": len(requests),
    "answered": len(requests) - failed,
    "failed": failed,
    "groups": len(groups),
    "device": str(getattr(agent, "device", None)),
    "load_seconds": round(load_seconds, 3),
    "predict_seconds": round(predict_seconds, 3),
})
