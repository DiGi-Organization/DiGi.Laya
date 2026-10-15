using DiGi.Laya.Classes;
using DiGi.Laya.Enums;
using DiGi.Python.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.Laya
{
    public static partial class Modify
    {
        /// <summary>
        /// Fits calibration temperatures for an existing Laya checkpoint in one CPython run of calibrate.py and writes them to a calibration file outside the checkpoint.
        /// <para>Refused before a process starts, with the reason in <see cref="LayaCalibrationResult.Messages"/>: an interpreter or checkpoint that does not resolve (<see cref="Query.LayaPythonPath(string?)"/>, <see cref="Query.LayaModelPath(string?)"/>), a labelled file that does not exist, no calibration path, or one inside the checkpoint directory - writing there would change the checkpoint's SHA-256, which is its identity (DiGi-Organization/DiGi.Laya#1, D3).</para>
        /// <para>A file already at the calibration path is deleted before the run, so a failed run can never leave an older calibration that looks like this one's. calibrate.py runs once, offline, with the options' limits; laya fits one temperature per question type (clamped to [0.5, 5.0]) and, only for buckets of about 2500 records or more, scores the expected calibration error on a held-out fifth. Its report is read from between <see cref="Constants.Marker.CalibrateJsonBegin"/> and <see cref="Constants.Marker.CalibrateJsonEnd"/>. The calibration file is hashed into <see cref="LayaCalibrationResult.CalibrationSHA256"/> when the run exited with 0 and wrote it.</para>
        /// </summary>
        /// <param name="layaCalibrationOptions">The settings of the run.</param>
        /// <param name="cancellationToken">The token that cancels the run.</param>
        /// <returns>The result of the run, or <c>null</c> when the options are <c>null</c>.</returns>
        public static async Task<LayaCalibrationResult?> CalibrateAsync(this LayaCalibrationOptions? layaCalibrationOptions, CancellationToken cancellationToken = default)
        {
            if (layaCalibrationOptions == null)
            {
                return null;
            }

            LayaCalibrationResult Calibrate()
            {
                List<string> messages = [];
                string? calibrationPath = Python.Query.NormalizedPath(layaCalibrationOptions.CalibrationPath);
                string? modelSHA256 = null;

                LayaCalibrationResult Refused(string message)
                {
                    messages.Add(message);
                    return new LayaCalibrationResult(calibrationPath, null, modelSHA256, null, null, null, null, null, null, null, -1, false, false, false, messages);
                }

                string? pythonPath = Query.LayaPythonPath(layaCalibrationOptions.PythonPath);
                if (pythonPath == null)
                {
                    return Refused(string.IsNullOrWhiteSpace(layaCalibrationOptions.PythonPath) ? "No Python interpreter was found on PATH." : string.Format(CultureInfo.InvariantCulture, "The Python interpreter '{0}' was not found.", layaCalibrationOptions.PythonPath));
                }

                string? modelPath = Query.LayaModelPath(layaCalibrationOptions.ModelPath);
                if (modelPath == null)
                {
                    return Refused(string.Format(CultureInfo.InvariantCulture, "The model directory '{0}' does not exist or holds no {1}; a model name or Hub id is not accepted.", layaCalibrationOptions.ModelPath, Constants.FileName.CheckpointConfiguration));
                }

                string? calibrationFilePath = Python.Query.NormalizedPath(layaCalibrationOptions.CalibrationFilePath);
                if (calibrationFilePath == null || !File.Exists(calibrationFilePath))
                {
                    return Refused(string.Format(CultureInfo.InvariantCulture, "The labelled file '{0}' does not exist.", layaCalibrationOptions.CalibrationFilePath));
                }

                if (calibrationPath == null)
                {
                    return Refused("No calibration path was given.");
                }

                if (calibrationPath.StartsWith(string.Concat(modelPath, Path.DirectorySeparatorChar), StringComparison.OrdinalIgnoreCase))
                {
                    return Refused(string.Format(CultureInfo.InvariantCulture, "The calibration path '{0}' is inside the checkpoint, which would change its SHA-256; write it beside the checkpoint instead.", calibrationPath));
                }

                string? workingDirectory = Python.Query.NormalizedPath(layaCalibrationOptions.WorkingDirectory);
                bool temporary = workingDirectory == null;
                workingDirectory ??= Path.Combine(Path.GetTempPath(), "DiGi_Laya", Guid.NewGuid().ToString("N"));

                try
                {
                    Directory.CreateDirectory(workingDirectory);

                    if (!WriteScripts(workingDirectory))
                    {
                        return Refused(string.Format(CultureInfo.InvariantCulture, "The Laya scripts could not be written to '{0}'.", workingDirectory));
                    }

                    //An older calibration file would otherwise survive a failed run and be read as this one's
                    if (File.Exists(calibrationPath))
                    {
                        File.Delete(calibrationPath);
                    }

                    modelSHA256 = Python.Query.DirectorySHA256(modelPath);

                    string arguments = Query.CalibrateArguments(Path.Combine(workingDirectory, Constants.FileName.Calibrate), modelPath, calibrationFilePath, calibrationPath, layaCalibrationOptions.Device, layaCalibrationOptions.Seed)!;

                    Stopwatch stopwatch = Stopwatch.StartNew();
                    PythonProcessResult pythonProcessResult = Query.PythonProcessResult(pythonPath, arguments, workingDirectory, layaCalibrationOptions.InactivityTimeout, layaCalibrationOptions.Timeout, cancellationToken);
                    stopwatch.Stop();

                    messages.AddRange(Query.LayaProcessMessages(pythonProcessResult, Constants.FileName.Calibrate, layaCalibrationOptions.InactivityTimeout, layaCalibrationOptions.Timeout, cancellationToken.IsCancellationRequested));

                    JsonObject? jsonObject = null;
                    string? json = Python.Query.MarkedJson(pythonProcessResult.StandardOutput, Constants.Marker.CalibrateJsonBegin, Constants.Marker.CalibrateJsonEnd);
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

                    List<LayaTemperature>? layaTemperatures = null;
                    if (jsonObject?["temperature"] is JsonArray jsonArray_Temperatures)
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

                    bool written = pythonProcessResult.ExitCode == 0 && File.Exists(calibrationPath);
                    if (pythonProcessResult.ExitCode == 0 && !written)
                    {
                        messages.Add(string.Format(CultureInfo.InvariantCulture, "calibrate.py exited with 0 but wrote no calibration file at '{0}'.", calibrationPath));
                    }

                    return new LayaCalibrationResult(
                        calibrationPath,
                        written ? Python.Query.FileSHA256(calibrationPath) : null,
                        modelSHA256,
                        Integer(jsonObject?["records"]),
                        Integer(jsonObject?["skipped"]),
                        layaTemperatures,
                        Number(jsonObject?["ece_before"]),
                        Number(jsonObject?["ece_after"]),
                        Integer(jsonObject?["evaluation_records"]),
                        stopwatch.Elapsed,
                        pythonProcessResult.ExitCode,
                        pythonProcessResult.Stalled,
                        pythonProcessResult.Cancelled && !cancellationToken.IsCancellationRequested,
                        pythonProcessResult.Cancelled && cancellationToken.IsCancellationRequested,
                        messages);
                }
                catch (Exception exception) when (exception is IOException || exception is UnauthorizedAccessException)
                {
                    return Refused(string.Format(CultureInfo.InvariantCulture, "The working directory '{0}' or the calibration path could not be used: {1}", workingDirectory, exception.Message));
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

            return await Task.Run(Calibrate, CancellationToken.None).ConfigureAwait(false);
        }
    }
}
