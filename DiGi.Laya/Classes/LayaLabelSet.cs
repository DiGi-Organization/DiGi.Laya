using DiGi.Core.Classes;
using DiGi.Laya.Enums;
using DiGi.Laya.Interfaces;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents a closed set of labels one question decides for every item.
    /// <para>Laya's accuracy drops sharply past about 20 options in one choice question and it refuses more than 100; <c>Modify.ClassifyAsync</c> warns above the first and refuses above the second for a single-choice set.</para>
    /// </summary>
    public class LayaLabelSet : SerializableObject, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Id))]
        private readonly string? id;

        [JsonInclude, JsonPropertyName(nameof(Instructions))]
        private readonly string? instructions;

        [JsonInclude, JsonPropertyName(nameof(Kind))]
        private readonly LayaLabelSetKind kind;

        [JsonInclude, JsonPropertyName(nameof(Labels))]
        private readonly List<LayaLabel>? labels;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabelSet"/> class.
        /// </summary>
        /// <param name="id">The identifier of the set, unique within one run; a single-choice set's question is named after it. It must not contain a colon, which separates set and label in a multi-label question name.</param>
        /// <param name="instructions">The instructions of the set: the choice question of a single-choice set, or the noul statement template (with {label}) of a multi-label set's labels that carry none of their own.</param>
        /// <param name="kind">How the labels are asked and decided.</param>
        /// <param name="labels">The labels, in the order they are shown to the model.</param>
        public LayaLabelSet(string? id, string? instructions, LayaLabelSetKind kind, IEnumerable<LayaLabel>? labels)
        {
            this.id = id;
            this.instructions = instructions;
            this.kind = kind;
            this.labels = labels == null ? null : [.. labels];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabelSet"/> class by copying an existing instance.
        /// </summary>
        /// <param name="layaLabelSet">The source instance to copy from.</param>
        public LayaLabelSet(LayaLabelSet? layaLabelSet)
            : base(layaLabelSet)
        {
            if (layaLabelSet != null)
            {
                id = layaLabelSet.id;
                instructions = layaLabelSet.instructions;
                kind = layaLabelSet.kind;

                if (layaLabelSet.labels != null)
                {
                    labels = [];
                    foreach (LayaLabel layaLabel in layaLabelSet.labels)
                    {
                        if (Core.Query.Clone(layaLabel) is LayaLabel layaLabel_Clone)
                        {
                            labels.Add(layaLabel_Clone);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaLabelSet"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data.</param>
        public LayaLabelSet(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the identifier of the set, unique within one run; a single-choice set's question is named after it. It must not contain a colon, which separates set and label in a multi-label question name.
        /// </summary>
        [JsonIgnore]
        public string? Id
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// Gets the instructions of the set: the choice question of a single-choice set, or the noul statement template (with {label}) of a multi-label set's labels that carry none of their own.
        /// </summary>
        [JsonIgnore]
        public string? Instructions
        {
            get
            {
                return instructions;
            }
        }

        /// <summary>
        /// Gets how the labels are asked and decided.
        /// </summary>
        [JsonIgnore]
        public LayaLabelSetKind Kind
        {
            get
            {
                return kind;
            }
        }

        /// <summary>
        /// Gets the labels, in the order they are shown to the model.
        /// </summary>
        [JsonIgnore]
        public List<LayaLabel>? Labels
        {
            get
            {
                return labels;
            }
        }
    }
}
