/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboRelationSource.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-03-24 11:00:23
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
    public class WeiboRelationSource
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string ScreenName { get; set; }

        [DataMember]
        public bool FollowedBy { get; set; }

        [DataMember]
        public bool Following { get; set; }

        [DataMember]
        public bool NotificationsEnabled { get; set; }
    }
}
