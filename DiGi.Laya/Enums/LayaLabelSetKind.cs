namespace DiGi.Laya.Enums
{
    /// <summary>
    /// Specifies how the labels of a <see cref="Classes.LayaLabelSet"/> are asked of Laya and decided.
    /// </summary>
    public enum LayaLabelSetKind
    {
        /// <summary>
        /// Exactly one label applies: the set is one choice question named after the set, its labels the options; the labels with the highest probabilities are suggested.
        /// </summary>
        SingleChoice,

        /// <summary>
        /// Any number of labels apply: each label is its own noul question named "&lt;set id&gt;:&lt;label id&gt;"; a label is suggested when its probability reaches the threshold.
        /// </summary>
        MultiLabel
    }
}
