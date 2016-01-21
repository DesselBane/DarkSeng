using System;

namespace DarkSeng.Custom
{
    public static class EnumHelper
    {
        /// <summary>
        /// Returns the enum value from the given string
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        /// <param name="value">String containing an enum value</param>
        /// <returns></returns>
        public static T Parse<T>(string value)
            where T : struct
        {
            T parseTest;

            if (Enum.TryParse(value, out parseTest))
                return (T)Enum.Parse(typeof(T), value);
            else
                return default(T);
        }
    }
}
