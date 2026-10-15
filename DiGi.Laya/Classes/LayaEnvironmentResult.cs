using DiGi.Laya.Interfaces;
using DiGi.Python.Classes;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents the preflight result of a CPython environment and a checkpoint for the Laya scripts.
    /// <para>The installed versions of laya, torch, transformers and their companions are reported in <see cref="PythonEnvironmentResult.Packages"/> only, which is authoritative; this type adds what describes the checkpoint (DiGi-Organization/DiGi.Laya#1, D2). Its member names collide with none of the base type's, as the DiGi serializer requires.</para>
    /// </summary>
    public class LayaEnvironmentResult : PythonEnvironmentResult, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(HeadMaxLength))]
        private readonly int? headMaxLength;

        [JsonInclude, JsonPropertyName(nameof(MaxLength))]
        private readonly int? maxLength;

        [JsonInclude, JsonPropertyName(nameof(ModelPath))]
        private readonly string? modelPath;

        [JsonInclude, JsonPropertyName(nameof(ModelSHA256))]
        private readonly string? modelSHA256;

        [JsonInclude, JsonPropertyName(nameof(OptionLayout))]
        private readonly string? optionLayout;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaEnvironmentResult"/> class.
        /// </summary>
        /// <param name="runnable">A value indicating whether the interpreter can run the Laya scripts with the checkpoint.</param>
        /// <param name="pythonPath">The full path of the interpreter that was probed.</param>
        /// <param name="pythonVersion">The Python version reported by the interpreter.</param>
        /// <param name="cudaAvailable">A value indicating whether torch reports a CUDA device, or <c>null</c> when it was not determined.</param>
        /// <param name="packages">The installed versions of laya and its dependencies.</param>
        /// <param name="messages">The findings that stop a run.</param>
        /// <param name="warnings">The findings that do not stop a run.</param>
        /// <param name="checkedTime">The moment the preflight completed.</param>
        /// <param name="modelPath">The resolved checkpoint directory, or the configured value when it did not resolve.</param>
        /// <param name="modelSHA256">The SHA-256 of the checkpoint directory, or <c>null</c> when it was not hashed.</param>
        /// <param name="optionLayout">The option layout the checkpoint was trained with, "sequential" or "parallel".</param>
        /// <param name="maxLength">The checkpoint's own token budget of the state.</param>
        /// <param name="headMaxLength">The checkpoint's own token budget of one question.</param>
        public LayaEnvironmentResult(
            bool runnable,
            string? pythonPath,
            string? pythonVersion,
            bool? cudaAvailable,
            IEnumerable<PythonPackageVersion>? packages,
            IEnumerable<string>? messages,
            IEnumerable<string>? warnings,
            DateTimeOffset? checkedTime,
            string? modelPath,
            string? modelSHA256,
            string? optionLayout,
            int? maxLength,
            int? headMaxLength)
            : base(runnable, pythonPath, pythonVersion, cudaAvailable, packages, messages, warnings, checkedTime)
        {
            this.modelPath = modelPath;
            this.modelSHA256 = modelSHA256;
            this.optionLayout = optionLayout;
            this.maxLength = maxLength;
            this.headMaxLength = headMaxLength;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaEnvironmentResult"/> class by copying an existing result.
        /// </summary>
        /// <param name="layaEnvironmentResult">The source result to copy from.</param>
        public LayaEnvironmentResult(LayaEnvironmentResult? layaEnvironmentResult)
            : base(layaEnvironmentResult)
        {
            if (layaEnvironmentResult != null)
            {
                headMaxLength = layaEnvironmentResult.headMaxLength;
                maxLength = layaEnvironmentResult.maxLength;
                modelPath = layaEnvironmentResult.modelPath;
                modelSHA256 = layaEnvironmentResult.modelSHA256;
                optionLayout = layaEnvironmentResult.optionLayout;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaEnvironmentResult"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the result data.</param>
        public LayaEnvironmentResult(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the checkpoint's own token budget of one question, from its rl_agent_config.json.
        /// </summary>
        [JsonIgnore]
        public int? HeadMaxLength
        {
            get
            {
                return headMaxLength;
            }
        }

        /// <summary>
        /// Gets the checkpoint's own token budget of the state, from its rl_agent_config.json.
        /// </summary>
        [JsonIgnore]
        public int? MaxLength
        {
            get
            {
                return maxLength;
            }
        }

        /// <summary>
        /// Gets the resolved checkpoint directory, or the configured value when it did not resolve.
        /// </summary>
        [JsonIgnore]
        public string? ModelPath
        {
            get
            {
                return modelPath;
            }
        }

        /// <summary>
        /// Gets the SHA-256 of the checkpoint directory (DiGi.Python's <c>Query.DirectorySHA256</c>), or <c>null</c> when it was not hashed.
        /// <para>A checkpoint directory can be replaced in place, so its name says nothing about which weights a run used; compare this instead.</para>
        /// </summary>
        [JsonIgnore]
        public string? ModelSHA256
        {
            get
            {
                return modelSHA256;
            }
        }

        /// <summary>
        /// Gets the option layout the checkpoint was trained with, "sequential" or "parallel"; a parallel checkpoint needs transformers 5 or later.
        /// </summary>
        [JsonIgnore]
        public string? OptionLayout
        {
            get
            {
                return optionLayout;
            }
        }
    }
}
