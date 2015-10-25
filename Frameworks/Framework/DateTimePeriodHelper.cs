using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework
{
    /// <summary>
    /// this class is used in specific situation
    /// </summary>
    public static class DateTimePeriodHelper
    {
        /// <summary>
        /// MinValueOfDateTimeInSQL
        /// </summary>
        public static DateTime MinValueOfDateTimeInSQL = new DateTime(1753, 1, 1, 0, 0, 0, 0);
        /// <summary>
        /// StartDateOfDatePeriodID
        /// </summary>
        public static DateTime StartDateOfDatePeriodID = new DateTime(1970, 1, 1, 0, 0, 0, 0);

        /// <summary>
        /// Gets the date period ID.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>DatePeriodID calculated</returns>
        public static long GetDatePeriodID(DateTime input)
        {
            return (input - StartDateOfDatePeriodID).Days + 1;
        }
        /// <summary>
        /// Gets the time period ID.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>TimePeriodID</returns>
        public static int GetTimePeriodID(DateTime input)
        {
            return (int)input.TimeOfDay.TotalMinutes;
        }

		/// <summary>
        /// Parses the date time.
        /// </summary>
        /// <param name="inputDateTimeInString">The input date time in string.</param>
        /// <returns>date time represented in the input string</returns>
        public static DateTime ParseDateTime(string inputDateTimeInString)
        {
            DateTime _retval;
            if (string.IsNullOrWhiteSpace(inputDateTimeInString))
            {
                _retval = DateTime.Now.AddDays(-1);
            }
            else
            {
                try
                {
                    _retval = DateTime.Parse(inputDateTimeInString);
                }
                catch
                {
                    _retval = DateTime.Now.AddDays(-1);
                }
            }
            return _retval;
        }
    }
}