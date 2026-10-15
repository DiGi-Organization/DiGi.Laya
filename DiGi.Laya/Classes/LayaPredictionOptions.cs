using DiGi.Core.Classes;
using DiGi.Laya.Enums;
using DiGi.Laya.Interfaces;
using System;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Provides the settings a Laya prediction run and its preflight need: the interpreter, the checkpoint, the device and the limits of the run.
    /// <para>The constructors only assign. Use <see cref="Create.LayaPredictionOptions(string?, string?, string?, LayaDevice)"/> to resolve the interpreter and the checkpoint directory and refuse a combination that cannot make a run.</para>
    /// </summary>
    public class LayaPredictionOptions : SerializableOptions, ILayaSerializableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LayaPredictionOptions"/> class with default values.
        /// </summary>
        public LayaPredictionOptions()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaPredictionOptions"/> class by copying an existing options instance.
        /// </summary>
        /// <param name="layaPredictionOptions">The source options instance to copy from.</param>
        public LayaPredictionOptions(LayaPredictionOptions? layaPredictionOptions)
            : base(layaPredictionOptions)
        {
            if (layaPredictionOptions != null)
            {
                BatchSize = layaPredictionOptions.BatchSize;
                CalibrationPath = layaPredictionOptions.CalibrationPath;
                Device = layaPredictionOptions.Device;
                HeadMaxLength = layaPredictionOptions.HeadMaxLength;
                InactivityTimeout = layaPredictionOptions.InactivityTimeout;
                MaxLength = layaPredictionOptions.MaxLength;
                ModelPath = layaPredictionOptions.ModelPath;
                PythonPath = layaPredictionOptions.PythonPath;
                Timeout = layaPredictionOptions.Timeout;
                WorkingDirectory = layaPredictionOptions.WorkingDirectory;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaPredictionOptions"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the settings.</param>
        public LayaPredictionOptions(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets or sets the number of states per forward pass, passed to predict.py as --batch-size.
        /// <para>The default is 16. Lowering it reduces GPU memory; the answers do not depend on it.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(BatchSize))]
        public int BatchSize { get; set; } = 16;

        /// <summary>
        /// Gets or sets the calibration JSON written by <c>Modify.CalibrateAsync</c>, passed to predict.py as --calibration, or <c>null</c> for the checkpoint's own temperatures.
        /// <para>Kept outside the checkpoint directory, so that calibrating never changes the checkpoint's SHA-256.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(CalibrationPath))]
        public string? CalibrationPath { get; set; } = null;

        /// <summary>
        /// Gets or sets the device the model runs on, passed to the scripts as --device.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Device))]
        public LayaDevice Device { get; set; } = LayaDevice.Auto;

        /// <summary>
        /// Gets or sets the token budget of one question for a request that sets none, or <c>null</c> for the checkpoint's own (256 for laya-multilingual).
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(HeadMaxLength))]
        public int? HeadMaxLength { get; set; } = null;

        /// <summary>
        /// Gets or sets the span without output after which the run is ended as stalled, or <c>null</c> for no limit.
        /// <para>predict.py prints a progress line after every chunk of states, so the limit has to exceed the model load plus one chunk.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(InactivityTimeout))]
        public TimeSpan? InactivityTimeout { get; set; } = null;

        /// <summary>
        /// Gets or sets the token budget of the state for a request that sets none, or <c>null</c> for the checkpoint's own (1024 for laya-multilingual).
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(MaxLength))]
        public int? MaxLength { get; set; } = null;

        /// <summary>
        /// Gets or sets the checkpoint directory, resolved by <see cref="Query.LayaModelPath(string?)"/>.
        /// <para>It must be a directory holding rl_agent_config.json; a model name or Hugging Face Hub id is refused rather than downloaded.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(ModelPath))]
        public string? ModelPath { get; set; } = null;

        /// <summary>
        /// Gets or sets the path of the CPython interpreter carrying laya, or the name of one on PATH; <c>null</c> searches PATH. Resolved by <see cref="Query.LayaPythonPath(string?)"/>, which refuses a value that does not resolve as given rather than falling back to another Python.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(PythonPath))]
        public string? PythonPath { get; set; } = null;

        /// <summary>
        /// Gets or sets the span after which the run is ended whatever it is doing, or <c>null</c> for no limit.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Timeout))]
        public TimeSpan? Timeout { get; set; } = null;

        /// <summary>
        /// Gets or sets the directory the scripts, requests.jsonl and responses.jsonl are written to, or <c>null</c> for a fresh temporary directory removed after the run.
        /// <para>Two runs must not share a working directory at the same time: each deletes and rewrites the other's files.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(WorkingDirectory))]
        public string? WorkingDirectory { get; set; } = null;
    }
}
