using DiGi.Core.Classes;
using DiGi.Laya.Enums;
using DiGi.Laya.Interfaces;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents how well the classification results of one label set match the known assignments.
    /// </summary>
    public class LayaLabelSetEvaluation : SerializableObject, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(BrierScore))]
        private readonly double? brierScore;

        [JsonInclude, JsonPropertyName(nameof(ConfusionRows))]
        private readonly List<LayaConfusionRow>? confusionRows;

        [JsonInclude, JsonPropertyName(nameof(ExpectedCalibrationError))]
        private readonly double? expectedCalibrationError;

        [JsonInclude, JsonPropertyName(nameof(ItemCount))]
        private readonly int itemCount;

        [JsonInclude, JsonPropertyName(nameof(Kind))]
        private readonly LayaLabelSetKind kind;

        [JsonInclude, JsonPropertyName(nameof(LabelEvaluations))]
        private readonly List<LayaLabelEvaluation>? labelEvaluations;

        [JsonInclude, JsonPropertyName(nameof(LabelSetId))]
        private readonly string? labelSetId;

        [JsonInclude, JsonPropertyName(nameof(MacroF1))]
        private readonly double? macroF1;

        [JsonInclude, JsonPropertyName(nameof(MicroF1))]
        private readonly double? microF1;

        [JsonInclude, JsonPropertyName(nameof(Top1Accuracy))]
        private readonly double? top1Accuracy;

        [JsonInclude, JsonPropertyName(nameof(Top3Accuracy))]
        private readonly double? top3Accuracy;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabelSetEvaluation"/> class.
        /// </summary>
        /// <param name="labelSetId">The identifier of the label set.</param>
        /// <param name="kind">How the set is decided, which decides which metrics apply.</param>
        /// <param name="itemCount">The number of items evaluated: items with both a known label in the set and scores for it.</param>
        /// <param name="top1Accuracy">The share of items whose true label is ranked first by probability; single-choice sets only.</param>
        /// <param name="top3Accuracy">The share of items whose true label is among the three most probable; single-choice sets only.</param>
        /// <param name="microF1">F1 over the true positives, false positives and false negatives of all labels together; multi-label sets only.</param>
        /// <param name="macroF1">The mean F1 of the labels with a support above 0, or <c>null</c> when there is none.</param>
        /// <param name="expectedCalibrationError">The expected calibration error over 10 equal-width probability bins, or <c>null</c> when nothing was evaluated.</param>
        /// <param name="brierScore">The mean squared difference between probability and truth, or <c>null</c> when nothing was evaluated.</param>
        /// <param name="labelEvaluations">The evaluation of every label, in label order.</param>
        /// <param name="confusionRows">The non-empty cells of the confusion matrix, actual label then predicted label in label order; single-choice sets only.</param>
        public LayaLabelSetEvaluation(
            string? labelSetId,
            LayaLabelSetKind kind,
            int itemCount,
            double? top1Accuracy,
            double? top3Accuracy,
            double? microF1,
            double? macroF1,
            double? expectedCalibrationError,
            double? brierScore,
            IEnumerable<LayaLabelEvaluation>? labelEvaluations,
            IEnumerable<LayaConfusionRow>? confusionRows)
        {
            this.labelSetId = labelSetId;
            this.kind = kind;
            this.itemCount = itemCount;
            this.top1Accuracy = top1Accuracy;
            this.top3Accuracy = top3Accuracy;
            this.microF1 = microF1;
            this.macroF1 = macroF1;
            this.expectedCalibrationError = expectedCalibrationError;
            this.brierScore = brierScore;
            this.labelEvaluations = labelEvaluations == null ? null : [.. labelEvaluations];
            this.confusionRows = confusionRows == null ? null : [.. confusionRows];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabelSetEvaluation"/> class by copying an existing instance.
        /// </summary>
        /// <param name="layaLabelSetEvaluation">The source instance to copy from.</param>
        public LayaLabelSetEvaluation(LayaLabelSetEvaluation? layaLabelSetEvaluation)
            : base(layaLabelSetEvaluation)
        {
            if (layaLabelSetEvaluation != null)
            {
                brierScore = layaLabelSetEvaluation.brierScore;
                expectedCalibrationError = layaLabelSetEvaluation.expectedCalibrationError;
                itemCount = layaLabelSetEvaluation.itemCount;
                kind = layaLabelSetEvaluation.kind;
                labelSetId = layaLabelSetEvaluation.labelSetId;
                macroF1 = layaLabelSetEvaluation.macroF1;
                microF1 = layaLabelSetEvaluation.microF1;
                top1Accuracy = layaLabelSetEvaluation.top1Accuracy;
                top3Accuracy = layaLabelSetEvaluation.top3Accuracy;

                if (layaLabelSetEvaluation.confusionRows != null)
                {
                    confusionRows = [];
                    foreach (LayaConfusionRow layaConfusionRow in layaLabelSetEvaluation.confusionRows)
                    {
                        if (Core.Query.Clone(layaConfusionRow) is LayaConfusionRow layaConfusionRow_Clone)
                        {
                            confusionRows.Add(layaConfusionRow_Clone);
                        }
                    }
                }

                if (layaLabelSetEvaluation.labelEvaluations != null)
                {
                    labelEvaluations = [];
                    foreach (LayaLabelEvaluation layaLabelEvaluation in layaLabelSetEvaluation.labelEvaluations)
                    {
                        if (Core.Query.Clone(layaLabelEvaluation) is LayaLabelEvaluation layaLabelEvaluation_Clone)
                        {
                            labelEvaluations.Add(layaLabelEvaluation_Clone);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabelSetEvaluation"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data.</param>
        public LayaLabelSetEvaluation(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the mean squared difference between probability and truth, or <c>null</c> when nothing was evaluated.
        /// </summary>
        [JsonIgnore]
        public double? BrierScore
        {
            get
            {
                return brierScore;
            }
        }

        /// <summary>
        /// Gets the non-empty cells of the confusion matrix, actual label then predicted label in label order; single-choice sets only.
        /// </summary>
        [JsonIgnore]
        public List<LayaConfusionRow>? ConfusionRows
        {
            get
            {
                return confusionRows;
            }
        }

        /// <summary>
        /// Gets the expected calibration error over 10 equal-width probability bins, or <c>null</c> when nothing was evaluated.
        /// </summary>
        [JsonIgnore]
        public double? ExpectedCalibrationError
        {
            get
            {
                return expectedCalibrationError;
            }
        }

        /// <summary>
        /// Gets the number of items evaluated: items with both a known label in the set and scores for it.
        /// </summary>
        [JsonIgnore]
        public int ItemCount
        {
            get
            {
                return itemCount;
            }
        }

        /// <summary>
        /// Gets how the set is decided, which decides which metrics apply.
        /// </summary>
        [JsonIgnore]
        public LayaLabelSetKind Kind
        {
            get
            {
                return kind;
            }
        }

        /// <summary>
        /// Gets the evaluation of every label, in label order.
        /// </summary>
        [JsonIgnore]
        public List<LayaLabelEvaluation>? LabelEvaluations
        {
            get
            {
                return labelEvaluations;
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
        /// Gets the mean F1 of the labels with a support above 0, or <c>null</c> when there is none.
        /// </summary>
        [JsonIgnore]
        public double? MacroF1
        {
            get
            {
                return macroF1;
            }
        }

        /// <summary>
        /// Gets f1 over the true positives, false positives and false negatives of all labels together; multi-label sets only.
        /// </summary>
        [JsonIgnore]
        public double? MicroF1
        {
            get
            {
                return microF1;
            }
        }

        /// <summary>
        /// Gets the share of items whose true label is ranked first by probability; single-choice sets only.
        /// </summary>
        [JsonIgnore]
        public double? Top1Accuracy
        {
            get
            {
                return top1Accuracy;
            }
        }

        /// <summary>
        /// Gets the share of items whose true label is among the three most probable; single-choice sets only.
        /// </summary>
        [JsonIgnore]
        public double? Top3Accuracy
        {
            get
            {
                return top3Accuracy;
            }
        }
    }
}
