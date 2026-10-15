using DiGi.Core.Classes;
using DiGi.Laya.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents a known label of an item: ground truth for training, folds and evaluation.
    /// </summary>
    public class LayaLabelAssignment : SerializableObject, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Group))]
        private readonly string? group;

        [JsonInclude, JsonPropertyName(nameof(ItemId))]
        private readonly string? itemId;

        [JsonInclude, JsonPropertyName(nameof(LabelId))]
        private readonly string? labelId;

        [JsonInclude, JsonPropertyName(nameof(LabelSetId))]
        private readonly string? labelSetId;

        [JsonInclude, JsonPropertyName(nameof(Truth))]
        private readonly bool truth;

        [JsonInclude, JsonPropertyName(nameof(Weight))]
        private readonly double weight;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabelAssignment"/> class.
        /// </summary>
        /// <param name="itemId">The identifier of the item.</param>
        /// <param name="labelSetId">The identifier of the label set.</param>
        /// <param name="labelId">The identifier of the label.</param>
        /// <param name="truth">A value indicating whether the label applies to the item (<c>false</c> records an explicit negative).</param>
        /// <param name="weight">The confidence in the assignment, from 0 (no information) to 1 (certain); a weak label below 1 becomes a soft training target.</param>
        /// <param name="group">The group the item belongs to, which folds never split, or <c>null</c> when the item stands alone.</param>
        public LayaLabelAssignment(string? itemId, string? labelSetId, string? labelId, bool truth, double weight, string? group)
        {
            this.itemId = itemId;
            this.labelSetId = labelSetId;
            this.labelId = labelId;
            this.truth = truth;
            this.weight = weight;
            this.group = group;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabelAssignment"/> class by copying an existing instance.
        /// </summary>
        /// <param name="layaLabelAssignment">The source instance to copy from.</param>
        public LayaLabelAssignment(LayaLabelAssignment? layaLabelAssignment)
            : base(layaLabelAssignment)
        {
            if (layaLabelAssignment != null)
            {
                group = layaLabelAssignment.group;
                itemId = layaLabelAssignment.itemId;
                labelId = layaLabelAssignment.labelId;
                labelSetId = layaLabelAssignment.labelSetId;
                truth = layaLabelAssignment.truth;
                weight = layaLabelAssignment.weight;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabelAssignment"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data.</param>
        public LayaLabelAssignment(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the group the item belongs to, which folds never split, or <c>null</c> when the item stands alone.
        /// </summary>
        [JsonIgnore]
        public string? Group
        {
            get
            {
                return group;
            }
        }

        /// <summary>
        /// Gets the identifier of the item.
        /// </summary>
        [JsonIgnore]
        public string? ItemId
        {
            get
            {
                return itemId;
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
        /// Gets a value indicating whether the label applies to the item (<c>false</c> records an explicit negative).
        /// </summary>
        [JsonIgnore]
        public bool Truth
        {
            get
            {
                return truth;
            }
        }

        /// <summary>
        /// Gets the confidence in the assignment, from 0 (no information) to 1 (certain); a weak label below 1 becomes a soft training target.
        /// </summary>
        [JsonIgnore]
        public double Weight
        {
            get
            {
                return weight;
            }
        }
    }
}
