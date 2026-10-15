using DiGi.Laya.Classes;
using DiGi.Laya.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiGi.Laya
{
    public static partial class Create
    {
        /// <summary>
        /// Creates the training samples that teach Laya the known labels of items, asked exactly as the classification workflow asks them.
        /// <para>The questions come from <see cref="LayaQuestions(LayaLabelSet?)"/>. A single-choice set gives one choice sample per item with a true assignment in the set (the first in assignment order whose label is in the set), labelled with that label. A multi-label set gives one noul sample per assignment of one of its labels, labelled with the assignment's truth; only assigned labels are trained, so explicit negatives have to be assigned (<see cref="LayaLabelAssignment.Truth"/> <c>false</c>), typically with a weight below 1.</para>
        /// <para>Laya has no per-sample weight (DiGi-Organization/DiGi.Laya#1, D1). A noul assignment with a weight w below 1 becomes the soft target P(true) = 0.5 + 0.5 w for a true one and 0.5 - 0.5 w for a false one in <see cref="LayaTrainingSample.Probability"/>; a weight of 1 or more is a hard label. A single-choice sample has no soft form here and takes its label whatever the weight. An assignment with a weight of 0 or less carries no information and gives no sample. Assignments of unknown items, sets or labels are skipped.</para>
        /// <para>Each sample is id'd "&lt;item id&gt;|&lt;question name&gt;", carries its assignment's group, and the list is shuffled with <see cref="Random"/> seeded with <paramref name="seed"/> after being built in item, set and label order, so the same inputs and seed always give the same file.</para>
        /// </summary>
        /// <param name="layaItems">The items whose states the samples carry.</param>
        /// <param name="layaLabelSets">The label sets asked.</param>
        /// <param name="layaLabelAssignments">The known labels.</param>
        /// <param name="seed">The seed of the shuffle.</param>
        /// <returns>The samples; empty when any argument is <c>null</c>.</returns>
        public static List<LayaTrainingSample> LayaTrainingSamples(IEnumerable<LayaItem>? layaItems, IEnumerable<LayaLabelSet>? layaLabelSets, IEnumerable<LayaLabelAssignment>? layaLabelAssignments, int seed)
        {
            if (layaItems == null || layaLabelSets == null || layaLabelAssignments == null)
            {
                return [];
            }

            List<LayaLabelAssignment> layaLabelAssignments_All = [.. layaLabelAssignments.OfType<LayaLabelAssignment>().Where(x => x.ItemId != null && x.LabelSetId != null && x.LabelId != null && x.Weight > 0)];

            List<LayaTrainingSample> result = [];
            foreach (LayaItem layaItem in layaItems.OfType<LayaItem>())
            {
                if (layaItem.Id == null)
                {
                    continue;
                }

                List<LayaLabelAssignment> layaLabelAssignments_Item = [.. layaLabelAssignments_All.Where(x => string.Equals(x.ItemId, layaItem.Id, StringComparison.Ordinal))];
                if (layaLabelAssignments_Item.Count == 0)
                {
                    continue;
                }

                foreach (LayaLabelSet layaLabelSet in layaLabelSets.OfType<LayaLabelSet>())
                {
                    List<LayaQuestion> layaQuestions = LayaQuestions(layaLabelSet);
                    if (layaQuestions.Count == 0)
                    {
                        continue;
                    }

                    HashSet<string> labelIds = new((layaLabelSet.Labels?.OfType<LayaLabel>() ?? []).Select(x => x.Id).OfType<string>(), StringComparer.Ordinal);
                    List<LayaLabelAssignment> layaLabelAssignments_Set = [.. layaLabelAssignments_Item.Where(x => string.Equals(x.LabelSetId, layaLabelSet.Id, StringComparison.Ordinal) && labelIds.Contains(x.LabelId!))];

                    if (layaLabelSet.Kind == LayaLabelSetKind.SingleChoice)
                    {
                        LayaLabelAssignment? layaLabelAssignment = layaLabelAssignments_Set.FirstOrDefault(x => x.Truth);
                        if (layaLabelAssignment != null)
                        {
                            LayaQuestion layaQuestion = layaQuestions[0];
                            result.Add(new LayaTrainingSample(string.Concat(layaItem.Id, "|", layaQuestion.Name), layaItem.State, layaItem.StateIsJson, layaQuestion, layaLabelAssignment.LabelId, null, null, null, layaLabelAssignment.Group));
                        }

                        continue;
                    }

                    foreach (LayaQuestion layaQuestion in layaQuestions)
                    {
                        LayaLabelAssignment? layaLabelAssignment = layaLabelAssignments_Set.FirstOrDefault(x => string.Equals(Query.LayaQuestionName(x.LabelSetId, x.LabelId), layaQuestion.Name, StringComparison.Ordinal));
                        if (layaLabelAssignment == null)
                        {
                            continue;
                        }

                        double? probability = layaLabelAssignment.Weight >= 1 ? null : layaLabelAssignment.Truth ? 0.5 + (0.5 * layaLabelAssignment.Weight) : 0.5 - (0.5 * layaLabelAssignment.Weight);
                        result.Add(new LayaTrainingSample(string.Concat(layaItem.Id, "|", layaQuestion.Name), layaItem.State, layaItem.StateIsJson, layaQuestion, null, null, layaLabelAssignment.Truth, probability, layaLabelAssignment.Group));
                    }
                }
            }

            Random random = new(seed);
            for (int i = result.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (result[i], result[j]) = (result[j], result[i]);
            }

            return result;
        }
    }
}
