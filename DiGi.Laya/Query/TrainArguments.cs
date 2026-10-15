using DiGi.Laya.Enums;
using System.Text;

namespace DiGi.Laya
{
    public static partial class Query
    {
        /// <summary>
        /// Builds the command line train.py is run with: <c>"&lt;script&gt;" --base "&lt;dir&gt;" --data "&lt;file&gt;" --output "&lt;dir&gt;" --config "&lt;file&gt;" --device &lt;device&gt;</c>.
        /// <para>Every path is quoted by <see cref="QuotedArgument(string?)"/>; the device is written lower-case as the scripts expect.</para>
        /// </summary>
        /// <param name="scriptPath">The path of train.py.</param>
        /// <param name="baseModelPath">The base checkpoint directory, already resolved by <see cref="LayaModelPath(string?)"/>.</param>
        /// <param name="trainingFilePath">The training JSONL.</param>
        /// <param name="outputDirectory">The directory the new checkpoint is written to.</param>
        /// <param name="configurationPath">The train_config.json of TrainConfig fields.</param>
        /// <param name="layaDevice">The device to train on.</param>
        /// <returns>The command line, or <c>null</c> when a path is blank.</returns>
        public static string? TrainArguments(string? scriptPath, string? baseModelPath, string? trainingFilePath, string? outputDirectory, string? configurationPath, LayaDevice layaDevice)
        {
            if (string.IsNullOrWhiteSpace(scriptPath) || string.IsNullOrWhiteSpace(baseModelPath) || string.IsNullOrWhiteSpace(trainingFilePath) || string.IsNullOrWhiteSpace(outputDirectory) || string.IsNullOrWhiteSpace(configurationPath))
            {
                return null;
            }

            StringBuilder stringBuilder = new();
            stringBuilder.Append(QuotedArgument(scriptPath));
            stringBuilder.Append(" --base ").Append(QuotedArgument(baseModelPath));
            stringBuilder.Append(" --data ").Append(QuotedArgument(trainingFilePath));
            stringBuilder.Append(" --output ").Append(QuotedArgument(outputDirectory));
            stringBuilder.Append(" --config ").Append(QuotedArgument(configurationPath));
            stringBuilder.Append(" --device ").Append(layaDevice.ToString().ToLowerInvariant());

            return stringBuilder.ToString();
        }
    }
}
