namespace PropertyManagement.Common.Extensions
{
    using System;
    
    public static class DateTimeExtensions
    {

        /// <summary>
        /// Gets the last month end date.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static DateTime GetLastMonthEndDate(this DateTime input)
        {
            return new DateTime(input.Year, input.Month, 1).AddDays(-1);
        }
    }
}
