
using System.Globalization;

namespace SBase.Helper
{
    public class DateTimeHelper
    {
        /// <summary>
        /// Gets the first day of the week.
        /// </summary>
        /// <returns></returns>
        public static DateTime GetFirstDayOfWeek()
        {
            var d = DateTime.UtcNow;

            var culture = CultureInfo.CurrentCulture;
            var diff = d.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0)
                diff += 7;
            d = d.AddDays(-diff).Date;

            return d;
        }
    }
}
