using DiGi.Core.Classes;
using DiGi.Laya.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents how a fine-tuning run went: the checkpoint it produced, what laya reported about it, and every finding about the run.
    /// <para>A checkpoint is trusted only when the run exited with 0, its report was read and the directory holds rl_agent_config.json and model.safetensors; only then is <see cref="ModelSHA256"/> set (DiGi-Organization/DiGi.Laya#1, D5).</para>
    /// </summary>
    public class LayaTrainingResult : SerializableResult, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(BaseModelSHA256))]
        private readonly string? baseModelSHA256;

        [JsonInclude, JsonPropertyName(nameof(CalibrationItemCount))]
        private readonly int? calibrationItemCount;

        [JsonInclude, JsonPropertyName(nameof(Cancelled))]
        private readonly bool cancelled;

        [JsonInclude, JsonPropertyName(nameof(CheckpointDirectory))]
        private readonly string? checkpointDirectory;

        [JsonInclude, JsonPropertyName(nameof(Duration))]
        private readonly TimeSpan? duration;

        [JsonInclude, JsonPropertyName(nameof(EpochLosses))]
        private readonly List<double>? epochLosses;

        [JsonInclude, JsonPropertyName(nameof(EvaluationItemCount))]
        private readonly int? evaluationItemCount;

        [JsonInclude, JsonPropertyName(nameof(ExitCode))]
        private readonly int exitCode;

        [JsonInclude, JsonPropertyName(nameof(Messages))]
        private readonly List<string>? messages;

        [JsonInclude, JsonPropertyName(nameof(ModelSHA256))]
        private readonly string? modelSHA256;

        [JsonInclude, JsonPropertyName(nameof(SkippedCounts))]
        private readonly List<LayaSkippedCount>? skippedCounts;

        [JsonInclude, JsonPropertyName(nameof(Stalled))]
        private readonly bool stalled;

        [JsonInclude, JsonPropertyName(nameof(Temperatures))]
        private readonly List<LayaTemperature>? temperatures;

        [JsonInclude, JsonPropertyName(nameof(TimedOut))]
        private readonly bool timedOut;

        [JsonInclude, JsonPropertyName(nameof(TrainItemCount))]
        private readonly int? trainItemCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaTrainingResult"/> class.
        /// </summary>
        /// <param name="checkpointDirectory">The directory the new checkpoint was written to.</param>
        /// <param name="modelSHA256">The SHA-256 of the new checkpoint directory, or <c>null</c> when the checkpoint is not trusted (the run failed, reported nothing, or left no rl_agent_config.json or model.safetensors).</param>
        /// <param name="baseModelSHA256">The SHA-256 of the base checkpoint directory, taken before the run.</param>
        /// <param name="trainItemCount">The number of labelled questions trained on, or <c>null</c> when not reported.</param>
        /// <param name="calibrationItemCount">The number of labelled questions held out to fit the calibration temperatures, or <c>null</c> when not reported.</param>
        /// <param name="evaluationItemCount">The number of labelled questions answered before and after training, or <c>null</c> when not reported.</param>
        /// <param name="skippedCounts">The labelled questions laya skipped, by reason.</param>
        /// <param name="epochLosses">The mean training loss of every epoch, in epoch order.</param>
        /// <param name="temperatures">The calibration temperatures written into the new checkpoint, by question type.</param>
        /// <param name="duration">The wall-clock time of the run, or <c>null</c> when no process was started.</param>
        /// <param name="exitCode">The exit code of the script; -1 when the process was ended, failed to start or was never started.</param>
        /// <param name="stalled">A value indicating whether the process was ended for inactivity.</param>
        /// <param name="timedOut">A value indicating whether the process was ended by the overall time limit.</param>
        /// <param name="cancelled">A value indicating whether the caller cancelled the run.</param>
        /// <param name="messages">The findings about the run.</param>
        public LayaTrainingResult(
            string? checkpointDirectory,
            string? modelSHA256,
            string? baseModelSHA256,
            int? trainItemCount,
            int? calibrationItemCount,
            int? evaluationItemCount,
            IEnumerable<LayaSkippedCount>? skippedCounts,
            IEnumerable<double>? epochLosses,
            IEnumerable<LayaTemperature>? temperatures,
            TimeSpan? duration,
            int exitCode,
            bool stalled,
            bool timedOut,
            bool cancelled,
            IEnumerable<string>? messages)
        {
            this.checkpointDirectory = checkpointDirectory;
            this.modelSHA256 = modelSHA256;
            this.baseModelSHA256 = baseModelSHA256;
            this.trainItemCount = trainItemCount;
            this.calibrationItemCount = calibrationItemCount;
            this.evaluationItemCount = evaluationItemCount;
            this.skippedCounts = skippedCounts == null ? null : [.. skippedCounts];
            this.epochLosses = epochLosses == null ? null : [.. epochLosses];
            this.temperatures = temperatures == null ? null : [.. temperatures];
            this.duration = duration;
            this.exitCode = exitCode;
            this.stalled = stalled;
            this.timedOut = timedOut;
            this.cancelled = cancelled;
            this.messages = messages == null ? null : [.. messages];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaTrainingResult"/> class by copying an existing instance.
        /// </summary>
        /// <param name="layaTrainingResult">The source instance to copy from.</param>
        public LayaTrainingResult(LayaTrainingResult? layaTrainingResult)
            : base(layaTrainingResult)
        {
            if (layaTrainingResult != null)
            {
                baseModelSHA256 = layaTrainingResult.baseModelSHA256;
                calibrationItemCount = layaTrainingResult.calibrationItemCount;
                cancelled = layaTrainingResult.cancelled;
                checkpointDirectory = layaTrainingResult.checkpointDirectory;
                duration = layaTrainingResult.duration;
                epochLosses = layaTrainingResult.epochLosses == null ? null : [.. layaTrainingResult.epochLosses];
                evaluationItemCount = layaTrainingResult.evaluationItemCount;
                exitCode = layaTrainingResult.exitCode;
                messages = layaTrainingResult.messages == null ? null : [.. layaTrainingResult.messages];
                modelSHA256 = layaTrainingResult.modelSHA256;
                stalled = layaTrainingResult.stalled;
                timedOut = layaTrainingResult.timedOut;
                trainItemCount = layaTrainingResult.trainItemCount;

                if (layaTrainingResult.skippedCounts != null)
                {
                    skippedCounts = [];
                    foreach (LayaSkippedCount layaSkippedCount in layaTrainingResult.skippedCounts)
                    {
                        if (Core.Query.Clone(layaSkippedCount) is LayaSkippedCount layaSkippedCount_Clone)
                        {
                            skippedCounts.Add(layaSkippedCount_Clone);
                        }
                    }
                }

                if (layaTrainingResult.temperatures != null)
                {
                    temperatures = [];
                    foreach (LayaTemperature layaTemperature in layaTrainingResult.temperatures)
                    {
                        if (Core.Query.Clone(layaTemperature) is LayaTemperature layaTemperature_Clone)
                        {
                            temperatures.Add(layaTemperature_Clone);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaTrainingResult"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data.</param>
        public LayaTrainingResult(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the SHA-256 of the base checkpoint directory, taken before the run.
        /// </summary>
        [JsonIgnore]
        public string? BaseModelSHA256
        {
            get
            {
                return baseModelSHA256;
            }
        }

        /// <summary>
        /// Gets the number of labelled questions held out to fit the calibration temperatures, or <c>null</c> when not reported.
        /// </summary>
        [JsonIgnore]
        public int? CalibrationItemCount
        {
            get
            {
                return calibrationItemCount;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the caller cancelled the run.
        /// </summary>
        [JsonIgnore]
        public bool Cancelled
        {
            get
            {
                return cancelled;
            }
        }

        /// <summary>
        /// Gets the directory the new checkpoint was written to.
        /// </summary>
        [JsonIgnore]
        public string? CheckpointDirectory
        {
            get
            {
                return checkpointDirectory;
            }
        }

        /// <summary>
        /// Gets the wall-clock time of the run, or <c>null</c> when no process was started.
        /// </summary>
        [JsonIgnore]
        public TimeSpan? Duration
        {
            get
            {
                return duration;
            }
        }

        /// <summary>
        /// Gets the mean training loss of every epoch, in epoch order.
        /// </summary>
        [JsonIgnore]
        public List<double>? EpochLosses
        {
            get
            {
                return epochLosses;
            }
        }

        /// <summary>
        /// Gets the number of labelled questions answered before and after training, or <c>null</c> when not reported.
        /// </summary>
        [JsonIgnore]
        public int? EvaluationItemCount
        {
            get
            {
                return evaluationItemCount;
            }
        }

        /// <summary>
        /// Gets the exit code of the script; -1 when the process was ended, failed to start or was never started.
        /// </summary>
        [JsonIgnore]
        public int ExitCode
        {
            get
            {
                return exitCode;
            }
        }

        /// <summary>
        /// Gets the findings about the run.
        /// </summary>
        [JsonIgnore]
        public List<string>? Messages
        {
            get
            {
                return messages;
            }
        }

        /// <summary>
        /// Gets the SHA-256 of the new checkpoint directory, or <c>null</c> when the checkpoint is not trusted (the run failed, reported nothing, or left no rl_agent_config.json or model.safetensors).
        /// </summary>
        [JsonIgnore]
        public string? ModelSHA256
        {
            get
            {
                return modelSHA256;
            }
        }

        /// <summary>
        /// Gets the labelled questions laya skipped, by reason.
        /// </summary>
        [JsonIgnore]
        public List<LayaSkippedCount>? SkippedCounts
        {
            get
            {
                return skippedCounts;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the process was ended for inactivity.
        /// </summary>
        [JsonIgnore]
        public bool Stalled
        {
            get
            {
                return stalled;
            }
        }

        /// <summary>
        /// Gets the calibration temperatures written into the new checkpoint, by question type.
        /// </summary>
        [JsonIgnore]
        public List<LayaTemperature>? Temperatures
        {
            get
            {
                return temperatures;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the process was ended by the overall time limit.
        /// </summary>
        [JsonIgnore]
        public bool TimedOut
        {
            get
            {
                return timedOut;
            }
        }

        /// <summary>
        /// Gets the number of labelled questions trained on, or <c>null</c> when not reported.
        /// </summary>
        [JsonIgnore]
        public int? TrainItemCount
        {
            get
            {
                return trainItemCount;
            }
        }
    }
}
