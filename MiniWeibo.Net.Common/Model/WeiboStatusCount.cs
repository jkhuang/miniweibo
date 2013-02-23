/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboStatusCount.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-02-06 09:27:48
 * *******************************************************************/

using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MiniWeibo.Net.Common
{
    [Serializable]
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class WeiboStatusCount : IWeiboModel
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public int Comments { get; set; }

        [DataMember]
        public int Reposts { get; set; }

        [DataMember]
        public int Attitudes { get; set; }

        public string RawSource { get; set; }
    }
}
