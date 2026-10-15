using System;

namespace DiGi.Laya
{
    public static partial class Query
    {
        /// <summary>
        /// Quotes one command-line argument for a script, so that a path with spaces stays one argument.
        /// <para>A trailing backslash is doubled, since a backslash before the closing quote would escape it - a drive root such as D:\ would otherwise swallow the rest of the command line. Windows paths cannot contain a quote, so nothing else is escaped.</para>
        /// </summary>
        /// <param name="value">The argument.</param>
        /// <returns>The quoted argument; <c>""</c> for <c>null</c>.</returns>
        public static string QuotedArgument(string? value)
        {
            if (value == null)
            {
                return "\"\"";
            }

            return string.Concat("\"", value.EndsWith("\\", StringComparison.Ordinal) ? string.Concat(value, "\\") : value, "\"");
        }
    }
}
