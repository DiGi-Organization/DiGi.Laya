using DiGi.Laya.Classes;
using DiGi.Laya.Enums;
using System;
using System.Collections.Generic;

namespace DiGi.Laya
{
    public static partial class Modify
    {
        /// <summary>
        /// Applies the constraints of an item to its classification result.
        /// <para>A <see cref="LayaConstraintEffect.Forbid"/> constraint whose item, label set and label match a score replaces that score with one that is forbidden, not suggested, carries the constraint's reason and keeps its probability, so the model's view stays visible beside the rule that overrode it. The first constraint on a label wins; a label already forbidden keeps its reason. Constraints of other items, and those naming a label the result has no score for, are ignored.</para>
        /// <para>Forbidding a suggested label of a single-choice set does not promote the next label: the set then has one suggestion fewer, which is the honest answer when the most probable label is ruled out from outside the model.</para>
        /// </summary>
        /// <param name="layaClassificationResult">The result to change.</param>
        /// <param name="layaLabelConstraints">The constraints to apply; any item's may be passed.</param>
        /// <returns><c>true</c> when at least one score was forbidden; otherwise <c>false</c>.</returns>
        public static bool ApplyConstraints(this LayaClassificationResult? layaClassificationResult, IEnumerable<LayaLabelConstraint>? layaLabelConstraints)
        {
            List<LayaLabelScore>? layaLabelScores = layaClassificationResult?.Scores;
            if (layaLabelScores == null || layaLabelConstraints == null)
            {
                return false;
            }

            bool result = false;
            foreach (LayaLabelConstraint layaLabelConstraint in layaLabelConstraints)
            {
                if (layaLabelConstraint == null || layaLabelConstraint.Effect != LayaConstraintEffect.Forbid || !string.Equals(layaLabelConstraint.ItemId, layaClassificationResult!.ItemId, StringComparison.Ordinal))
                {
                    continue;
                }

                for (int i = 0; i < layaLabelScores.Count; i++)
                {
                    LayaLabelScore layaLabelScore = layaLabelScores[i];
                    if (layaLabelScore == null || layaLabelScore.IsForbidden || !string.Equals(layaLabelScore.LabelSetId, layaLabelConstraint.LabelSetId, StringComparison.Ordinal) || !string.Equals(layaLabelScore.LabelId, layaLabelConstraint.LabelId, StringComparison.Ordinal))
                    {
                        continue;
                    }

                    layaLabelScores[i] = new LayaLabelScore(layaLabelScore.LabelSetId, layaLabelScore.LabelId, layaLabelScore.Probability, false, true, layaLabelConstraint.Reason);
                    result = true;
                }
            }

            return result;
        }
    }
}
