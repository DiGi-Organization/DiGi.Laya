using DiGi.Laya.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DiGi.Laya
{
    public static partial class Modify
    {
        /// <summary>
        /// Writes training samples to the JSONL file laya.train.finetune reads, one <see cref="Convert.ToLaya_TrainingLine(LayaTrainingSample?)"/> line per sample.
        /// <para>The file is UTF-8 without a byte order mark, with "\n" line ends, written through a temporary file beside it so a failed write never leaves a partial file at <paramref name="path"/>. A sample the converter refuses - a target that does not fit its question, no state, no question - is left out; compare the count returned with the number of samples to notice it. Training data belongs in a training directory outside the workspace, never in user files, which ships with every build.</para>
        /// </summary>
        /// <param name="layaTrainingSamples">The samples to write.</param>
        /// <param name="path">The path of the JSONL file, created or replaced; its directory is created when missing.</param>
        /// <returns>The number of lines written, or <c>null</c> when the samples or the path are <c>null</c> or the file could not be written.</returns>
        public static int? WriteTrainingFile(this IEnumerable<LayaTrainingSample>? layaTrainingSamples, string? path)
        {
            string? path_Full = Python.Query.NormalizedPath(path);
            if (layaTrainingSamples == null || path_Full == null)
            {
                return null;
            }

            StringBuilder stringBuilder = new();
            int count = 0;
            foreach (LayaTrainingSample layaTrainingSample in layaTrainingSamples)
            {
                string? line = layaTrainingSample.ToLaya_TrainingLine();
                if (line == null)
                {
                    continue;
                }

                stringBuilder.Append(line).Append('\n');
                count++;
            }

            string path_Temporary = string.Concat(path_Full, ".tmp");
            try
            {
                string? directory = Path.GetDirectoryName(path_Full);
                if (!string.IsNullOrEmpty(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.WriteAllText(path_Temporary, stringBuilder.ToString(), new UTF8Encoding(false));
                if (File.Exists(path_Full))
                {
                    File.Delete(path_Full);
                }

                File.Move(path_Temporary, path_Full);
            }
            catch (Exception exception) when (exception is IOException || exception is UnauthorizedAccessException)
            {
                return null;
            }

            return count;
        }
    }
}
