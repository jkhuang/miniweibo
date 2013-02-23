/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboComment.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-02-09 04:42:02
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
    public class WeiboComment : IWeiboModel
    {
        [DataMember]
        public DateTime CreatedAt { get; set; }

        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public string Source { get; set; }

        [DataMember]
        public WeiboUser User { get; set; }

        [DataMember]
        public long? Mid { get; set; }

        [DataMember]
        public string Idstr { get; set; }

        [DataMember]
        public WeiboStatus Status { get; set; }

        [DataMember]
        public WeiboComment ReplyComment { get; set; }

        public string RawSource { get; set; }
    }
}
