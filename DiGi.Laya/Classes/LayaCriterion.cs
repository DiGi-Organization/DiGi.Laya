using DiGi.Core.Classes;
using DiGi.Laya.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents one option of a <see cref="LayaChoiceQuestion"/>: the label the model answers with and the description it reads.
    /// <para>Held in a list by <see cref="LayaChoiceQuestion.Criteria"/> rather than in a dictionary keyed by label, because the DiGi serializer rebuilds a dictionary with the default comparer of its type and loses the option order, which Laya reads as the order of the options.</para>
    /// </summary>
    public class LayaCriterion : SerializableObject, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Description))]
        private readonly string? description;

        [JsonInclude, JsonPropertyName(nameof(Label))]
        private readonly string? label;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaCriterion"/> class.
        /// </summary>
        /// <param name="label">The label the model answers with when it selects this option.</param>
        /// <param name="description">The description of the option shown to the model.</param>
        public LayaCriterion(string? label, string? description)
        {
            this.label = label;
            this.description = description;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaCriterion"/> class by copying an existing criterion.
        /// </summary>
        /// <param name="layaCriterion">The source criterion to copy from.</param>
        public LayaCriterion(LayaCriterion? layaCriterion)
            : base(layaCriterion)
        {
            if (layaCriterion != null)
            {
                description = layaCriterion.description;
                label = layaCriterion.label;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaCriterion"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the criterion data.</param>
        public LayaCriterion(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the description of the option shown to the model.
        /// </summary>
        [JsonIgnore]
        public string? Description
        {
            get
            {
                return description;
            }
        }

        /// <summary>
        /// Gets the label the model answers with when it selects this option.
        /// </summary>
        [JsonIgnore]
        public string? Label
        {
            get
            {
                return label;
            }
        }
    }
}
