/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboRemindCount.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-05-10 09:01:40
 * *******************************************************************/
using System.Runtime.Serialization;

namespace MiniWeibo.Net.Common
{
    public class WeiboRemindCount : IWeiboModel
    {
        [DataMember]
        public int Status { get; set; }

        [DataMember]
        public int Follower { get; set; }

        [DataMember]
        public int Cmt { get; set; }

        [DataMember]
        public int Dm { get; set; }

        [DataMember]
        public int MentionStatus { get; set; }

        [DataMember]
        public int MentionCmt { get; set; }

        [DataMember]
        public int Group { get; set; }

        [DataMember]
        public int PrivateGroup { get; set; }

        [DataMember]
        public int Notice { get; set; }

        [DataMember]
        public int Invite { get; set; }

        [DataMember]
        public int Badge { get; set; }

        [DataMember]
        public int Photo { get; set; }

        public string RawSource { get; set; }
    }
}
