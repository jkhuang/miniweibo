/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboShortUrl.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-05-14 09:40:51
 * *******************************************************************/

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MiniWeibo.Net.Common
{
    public class WeiboShortUrl : IWeiboModel
    {
        [DataMember]
        public bool Result { get; set; }

        [DataMember]
        public int LastModified { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string UrlShort { get; set; }

        [DataMember]
        public IList<WeiboAnnotation> Annotations { get; set; }

        [DataMember]
        public string UrlLong { get; set; }

        [DataMember]
        public int Type { get; set; }

        public string RawSource { get; set; }
    }
}
