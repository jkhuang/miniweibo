/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboTrend.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-04-01 09:08:44
 * *******************************************************************/

using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MiniWeibo.Net.Common
{
    [Serializable]
    [DataContract]
    [DebuggerDisplay("{User.ScreenName}: {Text}")]
    [JsonObject(MemberSerialization.OptIn)]
    public class WeiboTrend : IWeiboModel
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Query { get; set; }

        [DataMember]
        public int Amount { get; set; }

        [DataMember]
        public int Delta { get; set; }

        [DataMember]
        public virtual DateTime TrendingAsOf { get; set; }

        public string RawSource { get; set; }
    }
}
