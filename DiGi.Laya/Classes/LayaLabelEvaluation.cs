using DiGi.Core.Classes;
using DiGi.Laya.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents the precision, recall and F1 of one label of a label set.
    /// </summary>
    public class LayaLabelEvaluation : SerializableObject, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(F1))]
        private readonly double? f1;

        [JsonInclude, JsonPropertyName(nameof(FalseNegativeCount))]
        private readonly int falseNegativeCount;

        [JsonInclude, JsonPropertyName(nameof(FalsePositiveCount))]
        private readonly int falsePositiveCount;

        [JsonInclude, JsonPropertyName(nameof(LabelId))]
        private readonly string? labelId;

        [JsonInclude, JsonPropertyName(nameof(Precision))]
        private readonly double? precision;

        [JsonInclude, JsonPropertyName(nameof(Recall))]
        private readonly double? recall;

        [JsonInclude, JsonPropertyName(nameof(Support))]
        private readonly int support;

        [JsonInclude, JsonPropertyName(nameof(TruePositiveCount))]
        private readonly int truePositiveCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabelEvaluation"/> class.
        /// </summary>
        /// <param name="labelId">The identifier of the label.</param>
        /// <param name="support">The number of evaluated items the label truly applies to.</param>
        /// <param name="truePositiveCount">The number of items the label was predicted for and applies to.</param>
        /// <param name="falsePositiveCount">The number of items the label was predicted for and does not apply to.</param>
        /// <param name="falseNegativeCount">The number of items the label applies to and was not predicted for.</param>
        /// <param name="precision">The true positives over all predictions of the label, or <c>null</c> when it was never predicted.</param>
        /// <param name="recall">The true positives over the support, or <c>null</c> when the support is 0.</param>
        /// <param name="f1">Two true positives over two true positives plus false positives plus false negatives, or <c>null</c> when all three are 0.</param>
        public LayaLabelEvaluation(
            string? labelId,
            int support,
            int truePositiveCount,
            int falsePositiveCount,
            int falseNegativeCount,
            double? precision,
            double? recall,
            double? f1)
        {
            this.labelId = labelId;
            this.support = support;
            this.truePositiveCount = truePositiveCount;
            this.falsePositiveCount = falsePositiveCount;
            this.falseNegativeCount = falseNegativeCount;
            this.precision = precision;
            this.recall = recall;
            this.f1 = f1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabelEvaluation"/> class by copying an existing instance.
        /// </summary>
        /// <param name="layaLabelEvaluation">The source instance to copy from.</param>
        public LayaLabelEvaluation(LayaLabelEvaluation? layaLabelEvaluation)
            : base(layaLabelEvaluation)
        {
            if (layaLabelEvaluation != null)
            {
                f1 = layaLabelEvaluation.f1;
                falseNegativeCount = layaLabelEvaluation.falseNegativeCount;
                falsePositiveCount = layaLabelEvaluation.falsePositiveCount;
                labelId = layaLabelEvaluation.labelId;
                precision = layaLabelEvaluation.precision;
                recall = layaLabelEvaluation.recall;
                support = layaLabelEvaluation.support;
                truePositiveCount = layaLabelEvaluation.truePositiveCount;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabelEvaluation"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data.</param>
        public LayaLabelEvaluation(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets two true positives over two true positives plus false positives plus false negatives, or <c>null</c> when all three are 0.
        /// </summary>
        [JsonIgnore]
        public double? F1
        {
            get
            {
                return f1;
            }
        }

        /// <summary>
        /// Gets the number of items the label applies to and was not predicted for.
        /// </summary>
        [JsonIgnore]
        public int FalseNegativeCount
        {
            get
            {
                return falseNegativeCount;
            }
        }

        /// <summary>
        /// Gets the number of items the label was predicted for and does not apply to.
        /// </summary>
        [JsonIgnore]
        public int FalsePositiveCount
        {
            get
            {
                return falsePositiveCount;
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
        /// Gets the true positives over all predictions of the label, or <c>null</c> when it was never predicted.
        /// </summary>
        [JsonIgnore]
        public double? Precision
        {
            get
            {
                return precision;
            }
        }

        /// <summary>
        /// Gets the true positives over the support, or <c>null</c> when the support is 0.
        /// </summary>
        [JsonIgnore]
        public double? Recall
        {
            get
            {
                return recall;
            }
        }

        /// <summary>
        /// Gets the number of evaluated items the label truly applies to.
        /// </summary>
        [JsonIgnore]
        public int Support
        {
            get
            {
                return support;
            }
        }

        /// <summary>
        /// Gets the number of items the label was predicted for and applies to.
        /// </summary>
        [JsonIgnore]
        public int TruePositiveCount
        {
            get
            {
                return truePositiveCount;
            }
        }
    }
}
