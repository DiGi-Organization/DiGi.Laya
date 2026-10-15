using DiGi.Laya.Enums;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents a statement the model judges true or false, answered with the probability that it is true.
    /// <para>The statement is <see cref="LayaQuestion.Instructions"/>; the question carries nothing else.</para>
    /// </summary>
    public class LayaNoulQuestion : LayaQuestion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LayaNoulQuestion"/> class.
        /// </summary>
        /// <param name="name">The name the question is asked and answered under, unique within one request.</param>
        /// <param name="instructions">The statement the model judges true or false.</param>
        public LayaNoulQuestion(string? name, string? instructions)
            : base(name, instructions)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaNoulQuestion"/> class by copying an existing question.
        /// </summary>
        /// <param name="layaNoulQuestion">The source question to copy from.</param>
        public LayaNoulQuestion(LayaNoulQuestion? layaNoulQuestion)
            : base(layaNoulQuestion)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaNoulQuestion"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the question data.</param>
        public LayaNoulQuestion(JsonObject? jsonObject)
            : base(jsonObject)
        {
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
