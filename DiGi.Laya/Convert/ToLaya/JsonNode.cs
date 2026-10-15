using System.Text.Json;
using System.Text.Json.Nodes;

namespace DiGi.Laya
{
    public static partial class Convert
    {
        /// <summary>
        /// Converts a state held as text into the JSON node Laya reads as its state.
        /// <para>Laya encodes a JSON object or array state differently from a plain string, so a state flagged as JSON is parsed back into an object or array, and any other state becomes a JSON string.</para>
        /// </summary>
        /// <param name="state">The state as text.</param>
        /// <param name="stateIsJson">A value indicating whether <paramref name="state"/> is a JSON object or array rather than plain text.</param>
        /// <returns>The state node, or <c>null</c> when the state is <c>null</c>, blank, or flagged as JSON but not a well-formed JSON object or array.</returns>
        public static JsonNode? ToLaya_JsonNode(this string? state, bool stateIsJson)
        {
            if (string.IsNullOrWhiteSpace(state))
            {
                return null;
            }

            if (!stateIsJson)
            {
                return JsonValue.Create(state);
            }

            JsonNode? jsonNode;
            try
            {
                jsonNode = JsonNode.Parse(state!);
            }
            catch (JsonException)
            {
                return null;
            }

            return jsonNode is JsonObject || jsonNode is JsonArray ? jsonNode : null;
        }
    }
}
