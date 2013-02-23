/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboDateTime.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-02-10 09:00:05
 * *******************************************************************/

namespace MiniWeibo.Net.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Runtime.Serialization;
    using System.Threading;

    /// <summary>
    /// Represents the possible known date formats that Twitter reports.
    /// </summary>
    public enum WeiboDateFormat
    {
        /// <summary>
        /// RestApi
        /// </summary>
        [Description("ddd MMM dd HH:mm:ss zzzzz yyyy")]
        RestApi,

        /// <summary>
        /// SearchApi
        /// </summary>
        [Description("ddd, dd MMM yyyy HH:mm:ss zzzzz")]
        SearchApi,

        /// <summary>
        /// Atom
        /// </summary>
        [Description("yyyy-MM-ddTHH:mm:ssZ")]
        Atom,

        /// <summary>
        /// XmlHashesAndRss
        /// </summary>
        [Description("yyyy-MM-ddTHH:mm:sszzzzzz")]
        XmlHashesAndRss,

        /// <summary>
        /// TrendsCurrent
        /// </summary>
        [Description("ddd MMM dd HH:mm:ss zzzzz yyyy")]
        TrendsCurrent,

        /// <summary>
        /// TrendsDaily
        /// </summary>
        [Description("yyyy-MM-dd HH:mm")]
        TrendsDaily,

        /// <summary>
        /// TrendsWeekly
        /// </summary>
        [Description("yyyy-MM-dd")]
        TrendsWeekly
    }

    [DataContract]
    public class WeiboDateTime : IWeiboModel
    {

        #region Private fields

        /// <summary>
        /// The single object.
        /// </summary>
        private static readonly ReaderWriterLockSlim _readerWriterLock = new ReaderWriterLockSlim();

        /// <summary>
        /// Maintains the type of <see cref="WeiboDateFormat"/> in type name / description.
        /// </summary>
        private static readonly IDictionary<string, string> _map = new Dictionary<string, string>();

        #endregion

        #region Properties

        public virtual WeiboDateFormat Format { get; private set; }

        public virtual DateTime DateTime { get; private set; }

        public string RawSource { get; set; }

        #endregion

        #region Constructors

        public WeiboDateTime(DateTime dateTime, WeiboDateFormat format)
        {
            Format = format;
            DateTime = dateTime;
        }

        #endregion

        #region Members

        /// <summary>
        /// Converts from date time to string.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="dateFormat">The date format.</param>
        /// <returns>Converts date time to specifies format string.</returns>
        public static string ConvertFromDateTime(DateTime input, WeiboDateFormat dateFormat)
        {
            EnsureDateFormatsAreMapped();

            var name = Enum.GetName(typeof(WeiboDateFormat), dateFormat);

            GetReadLockOnMap();
            var value = _map[name];
            ReleaseReadLockOnMap();

            value = value.Replace(" zzzzz", " +0000");
            var converted = input.ToString(value, CultureInfo.InvariantCulture);
            return converted;

        }

        public static DateTime ConvertToDateTime(string input)
        {
            EnsureDateFormatsAreMapped();
            GetReadLockOnMap();
            var formats = _map.Values;
            ReleaseReadLockOnMap();
            foreach (var format in formats)
            {
                DateTime date;
                if (DateTime.TryParseExact(
                    input,
                    format,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.AdjustToUniversal,
                    out date))
                {
                    return date;
                }
            }
            return default(DateTime);
        }

        public static WeiboDateTime ConvertToWeiboDateTime(string input)
        {
            EnsureDateFormatsAreMapped();
            GetReadLockOnMap();
            try
            {
                foreach (var format in _map)
                {
                    DateTime date;
                    if (DateTime.TryParseExact(
                        input,
                        format.Value,
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.AdjustToUniversal,
                        out date))
                    {
                        var kind = Enum.Parse(typeof(WeiboDateFormat), format.Key, true);
                        return new WeiboDateTime(date, (WeiboDateFormat)kind);
                    }
                }

                return default(WeiboDateTime);
            }
            finally
            {
                ReleaseReadLockOnMap();
            }
        }

        private static void EnsureDateFormatsAreMapped()
        {
            var type = typeof(WeiboDateFormat);

            //// Get the fields name of WeiboDateFormat.
            var names = Enum.GetNames(type);

            GetReadLockOnMap();

            try
            {
                foreach (var name in names)
                {
                    if (_map.ContainsKey(name))
                    {
                        continue;
                    }

                    GetWriteLockOnMap();
                    try
                    {
                        var fi = typeof(WeiboDateFormat).GetField(name);

                        //// Get the attribute for WeiboDateTime's fields.
                        var attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        var format = (DescriptionAttribute)attributes[0];
                        _map.Add(name, format.Description);
                    }
                    finally
                    {
                        ReleaseWriteLockOnMap();
                    }

                }
            }
            finally
            {
                ReleaseReadLockOnMap();
            }
        }

        private static void GetReadLockOnMap()
        {
            _readerWriterLock.EnterUpgradeableReadLock();
        }

        private static void ReleaseReadLockOnMap()
        {
            _readerWriterLock.ExitUpgradeableReadLock();
        }

        private static void GetWriteLockOnMap()
        {
            _readerWriterLock.EnterWriteLock();
        }

        private static void ReleaseWriteLockOnMap()
        {
            _readerWriterLock.ExitWriteLock();
        }

        public override string ToString()
        {
            return ConvertFromDateTime(DateTime, Format);
        }

        #endregion


    }
}
