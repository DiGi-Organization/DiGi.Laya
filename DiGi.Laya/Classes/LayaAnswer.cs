using DiGi.Core.Classes;
using DiGi.Laya.Enums;
using DiGi.Laya.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents the Laya decision model's answer to one named question.
    /// <para>The derived type matches the question type: <see cref="LayaChoiceAnswer"/>, <see cref="LayaScoreAnswer"/> or <see cref="LayaNoulAnswer"/>. A list of answers round-trips polymorphically through the type discriminator of the DiGi serializer.</para>
    /// <para>The DiGi serializer keys members by name across the hierarchy and lets the derived one win, so a derived type must not reuse <see cref="Name"/>, <see cref="Confidence"/> or <see cref="AnswerConfidence"/>.</para>
    /// </summary>
    public abstract class LayaAnswer : SerializableObject, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(AnswerConfidence))]
        private readonly double? answerConfidence;

        [JsonInclude, JsonPropertyName(nameof(Confidence))]
        private readonly double? confidence;

        [JsonInclude, JsonPropertyName(nameof(Name))]
        private readonly string? name;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaAnswer"/> class.
        /// </summary>
        /// <param name="name">The name of the question answered.</param>
        /// <param name="confidence">The confidence Laya derives from the answer's probability distribution, or <c>null</c> when not reported.</param>
        /// <param name="answerConfidence">The confidence Laya reports for the selected answer itself, or <c>null</c> when not reported.</param>
        protected LayaAnswer(string? name, double? confidence, double? answerConfidence)
        {
            this.name = name;
            this.confidence = confidence;
            this.answerConfidence = answerConfidence;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaAnswer"/> class by copying an existing answer.
        /// </summary>
        /// <param name="layaAnswer">The source answer to copy from.</param>
        protected LayaAnswer(LayaAnswer? layaAnswer)
            : base(layaAnswer)
        {
            if (layaAnswer != null)
            {
                answerConfidence = layaAnswer.answerConfidence;
                confidence = layaAnswer.confidence;
                name = layaAnswer.name;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaAnswer"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the answer data.</param>
        protected LayaAnswer(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the confidence Laya reports for the selected answer itself (its <c>answer_confidence</c>), or <c>null</c> when not reported.
        /// </summary>
        [JsonIgnore]
        public double? AnswerConfidence
        {
            get
            {
                return answerConfidence;
            }
        }

        /// <summary>
        /// Gets the confidence Laya derives from the answer's probability distribution (its <c>confidence</c>), or <c>null</c> when not reported.
        /// <para>The shipped checkpoints are uncalibrated and over-confident; read this only from a calibrated checkpoint.</para>
        /// </summary>
        [JsonIgnore]
        public double? Confidence
        {
            get
            {
                return confidence;
            }
        }

        /// <summary>
        /// Gets the name of the question answered.
        /// </summary>
        [JsonIgnore]
        public string? Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Gets the type of the question answered, fixed by the derived type.
        /// </summary>
        [JsonIgnore]
        public abstract LayaQuestionType QuestionType { get; }
    }
}
