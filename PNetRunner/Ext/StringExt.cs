namespace PNetRunner.Ext
{
    /// <summary>
    /// Provides extension methods for string manipulation.
    /// </summary>
    public static class StringExt
    {
        /// <summary>
        /// Converts the string to a hyperlink reference (href) format.
        /// </summary>
        /// <param name="str">The input string.</param>
        /// <param name="addHttp">Specifies whether to add "http://" to the string.</param>
        /// <param name="toReplace">The strings to be replaced in the input string.</param>
        /// <returns>The converted string in href format.</returns>
        public static string AsHref(this string str, bool addHttp, params string[] toReplace)
        {
            foreach (var rep in toReplace)
            {
                str = str.Replace(rep, string.Empty);
            }

            if (addHttp)
            {
                str = "http://" + str;
            }

            return str;
        }
    }
}
