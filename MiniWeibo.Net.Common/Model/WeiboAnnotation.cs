/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboAnnotation.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-01-16 09:12:27
 * *******************************************************************/

using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MiniWeibo.Net.Common
{
    [Serializable]
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class WeiboAnnotation
    {
        [DataMember]
        public string Fid { get; set; }
    }
}
