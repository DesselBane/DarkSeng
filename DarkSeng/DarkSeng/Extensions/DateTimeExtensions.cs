using System;

namespace DarkSeng.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Gets the first day of this month as a DateTime
        /// </summary>
        /// <returns>First day of Month</returns>
        public static DateTime FirstCalandarDayOfMonth(this DateTime dayInMonth)
        {
            return (new DateTime(dayInMonth.Year, dayInMonth.Month, 01).AddDays(-1 * (((int)new DateTime(dayInMonth.Year, dayInMonth.Month, 01).DayOfWeek + 6) % 7)));
        }

        /// <summary>
        /// Gets the first day of the week as DateTime
        /// </summary>
        /// <returns>First day of Week as DateTime</returns>
        public static DateTime FirstDayOfWeek(this DateTime dayInWeek)
        {
            return (dayInWeek.AddDays(-1 * (((int)dayInWeek.DayOfWeek + 6) % 7)));
        }
    }
}
