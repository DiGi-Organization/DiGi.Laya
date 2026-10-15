using DiGi.Core.Classes;
using DiGi.Laya.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents a finding of a Laya prediction run about one request, together with the identifier of that request.
    /// <para>Held by <see cref="LayaPredictionResult.RequestMessages"/> so that a caller can find the findings of a request by its identifier rather than by reading the message text.</para>
    /// </summary>
    public class LayaRequestMessage : SerializableObject, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Message))]
        private readonly string? message;

        [JsonInclude, JsonPropertyName(nameof(RequestId))]
        private readonly string? requestId;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaRequestMessage"/> class.
        /// </summary>
        /// <param name="requestId">The identifier of the request the finding is about.</param>
        /// <param name="message">The finding, as it also appears in <see cref="LayaPredictionResult.Messages"/>.</param>
        public LayaRequestMessage(string? requestId, string? message)
        {
            this.requestId = requestId;
            this.message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaRequestMessage"/> class by copying an existing request message.
        /// </summary>
        /// <param name="layaRequestMessage">The source request message to copy from.</param>
        public LayaRequestMessage(LayaRequestMessage? layaRequestMessage)
            : base(layaRequestMessage)
        {
            if (layaRequestMessage != null)
            {
                message = layaRequestMessage.message;
                requestId = layaRequestMessage.requestId;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaRequestMessage"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the request message data.</param>
        public LayaRequestMessage(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the finding, as it also appears in <see cref="LayaPredictionResult.Messages"/>.
        /// </summary>
        [JsonIgnore]
        public string? Message
        {
            get
            {
                return message;
            }
        }

        /// <summary>
        /// Gets the identifier of the request the finding is about.
        /// </summary>
        [JsonIgnore]
        public string? RequestId
        {
            get
            {
                return requestId;
            }
        }
    }
}
