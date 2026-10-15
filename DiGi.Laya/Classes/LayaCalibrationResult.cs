using DiGi.Core.Classes;
using DiGi.Laya.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents how a calibration run went: the calibration file it wrote, the temperatures in it, and every finding about the run.
    /// </summary>
    public class LayaCalibrationResult : SerializableResult, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(CalibrationPath))]
        private readonly string? calibrationPath;

        [JsonInclude, JsonPropertyName(nameof(CalibrationSHA256))]
        private readonly string? calibrationSHA256;

        [JsonInclude, JsonPropertyName(nameof(Cancelled))]
        private readonly bool cancelled;

        [JsonInclude, JsonPropertyName(nameof(Duration))]
        private readonly TimeSpan? duration;

        [JsonInclude, JsonPropertyName(nameof(EvaluationRecordCount))]
        private readonly int? evaluationRecordCount;

        [JsonInclude, JsonPropertyName(nameof(ExitCode))]
        private readonly int exitCode;

        [JsonInclude, JsonPropertyName(nameof(ExpectedCalibrationErrorAfter))]
        private readonly double? expectedCalibrationErrorAfter;

        [JsonInclude, JsonPropertyName(nameof(ExpectedCalibrationErrorBefore))]
        private readonly double? expectedCalibrationErrorBefore;

        [JsonInclude, JsonPropertyName(nameof(Messages))]
        private readonly List<string>? messages;

        [JsonInclude, JsonPropertyName(nameof(ModelSHA256))]
        private readonly string? modelSHA256;

        [JsonInclude, JsonPropertyName(nameof(RecordCount))]
        private readonly int? recordCount;

        [JsonInclude, JsonPropertyName(nameof(SkippedCount))]
        private readonly int? skippedCount;

        [JsonInclude, JsonPropertyName(nameof(Stalled))]
        private readonly bool stalled;

        [JsonInclude, JsonPropertyName(nameof(Temperatures))]
        private readonly List<LayaTemperature>? temperatures;

        [JsonInclude, JsonPropertyName(nameof(TimedOut))]
        private readonly bool timedOut;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaCalibrationResult"/> class.
        /// </summary>
        /// <param name="calibrationPath">The calibration file the run was to write.</param>
        /// <param name="calibrationSHA256">The SHA-256 of the calibration file, or <c>null</c> when the run did not write one.</param>
        /// <param name="modelSHA256">The SHA-256 of the checkpoint directory the temperatures were fitted for; the checkpoint itself is never changed.</param>
        /// <param name="recordCount">The number of labelled questions the temperatures were fitted on, or <c>null</c> when not reported.</param>
        /// <param name="skippedCount">The number of labelled rows or questions that could not be read, or <c>null</c> when not reported.</param>
        /// <param name="temperatures">The fitted temperatures, by question type.</param>
        /// <param name="expectedCalibrationErrorBefore">The expected calibration error before calibration on the held-out records, or <c>null</c> when laya held none out (fewer than about 2500 records per question type and option count).</param>
        /// <param name="expectedCalibrationErrorAfter">The expected calibration error after calibration on the held-out records, or <c>null</c> when laya held none out.</param>
        /// <param name="evaluationRecordCount">The number of held-out records the expected calibration errors rest on, or <c>null</c> when not reported.</param>
        /// <param name="duration">The wall-clock time of the run, or <c>null</c> when no process was started.</param>
        /// <param name="exitCode">The exit code of the script; -1 when the process was ended, failed to start or was never started.</param>
        /// <param name="stalled">A value indicating whether the process was ended for inactivity.</param>
        /// <param name="timedOut">A value indicating whether the process was ended by the overall time limit.</param>
        /// <param name="cancelled">A value indicating whether the caller cancelled the run.</param>
        /// <param name="messages">The findings about the run.</param>
        public LayaCalibrationResult(
            string? calibrationPath,
            string? calibrationSHA256,
            string? modelSHA256,
            int? recordCount,
            int? skippedCount,
            IEnumerable<LayaTemperature>? temperatures,
            double? expectedCalibrationErrorBefore,
            double? expectedCalibrationErrorAfter,
            int? evaluationRecordCount,
            TimeSpan? duration,
            int exitCode,
            bool stalled,
            bool timedOut,
            bool cancelled,
            IEnumerable<string>? messages)
        {
            this.calibrationPath = calibrationPath;
            this.calibrationSHA256 = calibrationSHA256;
            this.modelSHA256 = modelSHA256;
            this.recordCount = recordCount;
            this.skippedCount = skippedCount;
            this.temperatures = temperatures == null ? null : [.. temperatures];
            this.expectedCalibrationErrorBefore = expectedCalibrationErrorBefore;
            this.expectedCalibrationErrorAfter = expectedCalibrationErrorAfter;
            this.evaluationRecordCount = evaluationRecordCount;
            this.duration = duration;
            this.exitCode = exitCode;
            this.stalled = stalled;
            this.timedOut = timedOut;
            this.cancelled = cancelled;
            this.messages = messages == null ? null : [.. messages];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaCalibrationResult"/> class by copying an existing instance.
        /// </summary>
        /// <param name="layaCalibrationResult">The source instance to copy from.</param>
        public LayaCalibrationResult(LayaCalibrationResult? layaCalibrationResult)
            : base(layaCalibrationResult)
        {
            if (layaCalibrationResult != null)
            {
                calibrationPath = layaCalibrationResult.calibrationPath;
                calibrationSHA256 = layaCalibrationResult.calibrationSHA256;
                cancelled = layaCalibrationResult.cancelled;
                duration = layaCalibrationResult.duration;
                evaluationRecordCount = layaCalibrationResult.evaluationRecordCount;
                exitCode = layaCalibrationResult.exitCode;
                expectedCalibrationErrorAfter = layaCalibrationResult.expectedCalibrationErrorAfter;
                expectedCalibrationErrorBefore = layaCalibrationResult.expectedCalibrationErrorBefore;
                messages = layaCalibrationResult.messages == null ? null : [.. layaCalibrationResult.messages];
                modelSHA256 = layaCalibrationResult.modelSHA256;
                recordCount = layaCalibrationResult.recordCount;
                skippedCount = layaCalibrationResult.skippedCount;
                stalled = layaCalibrationResult.stalled;
                timedOut = layaCalibrationResult.timedOut;

                if (layaCalibrationResult.temperatures != null)
                {
                    temperatures = [];
                    foreach (LayaTemperature layaTemperature in layaCalibrationResult.temperatures)
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
        /// Initializes a new instance of the <see cref="LayaCalibrationResult"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data.</param>
        public LayaCalibrationResult(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the calibration file the run was to write.
        /// </summary>
        [JsonIgnore]
        public string? CalibrationPath
        {
            get
            {
                return calibrationPath;
            }
        }

        /// <summary>
        /// Gets the SHA-256 of the calibration file, or <c>null</c> when the run did not write one.
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
        /// Gets the number of held-out records the expected calibration errors rest on, or <c>null</c> when not reported.
        /// </summary>
        [JsonIgnore]
        public int? EvaluationRecordCount
        {
            get
            {
                return evaluationRecordCount;
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
        /// Gets the expected calibration error after calibration on the held-out records, or <c>null</c> when laya held none out.
        /// </summary>
        [JsonIgnore]
        public double? ExpectedCalibrationErrorAfter
        {
            get
            {
                return expectedCalibrationErrorAfter;
            }
        }

        /// <summary>
        /// Gets the expected calibration error before calibration on the held-out records, or <c>null</c> when laya held none out (fewer than about 2500 records per question type and option count).
        /// </summary>
        [JsonIgnore]
        public double? ExpectedCalibrationErrorBefore
        {
            get
            {
                return expectedCalibrationErrorBefore;
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
        /// Gets the SHA-256 of the checkpoint directory the temperatures were fitted for; the checkpoint itself is never changed.
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
        /// Gets the number of labelled questions the temperatures were fitted on, or <c>null</c> when not reported.
        /// </summary>
        [JsonIgnore]
        public int? RecordCount
        {
            get
            {
                return recordCount;
            }
        }

        /// <summary>
        /// Gets the number of labelled rows or questions that could not be read, or <c>null</c> when not reported.
        /// </summary>
        [JsonIgnore]
        public int? SkippedCount
        {
            get
            {
                return skippedCount;
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
        /// Gets the fitted temperatures, by question type.
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
    }
}
