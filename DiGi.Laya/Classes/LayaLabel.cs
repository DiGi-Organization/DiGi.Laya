using DiGi.Core.Classes;
using DiGi.Laya.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents one label of a <see cref="LayaLabelSet"/>.
    /// </summary>
    public class LayaLabel : SerializableObject, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Id))]
        private readonly string? id;

        [JsonInclude, JsonPropertyName(nameof(Instructions))]
        private readonly string? instructions;

        [JsonInclude, JsonPropertyName(nameof(Text))]
        private readonly string? text;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabel"/> class.
        /// </summary>
        /// <param name="id">The identifier of the label, unique within its set; the answer key of a single-choice set and the suffix of the noul question of a multi-label set.</param>
        /// <param name="text">The description of the label shown to the model: the option description of a single-choice set, and what replaces {label} in the noul statement of a multi-label set.</param>
        /// <param name="instructions">The noul statement template of this label in a multi-label set, with {label} replaced by the text, or <c>null</c> for the set's instructions.</param>
        public LayaLabel(string? id, string? text, string? instructions)
        {
            this.id = id;
            this.text = text;
            this.instructions = instructions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabel"/> class by copying an existing instance.
        /// </summary>
        /// <param name="layaLabel">The source instance to copy from.</param>
        public LayaLabel(LayaLabel? layaLabel)
            : base(layaLabel)
        {
            if (layaLabel != null)
            {
                id = layaLabel.id;
                instructions = layaLabel.instructions;
                text = layaLabel.text;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabel"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data.</param>
        public LayaLabel(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the identifier of the label, unique within its set; the answer key of a single-choice set and the suffix of the noul question of a multi-label set.
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
        /// Gets the noul statement template of this label in a multi-label set, with {label} replaced by the text, or <c>null</c> for the set's instructions.
        /// </summary>
        [JsonIgnore]
        public string? Instructions
        {
            get
            {
                return instructions;
            }
        }

        /// <summary>
        /// Gets the description of the label shown to the model: the option description of a single-choice set, and what replaces {label} in the noul statement of a multi-label set.
        /// </summary>
        [JsonIgnore]
        public string? Text
        {
            get
            {
                return text;
            }
        }
    }
}
