namespace DiGi.Laya.Enums
{
    /// <summary>
    /// Specifies the type of a question asked of the Laya decision model, which decides the shape of its answer.
    /// </summary>
    public enum LayaQuestionType
    {
        /// <summary>
        /// A closed choice between labelled options, answered with the selected label and a probability per option.
        /// </summary>
        Choice,

        /// <summary>
        /// An ordered scale of levels, answered with the expected level and a probability per level.
        /// </summary>
        Score,

        /// <summary>
        /// A statement judged true or false, answered with the probability that it is true.
        /// </summary>
        Noul
    }
}
