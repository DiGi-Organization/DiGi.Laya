using DiGi.Core.Classes;
using DiGi.Laya.Interfaces;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents one state and the named questions the Laya decision model answers about it in one forward pass.
    /// <para>The state travels as text. Laya encodes a JSON object or array state differently from a plain string, so a state that is JSON sets <see cref="StateIsJson"/> and is parsed back into JSON when the request is written for Laya.</para>
    /// </summary>
    public class LayaRequest : SerializableObject, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(HeadMaxLength))]
        private readonly int? headMaxLength;

        [JsonInclude, JsonPropertyName(nameof(Id))]
        private readonly string? id;

        [JsonInclude, JsonPropertyName(nameof(MaxLength))]
        private readonly int? maxLength;

        [JsonInclude, JsonPropertyName(nameof(Questions))]
        private readonly List<LayaQuestion>? questions;

        [JsonInclude, JsonPropertyName(nameof(State))]
        private readonly string? state;

        [JsonInclude, JsonPropertyName(nameof(StateIsJson))]
        private readonly bool stateIsJson;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaRequest"/> class.
        /// </summary>
        /// <param name="id">The identifier the response is matched back to the request by, unique within one run.</param>
        /// <param name="state">The state the questions are asked about, as text.</param>
        /// <param name="stateIsJson">A value indicating whether <paramref name="state"/> is a JSON object or array rather than plain text.</param>
        /// <param name="questions">The questions to answer, each under a name unique within the request.</param>
        /// <param name="maxLength">The token budget of the state, or <c>null</c> for the checkpoint's own.</param>
        /// <param name="headMaxLength">The token budget of one question, or <c>null</c> for the checkpoint's own.</param>
        public LayaRequest(string? id, string? state, bool stateIsJson, IEnumerable<LayaQuestion>? questions, int? maxLength, int? headMaxLength)
        {
            this.id = id;
            this.state = state;
            this.stateIsJson = stateIsJson;
            this.questions = questions == null ? null : [.. questions];
            this.maxLength = maxLength;
            this.headMaxLength = headMaxLength;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaRequest"/> class by copying an existing request.
        /// </summary>
        /// <param name="layaRequest">The source request to copy from.</param>
        public LayaRequest(LayaRequest? layaRequest)
            : base(layaRequest)
        {
            if (layaRequest != null)
            {
                headMaxLength = layaRequest.headMaxLength;
                id = layaRequest.id;
                maxLength = layaRequest.maxLength;
                state = layaRequest.state;
                stateIsJson = layaRequest.stateIsJson;

                if (layaRequest.questions != null)
                {
                    questions = [];
                    foreach (LayaQuestion layaQuestion in layaRequest.questions)
                    {
                        if (Core.Query.Clone(layaQuestion) is LayaQuestion layaQuestion_Clone)
                        {
                            questions.Add(layaQuestion_Clone);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaRequest"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the request data.</param>
        public LayaRequest(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the token budget of one question, or <c>null</c> for the checkpoint's own.
        /// </summary>
        [JsonIgnore]
        public int? HeadMaxLength
        {
            get
            {
                return headMaxLength;
            }
        }

        /// <summary>
        /// Gets the identifier the response is matched back to the request by, unique within one run.
        /// </summary>
        [JsonIgnore]
        public string? Id
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// Gets the token budget of the state, or <c>null</c> for the checkpoint's own.
        /// </summary>
        [JsonIgnore]
        public int? MaxLength
        {
            get
            {
                return maxLength;
            }
        }

        /// <summary>
        /// Gets the questions to answer, each under a name unique within the request.
        /// </summary>
        [JsonIgnore]
        public List<LayaQuestion>? Questions
        {
            get
            {
                return questions;
            }
        }

        /// <summary>
        /// Gets the state the questions are asked about, as text.
        /// </summary>
        [JsonIgnore]
        public string? State
        {
            get
            {
                return state;
            }
        }

        /// <summary>
        /// Gets a value indicating whether <see cref="State"/> is a JSON object or array rather than plain text.
        /// </summary>
        [JsonIgnore]
        public bool StateIsJson
        {
            get
            {
                return stateIsJson;
            }
        }
    }
}
