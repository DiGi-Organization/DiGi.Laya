using DiGi.Core.Classes;
using DiGi.Laya.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents one labelled decision Laya is fine-tuned on: a state, one question about it, and the answer the model should give.
    /// <para>The target member matches the question type: <see cref="Label"/> for a <see cref="LayaChoiceQuestion"/>, <see cref="Level"/> for a <see cref="LayaScoreQuestion"/>, and <see cref="Truth"/> or <see cref="Probability"/> for a <see cref="LayaNoulQuestion"/>. Laya has no per-sample weight, so a weak noul label is expressed as a soft target in <see cref="Probability"/> instead.</para>
    /// <para>The constructors only assign. <see cref="Convert.ToLaya_TrainingLine(LayaTrainingSample?)"/> rejects a sample whose target does not fit its question.</para>
    /// </summary>
    public class LayaTrainingSample : SerializableObject, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Group))]
        private readonly string? group;

        [JsonInclude, JsonPropertyName(nameof(Id))]
        private readonly string? id;

        [JsonInclude, JsonPropertyName(nameof(Label))]
        private readonly string? label;

        [JsonInclude, JsonPropertyName(nameof(Level))]
        private readonly double? level;

        [JsonInclude, JsonPropertyName(nameof(Probability))]
        private readonly double? probability;

        [JsonInclude, JsonPropertyName(nameof(Question))]
        private readonly LayaQuestion? question;

        [JsonInclude, JsonPropertyName(nameof(State))]
        private readonly string? state;

        [JsonInclude, JsonPropertyName(nameof(StateIsJson))]
        private readonly bool stateIsJson;

        [JsonInclude, JsonPropertyName(nameof(Truth))]
        private readonly bool? truth;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaTrainingSample"/> class.
        /// </summary>
        /// <param name="id">The identifier of the sample, written to the training line for tracing.</param>
        /// <param name="state">The state the question is asked about, as text.</param>
        /// <param name="stateIsJson">A value indicating whether <paramref name="state"/> is a JSON object or array rather than plain text.</param>
        /// <param name="question">The question the sample labels.</param>
        /// <param name="label">The expected label of a choice question.</param>
        /// <param name="level">The expected zero-based level of a score question; a fractional level splits its weight between the two neighbouring levels.</param>
        /// <param name="truth">The expected answer of a noul question.</param>
        /// <param name="probability">The soft target of a noul question, the probability that the statement is true; takes precedence over <paramref name="truth"/>.</param>
        /// <param name="group">The group that has to stay within one fold, or <c>null</c> when the sample stands alone.</param>
        public LayaTrainingSample(
            string? id,
            string? state,
            bool stateIsJson,
            LayaQuestion? question,
            string? label,
            double? level,
            bool? truth,
            double? probability,
            string? group)
        {
            this.id = id;
            this.state = state;
            this.stateIsJson = stateIsJson;
            this.question = question;
            this.label = label;
            this.level = level;
            this.truth = truth;
            this.probability = probability;
            this.group = group;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaTrainingSample"/> class by copying an existing sample.
        /// </summary>
        /// <param name="layaTrainingSample">The source sample to copy from.</param>
        public LayaTrainingSample(LayaTrainingSample? layaTrainingSample)
            : base(layaTrainingSample)
        {
            if (layaTrainingSample != null)
            {
                group = layaTrainingSample.group;
                id = layaTrainingSample.id;
                label = layaTrainingSample.label;
                level = layaTrainingSample.level;
                probability = layaTrainingSample.probability;
                question = Core.Query.Clone(layaTrainingSample.question);
                state = layaTrainingSample.state;
                stateIsJson = layaTrainingSample.stateIsJson;
                truth = layaTrainingSample.truth;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaTrainingSample"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the sample data.</param>
        public LayaTrainingSample(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the group that has to stay within one fold, or <c>null</c> when the sample stands alone.
        /// </summary>
        [JsonIgnore]
        public string? Group
        {
            get
            {
                return group;
            }
        }

        /// <summary>
        /// Gets the identifier of the sample, written to the training line for tracing.
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
        /// Gets the expected label of a choice question.
        /// </summary>
        [JsonIgnore]
        public string? Label
        {
            get
            {
                return label;
            }
        }

        /// <summary>
        /// Gets the expected zero-based level of a score question; a fractional level splits its weight between the two neighbouring levels.
        /// </summary>
        [JsonIgnore]
        public double? Level
        {
            get
            {
                return level;
            }
        }

        /// <summary>
        /// Gets the soft target of a noul question, the probability that the statement is true; takes precedence over <see cref="Truth"/>.
        /// </summary>
        [JsonIgnore]
        public double? Probability
        {
            get
            {
                return probability;
            }
        }

        /// <summary>
        /// Gets the question the sample labels.
        /// </summary>
        [JsonIgnore]
        public LayaQuestion? Question
        {
            get
            {
                return question;
            }
        }

        /// <summary>
        /// Gets the state the question is asked about, as text.
        /// </summary>
        [JsonIgnore]
        public string? State
        {
            get
            {
                return state;
            }
        }

        /// <summary>
        /// Gets a value indicating whether <see cref="State"/> is a JSON object or array rather than plain text.
        /// </summary>
        [JsonIgnore]
        public bool StateIsJson
        {
            get
            {
                return stateIsJson;
            }
        }

        /// <summary>
        /// Gets the expected answer of a noul question.
        /// </summary>
        [JsonIgnore]
        public bool? Truth
        {
            get
            {
                return truth;
            }
        }
    }
}
