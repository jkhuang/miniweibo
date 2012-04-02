using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniWeibo.Net.Common
{
    using System.ComponentModel;
    using System.Runtime.Serialization;

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
#region Properties

        public virtual WeiboDateFormat DateFormat { get; private set; }

        public virtual DateTime DateTime { get; private set; }


#endregion

#region Members

        public static string ConvertFromDateTime(DateTime input, WeiboDateFormat dateFormat)
        {
            
        }

#endregion
    }
}
