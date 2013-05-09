/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboInterestedUser.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-05-09 09:15:46
 * *******************************************************************/
using System.Runtime.Serialization;

namespace MiniWeibo.Net.Common
{
    public class WeiboInterestedUser : IWeiboModel
    {
        [DataMember]
        public long Uid { get; set; }

        [DataMember]
        public WeiboSuggestionReason Reason { get; set; }

        public string RawSource { get; set; }
    }
}
