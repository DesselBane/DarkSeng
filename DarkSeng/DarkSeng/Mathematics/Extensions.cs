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

        /// <summary>
        /// Check if a number is a prime number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsPrime(this int number)
        {
            int boundary = (int)Math.Floor(Math.Sqrt(number));

            if (number == 0) return false;
            if (number == 1) return false;
            if (number == 2) return true;

            for (int i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        /// <summary>
        /// Returns the number of divisors.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static public int NumberOfDivisors(int number)
        {
            int nod = 0;
            int sqrt = (int)Math.Sqrt(number);

            for (int i = 1; i <= sqrt; i++)
            {
                if (number % i == 0)
                {
                    nod += 2;
                }
            }
            //Correction if the number is a perfect square
            if (sqrt * sqrt == number)
            {
                nod--;
            }

            return nod;
        }
    }
}
