using DiGi.Laya.Classes;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace DiGi.Laya
{
    public static partial class Convert
    {
        /// <summary>
        /// Converts one line predict.py writes to responses.jsonl into a <see cref="Classes.LayaResponse"/>.
        /// <para>The line is the result of Laya's <c>predict</c>/<c>predict_batch</c> plus the request id: <c>{"id": …, "answers": {name: answer}, "usage": {"input_tokens": …, "truncated": …}}</c>. Each answer is read by its <c>type</c> (laya 0.4.7): a <c>choice</c> answer's label from <c>choice</c> and its probabilities from <c>probabilities</c> in document order (Laya writes them in criteria order); a <c>score</c> answer's expected level from <c>score</c> and its distribution from <c>probabilities</c> keyed by level index; a <c>noul</c> answer's probability from <c>noul</c>; every answer's <c>confidence</c> and <c>answer_confidence</c>. Answers keep their document order.</para>
        /// <para>Numbers are read from their JSON text with <see cref="CultureInfo.InvariantCulture"/>, so a node built in memory and the same node parsed from a file give the same values and the current culture plays no part. An answer of an unknown type, or one that is not an object, is skipped rather than failing the response: a missing answer is reported by the caller, which knows the questions it asked.</para>
        /// </summary>
        /// <param name="jsonObject">The response line to convert.</param>
        /// <returns>The response, or <c>null</c> when <paramref name="jsonObject"/> is <c>null</c>.</returns>
        public static LayaResponse? ToDiGi_LayaResponse(this JsonObject? jsonObject)
        {
            if (jsonObject == null)
            {
                return null;
            }

            static double? Number(JsonNode? jsonNode)
            {
                if (jsonNode is not JsonValue jsonValue || jsonValue.GetValueKind() != JsonValueKind.Number)
                {
                    return null;
                }

                return double.TryParse(jsonValue.ToJsonString(), NumberStyles.Float, CultureInfo.InvariantCulture, out double value) ? value : null;
            }

            static string? Text(JsonNode? jsonNode)
            {
                if (jsonNode is not JsonValue jsonValue)
                {
                    return null;
                }

                //Laya accepts a number or bool as a choice label and answers with the same scalar, so anything that is not a string keeps its JSON text
                return jsonValue.GetValueKind() == JsonValueKind.String ? jsonValue.GetValue<string>() : jsonValue.ToJsonString();
            }

            List<LayaAnswer> layaAnswers = [];
            if (jsonObject["answers"] is JsonObject jsonObject_Answers)
            {
                foreach (KeyValuePair<string, JsonNode?> keyValuePair in jsonObject_Answers)
                {
                    if (keyValuePair.Value is not JsonObject jsonObject_Answer)
                    {
                        continue;
                    }

                    string name = keyValuePair.Key;
                    double? confidence = Number(jsonObject_Answer["confidence"]);
                    double? answerConfidence = Number(jsonObject_Answer["answer_confidence"]);
                    JsonObject? jsonObject_Probabilities = jsonObject_Answer["probabilities"] as JsonObject;

                    switch (Text(jsonObject_Answer["type"]))
                    {
                        case "choice":
                            List<LayaProbability>? layaProbabilities = null;
                            if (jsonObject_Probabilities != null)
                            {
                                layaProbabilities = [];
                                foreach (KeyValuePair<string, JsonNode?> keyValuePair_Probability in jsonObject_Probabilities)
                                {
                                    double? value = Number(keyValuePair_Probability.Value);
                                    if (value != null)
                                    {
                                        layaProbabilities.Add(new LayaProbability(keyValuePair_Probability.Key, value.Value));
                                    }
                                }
                            }

                            layaAnswers.Add(new LayaChoiceAnswer(name, confidence, answerConfidence, Text(jsonObject_Answer["choice"]), layaProbabilities));
                            break;

                        case "score":
                            List<double>? distribution = null;
                            if (jsonObject_Probabilities != null)
                            {
                                SortedDictionary<int, double> values = [];
                                foreach (KeyValuePair<string, JsonNode?> keyValuePair_Probability in jsonObject_Probabilities)
                                {
                                    double? value = Number(keyValuePair_Probability.Value);
                                    if (value != null && int.TryParse(keyValuePair_Probability.Key, NumberStyles.None, CultureInfo.InvariantCulture, out int index))
                                    {
                                        values[index] = value.Value;
                                    }
                                }

                                //Indexed by level, so a gap would shift every later level onto the wrong index: only a contiguous run from level 0 is a distribution
                                distribution = values.Keys.Select((index, position) => index == position).All(x => x) ? [.. values.Values] : null;
                            }

                            layaAnswers.Add(new LayaScoreAnswer(name, confidence, answerConfidence, Number(jsonObject_Answer["score"]), distribution));
                            break;

                        case "noul":
                            layaAnswers.Add(new LayaNoulAnswer(name, confidence, answerConfidence, Number(jsonObject_Answer["noul"])));
                            break;
                    }
                }
            }

            JsonObject? jsonObject_Usage = jsonObject["usage"] as JsonObject;
            double? inputTokenCount = Number(jsonObject_Usage?["input_tokens"]);

            bool? truncated = null;
            if (jsonObject_Usage?["truncated"] is JsonValue jsonValue_Truncated)
            {
                JsonValueKind jsonValueKind = jsonValue_Truncated.GetValueKind();
                truncated = jsonValueKind == JsonValueKind.True ? true : jsonValueKind == JsonValueKind.False ? false : null;
            }

            return new LayaResponse(Text(jsonObject["id"]), layaAnswers, inputTokenCount == null ? null : (int)inputTokenCount.Value, truncated);
        }
    }
}
