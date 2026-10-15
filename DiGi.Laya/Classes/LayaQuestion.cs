using DiGi.Core.Classes;
using DiGi.Laya.Enums;
using DiGi.Laya.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents one named question asked of the Laya decision model about a state.
    /// <para>The derived type decides the question type and what it carries: <see cref="LayaChoiceQuestion"/>, <see cref="LayaScoreQuestion"/> or <see cref="LayaNoulQuestion"/>. A list of questions round-trips polymorphically through the type discriminator of the DiGi serializer.</para>
    /// <para>The DiGi serializer keys members by name across the hierarchy and lets the derived one win, so a derived type must not reuse <see cref="Name"/> or <see cref="Instructions"/>.</para>
    /// </summary>
    public abstract class LayaQuestion : SerializableObject, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Instructions))]
        private readonly string? instructions;

        [JsonInclude, JsonPropertyName(nameof(Name))]
        private readonly string? name;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaQuestion"/> class.
        /// </summary>
        /// <param name="name">The name the question is asked and answered under, unique within one request.</param>
        /// <param name="instructions">The instructions telling the model what to decide.</param>
        protected LayaQuestion(string? name, string? instructions)
        {
            this.name = name;
            this.instructions = instructions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaQuestion"/> class by copying an existing question.
        /// </summary>
        /// <param name="layaQuestion">The source question to copy from.</param>
        protected LayaQuestion(LayaQuestion? layaQuestion)
            : base(layaQuestion)
        {
            if (layaQuestion != null)
            {
                instructions = layaQuestion.instructions;
                name = layaQuestion.name;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaQuestion"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the question data.</param>
        protected LayaQuestion(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the instructions telling the model what to decide.
        /// <para>For a <see cref="LayaNoulQuestion"/> this is the statement judged true or false.</para>
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
        /// Gets the name the question is asked and answered under, unique within one request.
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
        /// Gets the type of the question, fixed by the derived type.
        /// </summary>
        [JsonIgnore]
        public abstract LayaQuestionType QuestionType { get; }
    }
}
