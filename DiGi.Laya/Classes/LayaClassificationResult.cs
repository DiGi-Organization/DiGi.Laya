using DiGi.Core.Classes;
using DiGi.Laya.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents the classification of one item: a score per label of every label set, and what went wrong with it.
    /// </summary>
    public class LayaClassificationResult : SerializableResult, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(CreatedAt))]
        private readonly DateTimeOffset? createdAt;

        [JsonInclude, JsonPropertyName(nameof(ItemId))]
        private readonly string? itemId;

        [JsonInclude, JsonPropertyName(nameof(Messages))]
        private readonly List<string>? messages;

        [JsonInclude, JsonPropertyName(nameof(ModelSHA256))]
        private readonly string? modelSHA256;

        [JsonInclude, JsonPropertyName(nameof(Scores))]
        private readonly List<LayaLabelScore>? scores;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaClassificationResult"/> class.
        /// </summary>
        /// <param name="itemId">The identifier of the item.</param>
        /// <param name="scores">The scores, label set by label set in set order, labels in label order.</param>
        /// <param name="modelSHA256">The SHA-256 of the checkpoint directory that scored the item.</param>
        /// <param name="createdAt">The moment the result was made.</param>
        /// <param name="messages">The findings about this item only: no response, left out of the run, refused by laya, a missing answer, a truncated request. Findings about the whole run are in <see cref="LayaClassificationRunResult.Messages"/>.</param>
        public LayaClassificationResult(string? itemId, IEnumerable<LayaLabelScore>? scores, string? modelSHA256, DateTimeOffset? createdAt, IEnumerable<string>? messages)
        {
            this.itemId = itemId;
            this.scores = scores == null ? null : [.. scores];
            this.modelSHA256 = modelSHA256;
            this.createdAt = createdAt;
            this.messages = messages == null ? null : [.. messages];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaClassificationResult"/> class by copying an existing instance.
        /// </summary>
        /// <param name="layaClassificationResult">The source instance to copy from.</param>
        public LayaClassificationResult(LayaClassificationResult? layaClassificationResult)
            : base(layaClassificationResult)
        {
            if (layaClassificationResult != null)
            {
                createdAt = layaClassificationResult.createdAt;
                itemId = layaClassificationResult.itemId;
                messages = layaClassificationResult.messages == null ? null : [.. layaClassificationResult.messages];
                modelSHA256 = layaClassificationResult.modelSHA256;

                if (layaClassificationResult.scores != null)
                {
                    scores = [];
                    foreach (LayaLabelScore layaLabelScore in layaClassificationResult.scores)
                    {
                        if (Core.Query.Clone(layaLabelScore) is LayaLabelScore layaLabelScore_Clone)
                        {
                            scores.Add(layaLabelScore_Clone);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaClassificationResult"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data.</param>
        public LayaClassificationResult(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the moment the result was made.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset? CreatedAt
        {
            get
            {
                return createdAt;
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
        /// Gets the findings about this item only: no response, left out of the run, refused by laya, a missing answer, a truncated request.
        /// <para>Findings about the whole run - a refused or oversized label set, the process exit, a time limit - are in <see cref="LayaClassificationRunResult.Messages"/> and are not repeated here.</para>
        /// </summary>
        [JsonIgnore]
        public List<string>? Messages
        {
            get
            {
                return messages;
            }
        }

        /// <summary>
        /// Gets the SHA-256 of the checkpoint directory that scored the item.
        /// </summary>
        [JsonIgnore]
        public string? ModelSHA256
        {
            get
            {
                return modelSHA256;
            }
        }

        /// <summary>
        /// Gets the scores, label set by label set in set order, labels in label order.
        /// </summary>
        [JsonIgnore]
        public List<LayaLabelScore>? Scores
        {
            get
            {
                return scores;
            }
        }
    }
}
