using DiGi.Laya.Classes;
using DiGi.Laya.Enums;
using System.Collections.Generic;
using System.Linq;

namespace DiGi.Laya
{
    public static partial class Create
    {
        /// <summary>
        /// Creates the questions the classification workflow asks about one label set.
        /// <para>A single-choice set becomes one choice question named after the set, with the set's instructions and one option per label (the label id as the answer key, the label text as its description). Each label of a multi-label set becomes one noul question named "&lt;set id&gt;:&lt;label id&gt;" (<see cref="Query.LayaQuestionName(string?, string?)"/>) whose statement is the label's instructions, or else the set's, with every "{label}" replaced by the label text (the id when it has none).</para>
        /// <para>Inference (<see cref="LayaRequests(IEnumerable{LayaItem}?, IEnumerable{LayaLabelSet}?)"/>) and training (<see cref="LayaTrainingSamples(IEnumerable{LayaItem}?, IEnumerable{LayaLabelSet}?, IEnumerable{LayaLabelAssignment}?, int)"/>) both build their questions here, so a checkpoint is fine-tuned on exactly the questions it is later asked. Nothing is validated; <c>null</c> labels are skipped.</para>
        /// </summary>
        /// <param name="layaLabelSet">The label set.</param>
        /// <returns>The questions in label order; empty when the set is <c>null</c> or has no labels.</returns>
        public static List<LayaQuestion> LayaQuestions(LayaLabelSet? layaLabelSet)
        {
            List<LayaLabel> layaLabels = [.. layaLabelSet?.Labels?.OfType<LayaLabel>() ?? []];
            if (layaLabelSet == null || layaLabels.Count == 0)
            {
                return [];
            }

            if (layaLabelSet.Kind == LayaLabelSetKind.SingleChoice)
            {
                return [new LayaChoiceQuestion(Query.LayaQuestionName(layaLabelSet.Id, null), layaLabelSet.Instructions, layaLabels.Select(x => new LayaCriterion(x.Id, x.Text)))];
            }

            List<LayaQuestion> result = [];
            foreach (LayaLabel layaLabel in layaLabels)
            {
                string? template = layaLabel.Instructions ?? layaLabelSet.Instructions;
                result.Add(new LayaNoulQuestion(Query.LayaQuestionName(layaLabelSet.Id, layaLabel.Id), template?.Replace("{label}", layaLabel.Text ?? layaLabel.Id)));
            }

            return result;
        }
    }
}
