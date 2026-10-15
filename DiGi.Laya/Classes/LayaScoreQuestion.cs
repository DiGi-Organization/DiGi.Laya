using DiGi.Laya.Enums;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents a question answered on an ordered scale of levels, lowest first.
    /// </summary>
    public class LayaScoreQuestion : LayaQuestion
    {
        [JsonInclude, JsonPropertyName(nameof(Levels))]
        private readonly List<string>? levels;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaScoreQuestion"/> class.
        /// </summary>
        /// <param name="name">The name the question is asked and answered under, unique within one request.</param>
        /// <param name="instructions">The instructions telling the model what to rate.</param>
        /// <param name="levels">The descriptions of the levels, lowest first; a level is answered by its zero-based index.</param>
        public LayaScoreQuestion(string? name, string? instructions, IEnumerable<string>? levels)
            : base(name, instructions)
        {
            this.levels = levels == null ? null : [.. levels];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaScoreQuestion"/> class by copying an existing question.
        /// </summary>
        /// <param name="layaScoreQuestion">The source question to copy from.</param>
        public LayaScoreQuestion(LayaScoreQuestion? layaScoreQuestion)
            : base(layaScoreQuestion)
        {
            if (layaScoreQuestion?.levels != null)
            {
                levels = [.. layaScoreQuestion.levels];
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaScoreQuestion"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the question data.</param>
        public LayaScoreQuestion(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the descriptions of the levels, lowest first; a level is answered by its zero-based index.
        /// </summary>
        [JsonIgnore]
        public List<string>? Levels
        {
            get
            {
                return levels;
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
