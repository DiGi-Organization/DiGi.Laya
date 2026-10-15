namespace DiGi.Laya.Constants
{
    /// <summary>
    /// Provides the names of the files the Laya scripts are shipped as, write and read, and the files that mark a Laya checkpoint directory.
    /// </summary>
    public static class FileName
    {
        /// <summary>
        /// The preflight check script.
        /// </summary>
        public const string Check = "check.py";

        /// <summary>
        /// The calibration script.
        /// </summary>
        public const string Calibrate = "calibrate.py";

        /// <summary>
        /// The prediction script.
        /// </summary>
        public const string Predict = "predict.py";

        /// <summary>
        /// The requirements file pinning the laya version the scripts are written against; check.py reads it.
        /// </summary>
        public const string Requirements = "requirements.txt";

        /// <summary>
        /// The fine-tuning script.
        /// </summary>
        public const string Train = "train.py";

        /// <summary>
        /// The module of helpers every script imports; Python resolves it against the directory the script sits in.
        /// </summary>
        public const string Utils = "utils.py";

        /// <summary>
        /// The JSONL file of requests predict.py reads, written into the working directory.
        /// </summary>
        public const string Requests = "requests.jsonl";

        /// <summary>
        /// The JSONL file of responses predict.py writes into the working directory.
        /// </summary>
        public const string Responses = "responses.jsonl";

        /// <summary>
        /// The JSON file of laya.train.TrainConfig fields train.py reads with --config, written into the working directory.
        /// </summary>
        public const string TrainConfiguration = "train_config.json";

        /// <summary>
        /// The weights file of a Laya checkpoint directory; a trained checkpoint without it is not trusted.
        /// </summary>
        public const string Model = "model.safetensors";

        /// <summary>
        /// The configuration file whose presence makes a directory a Laya checkpoint for laya.load.
        /// </summary>
        public const string CheckpointConfiguration = "rl_agent_config.json";
    }
}
