namespace DiGi.Laya
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the name the classification workflow asks a label set, or one label of it, under.
        /// <para>A single-choice set is one choice question named after the set; each label of a multi-label set is a noul question named "&lt;set id&gt;:&lt;label id&gt;". <see cref="Create.LayaRequests(System.Collections.Generic.IEnumerable{Classes.LayaItem}?, System.Collections.Generic.IEnumerable{Classes.LayaLabelSet}?)"/> writes the questions under these names and <see cref="LayaClassificationResults(Classes.LayaPredictionResult?, System.Collections.Generic.IEnumerable{Classes.LayaLabelSet}?, Classes.LayaClassificationOptions?)"/> reads the answers back by them, so both sides share this one rule. A set id must not contain the colon, or two questions could share a name.</para>
        /// </summary>
        /// <param name="labelSetId">The identifier of the label set.</param>
        /// <param name="labelId">The identifier of the label of a multi-label set, or <c>null</c> for a single-choice set.</param>
        /// <returns>The question name, or <c>null</c> when <paramref name="labelSetId"/> is <c>null</c>.</returns>
        public static string? LayaQuestionName(string? labelSetId, string? labelId)
        {
            if (labelSetId == null)
            {
                return null;
            }

            return labelId == null ? labelSetId : string.Concat(labelSetId, ":", labelId);
        }
    }
}
