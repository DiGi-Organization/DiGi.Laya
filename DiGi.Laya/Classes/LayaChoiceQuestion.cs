using DiGi.Laya.Enums;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents a question answered by choosing one of a closed set of labelled options.
    /// <para>Laya's accuracy drops sharply past about 20 short options in one question and it refuses more than 100.</para>
    /// </summary>
    public class LayaChoiceQuestion : LayaQuestion
    {
        [JsonInclude, JsonPropertyName(nameof(Criteria))]
        private readonly List<LayaCriterion>? criteria;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaChoiceQuestion"/> class.
        /// </summary>
        /// <param name="name">The name the question is asked and answered under, unique within one request.</param>
        /// <param name="instructions">The instructions telling the model what to decide.</param>
        /// <param name="criteria">The options to choose from, in the order they are shown to the model.</param>
        public LayaChoiceQuestion(string? name, string? instructions, IEnumerable<LayaCriterion>? criteria)
            : base(name, instructions)
        {
            this.criteria = criteria == null ? null : [.. criteria];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaChoiceQuestion"/> class by copying an existing question.
        /// </summary>
        /// <param name="layaChoiceQuestion">The source question to copy from.</param>
        public LayaChoiceQuestion(LayaChoiceQuestion? layaChoiceQuestion)
            : base(layaChoiceQuestion)
        {
            if (layaChoiceQuestion?.criteria != null)
            {
                criteria = [];
                foreach (LayaCriterion layaCriterion in layaChoiceQuestion.criteria)
                {
                    if (Core.Query.Clone(layaCriterion) is LayaCriterion layaCriterion_Clone)
                    {
                        criteria.Add(layaCriterion_Clone);
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaChoiceQuestion"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the question data.</param>
        public LayaChoiceQuestion(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the options to choose from, in the order they are shown to the model.
        /// </summary>
        [JsonIgnore]
        public List<LayaCriterion>? Criteria
        {
            get
            {
                return criteria;
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
