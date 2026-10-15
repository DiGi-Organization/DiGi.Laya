using DiGi.Laya.Enums;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents the answer to a <see cref="LayaScoreQuestion"/>: the expected level and the probability of every level.
    /// </summary>
    public class LayaScoreAnswer : LayaAnswer
    {
        [JsonInclude, JsonPropertyName(nameof(Distribution))]
        private readonly List<double>? distribution;

        [JsonInclude, JsonPropertyName(nameof(Level))]
        private readonly double? level;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaScoreAnswer"/> class.
        /// </summary>
        /// <param name="name">The name of the question answered.</param>
        /// <param name="confidence">The confidence Laya derives from the probability distribution, or <c>null</c> when not reported.</param>
        /// <param name="answerConfidence">The confidence Laya reports for the answer itself, or <c>null</c> when not reported.</param>
        /// <param name="level">The expected level, the probability-weighted mean of the zero-based level indexes.</param>
        /// <param name="distribution">The probability of every level, indexed by zero-based level.</param>
        public LayaScoreAnswer(string? name, double? confidence, double? answerConfidence, double? level, IEnumerable<double>? distribution)
            : base(name, confidence, answerConfidence)
        {
            this.level = level;
            this.distribution = distribution == null ? null : [.. distribution];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaScoreAnswer"/> class by copying an existing answer.
        /// </summary>
        /// <param name="layaScoreAnswer">The source answer to copy from.</param>
        public LayaScoreAnswer(LayaScoreAnswer? layaScoreAnswer)
            : base(layaScoreAnswer)
        {
            if (layaScoreAnswer != null)
            {
                distribution = layaScoreAnswer.distribution == null ? null : [.. layaScoreAnswer.distribution];
                level = layaScoreAnswer.level;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaScoreAnswer"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the answer data.</param>
        public LayaScoreAnswer(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the probability of every level, indexed by zero-based level.
        /// </summary>
        [JsonIgnore]
        public List<double>? Distribution
        {
            get
            {
                return distribution;
            }
        }

        /// <summary>
        /// Gets the expected level, the probability-weighted mean of the zero-based level indexes (Laya's <c>score</c>).
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
        /// Gets <see cref="LayaQuestionType.Score"/>.
        /// </summary>
        [JsonIgnore]
        public override LayaQuestionType QuestionType
        {
            get
            {
                return LayaQuestionType.Score;
            }
        }
    }
}
