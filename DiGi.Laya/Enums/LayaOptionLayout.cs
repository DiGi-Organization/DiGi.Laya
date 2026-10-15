namespace DiGi.Laya.Enums
{
    /// <summary>
    /// Specifies how the options of a question are laid out for the model, passed to laya.train.TrainConfig as option_layout.
    /// </summary>
    public enum LayaOptionLayout
    {
        /// <summary>
        /// The base checkpoint's own layout, sequential for every published checkpoint.
        /// </summary>
        Default,

        /// <summary>
        /// The options one after another ("sequential").
        /// </summary>
        Sequential,

        /// <summary>
        /// The options side by side ("parallel"); needs transformers 5 or later, and the ONNX runtime refuses such a checkpoint.
        /// </summary>
        Parallel
    }
}
