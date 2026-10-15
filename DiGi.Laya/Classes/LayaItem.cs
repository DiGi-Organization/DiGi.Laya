using DiGi.Core.Classes;
using DiGi.Laya.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents one item a classification workflow classifies: an identifier and the state Laya reads about it.
    /// <para>Domain-neutral: what an item is - a recipe, a ticket, a document - is the caller's business; the workflow only asks Laya about its state.</para>
    /// </summary>
    public class LayaItem : SerializableObject, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Id))]
        private readonly string? id;

        [JsonInclude, JsonPropertyName(nameof(State))]
        private readonly string? state;

        [JsonInclude, JsonPropertyName(nameof(StateIsJson))]
        private readonly bool stateIsJson;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaItem"/> class.
        /// </summary>
        /// <param name="id">The identifier of the item, unique within one run; it becomes the request id.</param>
        /// <param name="state">The state Laya reads about the item, as text.</param>
        /// <param name="stateIsJson">A value indicating whether the state is a JSON object or array rather than plain text.</param>
        public LayaItem(string? id, string? state, bool stateIsJson)
        {
            this.id = id;
            this.state = state;
            this.stateIsJson = stateIsJson;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaItem"/> class by copying an existing instance.
        /// </summary>
        /// <param name="layaItem">The source instance to copy from.</param>
        public LayaItem(LayaItem? layaItem)
            : base(layaItem)
        {
            if (layaItem != null)
            {
                id = layaItem.id;
                state = layaItem.state;
                stateIsJson = layaItem.stateIsJson;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaItem"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data.</param>
        public LayaItem(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the identifier of the item, unique within one run; it becomes the request id.
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
        /// Gets the state Laya reads about the item, as text.
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
        /// Gets a value indicating whether the state is a JSON object or array rather than plain text.
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
