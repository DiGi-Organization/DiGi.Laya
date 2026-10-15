using DiGi.Core.Classes;
using DiGi.Laya.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents how many labelled questions laya.train.finetune skipped for one reason.
    /// <para>Held in a list by <see cref="LayaTrainingResult.SkippedCounts"/> rather than in a dictionary keyed by reason, because the DiGi serializer rebuilds a dictionary with the default comparer of its type and files every key as a JSON object name.</para>
    /// </summary>
    public class LayaSkippedCount : SerializableObject, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Count))]
        private readonly int count;

        [JsonInclude, JsonPropertyName(nameof(Reason))]
        private readonly string? reason;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaSkippedCount"/> class.
        /// </summary>
        /// <param name="reason">The reason laya gives: empty_text, empty_label, invalid_question, invalid_target, options_collapsed or options_beyond_max_len.</param>
        /// <param name="count">The number of questions skipped for that reason.</param>
        public LayaSkippedCount(string? reason, int count)
        {
            this.reason = reason;
            this.count = count;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaSkippedCount"/> class by copying an existing instance.
        /// </summary>
        /// <param name="layaSkippedCount">The source instance to copy from.</param>
        public LayaSkippedCount(LayaSkippedCount? layaSkippedCount)
            : base(layaSkippedCount)
        {
            if (layaSkippedCount != null)
            {
                count = layaSkippedCount.count;
                reason = layaSkippedCount.reason;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaSkippedCount"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data.</param>
        public LayaSkippedCount(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the number of questions skipped for that reason.
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
        /// Gets the reason laya gives: empty_text, empty_label, invalid_question, invalid_target, options_collapsed or options_beyond_max_len.
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
