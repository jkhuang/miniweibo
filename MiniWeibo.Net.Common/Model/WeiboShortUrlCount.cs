/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboShortUrlCount.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-05-12 08:46:35
 * *******************************************************************/
using System.Runtime.Serialization;

namespace MiniWeibo.Net.Common
{
    public class WeiboShortUrlCount : IWeiboModel
    {
        [DataMember]
        public int ShareCounts { get; set; }

        [DataMember]
        public string UrlShort { get; set; }

        [DataMember]
        public string UrlLong { get; set; }

        [DataMember]
        public string CommentCounts { get; set; }

        public string RawSource { get; set; }
    }
}
