using System;
using System.IO;

namespace DiGi.Laya
{
    public static partial class Query
    {
        /// <summary>
        /// Resolves the configured CPython interpreter the Laya scripts run with, accepting only the interpreter that was configured.
        /// <para>A blank value searches PATH for "python", then "python3", through DiGi.Python's <c>Query.PythonPath</c>. A path (rooted, or holding a directory separator) must name an existing file. A bare name is searched for on PATH and accepted only when the match carries that name.</para>
        /// <para>DiGi.Python's <c>Query.PythonPath</c> falls back to any "python" on PATH when the given value is not found, which for a configured interpreter means a mistyped path silently runs a different Python - one that usually lacks laya, so the run fails on an import nothing on the command line explains. Laya options name a specific environment, so a value that does not resolve as given is refused instead.</para>
        /// </summary>
        /// <param name="pythonPath">The configured interpreter: a path, a name on PATH, or <c>null</c> to search PATH.</param>
        /// <returns>The full path of the interpreter, or <c>null</c> when it was not found as configured.</returns>
        public static string? LayaPythonPath(string? pythonPath)
        {
            if (string.IsNullOrWhiteSpace(pythonPath))
            {
                return Python.Query.PythonPath(null);
            }

            if (Path.IsPathRooted(pythonPath) || pythonPath!.IndexOfAny([Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar]) >= 0)
            {
                return File.Exists(pythonPath) ? Python.Query.NormalizedPath(pythonPath) : null;
            }

            string? path = Python.Query.PythonPath(pythonPath);
            if (path == null)
            {
                return null;
            }

            string name = Path.GetFileNameWithoutExtension(pythonPath);
            return string.Equals(Path.GetFileNameWithoutExtension(path), name, StringComparison.OrdinalIgnoreCase) || string.Equals(Path.GetFileName(path), pythonPath, StringComparison.OrdinalIgnoreCase) ? path : null;
        }
    }
}
