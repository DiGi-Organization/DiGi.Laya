using DiGi.Laya.Classes;
using DiGi.Laya.Enums;
using System.Text.Json.Nodes;

namespace DiGi.Laya
{
    public static partial class Convert
    {
        /// <summary>
        /// Converts training options into the JSON object of laya.train.TrainConfig fields train.py reads with --config.
        /// <para>Only the settings that are set are written, under laya 0.4.7's field names, so every other field keeps laya's default: epochs, micro_batch, grad_accum, encoder_lr, head_lr, loss ("rlcd" or "soft-ce"), shuffle_options (["choice"]), option_layout ("sequential" or "parallel"), freeze_encoder (only when true), label_smoothing, calib_max, calib_frac, calib_seed, seed, max_len, head_max_len, target_error and eval_data (the evaluation file as a full path). Numbers are written by <see cref="JsonValue"/>, so the current culture plays no part. The paths of the base checkpoint, the data and the output are command-line arguments of train.py, not TrainConfig fields.</para>
        /// </summary>
        /// <param name="layaTrainingOptions">The options to convert.</param>
        /// <returns>The TrainConfig fields, or <c>null</c> when the options are <c>null</c>.</returns>
        public static JsonObject? ToLaya_TrainConfiguration(this LayaTrainingOptions? layaTrainingOptions)
        {
            if (layaTrainingOptions == null)
            {
                return null;
            }

            JsonObject jsonObject = [];

            void Add(string name, JsonNode? jsonNode)
            {
                if (jsonNode != null)
                {
                    jsonObject[name] = jsonNode;
                }
            }

            static JsonNode? Number(int? value)
            {
                return value == null ? null : JsonValue.Create(value.Value);
            }

            static JsonNode? Real(double? value)
            {
                return value == null ? null : JsonValue.Create(value.Value);
            }

            Add("epochs", Number(layaTrainingOptions.Epochs));
            Add("micro_batch", Number(layaTrainingOptions.MicroBatch));
            Add("grad_accum", Number(layaTrainingOptions.GradientAccumulation));
            Add("encoder_lr", Real(layaTrainingOptions.EncoderLearningRate));
            Add("head_lr", Real(layaTrainingOptions.HeadLearningRate));

            switch (layaTrainingOptions.Loss)
            {
                case LayaLoss.Rlcd:
                    Add("loss", JsonValue.Create("rlcd"));
                    break;

                case LayaLoss.SoftCrossEntropy:
                    Add("loss", JsonValue.Create("soft-ce"));
                    break;
            }

            if (layaTrainingOptions.ShuffleChoiceOptions)
            {
                Add("shuffle_options", new JsonArray("choice"));
            }

            switch (layaTrainingOptions.OptionLayout)
            {
                case LayaOptionLayout.Sequential:
                    Add("option_layout", JsonValue.Create("sequential"));
                    break;

                case LayaOptionLayout.Parallel:
                    Add("option_layout", JsonValue.Create("parallel"));
                    break;
            }

            if (layaTrainingOptions.FreezeEncoder)
            {
                Add("freeze_encoder", JsonValue.Create(true));
            }

            Add("label_smoothing", Real(layaTrainingOptions.LabelSmoothing));
            Add("calib_max", Number(layaTrainingOptions.CalibrationMaximum));
            Add("calib_frac", Real(layaTrainingOptions.CalibrationFraction));
            Add("calib_seed", Number(layaTrainingOptions.CalibrationSeed));
            Add("seed", Number(layaTrainingOptions.Seed));
            Add("max_len", Number(layaTrainingOptions.MaxLength));
            Add("head_max_len", Number(layaTrainingOptions.HeadMaxLength));
            Add("target_error", Real(layaTrainingOptions.TargetError));

            string? evaluationFilePath = Python.Query.NormalizedPath(layaTrainingOptions.EvaluationFilePath);
            if (evaluationFilePath != null)
            {
                Add("eval_data", JsonValue.Create(evaluationFilePath));
            }

            return jsonObject;
        }
    }
}
