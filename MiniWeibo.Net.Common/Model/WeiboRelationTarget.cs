/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboRelationTarget.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-03-24 10:58:17
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
    public class WeiboRelationTarget
    {
        [DataMember]
        public long Id { get; set; }

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
