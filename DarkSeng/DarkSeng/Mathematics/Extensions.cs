using System;
using System.Text.RegularExpressions;

namespace DarkSeng.Mathematics
{
    public static class Extensions
    {
        /// <summary>
        /// Check if a string is numeric
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string text)
        {
            return Regex.IsMatch(text, @"^-*[\d]+$");
        }

        /// <summary>
        /// Check if a string is palindromic e.g. "12d3d21"
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsPalindrome(this string text)
        {
            for (int i = 0; i < text.Length / 2; i++)
                if (text[i] != text[text.Length - 1 - i])
                    return false;

            return true;
        }
    }
}
