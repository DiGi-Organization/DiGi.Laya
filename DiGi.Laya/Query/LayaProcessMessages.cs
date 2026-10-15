using DiGi.Python.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DiGi.Laya
{
    public static partial class Query
    {
        /// <summary>
        /// Describes how a script run through <see cref="PythonProcessResult(string, string, string, TimeSpan?, TimeSpan?, System.Threading.CancellationToken)"/> ended, when it did not end well.
        /// <para>One line for the first that applies - cancelled by the caller, ended by the overall time limit, ended for inactivity, a non-zero exit code - followed, for any non-zero exit code, by the last ten lines of standard error, where a Python traceback ends. A run that exited with 0 gives no messages.</para>
        /// </summary>
        /// <param name="pythonProcessResult">The result of the run.</param>
        /// <param name="scriptName">The script that was run, named in the exit code message.</param>
        /// <param name="inactivityTimeout">The inactivity limit of the run, named in its message.</param>
        /// <param name="timeout">The overall limit of the run, named in its message.</param>
        /// <param name="cancelledByCaller">A value indicating whether the caller's token was cancelled, which tells a cancellation from a timeout.</param>
        /// <returns>The messages; empty when the run exited with 0 or <paramref name="pythonProcessResult"/> is <c>null</c>.</returns>
        public static List<string> LayaProcessMessages(PythonProcessResult? pythonProcessResult, string? scriptName, TimeSpan? inactivityTimeout, TimeSpan? timeout, bool cancelledByCaller)
        {
            List<string> result = [];
            if (pythonProcessResult == null || pythonProcessResult.ExitCode == 0)
            {
                return result;
            }

            if (pythonProcessResult.Cancelled && cancelledByCaller)
            {
                result.Add("The run was cancelled.");
            }
            else if (pythonProcessResult.Cancelled)
            {
                result.Add(string.Format(CultureInfo.InvariantCulture, "The run exceeded its time limit of {0} and was ended.", timeout));
            }
            else if (pythonProcessResult.Stalled)
            {
                result.Add(string.Format(CultureInfo.InvariantCulture, "The run printed nothing for {0} and was ended.", inactivityTimeout));
            }
            else
            {
                result.Add(string.Format(CultureInfo.InvariantCulture, "{0} exited with code {1}.", scriptName, pythonProcessResult.ExitCode));
            }

            List<string>? standardError = pythonProcessResult.StandardError;
            if (standardError != null)
            {
                result.AddRange(standardError.Skip(Math.Max(0, standardError.Count - 10)));
            }

            return result;
        }
    }
}
