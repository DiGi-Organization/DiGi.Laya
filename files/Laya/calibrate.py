# Fits calibration temperatures for an existing Laya checkpoint and writes them to a calibration JSON beside it.
#
# Usage: calibrate.py --model <checkpoint directory> --data <labelled.jsonl> --output <calibration.json>
#                     [--device auto|cpu|cuda] [--seed <n>]
#
# For a checkpoint finetune did not calibrate - the shipped ones carry temperature [1.0, 1.0, 1.0] and are
# over-confident. The labelled lines have the training schema (Convert.ToLaya_TrainingLine): laya's request
# shape plus "expected" or "gold". Each labelled question is run through the model once; laya's fitter
# (Agent.fit_temperatures, compute_ece=True) holds out a fifth of the records per bucket, fits on the rest and
# scores the expected calibration error before and after on the held-out part. Temperatures are clamped by laya
# to [0.5, 5.0].
#
# The checkpoint is never modified, so its SHA-256 stays its identity: the result goes to --output through
# Agent.save_calibration, which laya.load reads back with calibration=<path> (predict.py --calibration). An
# output inside the checkpoint directory is refused for the same reason (DiGi-Organization/DiGi.Laya#1, D3).
#
# Output contract read by DiGi.Laya Modify.CalibrateAsync: one JSON object between LAYA_CALIBRATE_JSON_BEGIN and
# LAYA_CALIBRATE_JSON_END with {"output", "records", "skipped", "temperature", "temperature_by_options",
# "ece_before", "ece_after", "evaluation_records", "seconds"}; "temperature" is [choice, score, noul], and the
# two ECE values are null when no record was held out. laya holds records out only from a bucket (question type x
# option count) that keeps laya.calibrate.MIN_BUCKET_N (2000) records after the 20 % holdout, so below about 2500
# records in a bucket the ECE is null by design - an in-sample ECE would flatter the fit and is not computed here.
# A type-level temperature is fitted from 10 records of that type upward; on few records it often lands on a clamp
# bound (0.5 or 5.0), which says the data cannot place it, not that the model needs it.
# Exit codes: 0 when the calibration file was written, 2 when an argument or the data is refused, 1 on failure.
import argparse
import os
import time

from utils import checkpoint_directory, device_argument, fail, print_marked_json, read_jsonl

parser = argparse.ArgumentParser(description="DiGi.Laya calibration")
parser.add_argument("--model", type=str, required=True, help="Checkpoint directory")
parser.add_argument("--data", type=str, required=True, help="Labelled JSONL")
parser.add_argument("--output", type=str, required=True, help="Calibration JSON to write, outside the checkpoint")
parser.add_argument("--device", type=str, default="auto", help="auto, cpu or cuda")
parser.add_argument("--seed", type=int, default=0, help="Seed of the held-out split the ECE is scored on")
args = parser.parse_args()

model_path = checkpoint_directory(args.model)
if model_path is None:
    fail(f"Model directory does not exist or holds no rl_agent_config.json: {os.path.abspath(args.model)}")

if not os.path.isfile(args.data):
    fail(f"Labelled file does not exist: {args.data}")

output_path = os.path.abspath(args.output)
if os.path.normcase(output_path).startswith(os.path.normcase(model_path) + os.sep):
    fail(f"Calibration file lies inside the checkpoint, which would change its SHA-256: {output_path}")

try:
    rows = read_jsonl(args.data)
except Exception as exception:
    fail(f"Labelled file is not valid JSONL: {exception}")

import laya
from laya.calibrate import records_from_labeled
from laya.train import target_from_expected, target_from_gold, to_internal

# (state, questions, targets) per row, with only the labelled questions; a question laya refuses is counted, not fatal
pairs = []
skipped = 0
for row in rows:
    state = row.get("state") if isinstance(row, dict) else None
    questions = row.get("questions") if isinstance(row, dict) else None
    if state is None or not isinstance(questions, dict):
        skipped += 1
        continue
    expected = row.get("expected") if isinstance(row.get("expected"), dict) else {}
    gold = row.get("gold") if isinstance(row.get("gold"), dict) else {}
    labelled = {}
    targets = {}
    for qid, question in questions.items():
        if qid not in expected and qid not in gold:
            continue
        try:
            internal = to_internal(qid, question)
            targets[qid] = target_from_gold(internal, gold[qid]) if qid in gold else target_from_expected(internal, expected[qid])
            labelled[qid] = question
        except (ValueError, TypeError, KeyError):
            skipped += 1
    if labelled:
        pairs.append((state, labelled, targets))

if not pairs:
    fail(f"No labelled question could be read from {args.data} ({skipped} skipped)")

start = time.perf_counter()
agent = laya.load(model_path, device=device_argument(args.device))
records = records_from_labeled(agent, pairs)
fitted = agent.fit_temperatures(records, compute_ece=True, seed=args.seed)

directory = os.path.dirname(output_path)
if directory:
    os.makedirs(directory, exist_ok=True)
agent.save_calibration(output_path)
seconds = time.perf_counter() - start

report = fitted.get("report") or {}
evaluation_records = int(report.get("n_eval") or 0)

print_marked_json("LAYA_CALIBRATE_JSON_BEGIN", "LAYA_CALIBRATE_JSON_END", {
    "output": output_path,
    "records": len(records),
    "skipped": skipped,
    "temperature": [float(value) for value in fitted["temperature"]],
    "temperature_by_options": {str(key): float(value) for key, value in dict(fitted["temperature_by_options"]).items()},
    "ece_before": report.get("ece_before") if evaluation_records > 0 else None,
    "ece_after": report.get("ece_after") if evaluation_records > 0 else None,
    "evaluation_records": evaluation_records,
    "seconds": round(seconds, 3),
})
