using System;
using System.Collections.Generic;
using System.Threading;

namespace DiGi.Laya
{
    public static partial class Query
    {
        /// <summary>
        /// Runs one Laya script in a CPython process, offline, with an optional inactivity limit and an optional overall time limit.
        /// <para>The process gets HF_HUB_OFFLINE=1 and TRANSFORMERS_OFFLINE=1, so laya, transformers and huggingface_hub never download (DiGi-Organization/DiGi.Laya#1, D4); PYTHONIOENCODING=utf-8, matching the UTF-8 the output streams are decoded with; PYTHONUNBUFFERED=1, so progress lines reach the inactivity limit as they are printed rather than when a buffer fills; and PYTHONDONTWRITEBYTECODE=1, so no __pycache__ is left in the working directory.</para>
        /// <para>DiGi.Python's <c>ExecuteProcess</c> has an inactivity limit and cancellation but no overall limit, so <paramref name="timeout"/> is a token linked to <paramref name="cancellationToken"/> that cancels after it. Either way the result has <c>Cancelled</c> set; the run timed out exactly when <c>Cancelled</c> is set and <paramref name="cancellationToken"/> was not cancelled. Ending a run kills the interpreter together with every process it started.</para>
        /// </summary>
        /// <param name="pythonPath">The full path of the interpreter.</param>
        /// <param name="arguments">The command line: the quoted script path followed by its arguments.</param>
        /// <param name="workingDirectory">The directory the process runs in.</param>
        /// <param name="inactivityTimeout">The span without output after which the process is ended, or <c>null</c> for no limit.</param>
        /// <param name="timeout">The span after which the process is ended whatever it is doing, or <c>null</c> for no limit. A value that is not positive is no limit either.</param>
        /// <param name="cancellationToken">The token that cancels the run.</param>
        /// <returns>The exit code (-1 when the process was ended or failed to start), the trailing lines of both output streams, and whether it was ended for inactivity or cancelled.</returns>
        public static Python.Classes.PythonProcessResult PythonProcessResult(string pythonPath, string arguments, string workingDirectory, TimeSpan? inactivityTimeout, TimeSpan? timeout, CancellationToken cancellationToken = default)
        {
            Dictionary<string, string> environmentVariables = new()
            {
                ["HF_HUB_OFFLINE"] = "1",
                ["TRANSFORMERS_OFFLINE"] = "1",
                ["HF_HUB_DISABLE_TELEMETRY"] = "1",
                ["PYTHONIOENCODING"] = "utf-8",
                ["PYTHONUNBUFFERED"] = "1",
                ["PYTHONDONTWRITEBYTECODE"] = "1"
            };

            using CancellationTokenSource cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            if (timeout != null && timeout.Value > TimeSpan.Zero)
            {
                cancellationTokenSource.CancelAfter(timeout.Value);
            }

            return Python.Query.ExecuteProcess(pythonPath, arguments, workingDirectory, environmentVariables, inactivityTimeout, cancellationToken: cancellationTokenSource.Token);
        }
    }
}
