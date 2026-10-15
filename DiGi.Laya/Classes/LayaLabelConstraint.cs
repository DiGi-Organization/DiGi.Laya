using DiGi.Core.Classes;
using DiGi.Laya.Enums;
using DiGi.Laya.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents a rule from outside the model about one label of one item, applied to its classification result.
    /// </summary>
    public class LayaLabelConstraint : SerializableObject, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Effect))]
        private readonly LayaConstraintEffect effect;

        [JsonInclude, JsonPropertyName(nameof(ItemId))]
        private readonly string? itemId;

        [JsonInclude, JsonPropertyName(nameof(LabelId))]
        private readonly string? labelId;

        [JsonInclude, JsonPropertyName(nameof(LabelSetId))]
        private readonly string? labelSetId;

        [JsonInclude, JsonPropertyName(nameof(Reason))]
        private readonly string? reason;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabelConstraint"/> class.
        /// </summary>
        /// <param name="itemId">The identifier of the item.</param>
        /// <param name="labelSetId">The identifier of the label set.</param>
        /// <param name="labelId">The identifier of the label.</param>
        /// <param name="effect">What the constraint does to the label's score.</param>
        /// <param name="reason">Why the constraint applies, stored on the score it affects.</param>
        public LayaLabelConstraint(string? itemId, string? labelSetId, string? labelId, LayaConstraintEffect effect, string? reason)
        {
            this.itemId = itemId;
            this.labelSetId = labelSetId;
            this.labelId = labelId;
            this.effect = effect;
            this.reason = reason;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabelConstraint"/> class by copying an existing instance.
        /// </summary>
        /// <param name="layaLabelConstraint">The source instance to copy from.</param>
        public LayaLabelConstraint(LayaLabelConstraint? layaLabelConstraint)
            : base(layaLabelConstraint)
        {
            if (layaLabelConstraint != null)
            {
                effect = layaLabelConstraint.effect;
                itemId = layaLabelConstraint.itemId;
                labelId = layaLabelConstraint.labelId;
                labelSetId = layaLabelConstraint.labelSetId;
                reason = layaLabelConstraint.reason;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabelConstraint"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data.</param>
        public LayaLabelConstraint(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets what the constraint does to the label's score.
        /// </summary>
        [JsonIgnore]
        public LayaConstraintEffect Effect
        {
            get
            {
                return effect;
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
        /// Gets why the constraint applies, stored on the score it affects.
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
