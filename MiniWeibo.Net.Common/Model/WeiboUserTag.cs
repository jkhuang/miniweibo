/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboUserTag.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-04-02 09:29:28
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
    public class WeiboUserTag : IWeiboModel
    {
        [DataMember]
        public long UserTagId { get; set; }

        [DataMember]
        public string UserTagName { get; set; }

        [DataMember]
        public int Weight { get; set; }

        public string RawSource { get; set; }
    }
}
