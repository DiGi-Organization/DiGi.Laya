using DiGi.Core.Classes;
using DiGi.Laya.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents how a classification run went: one result per item, the status of the prediction run behind them and the findings about the run as a whole.
    /// <para>The run status tells a run that answered apart from one that did not without reading message text: a run that was refused before a process started has no <see cref="Duration"/> and an <see cref="ExitCode"/> of -1, and a process that failed or was ended has a non-zero <see cref="ExitCode"/> or sets <see cref="Stalled"/>, <see cref="TimedOut"/> or <see cref="Cancelled"/>. A run that answered with no suggested label still has <see cref="ExitCode"/> 0.</para>
    /// </summary>
    public class LayaClassificationRunResult : SerializableResult, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(CalibrationSHA256))]
        private readonly string? calibrationSHA256;

        [JsonInclude, JsonPropertyName(nameof(Cancelled))]
        private readonly bool cancelled;

        [JsonInclude, JsonPropertyName(nameof(Duration))]
        private readonly TimeSpan? duration;

        [JsonInclude, JsonPropertyName(nameof(ExitCode))]
        private readonly int exitCode;

        [JsonInclude, JsonPropertyName(nameof(Messages))]
        private readonly List<string>? messages;

        [JsonInclude, JsonPropertyName(nameof(ModelSHA256))]
        private readonly string? modelSHA256;

        [JsonInclude, JsonPropertyName(nameof(Results))]
        private readonly List<LayaClassificationResult>? results;

        [JsonInclude, JsonPropertyName(nameof(Stalled))]
        private readonly bool stalled;

        [JsonInclude, JsonPropertyName(nameof(TimedOut))]
        private readonly bool timedOut;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaClassificationRunResult"/> class.
        /// </summary>
        /// <param name="results">The classification results, one per item in item order.</param>
        /// <param name="modelSHA256">The SHA-256 of the checkpoint directory the run used, or <c>null</c> when no process was started.</param>
        /// <param name="calibrationSHA256">The SHA-256 of the calibration file the run used, or <c>null</c> when it used none.</param>
        /// <param name="duration">The wall-clock time of the prediction run, or <c>null</c> when no process was started.</param>
        /// <param name="exitCode">The exit code of predict.py; -1 when the process was ended, failed to start or was never started.</param>
        /// <param name="stalled">A value indicating whether the process was ended for inactivity.</param>
        /// <param name="timedOut">A value indicating whether the process was ended by the overall time limit.</param>
        /// <param name="cancelled">A value indicating whether the caller cancelled the run.</param>
        /// <param name="messages">The findings about the run as a whole: a refused label set, a label set warning, a refused prediction run, the process exit or a time limit.</param>
        public LayaClassificationRunResult(
            IEnumerable<LayaClassificationResult>? results,
            string? modelSHA256,
            string? calibrationSHA256,
            TimeSpan? duration,
            int exitCode,
            bool stalled,
            bool timedOut,
            bool cancelled,
            IEnumerable<string>? messages)
        {
            this.results = results == null ? null : [.. results];
            this.modelSHA256 = modelSHA256;
            this.calibrationSHA256 = calibrationSHA256;
            this.duration = duration;
            this.exitCode = exitCode;
            this.stalled = stalled;
            this.timedOut = timedOut;
            this.cancelled = cancelled;
            this.messages = messages == null ? null : [.. messages];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaClassificationRunResult"/> class by copying an existing result.
        /// </summary>
        /// <param name="layaClassificationRunResult">The source result to copy from.</param>
        public LayaClassificationRunResult(LayaClassificationRunResult? layaClassificationRunResult)
            : base(layaClassificationRunResult)
        {
            if (layaClassificationRunResult != null)
            {
                calibrationSHA256 = layaClassificationRunResult.calibrationSHA256;
                cancelled = layaClassificationRunResult.cancelled;
                duration = layaClassificationRunResult.duration;
                exitCode = layaClassificationRunResult.exitCode;
                messages = layaClassificationRunResult.messages == null ? null : [.. layaClassificationRunResult.messages];
                modelSHA256 = layaClassificationRunResult.modelSHA256;
                stalled = layaClassificationRunResult.stalled;
                timedOut = layaClassificationRunResult.timedOut;

                if (layaClassificationRunResult.results != null)
                {
                    results = [];
                    foreach (LayaClassificationResult layaClassificationResult in layaClassificationRunResult.results)
                    {
                        if (Core.Query.Clone(layaClassificationResult) is LayaClassificationResult layaClassificationResult_Clone)
                        {
                            results.Add(layaClassificationResult_Clone);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaClassificationRunResult"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the result data.</param>
        public LayaClassificationRunResult(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the SHA-256 of the calibration file the run used, or <c>null</c> when it used none.
        /// </summary>
        [JsonIgnore]
        public string? CalibrationSHA256
        {
            get
            {
                return calibrationSHA256;
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
        /// Gets the wall-clock time of the prediction run, or <c>null</c> when no process was started.
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
        /// Gets the exit code of predict.py; -1 when the process was ended, failed to start or was never started.
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
        /// Gets the findings about the run as a whole: a refused label set, a label set warning, a refused prediction run, the process exit or a time limit.
        /// <para>A finding about one item is in that item's <see cref="LayaClassificationResult.Messages"/> instead, and is not repeated here.</para>
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
        /// Gets the SHA-256 of the checkpoint directory the run used (DiGi.Python's <c>Query.DirectorySHA256</c>), or <c>null</c> when no process was started.
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
        /// Gets the classification results, one per item in item order; empty when the label sets were refused.
        /// </summary>
        [JsonIgnore]
        public List<LayaClassificationResult>? Results
        {
            get
            {
                return results;
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
    }
}
