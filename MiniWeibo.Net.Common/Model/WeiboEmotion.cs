/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboEmotion.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-02-07 08:37:03
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
    public class WeiboEmotion : IWeiboModel
    {
        [DataMember]
        public string Category { get; set; }

        [DataMember]
        public bool Common { get; set; }

        [DataMember]
        public bool Hot { get; set; }

        [DataMember]
        public string Icon { get; set; }

        [DataMember]
        public string Phrase { get; set; }

        [DataMember]
        public string Picid { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public string Value { get; set; }

        public string RawSource { get; set; }
    }
}
