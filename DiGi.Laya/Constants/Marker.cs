namespace DiGi.Laya.Constants
{
    /// <summary>
    /// Provides the marker lines the scripts print their JSON payload between.
    /// <para>The payload is read with DiGi.Python's <c>Query.MarkedJson</c>, which takes the last marker pair, so whatever laya, torch or transformers print before or after it is never parsed. The scripts print them through <c>print_marked_json</c> in files/Laya/utils.py.</para>
    /// </summary>
    public static class Marker
    {
        /// <summary>
        /// The line check.py prints before its payload.
        /// </summary>
        public const string CheckJsonBegin = "LAYA_CHECK_JSON_BEGIN";

        /// <summary>
        /// The line check.py prints after its payload.
        /// </summary>
        public const string CheckJsonEnd = "LAYA_CHECK_JSON_END";

        /// <summary>
        /// The line predict.py prints before its run summary.
        /// </summary>
        public const string PredictJsonBegin = "LAYA_PREDICT_JSON_BEGIN";

        /// <summary>
        /// The line predict.py prints after its run summary.
        /// </summary>
        public const string PredictJsonEnd = "LAYA_PREDICT_JSON_END";

        /// <summary>
        /// The line train.py prints before its report.
        /// </summary>
        public const string TrainJsonBegin = "LAYA_TRAIN_JSON_BEGIN";

        /// <summary>
        /// The line train.py prints after its report.
        /// </summary>
        public const string TrainJsonEnd = "LAYA_TRAIN_JSON_END";

        /// <summary>
        /// The line calibrate.py prints before its report.
        /// </summary>
        public const string CalibrateJsonBegin = "LAYA_CALIBRATE_JSON_BEGIN";

        /// <summary>
        /// The line calibrate.py prints after its report.
        /// </summary>
        public const string CalibrateJsonEnd = "LAYA_CALIBRATE_JSON_END";
    }
}
