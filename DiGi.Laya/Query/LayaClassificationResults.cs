using DiGi.Laya.Classes;
using DiGi.Laya.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DiGi.Laya
{
    public static partial class Query
    {
        /// <summary>
        /// Turns the responses of a prediction run into one classification result per response: a score per label and which labels are suggested.
        /// <para>Pure C#. The answers are found by <see cref="LayaQuestionName(string?, string?)"/>. A single-choice set scores every label with its option probability and suggests the <see cref="LayaLabelSetThreshold.TopCount"/> most probable (1 by default; ties go to the earlier label). A multi-label set scores every label with the probability its noul statement is true and suggests each label at or above <see cref="LayaLabelSetThreshold.Threshold"/> (0.5 by default). An answer whose <see cref="LayaAnswer.Confidence"/> is below <see cref="LayaClassificationOptions.MinimumConfidence"/>, or that reports none while a floor is set, suggests nothing but keeps its scores.</para>
        /// <para>A label set or label without an answer, a label missing from a choice answer, and a request Laya truncated are named in <see cref="LayaClassificationResult.Messages"/>; the scores that could be read are kept. No constraint is applied here - see <see cref="Modify.ApplyConstraints(LayaClassificationResult?, IEnumerable{LayaLabelConstraint}?)"/>.</para>
        /// </summary>
        /// <param name="layaPredictionResult">The prediction run whose responses are read.</param>
        /// <param name="layaLabelSets">The label sets the requests asked.</param>
        /// <param name="layaClassificationOptions">The decision rules, or <c>null</c> for the defaults.</param>
        /// <returns>One result per response, in response order; empty when the prediction result or the label sets are <c>null</c>.</returns>
        public static List<LayaClassificationResult> LayaClassificationResults(LayaPredictionResult? layaPredictionResult, IEnumerable<LayaLabelSet>? layaLabelSets, LayaClassificationOptions? layaClassificationOptions)
        {
            if (layaPredictionResult?.Responses == null || layaLabelSets == null)
            {
                return [];
            }

            List<LayaLabelSet> layaLabelSets_All = [.. layaLabelSets.OfType<LayaLabelSet>()];

            Dictionary<string, LayaLabelSetThreshold> layaLabelSetThresholds = new(StringComparer.Ordinal);
            foreach (LayaLabelSetThreshold layaLabelSetThreshold in layaClassificationOptions?.Thresholds?.OfType<LayaLabelSetThreshold>() ?? [])
            {
                if (layaLabelSetThreshold.LabelSetId != null && !layaLabelSetThresholds.ContainsKey(layaLabelSetThreshold.LabelSetId))
                {
                    layaLabelSetThresholds[layaLabelSetThreshold.LabelSetId] = layaLabelSetThreshold;
                }
            }

            double? minimumConfidence = layaClassificationOptions?.MinimumConfidence;

            bool Abstains(LayaAnswer layaAnswer)
            {
                return minimumConfidence != null && (layaAnswer.Confidence == null || layaAnswer.Confidence.Value < minimumConfidence.Value);
            }

            DateTimeOffset createdAt = DateTimeOffset.Now;

            List<LayaClassificationResult> result = [];
            foreach (LayaResponse layaResponse in layaPredictionResult.Responses.OfType<LayaResponse>())
            {
                Dictionary<string, LayaAnswer> layaAnswers = new(StringComparer.Ordinal);
                foreach (LayaAnswer layaAnswer in layaResponse.Answers?.OfType<LayaAnswer>() ?? [])
                {
                    if (layaAnswer.Name != null && !layaAnswers.ContainsKey(layaAnswer.Name))
                    {
                        layaAnswers[layaAnswer.Name] = layaAnswer;
                    }
                }

                List<LayaLabelScore> layaLabelScores = [];
                List<string> messages = [];

                if (layaResponse.Truncated == true)
                {
                    messages.Add("Laya truncated the request to fit its token budget, so it was answered from part of the state.");
                }

                foreach (LayaLabelSet layaLabelSet in layaLabelSets_All)
                {
                    List<LayaLabel> layaLabels = [.. layaLabelSet.Labels?.OfType<LayaLabel>() ?? []];
                    layaLabelSetThresholds.TryGetValue(layaLabelSet.Id ?? string.Empty, out LayaLabelSetThreshold? layaLabelSetThreshold);

                    if (layaLabelSet.Kind == LayaLabelSetKind.SingleChoice)
                    {
                        string? name = LayaQuestionName(layaLabelSet.Id, null);
                        if (name == null || !layaAnswers.TryGetValue(name, out LayaAnswer? layaAnswer) || layaAnswer is not LayaChoiceAnswer layaChoiceAnswer)
                        {
                            messages.Add(string.Format(CultureInfo.InvariantCulture, "No answer for the label set '{0}'.", layaLabelSet.Id));
                            continue;
                        }

                        Dictionary<string, double> probabilities = new(StringComparer.Ordinal);
                        foreach (LayaProbability layaProbability in layaChoiceAnswer.Probabilities?.OfType<LayaProbability>() ?? [])
                        {
                            if (layaProbability.Label != null && !probabilities.ContainsKey(layaProbability.Label))
                            {
                                probabilities[layaProbability.Label] = layaProbability.Value;
                            }
                        }

                        //Labels with a probability, most probable first and the earlier label first on a tie; the first TopCount of them are suggested
                        List<LayaLabel> layaLabels_Scored = [.. layaLabels.Where(x => x.Id != null && probabilities.ContainsKey(x.Id))];
                        HashSet<string> labelIds_Suggested = new(StringComparer.Ordinal);
                        if (!Abstains(layaChoiceAnswer))
                        {
                            int topCount = layaLabelSetThreshold?.TopCount ?? 1;
                            foreach (LayaLabel layaLabel in layaLabels_Scored.Select((x, i) => (x, i)).OrderByDescending(x => probabilities[x.x.Id!]).ThenBy(x => x.i).Select(x => x.x).Take(Math.Max(0, topCount)))
                            {
                                labelIds_Suggested.Add(layaLabel.Id!);
                            }
                        }

                        foreach (LayaLabel layaLabel in layaLabels)
                        {
                            if (layaLabel.Id == null || !probabilities.TryGetValue(layaLabel.Id, out double probability))
                            {
                                messages.Add(string.Format(CultureInfo.InvariantCulture, "The answer for the label set '{0}' has no probability for the label '{1}'.", layaLabelSet.Id, layaLabel.Id));
                                continue;
                            }

                            layaLabelScores.Add(new LayaLabelScore(layaLabelSet.Id, layaLabel.Id, probability, labelIds_Suggested.Contains(layaLabel.Id), false, null));
                        }
                    }
                    else
                    {
                        double threshold = layaLabelSetThreshold?.Threshold ?? 0.5;
                        foreach (LayaLabel layaLabel in layaLabels)
                        {
                            string? name = LayaQuestionName(layaLabelSet.Id, layaLabel.Id);
                            if (name == null || !layaAnswers.TryGetValue(name, out LayaAnswer? layaAnswer) || layaAnswer is not LayaNoulAnswer layaNoulAnswer || layaNoulAnswer.Probability == null)
                            {
                                messages.Add(string.Format(CultureInfo.InvariantCulture, "No answer for the label '{1}' of the label set '{0}'.", layaLabelSet.Id, layaLabel.Id));
                                continue;
                            }

                            double probability = layaNoulAnswer.Probability.Value;
                            layaLabelScores.Add(new LayaLabelScore(layaLabelSet.Id, layaLabel.Id, probability, probability >= threshold && !Abstains(layaNoulAnswer), false, null));
                        }
                    }
                }

                result.Add(new LayaClassificationResult(layaResponse.RequestId, layaLabelScores, layaPredictionResult.ModelSHA256, createdAt, messages));
            }

            return result;
        }
    }
}
