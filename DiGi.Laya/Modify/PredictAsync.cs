using DiGi.Laya.Classes;
using DiGi.Python.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.Laya
{
    public static partial class Modify
    {
        /// <summary>
        /// Answers Laya requests with a local checkpoint in one CPython run of predict.py and reads the responses back.
        /// <para>Each request is written as one line of requests.jsonl by <see cref="Convert.ToLaya_JsonObject(LayaRequest?)"/>, with the options' token budgets filled in where the request sets none. The scripts are rewritten into the working directory on every run, a responses.jsonl left by an earlier run is deleted before the process starts so it can never be read as this run's answer, and predict.py runs once, offline, through <see cref="Query.PythonProcessResult(string, string, string, TimeSpan?, TimeSpan?, CancellationToken)"/> with the options' inactivity and overall limits. Responses are read with <see cref="Convert.ToDiGi_LayaResponse(JsonObject?)"/> and matched to the requests by <see cref="LayaRequest.Id"/>.</para>
        /// <para>Nothing is reported by an exception. A request that cannot be written (no id, no usable state, no questions, a question Laya would refuse) is left out and named in <see cref="LayaPredictionResult.Messages"/>, and the others still run; a request laya refuses, gets no response, misses an answer or was truncated to fit the token budget is named there too. Ids used twice, an interpreter or checkpoint that does not resolve (<see cref="Query.LayaModelPath(string?)"/>; a model name or Hub id is refused, never downloaded) or a calibration file that does not exist refuse the whole run before a process starts. No requests at all is answered with an empty result without starting one.</para>
        /// <para>The process runs on a worker thread, so awaiting this does not block the caller. Cancelling, the overall limit and the inactivity limit each end the interpreter together with every process it started, and are told apart by <see cref="LayaPredictionResult.Cancelled"/>, <see cref="LayaPredictionResult.TimedOut"/> and <see cref="LayaPredictionResult.Stalled"/>. Without a working directory a temporary one is used and removed afterwards.</para>
        /// </summary>
        /// <param name="layaRequests">The requests to answer.</param>
        /// <param name="layaPredictionOptions">The interpreter, checkpoint, device, working directory and limits of the run.</param>
        /// <param name="cancellationToken">The token that cancels the run.</param>
        /// <returns>The result of the run, or <c>null</c> when <paramref name="layaRequests"/> or <paramref name="layaPredictionOptions"/> is <c>null</c>.</returns>
        public static async Task<LayaPredictionResult?> PredictAsync(this IEnumerable<LayaRequest>? layaRequests, LayaPredictionOptions? layaPredictionOptions, CancellationToken cancellationToken = default)
        {
            if (layaRequests == null || layaPredictionOptions == null)
            {
                return null;
            }

            List<LayaRequest> layaRequests_All = [.. layaRequests.OfType<LayaRequest>()];

            LayaPredictionResult Predict()
            {
                List<string> messages = [];

                LayaPredictionResult Refused()
                {
                    return new LayaPredictionResult([], null, null, null, -1, false, false, false, messages);
                }

                if (layaRequests_All.Count == 0)
                {
                    return new LayaPredictionResult([], null, null, null, 0, false, false, false, messages);
                }

                foreach (IGrouping<string, LayaRequest> grouping in layaRequests_All.Where(x => !string.IsNullOrWhiteSpace(x.Id)).GroupBy(x => x.Id!, StringComparer.Ordinal).Where(x => x.Count() > 1))
                {
                    messages.Add(string.Format(CultureInfo.InvariantCulture, "The request id '{0}' is used {1} times; responses are matched by id, so every id must be unique.", grouping.Key, grouping.Count()));
                }

                if (messages.Count != 0)
                {
                    return Refused();
                }

                //The requests that can be written, in request order, with their lines
                List<LayaRequest> layaRequests_Written = [];
                List<string> lines = [];
                foreach (LayaRequest layaRequest in layaRequests_All)
                {
                    if (string.IsNullOrWhiteSpace(layaRequest.Id))
                    {
                        messages.Add("A request without an id was left out: its response could not be matched to it.");
                        continue;
                    }

                    JsonObject? jsonObject = layaRequest.ToLaya_JsonObject();
                    if (jsonObject == null)
                    {
                        messages.Add(string.Format(CultureInfo.InvariantCulture, "The request '{0}' was left out: it has no usable state, no questions, two questions of one name, or a question Laya would refuse.", layaRequest.Id));
                        continue;
                    }

                    if (layaPredictionOptions.MaxLength != null && !jsonObject.ContainsKey("max_len"))
                    {
                        jsonObject["max_len"] = layaPredictionOptions.MaxLength.Value;
                    }

                    if (layaPredictionOptions.HeadMaxLength != null && !jsonObject.ContainsKey("head_max_len"))
                    {
                        jsonObject["head_max_len"] = layaPredictionOptions.HeadMaxLength.Value;
                    }

                    layaRequests_Written.Add(layaRequest);
                    lines.Add(jsonObject.ToJsonString());
                }

                if (layaRequests_Written.Count == 0)
                {
                    messages.Add("No request could be written for Laya.");
                    return Refused();
                }

                string? pythonPath = Query.LayaPythonPath(layaPredictionOptions.PythonPath);
                if (pythonPath == null)
                {
                    messages.Add(string.IsNullOrWhiteSpace(layaPredictionOptions.PythonPath) ? "No Python interpreter was found on PATH." : string.Format(CultureInfo.InvariantCulture, "The Python interpreter '{0}' was not found.", layaPredictionOptions.PythonPath));
                    return Refused();
                }

                string? modelPath = Query.LayaModelPath(layaPredictionOptions.ModelPath);
                if (modelPath == null)
                {
                    messages.Add(string.Format(CultureInfo.InvariantCulture, "The model directory '{0}' does not exist or holds no {1}; a model name or Hub id is not accepted.", layaPredictionOptions.ModelPath, Constants.FileName.CheckpointConfiguration));
                    return Refused();
                }

                string? calibrationPath = null;
                if (!string.IsNullOrWhiteSpace(layaPredictionOptions.CalibrationPath))
                {
                    calibrationPath = Python.Query.NormalizedPath(layaPredictionOptions.CalibrationPath);
                    if (calibrationPath == null || !File.Exists(calibrationPath))
                    {
                        messages.Add(string.Format(CultureInfo.InvariantCulture, "The calibration file '{0}' does not exist.", layaPredictionOptions.CalibrationPath));
                        return Refused();
                    }
                }

                string? workingDirectory = Python.Query.NormalizedPath(layaPredictionOptions.WorkingDirectory);
                bool temporary = workingDirectory == null;
                workingDirectory ??= Path.Combine(Path.GetTempPath(), "DiGi_Laya", Guid.NewGuid().ToString("N"));

                try
                {
                    Directory.CreateDirectory(workingDirectory);

                    if (!WriteScripts(workingDirectory))
                    {
                        messages.Add(string.Format(CultureInfo.InvariantCulture, "The Laya scripts could not be written to '{0}'.", workingDirectory));
                        return Refused();
                    }

                    string path_Requests = Path.Combine(workingDirectory, Constants.FileName.Requests);
                    string path_Responses = Path.Combine(workingDirectory, Constants.FileName.Responses);

                    //A responses file left by an earlier run would otherwise be read back as this run's answer; predict.py writes through .tmp, so a crashed run can leave that too
                    foreach (string path in new string[] { path_Responses, string.Concat(path_Responses, ".tmp") })
                    {
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                    }

                    File.WriteAllText(path_Requests, string.Concat(string.Join("\n", lines), "\n"), new UTF8Encoding(false));

                    string? modelSHA256 = Python.Query.DirectorySHA256(modelPath);
                    string? calibrationSHA256 = calibrationPath == null ? null : Python.Query.FileSHA256(calibrationPath);

                    string? arguments = Query.PredictArguments(Path.Combine(workingDirectory, Constants.FileName.Predict), modelPath, path_Requests, path_Responses, layaPredictionOptions.Device, layaPredictionOptions.BatchSize, calibrationPath);
                    if (arguments == null)
                    {
                        messages.Add(string.Format(CultureInfo.InvariantCulture, "The batch size {0} is not positive.", layaPredictionOptions.BatchSize));
                        return Refused();
                    }

                    Stopwatch stopwatch = Stopwatch.StartNew();
                    PythonProcessResult pythonProcessResult = Query.PythonProcessResult(pythonPath, arguments, workingDirectory, layaPredictionOptions.InactivityTimeout, layaPredictionOptions.Timeout, cancellationToken);
                    stopwatch.Stop();

                    bool stalled = pythonProcessResult.Stalled;
                    bool cancelled = pythonProcessResult.Cancelled && cancellationToken.IsCancellationRequested;
                    bool timedOut = pythonProcessResult.Cancelled && !cancellationToken.IsCancellationRequested;
                    int exitCode = pythonProcessResult.ExitCode;

                    messages.AddRange(Query.LayaProcessMessages(pythonProcessResult, Constants.FileName.Predict, layaPredictionOptions.InactivityTimeout, layaPredictionOptions.Timeout, cancellationToken.IsCancellationRequested));

                    HashSet<string> ids = new(layaRequests_Written.Select(x => x.Id!), StringComparer.Ordinal);
                    Dictionary<string, LayaResponse> layaResponses_ById = new(StringComparer.Ordinal);
                    HashSet<string> ids_Refused = new(StringComparer.Ordinal);

                    bool responsesWritten = File.Exists(path_Responses);
                    if (responsesWritten)
                    {
                        int lineNumber = 0;
                        foreach (string line in File.ReadAllLines(path_Responses, Encoding.UTF8))
                        {
                            lineNumber++;
                            if (string.IsNullOrWhiteSpace(line))
                            {
                                continue;
                            }

                            JsonObject? jsonObject;
                            try
                            {
                                jsonObject = JsonNode.Parse(line) as JsonObject;
                            }
                            catch (JsonException)
                            {
                                jsonObject = null;
                            }

                            if (jsonObject == null)
                            {
                                messages.Add(string.Format(CultureInfo.InvariantCulture, "Line {0} of {1} is not a JSON object.", lineNumber, Constants.FileName.Responses));
                                continue;
                            }

                            string? id = (jsonObject["id"] as JsonValue)?.GetValueKind() == JsonValueKind.String ? jsonObject["id"]!.GetValue<string>() : null;
                            if (id == null || !ids.Contains(id))
                            {
                                messages.Add(string.Format(CultureInfo.InvariantCulture, "Line {0} of {1} answers no request of this run (id '{2}').", lineNumber, Constants.FileName.Responses, id));
                                continue;
                            }

                            if (jsonObject["error"] is JsonNode jsonNode_Error)
                            {
                                ids_Refused.Add(id);
                                messages.Add(string.Format(CultureInfo.InvariantCulture, "The request '{0}' was refused by Laya: {1}", id, jsonNode_Error is JsonValue jsonValue_Error && jsonValue_Error.GetValueKind() == JsonValueKind.String ? jsonValue_Error.GetValue<string>() : jsonNode_Error.ToJsonString()));
                                continue;
                            }

                            LayaResponse? layaResponse = jsonObject.ToDiGi_LayaResponse();
                            if (layaResponse != null && !layaResponses_ById.ContainsKey(id))
                            {
                                layaResponses_ById[id] = layaResponse;
                            }
                        }
                    }

                    List<LayaResponse> layaResponses = [];
                    foreach (LayaRequest layaRequest in layaRequests_Written)
                    {
                        if (!layaResponses_ById.TryGetValue(layaRequest.Id!, out LayaResponse? layaResponse))
                        {
                            //A run that wrote no responses file has already been reported as a whole, and a refused request by its error
                            if (responsesWritten && !ids_Refused.Contains(layaRequest.Id!))
                            {
                                messages.Add(string.Format(CultureInfo.InvariantCulture, "The request '{0}' got no response.", layaRequest.Id));
                            }

                            continue;
                        }

                        HashSet<string> names = new(layaResponse.Answers?.Select(x => x.Name).OfType<string>() ?? [], StringComparer.Ordinal);
                        List<string> names_Missing = [.. layaRequest.Questions!.Select(x => x.Name!).Where(x => !names.Contains(x))];
                        if (names_Missing.Count != 0)
                        {
                            messages.Add(string.Format(CultureInfo.InvariantCulture, "The request '{0}' got no answer to: {1}.", layaRequest.Id, string.Join(", ", names_Missing)));
                        }

                        if (layaResponse.Truncated == true)
                        {
                            messages.Add(string.Format(CultureInfo.InvariantCulture, "The request '{0}' was truncated to fit the token budget and was answered from part of its input.", layaRequest.Id));
                        }

                        layaResponses.Add(layaResponse);
                    }

                    return new LayaPredictionResult(layaResponses, modelSHA256, calibrationSHA256, stopwatch.Elapsed, exitCode, stalled, timedOut, cancelled, messages);
                }
                catch (Exception exception) when (exception is IOException || exception is UnauthorizedAccessException)
                {
                    messages.Add(string.Format(CultureInfo.InvariantCulture, "The working directory '{0}' could not be used: {1}", workingDirectory, exception.Message));
                    return Refused();
                }
                finally
                {
                    if (temporary)
                    {
                        try
                        {
                            Directory.Delete(workingDirectory, true);
                        }
                        catch
                        {
                        }
                    }
                }
            }

            return await Task.Run(Predict, CancellationToken.None).ConfigureAwait(false);
        }
    }
}
