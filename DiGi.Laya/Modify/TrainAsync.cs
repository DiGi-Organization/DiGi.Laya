using DiGi.Laya.Classes;
using DiGi.Laya.Enums;
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
        /// Fine-tunes a local Laya checkpoint on a training JSONL in one CPython run of train.py (laya.train.finetune) and reports the new checkpoint.
        /// <para>Refused before a process starts, with the reason in <see cref="LayaTrainingResult.Messages"/>: an interpreter that does not resolve (<see cref="Query.LayaPythonPath(string?)"/>); a base that is not a checkpoint directory (<see cref="Query.LayaModelPath(string?)"/>; a model name or Hub id is never downloaded); a training or evaluation file that does not exist; no output directory, or one that is inside a Laya\models folder (<see cref="Query.IsInsideModelsDirectory(string?)"/> - training never writes where deployed checkpoints live), not empty, or the base checkpoint or inside it.</para>
        /// <para>The scripts and train_config.json (<see cref="Convert.ToLaya_TrainConfiguration(LayaTrainingOptions?)"/>) are written to the working directory, the base checkpoint is hashed, and train.py runs once, offline, with the options' limits (<see cref="Query.PythonProcessResult(string, string, string, TimeSpan?, TimeSpan?, CancellationToken)"/>). finetune holds out the calibration slice and writes the fitted temperatures into the new checkpoint; train.py removes the checkpoint_latest copy and prints its report between <see cref="Constants.Marker.TrainJsonBegin"/> and <see cref="Constants.Marker.TrainJsonEnd"/>.</para>
        /// <para>The new checkpoint is trusted - and only then hashed into <see cref="LayaTrainingResult.ModelSHA256"/> - when train.py exited with 0, its report was read, and the output directory holds rl_agent_config.json and model.safetensors (DiGi-Organization/DiGi.Laya#1, D5). The run is on a worker thread; cancelling, the overall limit and the inactivity limit end it and are told apart in the result. Without a working directory a temporary one is used and removed afterwards; the output directory is never removed.</para>
        /// </summary>
        /// <param name="layaTrainingOptions">The settings of the run.</param>
        /// <param name="cancellationToken">The token that cancels the run.</param>
        /// <returns>The result of the run, or <c>null</c> when the options are <c>null</c>.</returns>
        public static async Task<LayaTrainingResult?> TrainAsync(this LayaTrainingOptions? layaTrainingOptions, CancellationToken cancellationToken = default)
        {
            if (layaTrainingOptions == null)
            {
                return null;
            }

            LayaTrainingResult Train()
            {
                List<string> messages = [];
                string? outputDirectory = Python.Query.NormalizedPath(layaTrainingOptions.OutputDirectory);

                LayaTrainingResult Refused(string message)
                {
                    messages.Add(message);
                    return new LayaTrainingResult(outputDirectory, null, null, null, null, null, null, null, null, null, -1, false, false, false, messages);
                }

                string? pythonPath = Query.LayaPythonPath(layaTrainingOptions.PythonPath);
                if (pythonPath == null)
                {
                    return Refused(string.IsNullOrWhiteSpace(layaTrainingOptions.PythonPath) ? "No Python interpreter was found on PATH." : string.Format(CultureInfo.InvariantCulture, "The Python interpreter '{0}' was not found.", layaTrainingOptions.PythonPath));
                }

                string? baseModelPath = Query.LayaModelPath(layaTrainingOptions.BaseModelPath);
                if (baseModelPath == null)
                {
                    return Refused(string.Format(CultureInfo.InvariantCulture, "The base model directory '{0}' does not exist or holds no {1}; a model name or Hub id is not accepted.", layaTrainingOptions.BaseModelPath, Constants.FileName.CheckpointConfiguration));
                }

                string? trainingFilePath = Python.Query.NormalizedPath(layaTrainingOptions.TrainingFilePath);
                if (trainingFilePath == null || !File.Exists(trainingFilePath))
                {
                    return Refused(string.Format(CultureInfo.InvariantCulture, "The training file '{0}' does not exist.", layaTrainingOptions.TrainingFilePath));
                }

                if (!string.IsNullOrWhiteSpace(layaTrainingOptions.EvaluationFilePath) && !File.Exists(Python.Query.NormalizedPath(layaTrainingOptions.EvaluationFilePath) ?? string.Empty))
                {
                    return Refused(string.Format(CultureInfo.InvariantCulture, "The evaluation file '{0}' does not exist.", layaTrainingOptions.EvaluationFilePath));
                }

                if (outputDirectory == null)
                {
                    return Refused("No output directory was given.");
                }

                if (Query.IsInsideModelsDirectory(outputDirectory))
                {
                    return Refused(string.Format(CultureInfo.InvariantCulture, "The output directory '{0}' is inside a {1}\\{2} folder, where deployed checkpoints live; train into a training directory and deploy the checkpoint deliberately.", outputDirectory, Constants.DirectoryName.Laya, Constants.DirectoryName.Models));
                }

                if (Directory.Exists(outputDirectory) && Directory.EnumerateFileSystemEntries(outputDirectory).Any())
                {
                    return Refused(string.Format(CultureInfo.InvariantCulture, "The output directory '{0}' is not empty.", outputDirectory));
                }

                if (string.Equals(outputDirectory, baseModelPath, StringComparison.OrdinalIgnoreCase) || outputDirectory.StartsWith(string.Concat(baseModelPath, Path.DirectorySeparatorChar), StringComparison.OrdinalIgnoreCase))
                {
                    return Refused(string.Format(CultureInfo.InvariantCulture, "The output directory '{0}' is the base checkpoint or inside it.", outputDirectory));
                }

                string? workingDirectory = Python.Query.NormalizedPath(layaTrainingOptions.WorkingDirectory);
                bool temporary = workingDirectory == null;
                workingDirectory ??= Path.Combine(Path.GetTempPath(), "DiGi_Laya", Guid.NewGuid().ToString("N"));

                try
                {
                    Directory.CreateDirectory(workingDirectory);

                    if (!WriteScripts(workingDirectory))
                    {
                        return Refused(string.Format(CultureInfo.InvariantCulture, "The Laya scripts could not be written to '{0}'.", workingDirectory));
                    }

                    string configurationPath = Path.Combine(workingDirectory, Constants.FileName.TrainConfiguration);
                    File.WriteAllText(configurationPath, layaTrainingOptions.ToLaya_TrainConfiguration()!.ToJsonString(), new UTF8Encoding(false));

                    string? baseModelSHA256 = Python.Query.DirectorySHA256(baseModelPath);

                    string arguments = Query.TrainArguments(Path.Combine(workingDirectory, Constants.FileName.Train), baseModelPath, trainingFilePath, outputDirectory, configurationPath, layaTrainingOptions.Device)!;

                    Stopwatch stopwatch = Stopwatch.StartNew();
                    PythonProcessResult pythonProcessResult = Query.PythonProcessResult(pythonPath, arguments, workingDirectory, layaTrainingOptions.InactivityTimeout, layaTrainingOptions.Timeout, cancellationToken);
                    stopwatch.Stop();

                    messages.AddRange(Query.LayaProcessMessages(pythonProcessResult, Constants.FileName.Train, layaTrainingOptions.InactivityTimeout, layaTrainingOptions.Timeout, cancellationToken.IsCancellationRequested));

                    JsonObject? jsonObject = null;
                    string? json = Python.Query.MarkedJson(pythonProcessResult.StandardOutput, Constants.Marker.TrainJsonBegin, Constants.Marker.TrainJsonEnd);
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

                    static double? Number(JsonNode? jsonNode)
                    {
                        return jsonNode is JsonValue jsonValue && jsonValue.GetValueKind() == JsonValueKind.Number && double.TryParse(jsonValue.ToJsonString(), NumberStyles.Float, CultureInfo.InvariantCulture, out double value) ? value : null;
                    }

                    static int? Integer(JsonNode? jsonNode)
                    {
                        double? value = Number(jsonNode);
                        return value == null ? null : (int)value.Value;
                    }

                    List<LayaSkippedCount>? layaSkippedCounts = null;
                    List<double>? epochLosses = null;
                    List<LayaTemperature>? layaTemperatures = null;
                    if (jsonObject != null)
                    {
                        if (jsonObject["skipped"] is JsonObject jsonObject_Skipped)
                        {
                            layaSkippedCounts = [.. jsonObject_Skipped.Select(x => new LayaSkippedCount(x.Key, Integer(x.Value) ?? 0))];
                        }

                        if (jsonObject["epoch_loss"] is JsonArray jsonArray_Losses)
                        {
                            epochLosses = [.. jsonArray_Losses.Select(Number).OfType<double>()];
                        }

                        if (jsonObject["temperature"] is JsonArray jsonArray_Temperatures)
                        {
                            LayaQuestionType[] layaQuestionTypes = [LayaQuestionType.Choice, LayaQuestionType.Score, LayaQuestionType.Noul];
                            layaTemperatures = [];
                            for (int i = 0; i < Math.Min(layaQuestionTypes.Length, jsonArray_Temperatures.Count); i++)
                            {
                                double? value = Number(jsonArray_Temperatures[i]);
                                if (value != null)
                                {
                                    layaTemperatures.Add(new LayaTemperature(layaQuestionTypes[i], value.Value));
                                }
                            }
                        }
                    }

                    bool complete = File.Exists(Path.Combine(outputDirectory, Constants.FileName.CheckpointConfiguration)) && File.Exists(Path.Combine(outputDirectory, Constants.FileName.Model));
                    bool trusted = pythonProcessResult.ExitCode == 0 && jsonObject != null && complete;
                    if (pythonProcessResult.ExitCode == 0 && !trusted)
                    {
                        messages.Add(jsonObject == null ? "train.py exited with 0 but printed no report, so the checkpoint is not trusted." : string.Format(CultureInfo.InvariantCulture, "train.py exited with 0 but '{0}' holds no complete checkpoint ({1} and {2}), so it is not trusted.", outputDirectory, Constants.FileName.CheckpointConfiguration, Constants.FileName.Model));
                    }

                    return new LayaTrainingResult(
                        outputDirectory,
                        trusted ? Python.Query.DirectorySHA256(outputDirectory) : null,
                        baseModelSHA256,
                        Integer(jsonObject?["train_items"]),
                        Integer(jsonObject?["calibration_items"]),
                        Integer(jsonObject?["eval_items"]),
                        layaSkippedCounts,
                        epochLosses,
                        layaTemperatures,
                        stopwatch.Elapsed,
                        pythonProcessResult.ExitCode,
                        pythonProcessResult.Stalled,
                        pythonProcessResult.Cancelled && !cancellationToken.IsCancellationRequested,
                        pythonProcessResult.Cancelled && cancellationToken.IsCancellationRequested,
                        messages);
                }
                catch (Exception exception) when (exception is IOException || exception is UnauthorizedAccessException)
                {
                    return Refused(string.Format(CultureInfo.InvariantCulture, "The working directory '{0}' could not be used: {1}", workingDirectory, exception.Message));
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

            return await Task.Run(Train, CancellationToken.None).ConfigureAwait(false);
        }
    }
}
