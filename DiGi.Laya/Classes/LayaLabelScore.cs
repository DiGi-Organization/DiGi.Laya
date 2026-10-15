using DiGi.Core.Classes;
using DiGi.Laya.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents the score of one label of one label set for one item, and whether it is suggested.
    /// <para>The constructors only assign; <c>Modify.ApplyConstraints</c> replaces a score rather than changing it.</para>
    /// </summary>
    public class LayaLabelScore : SerializableObject, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(IsForbidden))]
        private readonly bool isForbidden;

        [JsonInclude, JsonPropertyName(nameof(IsSuggested))]
        private readonly bool isSuggested;

        [JsonInclude, JsonPropertyName(nameof(LabelId))]
        private readonly string? labelId;

        [JsonInclude, JsonPropertyName(nameof(LabelSetId))]
        private readonly string? labelSetId;

        [JsonInclude, JsonPropertyName(nameof(Probability))]
        private readonly double probability;

        [JsonInclude, JsonPropertyName(nameof(Reason))]
        private readonly string? reason;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabelScore"/> class.
        /// </summary>
        /// <param name="labelSetId">The identifier of the label set.</param>
        /// <param name="labelId">The identifier of the label.</param>
        /// <param name="probability">The probability Laya gives the label: its option probability in a single-choice set, or the probability its noul statement is true in a multi-label set.</param>
        /// <param name="isSuggested">A value indicating whether the label is suggested for the item.</param>
        /// <param name="isForbidden">A value indicating whether a constraint forbids the label for the item; a forbidden label is never suggested.</param>
        /// <param name="reason">The reason of the constraint that forbids the label, or <c>null</c>.</param>
        public LayaLabelScore(string? labelSetId, string? labelId, double probability, bool isSuggested, bool isForbidden, string? reason)
        {
            this.labelSetId = labelSetId;
            this.labelId = labelId;
            this.probability = probability;
            this.isSuggested = isSuggested;
            this.isForbidden = isForbidden;
            this.reason = reason;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabelScore"/> class by copying an existing instance.
        /// </summary>
        /// <param name="layaLabelScore">The source instance to copy from.</param>
        public LayaLabelScore(LayaLabelScore? layaLabelScore)
            : base(layaLabelScore)
        {
            if (layaLabelScore != null)
            {
                isForbidden = layaLabelScore.isForbidden;
                isSuggested = layaLabelScore.isSuggested;
                labelId = layaLabelScore.labelId;
                labelSetId = layaLabelScore.labelSetId;
                probability = layaLabelScore.probability;
                reason = layaLabelScore.reason;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabelScore"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data.</param>
        public LayaLabelScore(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets a value indicating whether a constraint forbids the label for the item; a forbidden label is never suggested.
        /// </summary>
        [JsonIgnore]
        public bool IsForbidden
        {
            get
            {
                return isForbidden;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the label is suggested for the item.
        /// </summary>
        [JsonIgnore]
        public bool IsSuggested
        {
            get
            {
                return isSuggested;
            }
        }

        /// <summary>
        /// Gets the identifier of the label.
        /// </summary>
        [JsonIgnore]
        public string? LabelId
        {
            get
            {
                return labelId;
            }
        }

        /// <summary>
        /// Gets the identifier of the label set.
        /// </summary>
        [JsonIgnore]
        public string? LabelSetId
        {
            get
            {
                return labelSetId;
            }
        }

        /// <summary>
        /// Gets the probability Laya gives the label: its option probability in a single-choice set, or the probability its noul statement is true in a multi-label set.
        /// </summary>
        [JsonIgnore]
        public double Probability
        {
            get
            {
                return probability;
            }
        }

        /// <summary>
        /// Gets the reason of the constraint that forbids the label, or <c>null</c>.
        /// </summary>
        [JsonIgnore]
        public string? Reason
        {
            get
            {
                return reason;
            }
        }
    }
}
