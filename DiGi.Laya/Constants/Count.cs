namespace DiGi.Laya.Constants
{
    /// <summary>
    /// Provides Laya's limits on the options of one choice question.
    /// </summary>
    public static class Count
    {
        /// <summary>
        /// The option count past which Laya's accuracy drops sharply in one choice question; a single-choice label set above it is classified with a warning.
        /// </summary>
        public const int ChoiceOptionWarning = 20;

        /// <summary>
        /// The most options Laya accepts in one choice question; a single-choice label set above it is refused.
        /// </summary>
        public const int ChoiceOptionMaximum = 100;
    }
}
