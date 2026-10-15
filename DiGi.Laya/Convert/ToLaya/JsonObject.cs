using DiGi.Laya.Classes;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace DiGi.Laya
{
    public static partial class Convert
    {
        /// <summary>
        /// Converts a question into the definition Laya reads under its name in a request's <c>questions</c> object.
        /// <para>A choice question becomes <c>{"type": "choice", "instructions": …, "criteria": {label: description}}</c> with the criteria in their order (a <c>null</c> description stays <c>null</c>, which Laya accepts); a score question becomes <c>{"type": "score", "instructions": …, "criteria": [level, …]}</c>, lowest first; a noul question becomes <c>{"type": "noul", "instructions": statement}</c>. The name is not part of the definition - it is the key the definition is filed under.</para>
        /// <para>Mirrors the checks Laya's <c>Agent._check_question</c> applies, so a question Laya would refuse is refused here instead of failing a whole batch in the CPython process.</para>
        /// </summary>
        /// <param name="layaQuestion">The question to convert.</param>
        /// <returns>The question definition, or <c>null</c> when the question is <c>null</c>, has a blank name or blank instructions, is a choice question without criteria or with a <c>null</c> or repeated label, or is a score question without levels or with a <c>null</c> level.</returns>
        public static JsonObject? ToLaya_JsonObject(this LayaQuestion? layaQuestion)
        {
            if (layaQuestion == null || string.IsNullOrWhiteSpace(layaQuestion.Name) || string.IsNullOrWhiteSpace(layaQuestion.Instructions))
            {
                return null;
            }

            JsonObject jsonObject = [];

            if (layaQuestion is LayaChoiceQuestion layaChoiceQuestion)
            {
                List<LayaCriterion>? layaCriteria = layaChoiceQuestion.Criteria;
                if (layaCriteria == null || layaCriteria.Count == 0)
                {
                    return null;
                }

                JsonObject jsonObject_Criteria = [];
                foreach (LayaCriterion layaCriterion in layaCriteria)
                {
                    string? label = layaCriterion?.Label;
                    if (label == null || jsonObject_Criteria.ContainsKey(label))
                    {
                        return null;
                    }

                    jsonObject_Criteria[label] = layaCriterion!.Description == null ? null : JsonValue.Create(layaCriterion.Description);
                }

                jsonObject["type"] = "choice";
                jsonObject["instructions"] = layaQuestion.Instructions;
                jsonObject["criteria"] = jsonObject_Criteria;
            }
            else if (layaQuestion is LayaScoreQuestion layaScoreQuestion)
            {
                List<string>? levels = layaScoreQuestion.Levels;
                if (levels == null || levels.Count == 0)
                {
                    return null;
                }

                JsonArray jsonArray_Levels = [];
                foreach (string level in levels)
                {
                    if (level == null)
                    {
                        return null;
                    }

                    jsonArray_Levels.Add(level);
                }

                jsonObject["type"] = "score";
                jsonObject["instructions"] = layaQuestion.Instructions;
                jsonObject["criteria"] = jsonArray_Levels;
            }
            else if (layaQuestion is LayaNoulQuestion)
            {
                jsonObject["type"] = "noul";
                jsonObject["instructions"] = layaQuestion.Instructions;
            }
            else
            {
                return null;
            }

            return jsonObject;
        }

        /// <summary>
        /// Converts a request into the line predict.py reads from requests.jsonl.
        /// <para>The line is Laya's request shape plus the fields predict.py needs to batch and match it: <c>{"id": …, "state": …, "questions": {name: definition}, "max_len": …, "head_max_len": …}</c>. <c>questions</c> is an object keyed by <see cref="LayaQuestion.Name"/> in question order, each definition from <see cref="ToLaya_JsonObject(LayaQuestion?)"/>; the state comes from <see cref="ToLaya_JsonNode(string?, bool)"/>; <c>max_len</c> and <c>head_max_len</c> are written only when set, so predict.py falls back to the checkpoint's own budgets.</para>
        /// <para>This method and <see cref="ToDiGi_LayaResponse(JsonObject?)"/> are, with <see cref="ToLaya_TrainingLine(LayaTrainingSample?)"/>, the only code that knows Laya's JSON.</para>
        /// </summary>
        /// <param name="layaRequest">The request to convert.</param>
        /// <returns>The request line, or <c>null</c> when the request is <c>null</c>, has no usable state or no questions, holds a question <see cref="ToLaya_JsonObject(LayaQuestion?)"/> refuses, or names two questions alike.</returns>
        public static JsonObject? ToLaya_JsonObject(this LayaRequest? layaRequest)
        {
            if (layaRequest == null)
            {
                return null;
            }

            JsonNode? jsonNode_State = layaRequest.State.ToLaya_JsonNode(layaRequest.StateIsJson);
            if (jsonNode_State == null)
            {
                return null;
            }

            List<LayaQuestion>? layaQuestions = layaRequest.Questions;
            if (layaQuestions == null || layaQuestions.Count == 0)
            {
                return null;
            }

            JsonObject jsonObject_Questions = [];
            foreach (LayaQuestion layaQuestion in layaQuestions)
            {
                JsonObject? jsonObject_Question = layaQuestion.ToLaya_JsonObject();
                if (jsonObject_Question == null || jsonObject_Questions.ContainsKey(layaQuestion.Name!))
                {
                    return null;
                }

                jsonObject_Questions[layaQuestion.Name!] = jsonObject_Question;
            }

            JsonObject jsonObject = [];
            if (layaRequest.Id != null)
            {
                jsonObject["id"] = layaRequest.Id;
            }

            jsonObject["state"] = jsonNode_State;
            jsonObject["questions"] = jsonObject_Questions;

            if (layaRequest.MaxLength != null)
            {
                jsonObject["max_len"] = layaRequest.MaxLength.Value;
            }

            if (layaRequest.HeadMaxLength != null)
            {
                jsonObject["head_max_len"] = layaRequest.HeadMaxLength.Value;
            }

            return jsonObject;
        }
    }
}
