using DiGi.Core.Classes;
using DiGi.Laya.Enums;
using DiGi.Laya.Interfaces;
using System;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Provides the settings of one calibration run of calibrate.py: the interpreter, the checkpoint, the labelled data, and where the calibration file goes.
    /// <para>For a checkpoint fine-tuning did not calibrate - the shipped ones carry temperatures of 1 and are over-confident. The checkpoint is never changed: the temperatures go to a calibration file outside it, which <see cref="LayaPredictionOptions.CalibrationPath"/> then names (DiGi-Organization/DiGi.Laya#1, D3).</para>
    /// </summary>
    public class LayaCalibrationOptions : SerializableOptions, ILayaSerializableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LayaCalibrationOptions"/> class with default values.
        /// </summary>
        public LayaCalibrationOptions()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaCalibrationOptions"/> class by copying an existing options instance.
        /// </summary>
        /// <param name="layaCalibrationOptions">The source options instance to copy from.</param>
        public LayaCalibrationOptions(LayaCalibrationOptions? layaCalibrationOptions)
            : base(layaCalibrationOptions)
        {
            if (layaCalibrationOptions != null)
            {
                CalibrationFilePath = layaCalibrationOptions.CalibrationFilePath;
                CalibrationPath = layaCalibrationOptions.CalibrationPath;
                Device = layaCalibrationOptions.Device;
                InactivityTimeout = layaCalibrationOptions.InactivityTimeout;
                ModelPath = layaCalibrationOptions.ModelPath;
                PythonPath = layaCalibrationOptions.PythonPath;
                Seed = layaCalibrationOptions.Seed;
                Timeout = layaCalibrationOptions.Timeout;
                WorkingDirectory = layaCalibrationOptions.WorkingDirectory;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaCalibrationOptions"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the settings.</param>
        public LayaCalibrationOptions(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets or sets the labelled JSONL the temperatures are fitted on, in the training-line schema (<c>Modify.WriteTrainingFile</c>); keep it apart from the training data.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(CalibrationFilePath))]
        public string? CalibrationFilePath { get; set; } = null;

        /// <summary>
        /// Gets or sets the calibration JSON to write, outside the checkpoint directory. An existing file there is deleted before the run, so a failed run never leaves an older calibration looking like this one's.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(CalibrationPath))]
        public string? CalibrationPath { get; set; } = null;

        /// <summary>
        /// Gets or sets the device the model runs on, passed to calibrate.py as --device.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Device))]
        public LayaDevice Device { get; set; } = LayaDevice.Auto;

        /// <summary>
        /// Gets or sets the span without output after which the run is ended as stalled, or <c>null</c> for no limit. calibrate.py prints nothing until it is done.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(InactivityTimeout))]
        public TimeSpan? InactivityTimeout { get; set; } = null;

        /// <summary>
        /// Gets or sets the checkpoint directory to calibrate, resolved by <see cref="Query.LayaModelPath(string?)"/>; a model name or Hub id is refused.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(ModelPath))]
        public string? ModelPath { get; set; } = null;

        /// <summary>
        /// Gets or sets the CPython interpreter carrying laya, resolved by <see cref="Query.LayaPythonPath(string?)"/>; <c>null</c> searches PATH.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(PythonPath))]
        public string? PythonPath { get; set; } = null;

        /// <summary>
        /// Gets or sets the seed of laya's held-out split, passed to calibrate.py as --seed.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Seed))]
        public int Seed { get; set; } = 0;

        /// <summary>
        /// Gets or sets the span after which the run is ended whatever it is doing, or <c>null</c> for no limit.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Timeout))]
        public TimeSpan? Timeout { get; set; } = null;

        /// <summary>
        /// Gets or sets the directory the scripts are written to, or <c>null</c> for a fresh temporary directory removed after the run.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(WorkingDirectory))]
        public string? WorkingDirectory { get; set; } = null;
    }
}
