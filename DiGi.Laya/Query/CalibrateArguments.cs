using DiGi.Laya.Enums;
using System.Globalization;
using System.Text;

namespace DiGi.Laya
{
    public static partial class Query
    {
        /// <summary>
        /// Builds the command line calibrate.py is run with: <c>"&lt;script&gt;" --model "&lt;dir&gt;" --data "&lt;file&gt;" --output "&lt;file&gt;" --device &lt;device&gt; --seed &lt;n&gt;</c>.
        /// <para>Every path is quoted by <see cref="QuotedArgument(string?)"/>; the seed is written with <see cref="CultureInfo.InvariantCulture"/>; the device is written lower-case as the scripts expect.</para>
        /// </summary>
        /// <param name="scriptPath">The path of calibrate.py.</param>
        /// <param name="modelPath">The checkpoint directory, already resolved by <see cref="LayaModelPath(string?)"/>.</param>
        /// <param name="calibrationFilePath">The labelled JSONL the temperatures are fitted on.</param>
        /// <param name="calibrationPath">The calibration JSON to write.</param>
        /// <param name="layaDevice">The device to run on.</param>
        /// <param name="seed">The seed of laya's held-out split.</param>
        /// <returns>The command line, or <c>null</c> when a path is blank.</returns>
        public static string? CalibrateArguments(string? scriptPath, string? modelPath, string? calibrationFilePath, string? calibrationPath, LayaDevice layaDevice, int seed)
        {
            if (string.IsNullOrWhiteSpace(scriptPath) || string.IsNullOrWhiteSpace(modelPath) || string.IsNullOrWhiteSpace(calibrationFilePath) || string.IsNullOrWhiteSpace(calibrationPath))
            {
                return null;
            }

            StringBuilder stringBuilder = new();
            stringBuilder.Append(QuotedArgument(scriptPath));
            stringBuilder.Append(" --model ").Append(QuotedArgument(modelPath));
            stringBuilder.Append(" --data ").Append(QuotedArgument(calibrationFilePath));
            stringBuilder.Append(" --output ").Append(QuotedArgument(calibrationPath));
            stringBuilder.Append(" --device ").Append(layaDevice.ToString().ToLowerInvariant());
            stringBuilder.Append(" --seed ").Append(seed.ToString(CultureInfo.InvariantCulture));

            return stringBuilder.ToString();
        }
    }
}
