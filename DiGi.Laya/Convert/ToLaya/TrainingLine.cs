using DiGi.Laya.Classes;
using System;
using System.Linq;
using System.Text.Json.Nodes;

namespace DiGi.Laya
{
    public static partial class Convert
    {
        /// <summary>
        /// Converts a training sample into one line of the JSONL file <c>laya.train.finetune</c> reads.
        /// <para>The line is the request shape plus the target Laya's <c>items_from_rows</c> reads: <c>{"id": …, "state": …, "questions": {name: definition}, "expected": {name: answer}}</c>, or <c>"gold": {name: {"probabilities": {"false": 1 - p, "true": p}}}</c> for a noul soft target. The expected answer is the label of a choice question, the zero-based level of a score question (a fractional level is written as is and split by Laya between its neighbours), and <c>true</c>/<c>false</c> for a noul question. Laya ignores <c>id</c>; it is written for tracing a line back to its sample.</para>
        /// <para>Numbers are written by <see cref="JsonValue"/>, never through <see cref="object.ToString"/>, so the line does not depend on the current culture. Non-ASCII text is escaped, which JSON readers decode.</para>
        /// </summary>
        /// <param name="layaTrainingSample">The sample to convert.</param>
        /// <returns>The JSONL line without a line terminator, or <c>null</c> when the sample is <c>null</c>, its state or question is refused by <see cref="ToLaya_JsonNode(string?, bool)"/> or <see cref="ToLaya_JsonObject(LayaQuestion?)"/>, or its target does not fit the question: a choice label that is not one of the criteria, a score level outside the levels or not finite, a noul question with neither a truth nor a probability between 0 and 1, or a probability on a question that is not a noul question.</returns>
        public static string? ToLaya_TrainingLine(this LayaTrainingSample? layaTrainingSample)
        {
            if (layaTrainingSample == null)
            {
                return null;
            }

            LayaQuestion? layaQuestion = layaTrainingSample.Question;

            JsonObject? jsonObject_Question = layaQuestion.ToLaya_JsonObject();
            if (jsonObject_Question == null)
            {
                return null;
            }

            JsonNode? jsonNode_State = layaTrainingSample.State.ToLaya_JsonNode(layaTrainingSample.StateIsJson);
            if (jsonNode_State == null)
            {
                return null;
            }

            if (layaTrainingSample.Probability != null && layaQuestion is not LayaNoulQuestion)
            {
                return null;
            }

            string name = layaQuestion!.Name!;

            string targetKey = "expected";
            JsonNode? jsonNode_Target = null;

            if (layaQuestion is LayaChoiceQuestion layaChoiceQuestion)
            {
                string? label = layaTrainingSample.Label;
                if (label == null || !layaChoiceQuestion.Criteria!.Any(x => x.Label == label))
                {
                    return null;
                }

                jsonNode_Target = JsonValue.Create(label);
            }
            else if (layaQuestion is LayaScoreQuestion layaScoreQuestion)
            {
                double? level = layaTrainingSample.Level;
                if (level == null || double.IsNaN(level.Value) || level.Value < 0 || level.Value > layaScoreQuestion.Levels!.Count - 1)
                {
                    return null;
                }

                //A whole level is written as an integer, the level index Laya documents; a fractional one as the double it is
                jsonNode_Target = level.Value == Math.Floor(level.Value) ? JsonValue.Create((int)level.Value) : JsonValue.Create(level.Value);
            }
            else if (layaQuestion is LayaNoulQuestion)
            {
                double? probability = layaTrainingSample.Probability;
                if (probability != null)
                {
                    if (double.IsNaN(probability.Value) || probability.Value < 0 || probability.Value > 1)
                    {
                        return null;
                    }

                    targetKey = "gold";
                    jsonNode_Target = new JsonObject
                    {
                        ["probabilities"] = new JsonObject
                        {
                            ["false"] = 1.0 - probability.Value,
                            ["true"] = probability.Value
                        }
                    };
                }
                else if (layaTrainingSample.Truth != null)
                {
                    jsonNode_Target = JsonValue.Create(layaTrainingSample.Truth.Value);
                }
                else
                {
                    return null;
                }
            }

            JsonObject jsonObject = [];
            if (layaTrainingSample.Id != null)
            {
                jsonObject["id"] = layaTrainingSample.Id;
            }

            jsonObject["state"] = jsonNode_State;
            jsonObject["questions"] = new JsonObject { [name] = jsonObject_Question };
            jsonObject[targetKey] = new JsonObject { [name] = jsonNode_Target };

            return jsonObject.ToJsonString();
        }
    }
}
