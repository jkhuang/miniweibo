/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboFriendRemark.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-03-23 09:15:23
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
    public class WeiboFriendRemark : IWeiboModel
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Remark { get; set; }

        public string RawSource { get; set; }
    }
}
