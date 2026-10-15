namespace DiGi.Laya.Enums
{
    /// <summary>
    /// Specifies the device the Laya scripts run the model on, passed to them as --device.
    /// </summary>
    public enum LayaDevice
    {
        /// <summary>
        /// Laya chooses: CUDA, then Apple MPS, then Intel XPU, then the CPU.
        /// </summary>
        Auto,

        /// <summary>
        /// The CPU, whatever accelerator the machine has.
        /// </summary>
        Cpu,

        /// <summary>
        /// CUDA device 0; the scripts refuse to run when torch reports no CUDA device.
        /// </summary>
        Cuda
    }
}
