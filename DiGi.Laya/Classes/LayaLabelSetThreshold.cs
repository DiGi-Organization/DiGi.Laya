using DiGi.Core.Classes;
using DiGi.Laya.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents the decision rule of one label set in <see cref="LayaClassificationOptions"/>.
    /// </summary>
    public class LayaLabelSetThreshold : SerializableObject, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(LabelSetId))]
        private readonly string? labelSetId;

        [JsonInclude, JsonPropertyName(nameof(Threshold))]
        private readonly double? threshold;

        [JsonInclude, JsonPropertyName(nameof(TopCount))]
        private readonly int? topCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabelSetThreshold"/> class.
        /// </summary>
        /// <param name="labelSetId">The identifier of the label set the rule applies to.</param>
        /// <param name="threshold">The probability a label of a multi-label set must reach to be suggested, or <c>null</c> for 0.5.</param>
        /// <param name="topCount">The number of labels of a single-choice set suggested, highest probability first, or <c>null</c> for 1.</param>
        public LayaLabelSetThreshold(string? labelSetId, double? threshold, int? topCount)
        {
            this.labelSetId = labelSetId;
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
        /// Gets the probability a label of a multi-label set must reach to be suggested, or <c>null</c> for 0.5.
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
        /// Gets the number of labels of a single-choice set suggested, highest probability first, or <c>null</c> for 1.
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
