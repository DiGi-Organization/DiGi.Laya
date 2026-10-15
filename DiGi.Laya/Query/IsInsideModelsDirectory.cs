using System;
using System.IO;

namespace DiGi.Laya
{
    public static partial class Query
    {
        /// <summary>
        /// Checks whether a path is a Laya\models or DiGi.Laya\models folder, or lies anywhere inside one - where deployed checkpoints live, which no training run may write into.
        /// <para>The path is made absolute first and compared with a trailing separator, case-insensitively, so "...\Laya\models" itself and "...\laya\MODELS\run" both count while a sibling such as "...\Laya\models_old" does not. Both folder names are guarded: Laya\models (<see cref="Constants.DirectoryName.Laya"/>) and DiGi.Laya\models (<see cref="Constants.DirectoryName.DiGiLaya"/>), the software destination DiGi.Maintenance's DeployLaya.ps1 deploys checkpoints to - a match on the Laya segment alone misses the latter, whose "Laya" follows a dot rather than a separator. The same guard as DiGi.YOLO's for YOLO\models: a training output written where a deploy reads ships an untested checkpoint.</para>
        /// <para>A relative path is resolved against the current directory of the calling process. A null, blank or unformable path returns <c>false</c>: it names no folder, and every caller refuses such a path for its own reason.</para>
        /// </summary>
        /// <param name="path">The directory path to check.</param>
        /// <returns><c>true</c> when the path is, or lies inside, a Laya\models or DiGi.Laya\models folder; otherwise <c>false</c>.</returns>
        public static bool IsInsideModelsDirectory(string? path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            string path_Full;
            try
            {
                path_Full = Path.GetFullPath(path!);
            }
            catch
            {
                return false;
            }

            string path_Compared = string.Concat(path_Full.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar), Path.DirectorySeparatorChar);

            foreach (string directoryName in new string[] { Constants.DirectoryName.Laya, Constants.DirectoryName.DiGiLaya })
            {
                string segment = string.Concat(Path.DirectorySeparatorChar, directoryName, Path.DirectorySeparatorChar, Constants.DirectoryName.Models, Path.DirectorySeparatorChar);
                if (path_Compared.IndexOf(segment, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
