# Helpers shared by check.py, predict.py, train.py and calibrate.py. Import it before laya, torch,
# transformers or huggingface_hub: importing it switches the Hugging Face libraries offline, so a production
# run never downloads anything - a checkpoint is always a local directory (DiGi-Organization/DiGi.Laya#1, D4).
# DiGi.Laya sets the same variables on the process; setting them here as well keeps a script run by hand
# offline too.
import json
import os
import sys

os.environ.setdefault("HF_HUB_OFFLINE", "1")
os.environ.setdefault("TRANSFORMERS_OFFLINE", "1")
os.environ.setdefault("HF_HUB_DISABLE_TELEMETRY", "1")

# The file laya reads to recognise a checkpoint directory (laya.agent._is_local_checkpoint_arg).
CHECKPOINT_CONFIG = "rl_agent_config.json"


def checkpoint_directory(path):
    """The absolute checkpoint directory, or None when `path` is not a directory holding rl_agent_config.json.

    laya.load and laya.train.finetune treat any other value as a model name or Hub id and resolve or
    download it, so a value that is not a checkpoint directory on disk is refused before laya sees it.
    """
    if not path:
        return None
    path = os.path.abspath(path)
    if not os.path.isfile(os.path.join(path, CHECKPOINT_CONFIG)):
        return None
    return path


def read_checkpoint_config(path):
    with open(os.path.join(path, CHECKPOINT_CONFIG), encoding="utf-8") as file:
        return json.load(file)


def device_argument(device):
    """The device laya is given: None for "auto" (CUDA, then MPS, then XPU, then CPU), otherwise as named."""
    if device is None or device == "" or device.lower() == "auto":
        return None
    return device.lower()


def read_jsonl(path):
    rows = []
    with open(path, encoding="utf-8-sig") as file:
        for line in file:
            line = line.strip()
            if line:
                rows.append(json.loads(line))
    return rows


def write_jsonl(path, rows):
    """Writes one JSON object per line through a temporary file, so a crash never leaves a partial file at `path`."""
    temporary = path + ".tmp"
    with open(temporary, "w", encoding="utf-8", newline="\n") as file:
        for row in rows:
            file.write(json.dumps(row, ensure_ascii=False, default=json_default))
            file.write("\n")
    os.replace(temporary, path)


def json_default(value):
    """Lets numpy and torch scalars, tuples and sets in a laya report reach json.dumps."""
    if hasattr(value, "item"):
        return value.item()
    if hasattr(value, "tolist"):
        return value.tolist()
    if isinstance(value, (set, tuple)):
        return list(value)
    return str(value)


def print_marked_json(begin, end, value):
    """The stdout contract of every script: the JSON payload between two marker lines.

    DiGi.Python's Query.MarkedJson reads the last marker pair and joins the lines between them, so whatever
    laya, torch or transformers print before or after - warnings and progress included - is never parsed.
    """
    sys.stdout.flush()
    print(begin)
    print(json.dumps(value, indent=1, default=json_default))
    print(end)
    sys.stdout.flush()


def fail(message, code=2):
    """Reports a refusal on stderr and exits with `code`; 2 is an argument or input the script refuses."""
    print(message, file=sys.stderr)
    sys.stderr.flush()
    sys.exit(code)
