using DiGi.Core.Classes;
using DiGi.Laya.Interfaces;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Provides the decision rules that turn Laya's probabilities into suggested labels.
    /// <para>A label set without a <see cref="LayaLabelSetThreshold"/> suggests the single most probable label of a single-choice set, and every label of a multi-label set with a probability of 0.5 or more.</para>
    /// <para>A multi-label label takes the threshold of the rule naming it (<see cref="LayaLabelSetThreshold.LabelId"/>), else of the rule of its set, else 0.5. A rule naming an unknown set or label is reported as a warning by <see cref="Modify.ClassifyAsync(System.Collections.Generic.IEnumerable{LayaItem}?, System.Collections.Generic.IEnumerable{LayaLabelSet}?, LayaClassificationOptions?, LayaPredictionOptions?, System.Collections.Generic.IEnumerable{LayaLabelConstraint}?, System.Threading.CancellationToken)"/>.</para>
    /// </summary>
    public class LayaClassificationOptions : SerializableOptions, ILayaSerializableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LayaClassificationOptions"/> class with default values.
        /// </summary>
        public LayaClassificationOptions()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaClassificationOptions"/> class by copying an existing options instance.
        /// </summary>
        /// <param name="layaClassificationOptions">The source options instance to copy from.</param>
        public LayaClassificationOptions(LayaClassificationOptions? layaClassificationOptions)
            : base(layaClassificationOptions)
        {
            if (layaClassificationOptions != null)
            {
                MinimumConfidence = layaClassificationOptions.MinimumConfidence;

                if (layaClassificationOptions.Thresholds != null)
                {
                    Thresholds = [];
                    foreach (LayaLabelSetThreshold layaLabelSetThreshold in layaClassificationOptions.Thresholds)
                    {
                        if (Core.Query.Clone(layaLabelSetThreshold) is LayaLabelSetThreshold layaLabelSetThreshold_Clone)
                        {
                            Thresholds.Add(layaLabelSetThreshold_Clone);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaClassificationOptions"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the settings.</param>
        public LayaClassificationOptions(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets or sets the confidence an answer must reach for any of its labels to be suggested, or <c>null</c> for no floor.
        /// <para>The confidence is Laya's own (<see cref="LayaAnswer.Confidence"/>): derived from the option distribution for a choice question, and the larger of the probabilities of true and false for a noul question. An answer below the floor suggests nothing, and its probabilities are still reported. Uncalibrated checkpoints are over-confident, so set a floor only with a calibrated one.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(MinimumConfidence))]
        public double? MinimumConfidence { get; set; } = null;

        /// <summary>
        /// Gets or sets the decision rule of each label set that does not use the defaults, or <c>null</c> for the defaults everywhere.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Thresholds))]
        public List<LayaLabelSetThreshold>? Thresholds { get; set; } = null;
    }
}
