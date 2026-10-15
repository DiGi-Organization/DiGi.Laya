using DiGi.Laya.Classes;
using DiGi.Python.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;

namespace DiGi.Laya
{
    public static partial class Query
    {
        /// <summary>
        /// Checks whether a machine can run the Laya scripts with the interpreter and checkpoint of a set of prediction options, without ever throwing.
        /// <para>The interpreter is resolved by <see cref="LayaPythonPath(string?)"/> and the checkpoint by <see cref="LayaModelPath(string?)"/> - exactly as <see cref="Modify.PredictAsync(IEnumerable{LayaRequest}?, LayaPredictionOptions?, CancellationToken)"/> resolves them - so the preflight never calls a checkpoint absent that the run would find, or the reverse. The scripts are written into the working directory and check.py is run offline (<see cref="PythonProcessResult(string, string, string, TimeSpan?, TimeSpan?, CancellationToken)"/>) with the options' device and limits; its payload is read from between <see cref="Constants.Marker.CheckJsonBegin"/> and <see cref="Constants.Marker.CheckJsonEnd"/>.</para>
        /// <para>The result is not runnable, with the reason in <see cref="PythonEnvironmentResult.Messages"/>, when: no interpreter is found; torch or laya does not import; laya is not the version requirements.txt pins; the checkpoint uses the parallel option layout under transformers older than 5; or a model path was given that is not a checkpoint directory or does not load. With no model path the interpreter alone is checked. The checkpoint directory is hashed whenever it resolved, so <see cref="LayaEnvironmentResult.ModelSHA256"/> names the weights the check saw.</para>
        /// </summary>
        /// <param name="layaPredictionOptions">The options naming the interpreter, the checkpoint, the device, the working directory and the limits; <see cref="LayaPredictionOptions.WorkingDirectory"/> <c>null</c> uses DiGi_Laya_Preflight in the temporary folder.</param>
        /// <param name="cancellationToken">The token that cancels the check.</param>
        /// <returns>The preflight result.</returns>
        public static Classes.LayaEnvironmentResult LayaEnvironmentResult(LayaPredictionOptions? layaPredictionOptions, CancellationToken cancellationToken = default)
        {
            if (layaPredictionOptions == null)
            {
                return new Classes.LayaEnvironmentResult(false, null, null, null, null, ["No prediction options were given."], null, DateTimeOffset.Now, null, null, null, null, null);
            }

            string? modelPath_Configured = layaPredictionOptions.ModelPath;
            bool modelRequested = !string.IsNullOrWhiteSpace(modelPath_Configured);
            string? modelPath = LayaModelPath(modelPath_Configured);
            string? modelPath_Reported = modelPath ?? modelPath_Configured;

            string? pythonPath = LayaPythonPath(layaPredictionOptions.PythonPath);
            if (pythonPath == null)
            {
                string message = string.IsNullOrWhiteSpace(layaPredictionOptions.PythonPath) ? "No Python interpreter was found on PATH." : string.Format(CultureInfo.InvariantCulture, "The Python interpreter '{0}' was not found.", layaPredictionOptions.PythonPath);
                return new Classes.LayaEnvironmentResult(false, layaPredictionOptions.PythonPath, null, null, null, [message], null, DateTimeOffset.Now, modelPath_Reported, null, null, null, null);
            }

            List<string> messages = [];
            List<string> warnings = [];

            if (modelRequested && modelPath == null)
            {
                messages.Add(string.Format(CultureInfo.InvariantCulture, "The model directory '{0}' does not exist or holds no {1}; a model name or Hub id is not accepted.", modelPath_Configured, Constants.FileName.CheckpointConfiguration));
            }

            string? modelSHA256 = modelPath == null ? null : Python.Query.DirectorySHA256(modelPath);

            string workingDirectory = Python.Query.NormalizedPath(layaPredictionOptions.WorkingDirectory) ?? Path.Combine(Path.GetTempPath(), "DiGi_Laya_Preflight");
            try
            {
                Directory.CreateDirectory(workingDirectory);
            }
            catch (Exception exception)
            {
                messages.Add(string.Format(CultureInfo.InvariantCulture, "The working directory '{0}' could not be created: {1}", workingDirectory, exception.Message));
                return new Classes.LayaEnvironmentResult(false, pythonPath, null, null, null, messages, warnings, DateTimeOffset.Now, modelPath_Reported, modelSHA256, null, null, null);
            }

            if (!Modify.WriteScripts(workingDirectory))
            {
                messages.Add(string.Format(CultureInfo.InvariantCulture, "The Laya scripts could not be written to '{0}'.", workingDirectory));
                return new Classes.LayaEnvironmentResult(false, pythonPath, null, null, null, messages, warnings, DateTimeOffset.Now, modelPath_Reported, modelSHA256, null, null, null);
            }

            string arguments = string.Concat("\"", Path.Combine(workingDirectory, Constants.FileName.Check), "\" --device ", layaPredictionOptions.Device.ToString().ToLowerInvariant());
            if (modelPath != null)
            {
                arguments = string.Concat(arguments, " --model \"", modelPath, "\"");
            }

            PythonProcessResult pythonProcessResult = PythonProcessResult(pythonPath, arguments, workingDirectory, layaPredictionOptions.InactivityTimeout, layaPredictionOptions.Timeout, cancellationToken);

            string? json = Python.Query.MarkedJson(pythonProcessResult.StandardOutput, Constants.Marker.CheckJsonBegin, Constants.Marker.CheckJsonEnd);
            JsonObject? jsonObject = null;
            if (json != null)
            {
                try
                {
                    jsonObject = JsonNode.Parse(json) as JsonObject;
                }
                catch (JsonException)
                {
                }
            }

            if (jsonObject == null)
            {
                if (pythonProcessResult.Cancelled)
                {
                    messages.Add(cancellationToken.IsCancellationRequested ? "The check was cancelled." : string.Format(CultureInfo.InvariantCulture, "The check exceeded its time limit of {0}.", layaPredictionOptions.Timeout));
                }
                else if (pythonProcessResult.Stalled)
                {
                    messages.Add(string.Format(CultureInfo.InvariantCulture, "The check printed nothing for {0} and was ended.", layaPredictionOptions.InactivityTimeout));
                }
                else
                {
                    messages.Add(string.Format(CultureInfo.InvariantCulture, "check.py exited with code {0} without its result.", pythonProcessResult.ExitCode));
                }

                List<string>? standardError = pythonProcessResult.StandardError;
                if (standardError != null)
                {
                    messages.AddRange(standardError.Skip(Math.Max(0, standardError.Count - 10)));
                }

                return new Classes.LayaEnvironmentResult(false, pythonPath, null, null, null, messages, warnings, DateTimeOffset.Now, modelPath_Reported, modelSHA256, null, null, null);
            }

            static string? Text(JsonNode? jsonNode)
            {
                return jsonNode is JsonValue jsonValue && jsonValue.GetValueKind() == JsonValueKind.String ? jsonValue.GetValue<string>() : null;
            }

            static bool? Boolean(JsonNode? jsonNode)
            {
                JsonValueKind? jsonValueKind = (jsonNode as JsonValue)?.GetValueKind();
                return jsonValueKind == JsonValueKind.True ? true : jsonValueKind == JsonValueKind.False ? false : null;
            }

            static int? Integer(JsonNode? jsonNode)
            {
                return jsonNode is JsonValue jsonValue && jsonValue.GetValueKind() == JsonValueKind.Number && int.TryParse(jsonValue.ToJsonString(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int value) ? value : null;
            }

            static void AddTexts(JsonNode? jsonNode, List<string> values)
            {
                if (jsonNode is JsonArray jsonArray)
                {
                    foreach (JsonNode? jsonNode_Item in jsonArray)
                    {
                        string? value = Text(jsonNode_Item);
                        if (value != null)
                        {
                            values.Add(value);
                        }
                    }
                }
            }

            AddTexts(jsonObject["messages"], messages);
            AddTexts(jsonObject["warnings"], warnings);

            List<PythonPackageVersion> pythonPackageVersions = [];
            if (jsonObject["packages"] is JsonArray jsonArray_Packages)
            {
                foreach (JsonNode? jsonNode_Package in jsonArray_Packages)
                {
                    string? name = Text(jsonNode_Package?["name"]);
                    if (name != null)
                    {
                        pythonPackageVersions.Add(new PythonPackageVersion(name, Text(jsonNode_Package?["version"])));
                    }
                }
            }

            JsonObject? jsonObject_Model = jsonObject["model"] as JsonObject;

            bool runnable = Boolean(jsonObject["runnable"]) == true && messages.Count == 0;

            return new Classes.LayaEnvironmentResult(
                runnable,
                Text(jsonObject["python_path"]) ?? pythonPath,
                Text(jsonObject["python_version"]),
                Boolean(jsonObject["cuda_available"]),
                pythonPackageVersions,
                messages,
                warnings,
                DateTimeOffset.Now,
                modelPath_Reported,
                modelSHA256,
                Text(jsonObject_Model?["option_layout"]),
                Integer(jsonObject_Model?["max_len"]),
                Integer(jsonObject_Model?["head_max_len"]));
        }
    }
}
