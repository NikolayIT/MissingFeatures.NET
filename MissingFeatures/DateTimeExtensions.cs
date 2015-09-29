namespace MissingFeatures
{
    using System;

    public static class DateTimeExtensions
    {
        public static DateTime GetMonday(this DateTime dateTime)
        {
            int diff = (int)dateTime.DayOfWeek - (int)DayOfWeek.Monday;
            if (dateTime.DayOfWeek == DayOfWeek.Sunday)
            {
                diff = 6;
            }

            return dateTime.AddDays(-diff);
        }

        /// <summary>
        /// Converts a regular DateTime to a RFC822 date string.
        /// </summary>
        /// <param name="date">DateTime object to convert.</param>
        /// <returns>The specified date formatted as a RFC822 date string.</returns>
        public static string ToRFC822Date(this DateTime date)
        {
            int offset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).Hours;
            string timeZone = "+" + offset.ToString().PadLeft(2, '0');

            if (offset < 0)
            {
                int i = offset * -1;
                timeZone = "-" + i.ToString().PadLeft(2, '0');
            }

            return date.ToString("ddd, dd MMM yyyy HH:mm:ss " + timeZone.PadRight(5, '0'));
        }
    }
}
