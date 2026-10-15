using DiGi.Laya.Classes;
using System.Collections.Generic;
using System.Linq;

namespace DiGi.Laya
{
    public static partial class Create
    {
        /// <summary>
        /// Creates one Laya request per item that asks every label set about the item's state.
        /// <para>The questions of each set come from <see cref="LayaQuestions(LayaLabelSet?)"/>: a single-choice set is one choice question named after the set, each label of a multi-label set one noul question named "&lt;set id&gt;:&lt;label id&gt;". Every request carries the same questions in set order, so predict.py answers all items in one group.</para>
        /// <para>Pure and permissive: <c>null</c> items, sets and labels and sets without labels are skipped, and nothing is validated - a request the converter would refuse is reported by <see cref="Modify.PredictAsync(IEnumerable{LayaRequest}?, LayaPredictionOptions?, System.Threading.CancellationToken)"/>, and <see cref="Modify.ClassifyAsync(IEnumerable{LayaItem}?, IEnumerable{LayaLabelSet}?, LayaClassificationOptions?, LayaPredictionOptions?, IEnumerable{LayaLabelConstraint}?, System.Threading.CancellationToken)"/> checks the label sets before it calls this. The token budgets are left to the prediction options.</para>
        /// </summary>
        /// <param name="layaItems">The items to classify.</param>
        /// <param name="layaLabelSets">The label sets to ask about each item.</param>
        /// <returns>The requests, one per item in item order; empty when either argument is <c>null</c>.</returns>
        public static List<LayaRequest> LayaRequests(IEnumerable<LayaItem>? layaItems, IEnumerable<LayaLabelSet>? layaLabelSets)
        {
            if (layaItems == null || layaLabelSets == null)
            {
                return [];
            }

            List<LayaQuestion> layaQuestions = [.. layaLabelSets.SelectMany(LayaQuestions)];

            List<LayaRequest> result = [];
            foreach (LayaItem layaItem in layaItems.OfType<LayaItem>())
            {
                result.Add(new LayaRequest(layaItem.Id, layaItem.State, layaItem.StateIsJson, layaQuestions, null, null));
            }

            return result;
        }
    }
}
