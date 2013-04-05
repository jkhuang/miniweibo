/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboCount.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-03-11 09:38:06
 * *******************************************************************/

using System;
using System.Runtime.Serialization;

namespace MiniWeibo.Net.Common
{
    [Serializable]
    [DataContract]
    public class WeiboCount : IWeiboModel
    {
        [DataMember]
        public Int64 Id { get; set; }

        [DataMember]
        public int FollowersCount { get; set; }

        [DataMember]
        public int FriendsCount { get; set; }

        [DataMember]
        public int StatusesCount { get; set; }

        [DataMember]
        public int PrivateFriendsCount { get; set; }

        public string RawSource { get; set; }
    }
}
