/******************************** Module Header ********************************
 * Module Name: TimeExtensions.cs
 * Project:     MiniWeibo.Net.Common
 * Copyright (c) Jackson Huang.
 * 
 * Code Logic:
 * 
 * 
 * Corresponding Source:
 * 
 * 
 * History:
 * 2012-1-29 12:14:49 Jackson Huang Created
 * Websiet:
 * http://www.cnblogs.com/rush/
 * *******************************************************************************/

namespace MiniWeibo.Net.Common
{
    using System;

    /// <summary>
    /// The time extension.
    /// </summary>
    internal static class TimeExtensions
    {
        /// <summary>
        /// Froms the unix time.
        /// </summary>
        /// <param name="seconds">The seconds.</param>
        /// <returns>The local time.</returns>
        public static DateTime FromUnixTime(this long seconds)
        {
            var time = new DateTime(1970, 1, 1);
            time = time.AddSeconds(seconds);
            return time.ToLocalTime();
        }

        /// <summary>
        /// Toes the unix time.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>The timestamp.</returns>
        public static long ToUnixTime(this DateTime dateTime)
        {
            var timeSpan = dateTime - new DateTime(1970, 1, 1);
            var timestamp = (long)timeSpan.TotalSeconds;
            return timestamp;
        }
    }
}