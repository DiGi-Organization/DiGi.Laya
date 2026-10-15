using DiGi.Core.Classes;
using DiGi.Laya.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents the decision rule of one label set, or of one label of a multi-label set, in <see cref="LayaClassificationOptions"/>.
    /// <para>A rule without a <see cref="LabelId"/> is the rule of the whole set. A rule with one is the rule of that label of a multi-label set and wins over the set's rule for it; only its <see cref="Threshold"/> is used - a label-level <see cref="TopCount"/> is ignored, because the number of labels suggested is a setting of the whole set.</para>
    /// </summary>
    public class LayaLabelSetThreshold : SerializableObject, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(LabelSetId))]
        private readonly string? labelSetId;

        [JsonInclude, JsonPropertyName(nameof(LabelId))]
        private readonly string? labelId;

        [JsonInclude, JsonPropertyName(nameof(Threshold))]
        private readonly double? threshold;

        [JsonInclude, JsonPropertyName(nameof(TopCount))]
        private readonly int? topCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabelSetThreshold"/> class.
        /// </summary>
        /// <param name="labelSetId">The identifier of the label set the rule applies to.</param>
        /// <param name="labelId">The identifier of the label of a multi-label set the rule applies to, or <c>null</c> for a rule of the whole set.</param>
        /// <param name="threshold">The probability a label of a multi-label set must reach to be suggested, or <c>null</c> for the set's rule, else 0.5.</param>
        /// <param name="topCount">The number of labels of a single-choice set suggested, highest probability first, or <c>null</c> for 1. Ignored when <paramref name="labelId"/> is set.</param>
        public LayaLabelSetThreshold(string? labelSetId, string? labelId, double? threshold, int? topCount)
        {
            this.labelSetId = labelSetId;
            this.labelId = labelId;
            this.threshold = threshold;
            this.topCount = topCount;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabelSetThreshold"/> class by copying an existing instance.
        /// </summary>
        /// <param name="layaLabelSetThreshold">The source instance to copy from.</param>
        public LayaLabelSetThreshold(LayaLabelSetThreshold? layaLabelSetThreshold)
            : base(layaLabelSetThreshold)
        {
            if (layaLabelSetThreshold != null)
            {
                labelSetId = layaLabelSetThreshold.labelSetId;
                labelId = layaLabelSetThreshold.labelId;
                threshold = layaLabelSetThreshold.threshold;
                topCount = layaLabelSetThreshold.topCount;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabelSetThreshold"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data.</param>
        public LayaLabelSetThreshold(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the identifier of the label set the rule applies to.
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
        /// Gets the identifier of the label of a multi-label set the rule applies to, or <c>null</c> for a rule of the whole set.
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
        /// Gets the probability a label of a multi-label set must reach to be suggested, or <c>null</c> for the set's rule, else 0.5.
        /// </summary>
        [JsonIgnore]
        public double? Threshold
        {
            get
            {
                return threshold;
            }
        }

        /// <summary>
        /// Gets the number of labels of a single-choice set suggested, highest probability first, or <c>null</c> for 1. Ignored when <see cref="LabelId"/> is set.
        /// </summary>
        [JsonIgnore]
        public int? TopCount
        {
            get
            {
                return topCount;
            }
        }
    }
}
