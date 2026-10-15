namespace DiGi.Laya.Enums
{
    /// <summary>
    /// Specifies the training objective of a fine-tuning run, passed to laya.train.TrainConfig as loss.
    /// </summary>
    public enum LayaLoss
    {
        /// <summary>
        /// laya's default, currently <see cref="Rlcd"/>.
        /// </summary>
        Default,

        /// <summary>
        /// The objective of the published fine-tuning notebook ("rlcd").
        /// </summary>
        Rlcd,

        /// <summary>
        /// The soft cross-entropy alone ("soft-ce"); scored slightly higher than rlcd on laya's typed-decisions benchmark.
        /// </summary>
        SoftCrossEntropy
    }
}
