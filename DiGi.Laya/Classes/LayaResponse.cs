using DiGi.Core.Classes;
using DiGi.Laya.Interfaces;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents the Laya decision model's answers to the questions of one <see cref="LayaRequest"/>.
    /// </summary>
    public class LayaResponse : SerializableObject, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Answers))]
        private readonly List<LayaAnswer>? answers;

        [JsonInclude, JsonPropertyName(nameof(InputTokenCount))]
        private readonly int? inputTokenCount;

        [JsonInclude, JsonPropertyName(nameof(RequestId))]
        private readonly string? requestId;

        [JsonInclude, JsonPropertyName(nameof(Truncated))]
        private readonly bool? truncated;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaResponse"/> class.
        /// </summary>
        /// <param name="requestId">The <see cref="LayaRequest.Id"/> of the request answered.</param>
        /// <param name="answers">The answers, one per question of the request.</param>
        /// <param name="inputTokenCount">The number of input tokens Laya reports for the request, or <c>null</c> when not reported.</param>
        /// <param name="truncated">A value indicating whether Laya cut the state or a question to fit its token budget, or <c>null</c> when not reported.</param>
        public LayaResponse(string? requestId, IEnumerable<LayaAnswer>? answers, int? inputTokenCount, bool? truncated)
        {
            this.requestId = requestId;
            this.answers = answers == null ? null : [.. answers];
            this.inputTokenCount = inputTokenCount;
            this.truncated = truncated;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaResponse"/> class by copying an existing response.
        /// </summary>
        /// <param name="layaResponse">The source response to copy from.</param>
        public LayaResponse(LayaResponse? layaResponse)
            : base(layaResponse)
        {
            if (layaResponse != null)
            {
                inputTokenCount = layaResponse.inputTokenCount;
                requestId = layaResponse.requestId;
                truncated = layaResponse.truncated;

                if (layaResponse.answers != null)
                {
                    answers = [];
                    foreach (LayaAnswer layaAnswer in layaResponse.answers)
                    {
                        if (Core.Query.Clone(layaAnswer) is LayaAnswer layaAnswer_Clone)
                        {
                            answers.Add(layaAnswer_Clone);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaResponse"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the response data.</param>
        public LayaResponse(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the answers, one per question of the request.
        /// </summary>
        [JsonIgnore]
        public List<LayaAnswer>? Answers
        {
            get
            {
                return answers;
            }
        }

        /// <summary>
        /// Gets the number of input tokens Laya reports for the request (its <c>usage.input_tokens</c>), or <c>null</c> when not reported.
        /// </summary>
        [JsonIgnore]
        public int? InputTokenCount
        {
            get
            {
                return inputTokenCount;
            }
        }

        /// <summary>
        /// Gets the <see cref="LayaRequest.Id"/> of the request answered.
        /// </summary>
        [JsonIgnore]
        public string? RequestId
        {
            get
            {
                return requestId;
            }
        }

        /// <summary>
        /// Gets a value indicating whether Laya cut the state or a question to fit its token budget (its <c>usage.truncated</c>), or <c>null</c> when not reported.
        /// <para>A truncated request was answered from part of its input only; raise <see cref="LayaRequest.MaxLength"/> or <see cref="LayaRequest.HeadMaxLength"/>, or shorten the state.</para>
        /// </summary>
        [JsonIgnore]
        public bool? Truncated
        {
            get
            {
                return truncated;
            }
        }
    }
}
