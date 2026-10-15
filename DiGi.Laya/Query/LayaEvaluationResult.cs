using DiGi.Laya.Classes;
using DiGi.Laya.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiGi.Laya
{
    public static partial class Query
    {
        /// <summary>
        /// Measures how well classification results match known label assignments, label set by label set.
        /// <para>A single-choice set evaluates every item that has a true assignment in the set (the first in assignment order is its label) and scores for the set. Labels are ranked by probability, the earlier label first on a tie: <see cref="LayaLabelSetEvaluation.Top1Accuracy"/> and <see cref="LayaLabelSetEvaluation.Top3Accuracy"/> count the true label at rank 1 and within ranks 1 to 3, and the per-label counts and the confusion rows take rank 1 as the prediction - the model's ranking, before constraints or thresholds. The expected calibration error bins the probability of rank 1 against whether it was right; the Brier score is the multi-class sum over the set's labels of (probability - truth) squared, a missing score counting as 0, averaged over items.</para>
        /// <para>A multi-label set evaluates every item with at least one assignment in the set and scores for it, closed-world per item: a label without an assignment does not apply. The prediction is <see cref="LayaLabelScore.IsSuggested"/> - the decision after the threshold and any constraint. The expected calibration error and the Brier score treat each label of each item as one binary forecast of its truth.</para>
        /// <para>Both kinds: the calibration error uses 10 equal-width bins on [0, 1] and is the sum over bins of (bin size / count) times |mean outcome - mean probability|; <see cref="LayaLabelSetEvaluation.MacroF1"/> is the mean F1 of the labels with a support above 0; <see cref="LayaLabelSetEvaluation.MicroF1"/> is computed for multi-label sets only. Assignment weights play no part. An item's first result is used when it has several.</para>
        /// </summary>
        /// <param name="layaLabelAssignments">The known labels.</param>
        /// <param name="layaClassificationResults">The classification results to measure.</param>
        /// <param name="layaLabelSets">The label sets to evaluate, in the order they are reported.</param>
        /// <returns>The evaluation, or <c>null</c> when any argument is <c>null</c>.</returns>
        public static Classes.LayaEvaluationResult? LayaEvaluationResult(IEnumerable<LayaLabelAssignment>? layaLabelAssignments, IEnumerable<LayaClassificationResult>? layaClassificationResults, IEnumerable<LayaLabelSet>? layaLabelSets)
        {
            if (layaLabelAssignments == null || layaClassificationResults == null || layaLabelSets == null)
            {
                return null;
            }

            List<LayaLabelAssignment> layaLabelAssignments_All = [.. layaLabelAssignments.OfType<LayaLabelAssignment>().Where(x => x.ItemId != null && x.LabelSetId != null && x.LabelId != null)];

            Dictionary<string, LayaClassificationResult> layaClassificationResults_ByItem = new(StringComparer.Ordinal);
            foreach (LayaClassificationResult layaClassificationResult in layaClassificationResults.OfType<LayaClassificationResult>())
            {
                if (layaClassificationResult.ItemId != null && !layaClassificationResults_ByItem.ContainsKey(layaClassificationResult.ItemId))
                {
                    layaClassificationResults_ByItem[layaClassificationResult.ItemId] = layaClassificationResult;
                }
            }

            static double? ExpectedCalibrationError(List<(double Probability, double Outcome)> forecasts)
            {
                if (forecasts.Count == 0)
                {
                    return null;
                }

                int[] counts = new int[10];
                double[] probabilities = new double[10];
                double[] outcomes = new double[10];
                foreach ((double probability, double outcome) in forecasts)
                {
                    double probability_Clamped = Math.Min(1.0, Math.Max(0.0, probability));
                    int index = Math.Min(9, (int)(probability_Clamped * 10));
                    counts[index]++;
                    probabilities[index] += probability_Clamped;
                    outcomes[index] += outcome;
                }

                double result = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (counts[i] != 0)
                    {
                        result += (double)counts[i] / forecasts.Count * Math.Abs((outcomes[i] / counts[i]) - (probabilities[i] / counts[i]));
                    }
                }

                return result;
            }

            static LayaLabelEvaluation LabelEvaluation(string labelId, int truePositiveCount, int falsePositiveCount, int falseNegativeCount)
            {
                int support = truePositiveCount + falseNegativeCount;
                double? precision = truePositiveCount + falsePositiveCount == 0 ? null : (double)truePositiveCount / (truePositiveCount + falsePositiveCount);
                double? recall = support == 0 ? null : (double)truePositiveCount / support;
                int denominator = (2 * truePositiveCount) + falsePositiveCount + falseNegativeCount;
                double? f1 = denominator == 0 ? null : 2.0 * truePositiveCount / denominator;
                return new LayaLabelEvaluation(labelId, support, truePositiveCount, falsePositiveCount, falseNegativeCount, precision, recall, f1);
            }

            static double? MacroF1(List<LayaLabelEvaluation> layaLabelEvaluations)
            {
                List<double> values = [.. layaLabelEvaluations.Where(x => x.Support > 0 && x.F1 != null).Select(x => x.F1!.Value)];
                return values.Count == 0 ? null : values.Average();
            }

            List<LayaLabelSetEvaluation> layaLabelSetEvaluations = [];
            foreach (LayaLabelSet layaLabelSet in layaLabelSets.OfType<LayaLabelSet>())
            {
                string? labelSetId = layaLabelSet.Id;
                List<string> labelIds = [.. (layaLabelSet.Labels?.OfType<LayaLabel>() ?? []).Select(x => x.Id).OfType<string>().Distinct(StringComparer.Ordinal)];
                HashSet<string> labelIds_Set = new(labelIds, StringComparer.Ordinal);

                List<LayaLabelAssignment> layaLabelAssignments_Set = [.. layaLabelAssignments_All.Where(x => string.Equals(x.LabelSetId, labelSetId, StringComparison.Ordinal) && labelIds_Set.Contains(x.LabelId!))];

                //The scores of the set per item, by label
                Dictionary<string, Dictionary<string, LayaLabelScore>> scores_ByItem = new(StringComparer.Ordinal);
                foreach (KeyValuePair<string, LayaClassificationResult> keyValuePair in layaClassificationResults_ByItem)
                {
                    Dictionary<string, LayaLabelScore> scores = new(StringComparer.Ordinal);
                    foreach (LayaLabelScore layaLabelScore in keyValuePair.Value.Scores?.OfType<LayaLabelScore>() ?? [])
                    {
                        if (string.Equals(layaLabelScore.LabelSetId, labelSetId, StringComparison.Ordinal) && layaLabelScore.LabelId != null && labelIds_Set.Contains(layaLabelScore.LabelId) && !scores.ContainsKey(layaLabelScore.LabelId))
                        {
                            scores[layaLabelScore.LabelId] = layaLabelScore;
                        }
                    }

                    if (scores.Count != 0)
                    {
                        scores_ByItem[keyValuePair.Key] = scores;
                    }
                }

                Dictionary<string, int> truePositiveCounts = labelIds.ToDictionary(x => x, x => 0, StringComparer.Ordinal);
                Dictionary<string, int> falsePositiveCounts = labelIds.ToDictionary(x => x, x => 0, StringComparer.Ordinal);
                Dictionary<string, int> falseNegativeCounts = labelIds.ToDictionary(x => x, x => 0, StringComparer.Ordinal);
                List<(double Probability, double Outcome)> forecasts = [];
                List<double> brierScores = [];
                int itemCount = 0;

                if (layaLabelSet.Kind == LayaLabelSetKind.SingleChoice)
                {
                    Dictionary<string, string> labelIds_Actual = new(StringComparer.Ordinal);
                    foreach (LayaLabelAssignment layaLabelAssignment in layaLabelAssignments_Set.Where(x => x.Truth))
                    {
                        if (!labelIds_Actual.ContainsKey(layaLabelAssignment.ItemId!))
                        {
                            labelIds_Actual[layaLabelAssignment.ItemId!] = layaLabelAssignment.LabelId!;
                        }
                    }

                    Dictionary<(string Actual, string Predicted), int> confusion = [];
                    int top1Count = 0;
                    int top3Count = 0;

                    foreach (KeyValuePair<string, string> keyValuePair in labelIds_Actual)
                    {
                        if (!scores_ByItem.TryGetValue(keyValuePair.Key, out Dictionary<string, LayaLabelScore>? scores))
                        {
                            continue;
                        }

                        itemCount++;
                        string labelId_Actual = keyValuePair.Value;

                        List<string> labelIds_Ranked = [.. labelIds.Select((x, i) => (x, i)).Where(x => scores.ContainsKey(x.x)).OrderByDescending(x => scores[x.x].Probability).ThenBy(x => x.i).Select(x => x.x)];
                        string labelId_Predicted = labelIds_Ranked[0];

                        if (labelId_Predicted == labelId_Actual)
                        {
                            top1Count++;
                            truePositiveCounts[labelId_Actual]++;
                        }
                        else
                        {
                            falsePositiveCounts[labelId_Predicted]++;
                            falseNegativeCounts[labelId_Actual]++;
                        }

                        if (labelIds_Ranked.Take(3).Contains(labelId_Actual))
                        {
                            top3Count++;
                        }

                        confusion.TryGetValue((labelId_Actual, labelId_Predicted), out int count);
                        confusion[(labelId_Actual, labelId_Predicted)] = count + 1;

                        forecasts.Add((scores[labelId_Predicted].Probability, labelId_Predicted == labelId_Actual ? 1.0 : 0.0));
                        brierScores.Add(labelIds.Sum(x => Math.Pow((scores.TryGetValue(x, out LayaLabelScore? layaLabelScore) ? layaLabelScore.Probability : 0.0) - (x == labelId_Actual ? 1.0 : 0.0), 2)));
                    }

                    List<LayaLabelEvaluation> layaLabelEvaluations = [.. labelIds.Select(x => LabelEvaluation(x, truePositiveCounts[x], falsePositiveCounts[x], falseNegativeCounts[x]))];
                    List<LayaConfusionRow> layaConfusionRows = [];
                    foreach (string labelId_Actual in labelIds)
                    {
                        foreach (string labelId_Predicted in labelIds)
                        {
                            if (confusion.TryGetValue((labelId_Actual, labelId_Predicted), out int count))
                            {
                                layaConfusionRows.Add(new LayaConfusionRow(labelId_Actual, labelId_Predicted, count));
                            }
                        }
                    }

                    layaLabelSetEvaluations.Add(new LayaLabelSetEvaluation(
                        labelSetId,
                        layaLabelSet.Kind,
                        itemCount,
                        itemCount == 0 ? null : (double)top1Count / itemCount,
                        itemCount == 0 ? null : (double)top3Count / itemCount,
                        null,
                        MacroF1(layaLabelEvaluations),
                        ExpectedCalibrationError(forecasts),
                        brierScores.Count == 0 ? null : brierScores.Average(),
                        layaLabelEvaluations,
                        layaConfusionRows));
                }
                else
                {
                    Dictionary<string, Dictionary<string, bool>> truths_ByItem = new(StringComparer.Ordinal);
                    foreach (LayaLabelAssignment layaLabelAssignment in layaLabelAssignments_Set)
                    {
                        if (!truths_ByItem.TryGetValue(layaLabelAssignment.ItemId!, out Dictionary<string, bool>? truths))
                        {
                            truths = new(StringComparer.Ordinal);
                            truths_ByItem[layaLabelAssignment.ItemId!] = truths;
                        }

                        if (!truths.ContainsKey(layaLabelAssignment.LabelId!))
                        {
                            truths[layaLabelAssignment.LabelId!] = layaLabelAssignment.Truth;
                        }
                    }

                    foreach (KeyValuePair<string, Dictionary<string, bool>> keyValuePair in truths_ByItem)
                    {
                        if (!scores_ByItem.TryGetValue(keyValuePair.Key, out Dictionary<string, LayaLabelScore>? scores))
                        {
                            continue;
                        }

                        itemCount++;
                        foreach (string labelId in labelIds)
                        {
                            if (!scores.TryGetValue(labelId, out LayaLabelScore? layaLabelScore))
                            {
                                continue;
                            }

                            bool truth = keyValuePair.Value.TryGetValue(labelId, out bool value) && value;
                            if (layaLabelScore.IsSuggested && truth)
                            {
                                truePositiveCounts[labelId]++;
                            }
                            else if (layaLabelScore.IsSuggested)
                            {
                                falsePositiveCounts[labelId]++;
                            }
                            else if (truth)
                            {
                                falseNegativeCounts[labelId]++;
                            }

                            forecasts.Add((layaLabelScore.Probability, truth ? 1.0 : 0.0));
                            brierScores.Add(Math.Pow(layaLabelScore.Probability - (truth ? 1.0 : 0.0), 2));
                        }
                    }

                    List<LayaLabelEvaluation> layaLabelEvaluations = [.. labelIds.Select(x => LabelEvaluation(x, truePositiveCounts[x], falsePositiveCounts[x], falseNegativeCounts[x]))];
                    int truePositiveCount = truePositiveCounts.Values.Sum();
                    int denominator = (2 * truePositiveCount) + falsePositiveCounts.Values.Sum() + falseNegativeCounts.Values.Sum();

                    layaLabelSetEvaluations.Add(new LayaLabelSetEvaluation(
                        labelSetId,
                        layaLabelSet.Kind,
                        itemCount,
                        null,
                        null,
                        denominator == 0 ? null : 2.0 * truePositiveCount / denominator,
                        MacroF1(layaLabelEvaluations),
                        ExpectedCalibrationError(forecasts),
                        brierScores.Count == 0 ? null : brierScores.Average(),
                        layaLabelEvaluations,
                        []));
                }
            }

            return new Classes.LayaEvaluationResult(layaLabelSetEvaluations);
        }
    }
}
