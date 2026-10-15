# Preflight check: can this interpreter run DiGi.Laya's scripts, and does the checkpoint load?
#
# Usage: check.py [--model <checkpoint directory>] [--device auto|cpu|cuda]
#
# Output contract read by DiGi.Laya Query.LayaEnvironmentResult: one JSON object between the lines
# LAYA_CHECK_JSON_BEGIN and LAYA_CHECK_JSON_END (utils.print_marked_json), with the keys
#   runnable          true when nothing in "messages" stops a run
#   python_path, python_version
#   cuda_available    torch.cuda.is_available(), or null when torch did not import
#   cuda_device       the name of CUDA device 0, or null
#   packages          [{"name", "version"}] for every package below; version null when not installed
#   laya_required     the version requirements.txt pins laya to, or null when it pins none
#   model             null without --model; otherwise {"path", "option_layout", "max_len", "head_max_len", "device", "loaded"}
#   messages          findings that stop a run: no torch, no laya, laya not the pinned version, a parallel-layout
#                     checkpoint under transformers < 5, a model directory that is missing or does not load
#   warnings          findings that do not
# Exit code 0 whenever the payload was printed, whatever "runnable" says.
import argparse
import os
import sys

from utils import checkpoint_directory, device_argument, print_marked_json, read_checkpoint_config

parser = argparse.ArgumentParser(description="DiGi.Laya preflight check")
parser.add_argument("--model", type=str, default=None, help="Checkpoint directory to load")
parser.add_argument("--device", type=str, default="auto", help="auto, cpu or cuda")
args = parser.parse_args()

PACKAGES = ["laya", "torch", "transformers", "tokenizers", "safetensors", "huggingface_hub", "numpy"]

messages = []
warnings = []


def version_tuple(version):
    parts = []
    for part in version.split("+")[0].split("."):
        digits = "".join(character for character in part if character.isdigit())
        parts.append(int(digits) if digits else 0)
    return tuple(parts)


def installed_version(name):
    try:
        from importlib.metadata import PackageNotFoundError, version
        try:
            return version(name)
        except PackageNotFoundError:
            return None
    except Exception:
        return None


def required_laya_version():
    """The exact version requirements.txt beside this script pins laya to."""
    path = os.path.join(os.path.dirname(os.path.abspath(__file__)), "requirements.txt")
    if not os.path.isfile(path):
        return None
    with open(path, encoding="utf-8") as file:
        for line in file:
            line = line.split("#", 1)[0].strip().replace(" ", "")
            if line.lower().startswith("laya=="):
                return line[len("laya=="):]
    return None


packages = [{"name": name, "version": installed_version(name)} for name in PACKAGES]
versions = {package["name"]: package["version"] for package in packages}

cuda_available = None
cuda_device = None
try:
    import torch
    cuda_available = bool(torch.cuda.is_available())
    if cuda_available:
        cuda_device = torch.cuda.get_device_name(0)
except Exception as exception:
    messages.append(f"torch import failed: {exception}")

laya_required = required_laya_version()
if versions["laya"] is None:
    messages.append("laya is not installed; install requirements.txt")
elif laya_required is not None and versions["laya"] != laya_required:
    messages.append(f"laya {versions['laya']} is installed, but requirements.txt pins {laya_required}")

if args.device and args.device.lower() == "cuda" and cuda_available is False:
    messages.append("--device cuda was requested, but torch reports no CUDA device")

model = None
if args.model:
    path = checkpoint_directory(args.model)
    model = {"path": os.path.abspath(args.model), "option_layout": None, "max_len": None, "head_max_len": None, "device": None, "loaded": False}
    if path is None:
        messages.append(f"Model directory does not exist or holds no rl_agent_config.json: {os.path.abspath(args.model)}")
    else:
        try:
            config = read_checkpoint_config(path)
            model["option_layout"] = config.get("option_layout") or "sequential"
            model["max_len"] = config.get("max_len")
            model["head_max_len"] = config.get("head_max_len")
        except Exception as exception:
            messages.append(f"Could not read rl_agent_config.json: {exception}")

        # The parallel layout goes through ModernBERT's per-layer-type mask argument, which transformers 4.x lacks
        if model["option_layout"] == "parallel" and versions["transformers"] and version_tuple(versions["transformers"]) < (5,):
            messages.append(f"The checkpoint uses the parallel option layout, which needs transformers 5 or later; {versions['transformers']} is installed")

        if not messages:
            try:
                import laya
                agent = laya.load(path, device=device_argument(args.device))
                model["device"] = str(getattr(agent, "device", None))
                model["loaded"] = True
            except Exception as exception:
                messages.append(f"Model did not load: {type(exception).__name__}: {exception}")

if cuda_available is False:
    warnings.append("No CUDA device: Laya runs on the CPU, which is much slower for training")

print_marked_json("LAYA_CHECK_JSON_BEGIN", "LAYA_CHECK_JSON_END", {
    "runnable": len(messages) == 0,
    "python_path": sys.executable,
    "python_version": sys.version.split()[0],
    "cuda_available": cuda_available,
    "cuda_device": cuda_device,
    "packages": packages,
    "laya_required": laya_required,
    "model": model,
    "messages": messages,
    "warnings": warnings,
})
