/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboTrends.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-04-01 09:18:37
 * *******************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MiniWeibo.Net.Common
{
    [Serializable]
    [DataContract]
    [DebuggerDisplay("{User.ScreenName}: {Text}")]
    [JsonObject(MemberSerialization.OptIn)]
    public class WeiboTrends : IWeiboModel, IEnumerable<WeiboTrend> 
    {
        private DateTime _asOf;

        public virtual List<WeiboTrend> Trends { get; set; }

        public WeiboTrends()
        {
            Initialize();
        }

        private void Initialize()
        {
            Trends = new List<WeiboTrend>(0);
        }

        public string RawSource { get; set; }

        public DateTime AsOf
        {
            get { return _asOf; }
            set { _asOf = value; }
        }

        public IEnumerator<WeiboTrend> GetEnumerator()
        {
            return Trends.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
