using DiGi.Core.Classes;
using DiGi.Laya.Interfaces;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents how well classification results match known label assignments, label set by label set.
    /// </summary>
    public class LayaEvaluationResult : SerializableResult, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(LabelSetEvaluations))]
        private readonly List<LayaLabelSetEvaluation>? labelSetEvaluations;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaEvaluationResult"/> class.
        /// </summary>
        /// <param name="labelSetEvaluations">The evaluation of every label set, in set order.</param>
        public LayaEvaluationResult(IEnumerable<LayaLabelSetEvaluation>? labelSetEvaluations)
        {
            this.labelSetEvaluations = labelSetEvaluations == null ? null : [.. labelSetEvaluations];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaEvaluationResult"/> class by copying an existing instance.
        /// </summary>
        /// <param name="layaEvaluationResult">The source instance to copy from.</param>
        public LayaEvaluationResult(LayaEvaluationResult? layaEvaluationResult)
            : base(layaEvaluationResult)
        {
            if (layaEvaluationResult != null)
            {

                if (layaEvaluationResult.labelSetEvaluations != null)
                {
                    labelSetEvaluations = [];
                    foreach (LayaLabelSetEvaluation layaLabelSetEvaluation in layaEvaluationResult.labelSetEvaluations)
                    {
                        if (Core.Query.Clone(layaLabelSetEvaluation) is LayaLabelSetEvaluation layaLabelSetEvaluation_Clone)
                        {
                            labelSetEvaluations.Add(layaLabelSetEvaluation_Clone);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaEvaluationResult"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data.</param>
        public LayaEvaluationResult(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the evaluation of every label set, in set order.
        /// </summary>
        [JsonIgnore]
        public List<LayaLabelSetEvaluation>? LabelSetEvaluations
        {
            get
            {
                return labelSetEvaluations;
            }
        }
    }
}
