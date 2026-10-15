using DiGi.Laya.Enums;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents the answer to a <see cref="LayaChoiceQuestion"/>: the selected label and the probability of every option.
    /// </summary>
    public class LayaChoiceAnswer : LayaAnswer
    {
        [JsonInclude, JsonPropertyName(nameof(Label))]
        private readonly string? label;

        [JsonInclude, JsonPropertyName(nameof(Probabilities))]
        private readonly List<LayaProbability>? probabilities;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaChoiceAnswer"/> class.
        /// </summary>
        /// <param name="name">The name of the question answered.</param>
        /// <param name="confidence">The confidence Laya derives from the probability distribution, or <c>null</c> when not reported.</param>
        /// <param name="answerConfidence">The confidence Laya reports for the selected label itself, or <c>null</c> when not reported.</param>
        /// <param name="label">The selected label, the option with the highest probability.</param>
        /// <param name="probabilities">The probability of every option, in the order of the question's criteria.</param>
        public LayaChoiceAnswer(string? name, double? confidence, double? answerConfidence, string? label, IEnumerable<LayaProbability>? probabilities)
            : base(name, confidence, answerConfidence)
        {
            this.label = label;
            this.probabilities = probabilities == null ? null : [.. probabilities];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaChoiceAnswer"/> class by copying an existing answer.
        /// </summary>
        /// <param name="layaChoiceAnswer">The source answer to copy from.</param>
        public LayaChoiceAnswer(LayaChoiceAnswer? layaChoiceAnswer)
            : base(layaChoiceAnswer)
        {
            if (layaChoiceAnswer != null)
            {
                label = layaChoiceAnswer.label;

                if (layaChoiceAnswer.probabilities != null)
                {
                    probabilities = [];
                    foreach (LayaProbability layaProbability in layaChoiceAnswer.probabilities)
                    {
                        if (Core.Query.Clone(layaProbability) is LayaProbability layaProbability_Clone)
                        {
                            probabilities.Add(layaProbability_Clone);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaChoiceAnswer"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the answer data.</param>
        public LayaChoiceAnswer(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the selected label, the option with the highest probability (Laya's <c>choice</c>).
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
        /// Gets the probability of every option, in the order of the question's criteria.
        /// </summary>
        [JsonIgnore]
        public List<LayaProbability>? Probabilities
        {
            get
            {
                return probabilities;
            }
        }

        /// <summary>
        /// Gets <see cref="LayaQuestionType.Choice"/>.
        /// </summary>
        [JsonIgnore]
        public override LayaQuestionType QuestionType
        {
            get
            {
                return LayaQuestionType.Choice;
            }
        }
    }
}
