using System;
using System.Text;
using System.Text.RegularExpressions;

namespace DarkSeng.Parsing
{
    /// <summary>
    /// Class for parsing multiple things from strings
    /// </summary>
    public static class Parser
    {
        /// <summary>
        /// Removes numeric characters from the given string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveNumbers(string text)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var c in text)
                if (!char.IsDigit(c))
                    builder.Append(c);

            return builder.ToString();
        }

        /// <summary>
        /// Returns the string between two strings from the given string if those exist
        /// </summary>
        /// <param name="text">Text to search in</param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static string GetStringBetween(string text, string left, string right)
        {
            if (!text.ToUpper().Contains(left.ToUpper())) return string.Empty;
            if (!text.ToUpper().Contains(right.ToUpper())) return string.Empty;
            if (text.ToUpper().IndexOf(left.ToUpper()) >= text.ToUpper().IndexOf(right.ToUpper())) return string.Empty;

            int startIndex = text.ToUpper().IndexOf(left.ToUpper()) + left.Length;
            int endIndex = text.ToUpper().IndexOf(right.ToUpper());

            StringBuilder builder = new StringBuilder();

            for (int i = startIndex; i < endIndex; i++)
                builder.Append(text[i]);

            return builder.ToString();
        }

        /// <summary>
        /// Removes a standalone word from the given string.
        /// e.g.: "This is a string" with "is" as word parameter returns "This a string"
        /// </summary>
        /// <param name="text"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string SubstituteStandaloneWord(string text, string word)
        {
            string searchWord = word.Trim();
            string upperCaseText = text.ToUpper();

            if (searchWord.Contains(" ")) return text;
            if (!upperCaseText.Contains(searchWord.ToUpper())) return text;

            if (!upperCaseText.Contains(" " + searchWord.ToUpper() + " "))
            {
                if (upperCaseText.Contains(searchWord.ToUpper() + " ") &&
                    upperCaseText.IndexOf(searchWord.ToUpper()) != 0) return text;

                if (upperCaseText.Contains(" " + searchWord.ToUpper()) &&
                    upperCaseText.IndexOf(searchWord.ToUpper()) + searchWord.Length != text.Length) return text;

                if (!upperCaseText.Contains(" " + searchWord.ToUpper()) &&
                    !upperCaseText.Contains(searchWord.ToUpper() + " ")) return text;
            }

            StringBuilder regexBuilder = new StringBuilder();

            regexBuilder.Append('(');

            for (int i = 0; i < searchWord.Length; i++)
            {
                regexBuilder.Append("[");
                regexBuilder.Append(char.ToUpper(searchWord[i]));
                regexBuilder.Append(char.ToLower(searchWord[i]));
                regexBuilder.Append("]");
            }

            regexBuilder.Append(')');

            //Substitutes the word which got build before and replaces all multiple occuring whitespaces with a single whitespace
            return Regex.Replace(Regex.Replace(text, regexBuilder.ToString(), " ").Trim(), @"\s+", " ");
        }

        /// <summary>
        /// Removes the given characters from the given string
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="chars">Characters to remove</param>
        /// <returns></returns>
        public static string ParseCharacters(string text, params char[] chars)
        {
            StringBuilder builder = new StringBuilder(text);

            foreach (var character in chars)
                builder.Replace(character.ToString(), "");

            return builder.ToString();
        }
    }
}
