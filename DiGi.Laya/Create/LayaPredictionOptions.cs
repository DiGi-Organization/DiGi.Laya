using DiGi.Laya.Enums;

namespace DiGi.Laya
{
    public static partial class Create
    {
        /// <summary>
        /// Creates the settings of a Laya prediction run with the interpreter and the checkpoint directory resolved.
        /// <para>The interpreter is resolved by <see cref="Query.LayaPythonPath(string?)"/> (a <c>null</c> path searches PATH) and the checkpoint by <see cref="Query.LayaModelPath(string?)"/>, the same way the preflight and the run resolve them, so options made here name the files those will use. The constructors of <see cref="Classes.LayaPredictionOptions"/> do neither.</para>
        /// </summary>
        /// <param name="pythonPath">The path of the CPython interpreter, the name of one on PATH, or <c>null</c> to search PATH.</param>
        /// <param name="modelPath">The checkpoint directory.</param>
        /// <param name="workingDirectory">The working directory of the run, or <c>null</c> for a temporary one.</param>
        /// <param name="layaDevice">The device the model runs on.</param>
        /// <returns>The settings, or <c>null</c> when no interpreter is found or <paramref name="modelPath"/> is not a checkpoint directory.</returns>
        public static Classes.LayaPredictionOptions? LayaPredictionOptions(string? pythonPath, string? modelPath, string? workingDirectory = null, LayaDevice layaDevice = LayaDevice.Auto)
        {
            string? pythonPath_Resolved = Query.LayaPythonPath(pythonPath);
            if (pythonPath_Resolved == null)
            {
                return null;
            }

            string? modelPath_Resolved = Query.LayaModelPath(modelPath);
            if (modelPath_Resolved == null)
            {
                return null;
            }

            return new Classes.LayaPredictionOptions()
            {
                Device = layaDevice,
                ModelPath = modelPath_Resolved,
                PythonPath = pythonPath_Resolved,
                WorkingDirectory = Python.Query.NormalizedPath(workingDirectory)
            };
        }
    }
}
