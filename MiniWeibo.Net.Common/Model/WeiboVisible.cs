/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboVisible.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-01-16 09:10:50
 * *******************************************************************/

using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MiniWeibo.Net.Common
{
    [Serializable]
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class WeiboVisible
    {
        [DataMember]
        public int Type { get; set; }

        [DataMember]
        public long ListId { get; set; }

        [DataMember]
        public string listIdString { get; set; }
    }
}
