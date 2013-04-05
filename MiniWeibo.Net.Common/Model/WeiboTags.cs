/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboTags.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-03-28 09:17:03
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
    public class WeiboTags : IWeiboModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public string Tag { get; set; }

        [DataMember]
        public int? Count { get; set; }

        [DataMember]
        public int? Num { get; set; }

        public string RawSource { get; set; }
    }
}
