using DiGi.Core.Classes;
using DiGi.Laya.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents one non-empty cell of the confusion matrix of a single-choice label set.
    /// </summary>
    public class LayaConfusionRow : SerializableObject, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(ActualLabelId))]
        private readonly string? actualLabelId;

        [JsonInclude, JsonPropertyName(nameof(Count))]
        private readonly int count;

        [JsonInclude, JsonPropertyName(nameof(PredictedLabelId))]
        private readonly string? predictedLabelId;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaConfusionRow"/> class.
        /// </summary>
        /// <param name="actualLabelId">The true label.</param>
        /// <param name="predictedLabelId">The label ranked first by probability.</param>
        /// <param name="count">The number of items with that pair.</param>
        public LayaConfusionRow(string? actualLabelId, string? predictedLabelId, int count)
        {
            this.actualLabelId = actualLabelId;
            this.predictedLabelId = predictedLabelId;
            this.count = count;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaConfusionRow"/> class by copying an existing instance.
        /// </summary>
        /// <param name="layaConfusionRow">The source instance to copy from.</param>
        public LayaConfusionRow(LayaConfusionRow? layaConfusionRow)
            : base(layaConfusionRow)
        {
            if (layaConfusionRow != null)
            {
                actualLabelId = layaConfusionRow.actualLabelId;
                count = layaConfusionRow.count;
                predictedLabelId = layaConfusionRow.predictedLabelId;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaConfusionRow"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data.</param>
        public LayaConfusionRow(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the true label.
        /// </summary>
        [JsonIgnore]
        public string? ActualLabelId
        {
            get
            {
                return actualLabelId;
            }
        }

        /// <summary>
        /// Gets the number of items with that pair.
        /// </summary>
        [JsonIgnore]
        public int Count
        {
            get
            {
                return count;
            }
        }

        /// <summary>
        /// Gets the label ranked first by probability.
        /// </summary>
        [JsonIgnore]
        public string? PredictedLabelId
        {
            get
            {
                return predictedLabelId;
            }
        }
    }
}
