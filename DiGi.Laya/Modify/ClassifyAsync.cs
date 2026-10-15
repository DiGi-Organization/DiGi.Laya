using DiGi.Laya.Classes;
using DiGi.Laya.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.Laya
{
    public static partial class Modify
    {
        /// <summary>
        /// Classifies items against closed label sets with a local Laya checkpoint: requests, one prediction run, scores and suggestions, then constraints.
        /// <para>The label sets are checked first, and a set Laya cannot be asked refuses the whole run before a process starts: a blank, repeated or colon-holding set id; a set without labels; a blank or repeated label id; a multi-label label without a statement (its own instructions or the set's); a single-choice set with more than 100 labels, which Laya refuses. Every item then gets a result with no scores and the reasons. A single-choice set with more than 20 labels is run, with a warning on every result, because Laya's accuracy drops sharply past that.</para>
        /// <para>Otherwise the requests of <see cref="Create.LayaRequests(IEnumerable{LayaItem}?, IEnumerable{LayaLabelSet}?)"/> are answered by one <see cref="PredictAsync(IEnumerable{LayaRequest}?, LayaPredictionOptions?, CancellationToken)"/>, scored by <see cref="Query.LayaClassificationResults(LayaPredictionResult?, IEnumerable{LayaLabelSet}?, LayaClassificationOptions?)"/>, and constrained by <see cref="ApplyConstraints(LayaClassificationResult?, IEnumerable{LayaLabelConstraint}?)"/>. An item without a response still gets a result, with no scores and the prediction run's reasons: the run's messages that name the item (PredictAsync quotes a request id as its first quoted text) and those that name no item of the run. When the run was refused before a process started, every message concerns every item.</para>
        /// </summary>
        /// <param name="layaItems">The items to classify.</param>
        /// <param name="layaLabelSets">The label sets to decide for each item.</param>
        /// <param name="layaClassificationOptions">The decision rules, or <c>null</c> for the defaults.</param>
        /// <param name="layaPredictionOptions">The interpreter, checkpoint, device, working directory and limits of the run.</param>
        /// <param name="layaLabelConstraints">The constraints to apply to the results, or <c>null</c> for none.</param>
        /// <param name="cancellationToken">The token that cancels the run.</param>
        /// <returns>One result per item in item order, or <c>null</c> when the items, the label sets or the prediction options are <c>null</c>.</returns>
        public static async Task<List<LayaClassificationResult>?> ClassifyAsync(this IEnumerable<LayaItem>? layaItems, IEnumerable<LayaLabelSet>? layaLabelSets, LayaClassificationOptions? layaClassificationOptions, LayaPredictionOptions? layaPredictionOptions, IEnumerable<LayaLabelConstraint>? layaLabelConstraints = null, CancellationToken cancellationToken = default)
        {
            if (layaItems == null || layaLabelSets == null || layaPredictionOptions == null)
            {
                return null;
            }

            List<LayaItem> layaItems_All = [.. layaItems.OfType<LayaItem>()];
            List<LayaLabelSet> layaLabelSets_All = [.. layaLabelSets.OfType<LayaLabelSet>()];

            List<string> errors = [];
            List<string> warnings = [];
            HashSet<string> labelSetIds = new(StringComparer.Ordinal);
            foreach (LayaLabelSet layaLabelSet in layaLabelSets_All)
            {
                string? id = layaLabelSet.Id;
                if (string.IsNullOrWhiteSpace(id))
                {
                    errors.Add("A label set has no id.");
                    continue;
                }

                if (id!.IndexOf(':') >= 0)
                {
                    errors.Add(string.Format(CultureInfo.InvariantCulture, "The label set id '{0}' contains a colon, which separates set and label in a question name.", id));
                }

                if (!labelSetIds.Add(id))
                {
                    errors.Add(string.Format(CultureInfo.InvariantCulture, "The label set id '{0}' is used more than once.", id));
                }

                List<LayaLabel> layaLabels = [.. layaLabelSet.Labels?.OfType<LayaLabel>() ?? []];
                if (layaLabels.Count == 0)
                {
                    errors.Add(string.Format(CultureInfo.InvariantCulture, "The label set '{0}' has no labels.", id));
                    continue;
                }

                HashSet<string> labelIds = new(StringComparer.Ordinal);
                foreach (LayaLabel layaLabel in layaLabels)
                {
                    if (string.IsNullOrWhiteSpace(layaLabel.Id))
                    {
                        errors.Add(string.Format(CultureInfo.InvariantCulture, "A label of the label set '{0}' has no id.", id));
                    }
                    else if (!labelIds.Add(layaLabel.Id!))
                    {
                        errors.Add(string.Format(CultureInfo.InvariantCulture, "The label id '{1}' is used more than once in the label set '{0}'.", id, layaLabel.Id));
                    }

                    if (layaLabelSet.Kind == LayaLabelSetKind.MultiLabel && string.IsNullOrWhiteSpace(layaLabel.Instructions ?? layaLabelSet.Instructions))
                    {
                        errors.Add(string.Format(CultureInfo.InvariantCulture, "The label '{1}' of the label set '{0}' has no statement: neither the label nor the set has instructions.", id, layaLabel.Id));
                    }
                }

                if (layaLabelSet.Kind == LayaLabelSetKind.SingleChoice)
                {
                    if (layaLabels.Count > Constants.Count.ChoiceOptionMaximum)
                    {
                        errors.Add(string.Format(CultureInfo.InvariantCulture, "The single-choice label set '{0}' has {1} labels; Laya refuses more than {2} options in one question.", id, layaLabels.Count, Constants.Count.ChoiceOptionMaximum));
                    }
                    else if (layaLabels.Count > Constants.Count.ChoiceOptionWarning)
                    {
                        warnings.Add(string.Format(CultureInfo.InvariantCulture, "The single-choice label set '{0}' has {1} labels; Laya's accuracy drops sharply past {2} options in one question.", id, layaLabels.Count, Constants.Count.ChoiceOptionWarning));
                    }
                }
            }

            DateTimeOffset createdAt = DateTimeOffset.Now;

            if (errors.Count != 0)
            {
                return [.. layaItems_All.Select(x => new LayaClassificationResult(x.Id, [], null, createdAt, errors))];
            }

            List<LayaRequest> layaRequests = Create.LayaRequests(layaItems_All, layaLabelSets_All);
            LayaPredictionResult? layaPredictionResult = await layaRequests.PredictAsync(layaPredictionOptions, cancellationToken).ConfigureAwait(false);

            Dictionary<string, LayaClassificationResult> layaClassificationResults = new(StringComparer.Ordinal);
            foreach (LayaClassificationResult layaClassificationResult in Query.LayaClassificationResults(layaPredictionResult, layaLabelSets_All, layaClassificationOptions))
            {
                if (layaClassificationResult.ItemId != null && !layaClassificationResults.ContainsKey(layaClassificationResult.ItemId))
                {
                    layaClassificationResults[layaClassificationResult.ItemId] = layaClassificationResult;
                }
            }

            //The prediction run's messages, by the item they name; PredictAsync quotes the request id as the first quoted text of a message about a request
            HashSet<string> itemIds = new(layaItems_All.Select(x => x.Id).OfType<string>(), StringComparer.Ordinal);
            bool refused = layaPredictionResult?.Duration == null;
            Dictionary<string, List<string>> messages_ByItem = new(StringComparer.Ordinal);
            List<string> messages_Run = [];
            foreach (string message in layaPredictionResult?.Messages ?? [])
            {
                string? itemId = null;
                int start = message.IndexOf('\'');
                int end = start < 0 ? -1 : message.IndexOf('\'', start + 1);
                if (!refused && end > start)
                {
                    itemId = message.Substring(start + 1, end - start - 1);
                }

                if (itemId != null && itemIds.Contains(itemId))
                {
                    if (!messages_ByItem.TryGetValue(itemId, out List<string>? messages_Item))
                    {
                        messages_Item = [];
                        messages_ByItem[itemId] = messages_Item;
                    }

                    messages_Item.Add(message);
                }
                else
                {
                    messages_Run.Add(message);
                }
            }

            List<LayaClassificationResult> result = [];
            foreach (LayaItem layaItem in layaItems_All)
            {
                if (layaItem.Id != null && layaClassificationResults.TryGetValue(layaItem.Id, out LayaClassificationResult? layaClassificationResult))
                {
                    layaClassificationResult.Messages?.AddRange(warnings);
                    layaClassificationResult.ApplyConstraints(layaLabelConstraints);
                    result.Add(layaClassificationResult);
                    continue;
                }

                List<string> messages = [.. layaItem.Id != null && messages_ByItem.TryGetValue(layaItem.Id, out List<string>? messages_Item) ? messages_Item : []];
                messages.AddRange(messages_Run);
                messages.AddRange(warnings);
                if (messages.Count == 0)
                {
                    messages.Add("The item got no response.");
                }

                result.Add(new LayaClassificationResult(layaItem.Id, [], layaPredictionResult?.ModelSHA256, createdAt, messages));
            }

            return result;
        }
    }
}
