using DiGi.Core.Classes;
using DiGi.Laya.Enums;
using DiGi.Laya.Interfaces;
using System;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Provides the settings of one fine-tuning run of laya.train.finetune: the interpreter, the base checkpoint, the data, where the new checkpoint goes, and the training settings.
    /// <para>A training setting left <c>null</c> (or <c>Default</c>) keeps laya's own default, which follows the published notebook: 4 epochs, a micro-batch of 8 with 8 accumulation steps, learning rates 2.5e-5 (encoder) and 1e-4 (head), the base checkpoint's token budgets, and a calibration slice of 400 items or a tenth of the data, whichever is smaller. The settings that are set are written for train.py by <see cref="Convert.ToLaya_TrainConfiguration(LayaTrainingOptions?)"/>.</para>
    /// <para>Training data and outputs belong in a training directory outside the workspace; <c>Modify.TrainAsync</c> refuses an output directory inside a Laya\models folder, where deployed checkpoints live.</para>
    /// </summary>
    public class LayaTrainingOptions : SerializableOptions, ILayaSerializableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LayaTrainingOptions"/> class with default values.
        /// </summary>
        public LayaTrainingOptions()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaTrainingOptions"/> class by copying an existing options instance.
        /// </summary>
        /// <param name="layaTrainingOptions">The source options instance to copy from.</param>
        public LayaTrainingOptions(LayaTrainingOptions? layaTrainingOptions)
            : base(layaTrainingOptions)
        {
            if (layaTrainingOptions != null)
            {
                BaseModelPath = layaTrainingOptions.BaseModelPath;
                CalibrationFraction = layaTrainingOptions.CalibrationFraction;
                CalibrationMaximum = layaTrainingOptions.CalibrationMaximum;
                CalibrationSeed = layaTrainingOptions.CalibrationSeed;
                Device = layaTrainingOptions.Device;
                EncoderLearningRate = layaTrainingOptions.EncoderLearningRate;
                Epochs = layaTrainingOptions.Epochs;
                EvaluationFilePath = layaTrainingOptions.EvaluationFilePath;
                FreezeEncoder = layaTrainingOptions.FreezeEncoder;
                GradientAccumulation = layaTrainingOptions.GradientAccumulation;
                HeadLearningRate = layaTrainingOptions.HeadLearningRate;
                HeadMaxLength = layaTrainingOptions.HeadMaxLength;
                InactivityTimeout = layaTrainingOptions.InactivityTimeout;
                LabelSmoothing = layaTrainingOptions.LabelSmoothing;
                Loss = layaTrainingOptions.Loss;
                MaxLength = layaTrainingOptions.MaxLength;
                MicroBatch = layaTrainingOptions.MicroBatch;
                OptionLayout = layaTrainingOptions.OptionLayout;
                OutputDirectory = layaTrainingOptions.OutputDirectory;
                PythonPath = layaTrainingOptions.PythonPath;
                Seed = layaTrainingOptions.Seed;
                ShuffleChoiceOptions = layaTrainingOptions.ShuffleChoiceOptions;
                TargetError = layaTrainingOptions.TargetError;
                Timeout = layaTrainingOptions.Timeout;
                TrainingFilePath = layaTrainingOptions.TrainingFilePath;
                WorkingDirectory = layaTrainingOptions.WorkingDirectory;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaTrainingOptions"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the settings.</param>
        public LayaTrainingOptions(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets or sets the checkpoint directory training starts from, resolved by <see cref="Query.LayaModelPath(string?)"/>; a model name or Hub id is refused.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(BaseModelPath))]
        public string? BaseModelPath { get; set; } = null;

        /// <summary>
        /// Gets or sets the largest share of the items held out to fit the calibration temperatures (TrainConfig.calib_frac), or <c>null</c> for laya's 0.1.
        /// <para>laya holds out min(<see cref="CalibrationMaximum"/>, the item count times this, rounded down) items, so on a small dataset this, not the maximum, decides.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(CalibrationFraction))]
        public double? CalibrationFraction { get; set; } = null;

        /// <summary>
        /// Gets or sets the most items held out to fit the calibration temperatures (TrainConfig.calib_max), or <c>null</c> for laya's 400.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(CalibrationMaximum))]
        public int? CalibrationMaximum { get; set; } = null;

        /// <summary>
        /// Gets or sets the seed of the calibration hold-out (TrainConfig.calib_seed), or <c>null</c> for laya's.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(CalibrationSeed))]
        public int? CalibrationSeed { get; set; } = null;

        /// <summary>
        /// Gets or sets the device training runs on, passed to train.py as --device.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Device))]
        public LayaDevice Device { get; set; } = LayaDevice.Auto;

        /// <summary>
        /// Gets or sets the learning rate of the encoder (TrainConfig.encoder_lr), or <c>null</c> for laya's 2.5e-5.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(EncoderLearningRate))]
        public double? EncoderLearningRate { get; set; } = null;

        /// <summary>
        /// Gets or sets the number of epochs (TrainConfig.epochs), or <c>null</c> for laya's 4. A small dataset needs more epochs to reach a similar number of optimizer updates.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Epochs))]
        public int? Epochs { get; set; } = null;

        /// <summary>
        /// Gets or sets a second labelled JSONL answered before and after training (TrainConfig.eval_data), or <c>null</c> to report on the calibration slice.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(EvaluationFilePath))]
        public string? EvaluationFilePath { get; set; } = null;

        /// <summary>
        /// Gets or sets a value indicating whether only the decision head is trained (TrainConfig.freeze_encoder); fits a small GPU or a CPU, but gains much less.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(FreezeEncoder))]
        public bool FreezeEncoder { get; set; } = false;

        /// <summary>
        /// Gets or sets the number of micro-batches per optimizer update (TrainConfig.grad_accum), or <c>null</c> for laya's 8.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(GradientAccumulation))]
        public int? GradientAccumulation { get; set; } = null;

        /// <summary>
        /// Gets or sets the learning rate of the decision head (TrainConfig.head_lr), or <c>null</c> for laya's 1e-4.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(HeadLearningRate))]
        public double? HeadLearningRate { get; set; } = null;

        /// <summary>
        /// Gets or sets the token budget of one question (TrainConfig.head_max_len), or <c>null</c> for the base checkpoint's; it is written into the new checkpoint.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(HeadMaxLength))]
        public int? HeadMaxLength { get; set; } = null;

        /// <summary>
        /// Gets or sets the span without output after which the run is ended as stalled, or <c>null</c> for no limit. laya logs every 100 steps, so allow for that.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(InactivityTimeout))]
        public TimeSpan? InactivityTimeout { get; set; } = null;

        /// <summary>
        /// Gets or sets the share of each answer's weight moved to the other options (TrainConfig.label_smoothing), or <c>null</c> for none.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(LabelSmoothing))]
        public double? LabelSmoothing { get; set; } = null;

        /// <summary>
        /// Gets or sets the training objective (TrainConfig.loss).
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Loss))]
        public LayaLoss Loss { get; set; } = LayaLoss.Default;

        /// <summary>
        /// Gets or sets the token budget of the state (TrainConfig.max_len), or <c>null</c> for the base checkpoint's; it is written into the new checkpoint.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(MaxLength))]
        public int? MaxLength { get; set; } = null;

        /// <summary>
        /// Gets or sets the number of items per micro-batch (TrainConfig.micro_batch), or <c>null</c> for laya's 8. Lowering it reduces GPU memory.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(MicroBatch))]
        public int? MicroBatch { get; set; } = null;

        /// <summary>
        /// Gets or sets the option layout (TrainConfig.option_layout); parallel needs transformers 5 or later.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(OptionLayout))]
        public LayaOptionLayout OptionLayout { get; set; } = LayaOptionLayout.Default;

        /// <summary>
        /// Gets or sets the directory the new checkpoint is written to; it must be absent or empty, outside the base checkpoint, and not inside a Laya\models folder.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(OutputDirectory))]
        public string? OutputDirectory { get; set; } = null;

        /// <summary>
        /// Gets or sets the CPython interpreter carrying laya, resolved by <see cref="Query.LayaPythonPath(string?)"/>; <c>null</c> searches PATH.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(PythonPath))]
        public string? PythonPath { get; set; } = null;

        /// <summary>
        /// Gets or sets the training seed (TrainConfig.seed), or <c>null</c> for laya's 0. Leaving the initial plateau is seed-dependent, so repeat a run with other seeds before calling a task unlearnable.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Seed))]
        public int? Seed { get; set; } = null;

        /// <summary>
        /// Gets or sets a value indicating whether choice questions are re-encoded with a random option order every epoch (TrainConfig.shuffle_options = ["choice"]); worth it for questions with many options.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(ShuffleChoiceOptions))]
        public bool ShuffleChoiceOptions { get; set; } = false;

        /// <summary>
        /// Gets or sets the error the abstention thresholds are fitted to keep among accepted answers (TrainConfig.target_error), or <c>null</c> for laya's 0.10.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(TargetError))]
        public double? TargetError { get; set; } = null;

        /// <summary>
        /// Gets or sets the span after which the run is ended whatever it is doing, or <c>null</c> for no limit.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Timeout))]
        public TimeSpan? Timeout { get; set; } = null;

        /// <summary>
        /// Gets or sets the training JSONL, written by <c>Modify.WriteTrainingFile</c>.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(TrainingFilePath))]
        public string? TrainingFilePath { get; set; } = null;

        /// <summary>
        /// Gets or sets the directory the scripts and train_config.json are written to, or <c>null</c> for a fresh temporary directory removed after the run.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(WorkingDirectory))]
        public string? WorkingDirectory { get; set; } = null;
    }
}
