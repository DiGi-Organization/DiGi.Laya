using System;
using System.Collections.Generic;
using System.IO;

namespace DiGi.Laya
{
    public static partial class Query
    {
        /// <summary>
        /// Resolves a configured Laya checkpoint directory to the absolute directory the scripts are given, the way the preflight and every run resolve it.
        /// <para>The value is tried as given (a relative path against the current directory), then against the application base directory, then - for a value starting with "user files" - with that segment stripped, against the base directory and the current directory, since CopyUserFiles flattens user files into bin; any other relative value is also tried under "user files" of the current directory. The first candidate that is a directory holding rl_agent_config.json wins.</para>
        /// <para>No other value is accepted, deliberately: laya.load and laya.train.finetune treat a value that is not a checkpoint directory on disk as a model name or Hugging Face Hub id and download it, which a production run must never do (DiGi-Organization/DiGi.Laya#1, D4).</para>
        /// </summary>
        /// <param name="modelPath">The configured checkpoint directory.</param>
        /// <returns>The absolute checkpoint directory without a trailing separator, or <c>null</c> when no candidate is a directory holding rl_agent_config.json.</returns>
        public static string? LayaModelPath(string? modelPath)
        {
            if (string.IsNullOrWhiteSpace(modelPath))
            {
                return null;
            }

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string currentDirectory = Environment.CurrentDirectory;

            List<string> candidates = [modelPath!];
            if (!Path.IsPathRooted(modelPath))
            {
                candidates.Add(Path.Combine(baseDirectory, modelPath));

                string userFiles = "user files";
                if (modelPath!.StartsWith(userFiles + "/", StringComparison.OrdinalIgnoreCase) || modelPath.StartsWith(userFiles + "\\", StringComparison.OrdinalIgnoreCase))
                {
                    string stripped = modelPath.Substring(userFiles.Length + 1);
                    candidates.Add(Path.Combine(baseDirectory, stripped));
                    candidates.Add(Path.Combine(currentDirectory, stripped));
                }
                else
                {
                    candidates.Add(Path.Combine(currentDirectory, userFiles, modelPath));
                }
            }

            foreach (string candidate in candidates)
            {
                string? path = Python.Query.NormalizedPath(candidate);
                if (path != null && File.Exists(Path.Combine(path, Constants.FileName.CheckpointConfiguration)))
                {
                    return path;
                }
            }

            return null;
        }
    }
}
