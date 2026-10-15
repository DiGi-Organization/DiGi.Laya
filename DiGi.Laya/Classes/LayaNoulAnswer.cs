using DiGi.Laya.Enums;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents the answer to a <see cref="LayaNoulQuestion"/>: the probability that the statement is true.
    /// </summary>
    public class LayaNoulAnswer : LayaAnswer
    {
        [JsonInclude, JsonPropertyName(nameof(Probability))]
        private readonly double? probability;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaNoulAnswer"/> class.
        /// </summary>
        /// <param name="name">The name of the question answered.</param>
        /// <param name="confidence">The confidence Laya reports, the larger of the probabilities of true and false, or <c>null</c> when not reported.</param>
        /// <param name="answerConfidence">The confidence Laya reports for the answer itself, or <c>null</c> when not reported.</param>
        /// <param name="probability">The probability that the statement is true, between 0 and 1.</param>
        public LayaNoulAnswer(string? name, double? confidence, double? answerConfidence, double? probability)
            : base(name, confidence, answerConfidence)
        {
            this.probability = probability;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaNoulAnswer"/> class by copying an existing answer.
        /// </summary>
        /// <param name="layaNoulAnswer">The source answer to copy from.</param>
        public LayaNoulAnswer(LayaNoulAnswer? layaNoulAnswer)
            : base(layaNoulAnswer)
        {
            if (layaNoulAnswer != null)
            {
                probability = layaNoulAnswer.probability;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaNoulAnswer"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the answer data.</param>
        public LayaNoulAnswer(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the probability that the statement is true, between 0 and 1 (Laya's <c>noul</c>).
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
        /// Gets <see cref="LayaQuestionType.Noul"/>.
        /// </summary>
        [JsonIgnore]
        public override LayaQuestionType QuestionType
        {
            get
            {
                return LayaQuestionType.Noul;
            }
        }
    }
}
