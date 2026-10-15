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
        /// <para>The label sets are checked first, and a set Laya cannot be asked refuses the whole run before a process starts: a blank, repeated or colon-holding set id; a set without labels; a blank or repeated label id; a multi-label label without a statement (its own instructions or the set's); a single-choice set with more than 100 labels, which Laya refuses. The run result then holds the reasons in <see cref="LayaClassificationRunResult.Messages"/>, an <see cref="LayaClassificationRunResult.ExitCode"/> of -1 and no item results. A single-choice set with more than 20 labels is run, with a run-level warning, because Laya's accuracy drops sharply past that. A label-level rule of <see cref="LayaClassificationOptions.Thresholds"/> naming a set or label the label sets do not hold is also run, with a run-level warning, because the rule would silently never apply.</para>
        /// <para>Otherwise the requests of <see cref="Create.LayaRequests(IEnumerable{LayaItem}?, IEnumerable{LayaLabelSet}?)"/> are answered by one <see cref="PredictAsync(IEnumerable{LayaRequest}?, LayaPredictionOptions?, CancellationToken)"/>, scored by <see cref="Query.LayaClassificationResults(LayaPredictionResult?, IEnumerable{LayaLabelSet}?, LayaClassificationOptions?)"/>, and constrained by <see cref="ApplyConstraints(LayaClassificationResult?, IEnumerable{LayaLabelConstraint}?)"/>. The prediction run's status (<see cref="LayaPredictionResult.ExitCode"/>, <see cref="LayaPredictionResult.Stalled"/>, <see cref="LayaPredictionResult.TimedOut"/>, <see cref="LayaPredictionResult.Cancelled"/>, <see cref="LayaPredictionResult.Duration"/> and the SHA-256s) is carried onto the run result, so a caller tells a run that failed, was refused or ended on a limit from one that answered without reading message text.</para>
        /// <para>Messages are split by what they concern. The run result's <see cref="LayaClassificationRunResult.Messages"/> holds the label set warnings and the prediction run's findings that name no request (a refused run, the process exit, a time limit). An item without a response still gets a result, with no scores and only its own findings: those <see cref="LayaPredictionResult.RequestMessages"/> files under its id (left out, refused by laya, no response), or "The item got no response." when there are none, as after a failed run. An answered item's result holds the findings of <see cref="Query.LayaClassificationResults(LayaPredictionResult?, IEnumerable{LayaLabelSet}?, LayaClassificationOptions?)"/> (a missing answer, truncation).</para>
        /// </summary>
        /// <param name="layaItems">The items to classify.</param>
        /// <param name="layaLabelSets">The label sets to decide for each item.</param>
        /// <param name="layaClassificationOptions">The decision rules, or <c>null</c> for the defaults.</param>
        /// <param name="layaPredictionOptions">The interpreter, checkpoint, device, working directory and limits of the run.</param>
        /// <param name="layaLabelConstraints">The constraints to apply to the results, or <c>null</c> for none.</param>
        /// <param name="cancellationToken">The token that cancels the run.</param>
        /// <returns>The run result with one item result per item in item order, or <c>null</c> when the items, the label sets or the prediction options are <c>null</c>.</returns>
        public static async Task<LayaClassificationRunResult?> ClassifyAsync(this IEnumerable<LayaItem>? layaItems, IEnumerable<LayaLabelSet>? layaLabelSets, LayaClassificationOptions? layaClassificationOptions, LayaPredictionOptions? layaPredictionOptions, IEnumerable<LayaLabelConstraint>? layaLabelConstraints = null, CancellationToken cancellationToken = default)
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

            foreach (LayaLabelSetThreshold layaLabelSetThreshold in layaClassificationOptions?.Thresholds?.OfType<LayaLabelSetThreshold>() ?? [])
            {
                if (layaLabelSetThreshold.LabelId == null)
                {
                    continue;
                }

                LayaLabelSet? layaLabelSet = layaLabelSets_All.Find(x => string.Equals(x.Id, layaLabelSetThreshold.LabelSetId, StringComparison.Ordinal));
                if (layaLabelSet == null)
                {
                    warnings.Add(string.Format(CultureInfo.InvariantCulture, "The threshold for the label '{1}' names the label set '{0}', which is not among the label sets, so it never applies.", layaLabelSetThreshold.LabelSetId, layaLabelSetThreshold.LabelId));
                }
                else if (!(layaLabelSet.Labels?.OfType<LayaLabel>() ?? []).Any(x => string.Equals(x.Id, layaLabelSetThreshold.LabelId, StringComparison.Ordinal)))
                {
                    warnings.Add(string.Format(CultureInfo.InvariantCulture, "The threshold for the label '{1}' names a label that the label set '{0}' does not hold, so it never applies.", layaLabelSetThreshold.LabelSetId, layaLabelSetThreshold.LabelId));
                }
            }

            DateTimeOffset createdAt = DateTimeOffset.Now;

            if (errors.Count != 0)
            {
                return new LayaClassificationRunResult([], null, null, null, -1, false, false, false, [.. errors, .. warnings]);
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

            //The prediction run's findings about one request, by request id; every other finding of the run is run-level
            Dictionary<string, List<string>> messages_ByItem = new(StringComparer.Ordinal);
            Dictionary<string, int> counts_RequestMessage = new(StringComparer.Ordinal);
            foreach (LayaRequestMessage layaRequestMessage in layaPredictionResult?.RequestMessages?.OfType<LayaRequestMessage>() ?? [])
            {
                if (layaRequestMessage.RequestId == null || layaRequestMessage.Message == null)
                {
                    continue;
                }

                if (!messages_ByItem.TryGetValue(layaRequestMessage.RequestId, out List<string>? messages_Item))
                {
                    messages_Item = [];
                    messages_ByItem[layaRequestMessage.RequestId] = messages_Item;
                }

                messages_Item.Add(layaRequestMessage.Message);
                counts_RequestMessage[layaRequestMessage.Message] = counts_RequestMessage.TryGetValue(layaRequestMessage.Message, out int count) ? count + 1 : 1;
            }

            List<string> messages_Run = [.. warnings];
            foreach (string message in layaPredictionResult?.Messages ?? [])
            {
                if (counts_RequestMessage.TryGetValue(message, out int count) && count > 0)
                {
                    counts_RequestMessage[message] = count - 1;
                    continue;
                }

                messages_Run.Add(message);
            }

            List<LayaClassificationResult> layaClassificationResults_Items = [];
            foreach (LayaItem layaItem in layaItems_All)
            {
                if (layaItem.Id != null && layaClassificationResults.TryGetValue(layaItem.Id, out LayaClassificationResult? layaClassificationResult))
                {
                    layaClassificationResult.ApplyConstraints(layaLabelConstraints);
                    layaClassificationResults_Items.Add(layaClassificationResult);
                    continue;
                }

                List<string> messages = [.. layaItem.Id != null && messages_ByItem.TryGetValue(layaItem.Id, out List<string>? messages_Item) ? messages_Item : []];
                if (messages.Count == 0)
                {
                    messages.Add("The item got no response.");
                }

                layaClassificationResults_Items.Add(new LayaClassificationResult(layaItem.Id, [], layaPredictionResult?.ModelSHA256, createdAt, messages));
            }

            if (layaPredictionResult == null)
            {
                return new LayaClassificationRunResult(layaClassificationResults_Items, null, null, null, -1, false, false, false, messages_Run);
            }

            return new LayaClassificationRunResult(layaClassificationResults_Items, layaPredictionResult.ModelSHA256, layaPredictionResult.CalibrationSHA256, layaPredictionResult.Duration, layaPredictionResult.ExitCode, layaPredictionResult.Stalled, layaPredictionResult.TimedOut, layaPredictionResult.Cancelled, messages_Run);
        }
    }
}
