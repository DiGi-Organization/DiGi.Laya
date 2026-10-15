using DiGi.Core.Classes;
using DiGi.Laya.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents the probability the Laya decision model assigns to one option of a choice question.
    /// <para>Held in a list by <see cref="LayaChoiceAnswer.Probabilities"/> rather than in a dictionary keyed by label, because the DiGi serializer rebuilds a dictionary with the default comparer of its type and files every key as a JSON object name.</para>
    /// </summary>
    public class LayaProbability : SerializableObject, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Label))]
        private readonly string? label;

        [JsonInclude, JsonPropertyName(nameof(Value))]
        private readonly double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaProbability"/> class.
        /// </summary>
        /// <param name="label">The label of the option.</param>
        /// <param name="value">The probability of the option, between 0 and 1.</param>
        public LayaProbability(string? label, double value)
        {
            this.label = label;
            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaProbability"/> class by copying an existing probability.
        /// </summary>
        /// <param name="layaProbability">The source probability to copy from.</param>
        public LayaProbability(LayaProbability? layaProbability)
            : base(layaProbability)
        {
            if (layaProbability != null)
            {
                label = layaProbability.label;
                value = layaProbability.value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaProbability"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the probability data.</param>
        public LayaProbability(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the label of the option.
        /// </summary>
        [JsonIgnore]
        public string? Label
        {
            get
            {
                return label;
            }
        }

        /// <summary>
        /// Gets the probability of the option, between 0 and 1.
        /// </summary>
        [JsonIgnore]
        public double Value
        {
            get
            {
                return value;
            }
        }
    }
}
