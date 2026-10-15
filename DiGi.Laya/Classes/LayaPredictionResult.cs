using DiGi.Core.Classes;
using DiGi.Laya.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents how a Laya prediction run went: the responses it produced and every finding about the run and the requests.
    /// <para>A run is never reported by an exception. A request that could not be written, was refused by laya or got no response is named in <see cref="Messages"/>, and the responses of the others are kept. Every finding about one request is also kept, with that request's identifier, in <see cref="RequestMessages"/>.</para>
    /// </summary>
    public class LayaPredictionResult : SerializableResult, ILayaSerializableObject
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

        [JsonInclude, JsonPropertyName(nameof(RequestMessages))]
        private readonly List<LayaRequestMessage>? requestMessages;

        [JsonInclude, JsonPropertyName(nameof(Responses))]
        private readonly List<LayaResponse>? responses;

        [JsonInclude, JsonPropertyName(nameof(Stalled))]
        private readonly bool stalled;

        [JsonInclude, JsonPropertyName(nameof(TimedOut))]
        private readonly bool timedOut;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaPredictionResult"/> class.
        /// </summary>
        /// <param name="responses">The responses read back, in request order.</param>
        /// <param name="modelSHA256">The SHA-256 of the checkpoint directory the run used.</param>
        /// <param name="calibrationSHA256">The SHA-256 of the calibration file the run used, or <c>null</c> when it used none.</param>
        /// <param name="duration">The wall-clock time of the run, or <c>null</c> when no process was started.</param>
        /// <param name="exitCode">The exit code of predict.py; -1 when the process was ended, failed to start or was never started.</param>
        /// <param name="stalled">A value indicating whether the process was ended for inactivity.</param>
        /// <param name="timedOut">A value indicating whether the process was ended by the overall time limit.</param>
        /// <param name="cancelled">A value indicating whether the caller cancelled the run.</param>
        /// <param name="messages">The findings about the run and the requests.</param>
        /// <param name="requestMessages">The findings about one request each, with the identifier of that request; each is also one of <paramref name="messages"/>.</param>
        public LayaPredictionResult(
            IEnumerable<LayaResponse>? responses,
            string? modelSHA256,
            string? calibrationSHA256,
            TimeSpan? duration,
            int exitCode,
            bool stalled,
            bool timedOut,
            bool cancelled,
            IEnumerable<string>? messages,
            IEnumerable<LayaRequestMessage>? requestMessages)
        {
            this.responses = responses == null ? null : [.. responses];
            this.modelSHA256 = modelSHA256;
            this.calibrationSHA256 = calibrationSHA256;
            this.duration = duration;
            this.exitCode = exitCode;
            this.stalled = stalled;
            this.timedOut = timedOut;
            this.cancelled = cancelled;
            this.messages = messages == null ? null : [.. messages];
            this.requestMessages = requestMessages == null ? null : [.. requestMessages];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaPredictionResult"/> class by copying an existing result.
        /// </summary>
        /// <param name="layaPredictionResult">The source result to copy from.</param>
        public LayaPredictionResult(LayaPredictionResult? layaPredictionResult)
            : base(layaPredictionResult)
        {
            if (layaPredictionResult != null)
            {
                calibrationSHA256 = layaPredictionResult.calibrationSHA256;
                cancelled = layaPredictionResult.cancelled;
                duration = layaPredictionResult.duration;
                exitCode = layaPredictionResult.exitCode;
                messages = layaPredictionResult.messages == null ? null : [.. layaPredictionResult.messages];
                modelSHA256 = layaPredictionResult.modelSHA256;
                stalled = layaPredictionResult.stalled;
                timedOut = layaPredictionResult.timedOut;

                if (layaPredictionResult.requestMessages != null)
                {
                    requestMessages = [];
                    foreach (LayaRequestMessage layaRequestMessage in layaPredictionResult.requestMessages)
                    {
                        if (Core.Query.Clone(layaRequestMessage) is LayaRequestMessage layaRequestMessage_Clone)
                        {
                            requestMessages.Add(layaRequestMessage_Clone);
                        }
                    }
                }

                if (layaPredictionResult.responses != null)
                {
                    responses = [];
                    foreach (LayaResponse layaResponse in layaPredictionResult.responses)
                    {
                        if (Core.Query.Clone(layaResponse) is LayaResponse layaResponse_Clone)
                        {
                            responses.Add(layaResponse_Clone);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaPredictionResult"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the result data.</param>
        public LayaPredictionResult(JsonObject? jsonObject)
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
        /// Gets the findings about the run and the requests.
        /// <para>Every finding about one request is also in <see cref="RequestMessages"/>; the others concern the run as a whole.</para>
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
        /// Gets the SHA-256 of the checkpoint directory the run used (DiGi.Python's <c>Query.DirectorySHA256</c>).
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
        /// Gets the findings about one request each, with the identifier of that request: a request left out, refused by laya, without a response, missing an answer or truncated.
        /// <para>Each is also one of <see cref="Messages"/>, which is kept whole for compatibility. A finding that names no request of the run - a refused run, the process exit, a time limit, a response line answering no request - is only in <see cref="Messages"/>.</para>
        /// </summary>
        [JsonIgnore]
        public List<LayaRequestMessage>? RequestMessages
        {
            get
            {
                return requestMessages;
            }
        }

        /// <summary>
        /// Gets the responses read back, in request order.
        /// </summary>
        [JsonIgnore]
        public List<LayaResponse>? Responses
        {
            get
            {
                return responses;
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
