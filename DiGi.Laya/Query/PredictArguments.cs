using DiGi.Laya.Enums;
using System.Globalization;
using System.Text;

namespace DiGi.Laya
{
    public static partial class Query
    {
        /// <summary>
        /// Builds the command line predict.py is run with: <c>"&lt;script&gt;" --model "&lt;dir&gt;" --input "&lt;file&gt;" --output "&lt;file&gt;" --device &lt;device&gt; --batch-size &lt;n&gt;</c>, followed by <c>--calibration "&lt;file&gt;"</c> when a calibration file is given.
        /// <para>Every path is quoted by <see cref="QuotedArgument(string?)"/>; numbers are written with <see cref="CultureInfo.InvariantCulture"/>; the device is written lower-case as the scripts expect.</para>
        /// </summary>
        /// <param name="scriptPath">The path of predict.py.</param>
        /// <param name="modelPath">The checkpoint directory, already resolved by <see cref="LayaModelPath(string?)"/>.</param>
        /// <param name="inputPath">The requests JSONL file.</param>
        /// <param name="outputPath">The responses JSONL file to write.</param>
        /// <param name="layaDevice">The device to run on.</param>
        /// <param name="batchSize">The number of states per forward pass.</param>
        /// <param name="calibrationPath">The calibration JSON written by calibrate.py, or <c>null</c> for the checkpoint's own temperatures.</param>
        /// <returns>The command line, or <c>null</c> when a path is blank or <paramref name="batchSize"/> is not positive.</returns>
        public static string? PredictArguments(string? scriptPath, string? modelPath, string? inputPath, string? outputPath, LayaDevice layaDevice, int batchSize, string? calibrationPath)
        {
            if (string.IsNullOrWhiteSpace(scriptPath) || string.IsNullOrWhiteSpace(modelPath) || string.IsNullOrWhiteSpace(inputPath) || string.IsNullOrWhiteSpace(outputPath) || batchSize < 1)
            {
                return null;
            }

            StringBuilder stringBuilder = new();
            stringBuilder.Append(QuotedArgument(scriptPath!));
            stringBuilder.Append(" --model ").Append(QuotedArgument(modelPath!));
            stringBuilder.Append(" --input ").Append(QuotedArgument(inputPath!));
            stringBuilder.Append(" --output ").Append(QuotedArgument(outputPath!));
            stringBuilder.Append(" --device ").Append(layaDevice.ToString().ToLowerInvariant());
            stringBuilder.Append(" --batch-size ").Append(batchSize.ToString(CultureInfo.InvariantCulture));

            if (!string.IsNullOrWhiteSpace(calibrationPath))
            {
                stringBuilder.Append(" --calibration ").Append(QuotedArgument(calibrationPath!));
            }

            return stringBuilder.ToString();
        }
    }
}
