using DiGi.Laya.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiGi.Laya
{
    public static partial class Query
    {
        /// <summary>
        /// Splits the items of a set of label assignments into folds for cross-validation: stratified by one label set, never splitting a group, and the same for the same seed.
        /// <para>Items are gathered into units: the items sharing a <see cref="LayaLabelAssignment.Group"/> (an item's first assignment that names one) form one unit, and every other item is a unit of its own, so a group always lands in one fold. A unit's stratum is the most frequent true label of its items in <paramref name="stratifyLabelSetId"/> (an item's first true assignment there; ties go to the ordinally first label), or no label. Units are sorted by key, the units of each stratum - strata in ordinal order - are shuffled with <see cref="Random"/> seeded with <paramref name="seed"/>, and each unit goes to the fold with the fewest units of its stratum so far, then the fewest items, then the lowest index. The seeded <see cref="Random"/> keeps its sequence across .NET versions, so the folds depend only on the assignments, their order and the seed.</para>
        /// </summary>
        /// <param name="layaLabelAssignments">The assignments whose items are split; an item is any <see cref="LayaLabelAssignment.ItemId"/> they name.</param>
        /// <param name="foldCount">The number of folds.</param>
        /// <param name="stratifyLabelSetId">The label set whose true labels the folds are balanced on, or <c>null</c> for no stratification.</param>
        /// <param name="seed">The seed of the shuffle.</param>
        /// <returns>The item ids of each fold, ordinally sorted within a fold; empty when there are no assignments or <paramref name="foldCount"/> is below 1.</returns>
        public static List<List<string>> LayaFolds(IEnumerable<LayaLabelAssignment>? layaLabelAssignments, int foldCount, string? stratifyLabelSetId, int seed)
        {
            if (layaLabelAssignments == null || foldCount < 1)
            {
                return [];
            }

            List<LayaLabelAssignment> layaLabelAssignments_All = [.. layaLabelAssignments.OfType<LayaLabelAssignment>().Where(x => !string.IsNullOrEmpty(x.ItemId))];
            if (layaLabelAssignments_All.Count == 0)
            {
                return [];
            }

            //The unit key of every item: its group, or the item itself, in two separate key spaces so a group can share a name with an item
            Dictionary<string, string> unitKeys = new(StringComparer.Ordinal);
            foreach (LayaLabelAssignment layaLabelAssignment in layaLabelAssignments_All)
            {
                if (!string.IsNullOrEmpty(layaLabelAssignment.Group) && !unitKeys.ContainsKey(layaLabelAssignment.ItemId!))
                {
                    unitKeys[layaLabelAssignment.ItemId!] = string.Concat("g:", layaLabelAssignment.Group);
                }
            }

            foreach (LayaLabelAssignment layaLabelAssignment in layaLabelAssignments_All)
            {
                if (!unitKeys.ContainsKey(layaLabelAssignment.ItemId!))
                {
                    unitKeys[layaLabelAssignment.ItemId!] = string.Concat("i:", layaLabelAssignment.ItemId);
                }
            }

            Dictionary<string, string> labelIds_ByItem = new(StringComparer.Ordinal);
            if (stratifyLabelSetId != null)
            {
                foreach (LayaLabelAssignment layaLabelAssignment in layaLabelAssignments_All)
                {
                    if (layaLabelAssignment.Truth && layaLabelAssignment.LabelId != null && string.Equals(layaLabelAssignment.LabelSetId, stratifyLabelSetId, StringComparison.Ordinal) && !labelIds_ByItem.ContainsKey(layaLabelAssignment.ItemId!))
                    {
                        labelIds_ByItem[layaLabelAssignment.ItemId!] = layaLabelAssignment.LabelId;
                    }
                }
            }

            List<(string Key, List<string> ItemIds, string Stratum)> units = [];
            foreach (IGrouping<string, string> grouping in unitKeys.Keys.GroupBy(x => unitKeys[x], StringComparer.Ordinal).OrderBy(x => x.Key, StringComparer.Ordinal))
            {
                List<string> itemIds = [.. grouping.OrderBy(x => x, StringComparer.Ordinal)];
                string stratum = itemIds.Where(labelIds_ByItem.ContainsKey).Select(x => labelIds_ByItem[x]).GroupBy(x => x, StringComparer.Ordinal).OrderByDescending(x => x.Count()).ThenBy(x => x.Key, StringComparer.Ordinal).Select(x => x.Key).FirstOrDefault() ?? string.Empty;
                units.Add((grouping.Key, itemIds, stratum));
            }

            List<List<string>> result = [];
            for (int i = 0; i < foldCount; i++)
            {
                result.Add([]);
            }

            Random random = new(seed);
            foreach (IGrouping<string, (string Key, List<string> ItemIds, string Stratum)> grouping in units.GroupBy(x => x.Stratum, StringComparer.Ordinal).OrderBy(x => x.Key, StringComparer.Ordinal))
            {
                List<(string Key, List<string> ItemIds, string Stratum)> units_Stratum = [.. grouping];
                for (int i = units_Stratum.Count - 1; i > 0; i--)
                {
                    int j = random.Next(i + 1);
                    (units_Stratum[i], units_Stratum[j]) = (units_Stratum[j], units_Stratum[i]);
                }

                int[] counts_Stratum = new int[foldCount];
                foreach ((string _, List<string> itemIds, string _) in units_Stratum)
                {
                    int index = Enumerable.Range(0, foldCount).OrderBy(x => counts_Stratum[x]).ThenBy(x => result[x].Count).ThenBy(x => x).First();
                    counts_Stratum[index]++;
                    result[index].AddRange(itemIds);
                }
            }

            foreach (List<string> itemIds in result)
            {
                itemIds.Sort(StringComparer.Ordinal);
            }

            return result;
        }
    }
}
