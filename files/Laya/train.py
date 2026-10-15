# Fine-tunes a local Laya checkpoint on a JSONL of labelled decisions with laya.train.finetune.
#
# Usage: train.py --base <checkpoint directory> --data <training.jsonl> --output <new checkpoint directory>
#                 [--config <train_config.json>] [--device auto|cpu|cuda]
#
# A training line is DiGi.Laya's Convert.ToLaya_TrainingLine(LayaTrainingSample): laya's request shape plus
# "expected" or "gold". --config is a JSON object of laya.train.TrainConfig fields by their Python names
# (epochs, micro_batch, grad_accum, encoder_lr, head_lr, loss, shuffle_options, option_layout, freeze_encoder,
# label_smoothing, calib_max, calib_frac, calib_seed, seed, max_len, head_max_len, target_error, eval_data, ...);
# a field it leaves out keeps laya's default, and a field TrainConfig does not have is refused.
#
# finetune holds out a calibration slice, fits one temperature per question type and the abstention thresholds,
# and writes them into the new checkpoint's config. It also leaves a full copy of the checkpoint in
# <output>/checkpoint_latest, rewritten after every epoch so a crash costs at most one; once the run has finished
# that copy is only a duplicate of the checkpoint (about 644 MB for laya-multilingual) and would change the
# directory's SHA-256, so it is removed here (DiGi-Organization/DiGi.Laya#1, D5). DiGi.Laya hashes the output
# directory itself after this script exits.
#
# Output contract read by DiGi.Laya Modify.TrainAsync: one JSON object between LAYA_TRAIN_JSON_BEGIN and
# LAYA_TRAIN_JSON_END with {"output_dir", "train_items", "calibration_items", "eval_items", "skipped",
# "epoch_loss", "temperature", "seconds"}; "temperature" is [choice, score, noul].
# Exit codes: 0 when the checkpoint was written, 2 when an argument is refused (including an output directory
# that is not empty), 1 when training failed.
import argparse
import json
import os
import shutil
import time

from utils import checkpoint_directory, device_argument, fail, print_marked_json

parser = argparse.ArgumentParser(description="DiGi.Laya fine-tuning")
parser.add_argument("--base", type=str, required=True, help="Checkpoint directory to start from")
parser.add_argument("--data", type=str, required=True, help="Training JSONL")
parser.add_argument("--output", type=str, required=True, help="Directory the new checkpoint is written to; must be empty or absent")
parser.add_argument("--config", type=str, default=None, help="JSON file of TrainConfig fields")
parser.add_argument("--device", type=str, default="auto", help="auto, cpu or cuda")
args = parser.parse_args()

base_path = checkpoint_directory(args.base)
if base_path is None:
    fail(f"Base directory does not exist or holds no rl_agent_config.json: {os.path.abspath(args.base)}")

if not os.path.isfile(args.data):
    fail(f"Training file does not exist: {args.data}")

output_path = os.path.abspath(args.output)
if os.path.isdir(output_path) and os.listdir(output_path):
    fail(f"Output directory is not empty: {output_path}")

if os.path.normcase(output_path).startswith(os.path.normcase(base_path) + os.sep) or os.path.normcase(output_path) == os.path.normcase(base_path):
    fail(f"Output directory lies inside the base checkpoint: {output_path}")

settings = {}
if args.config:
    try:
        with open(args.config, encoding="utf-8-sig") as file:
            settings = json.load(file)
    except Exception as exception:
        fail(f"Could not read --config: {exception}")
    if not isinstance(settings, dict):
        fail("--config must hold a JSON object")

if isinstance(settings.get("shuffle_options"), list):
    settings["shuffle_options"] = tuple(settings["shuffle_options"])

if settings.get("eval_data") and not os.path.isfile(settings["eval_data"]):
    fail(f"Evaluation file does not exist: {settings['eval_data']}")

from laya.train import TrainConfig, finetune

try:
    config = TrainConfig(**settings)
    config.validate()
except (TypeError, ValueError) as exception:
    fail(f"Invalid training settings: {exception}")

start = time.perf_counter()
report = finetune(os.path.abspath(args.data), base_path, output_path, config, device=device_argument(args.device))
seconds = time.perf_counter() - start

checkpoint_latest = os.path.join(output_path, "checkpoint_latest")
if os.path.isdir(checkpoint_latest):
    shutil.rmtree(checkpoint_latest)

if checkpoint_directory(output_path) is None or not os.path.isfile(os.path.join(output_path, "model.safetensors")):
    fail(f"finetune returned without writing a checkpoint to {output_path}", 1)

print_marked_json("LAYA_TRAIN_JSON_BEGIN", "LAYA_TRAIN_JSON_END", {
    "output_dir": output_path,
    "train_items": report.get("train_items"),
    "calibration_items": report.get("calibration_items"),
    "eval_items": report.get("eval_items"),
    "skipped": report.get("skipped"),
    "epoch_loss": report.get("epoch_loss"),
    "temperature": report.get("temperature"),
    "seconds": round(seconds, 3),
})
