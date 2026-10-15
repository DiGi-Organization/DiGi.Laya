namespace DiGi.Laya.Enums
{
    /// <summary>
    /// Specifies what a <see cref="Classes.LayaLabelConstraint"/> does to the score of the label it names.
    /// </summary>
    public enum LayaConstraintEffect
    {
        /// <summary>
        /// The label must not be suggested for the item: the score is marked forbidden with the constraint's reason, is no longer suggested, and keeps its probability.
        /// </summary>
        Forbid
    }
}
