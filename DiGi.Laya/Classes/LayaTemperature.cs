using DiGi.Core.Classes;
using DiGi.Laya.Enums;
using DiGi.Laya.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Laya.Classes
{
    /// <summary>
    /// Represents the calibration temperature of one question type: the logits are divided by it before the softmax.
    /// <para>A value at a bound usually means the data could not place it - too few records of that type - rather than that the model needs it.</para>
    /// </summary>
    public class LayaTemperature : SerializableObject, ILayaSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(QuestionType))]
        private readonly LayaQuestionType questionType;

        [JsonInclude, JsonPropertyName(nameof(Value))]
        private readonly double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaTemperature"/> class.
        /// </summary>
        /// <param name="questionType">The question type the temperature applies to.</param>
        /// <param name="value">The temperature, clamped by laya to [0.5, 5.0]; 1 leaves the probabilities as the model gives them.</param>
        public LayaTemperature(LayaQuestionType questionType, double value)
        {
            this.questionType = questionType;
            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaTemperature"/> class by copying an existing instance.
        /// </summary>
        /// <param name="layaTemperature">The source instance to copy from.</param>
        public LayaTemperature(LayaTemperature? layaTemperature)
            : base(layaTemperature)
        {
            if (layaTemperature != null)
            {
                questionType = layaTemperature.questionType;
                value = layaTemperature.value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayaTemperature"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data.</param>
        public LayaTemperature(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the question type the temperature applies to.
        /// </summary>
        [JsonIgnore]
        public LayaQuestionType QuestionType
        {
            get
            {
                return questionType;
            }
        }

        /// <summary>
        /// Gets the temperature, clamped by laya to [0.5, 5.0]; 1 leaves the probabilities as the model gives them.
        /// </summary>
        [JsonIgnore]
        public double Value
        {
            get
            {
                return value;
            }
        }
    }
}
