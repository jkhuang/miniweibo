/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboSuggestionUser.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-05-05 08:58:01
 * *******************************************************************/

using System.Runtime.Serialization;

namespace MiniWeibo.Net.Common
{
    public class WeiboSuggestionUser : IWeiboModel
    {
        [DataMember]
        public string ScreenName { get; set; }

        [DataMember]
        public int FollowersCount { get; set; }

        [DataMember]
        public string Nickname { get; set; }

        [DataMember]
        public long Uid { get; set; }

        [DataMember]
        public string Remark { get; set; }

        public string RawSource { get; set; }
    }
}
