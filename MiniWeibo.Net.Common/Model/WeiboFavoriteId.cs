/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboFavorites.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-03-29 09:21:05
 * *******************************************************************/

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MiniWeibo.Net.Common
{
    public class WeiboFavoriteId : IWeiboModel
    {
        private List<WeiboTags> _tags;

        [DataMember]
        public long Status { get; set; }

        [DataMember]
        ////[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<WeiboTags> Tags { get; set; }

        [DataMember]
        public DateTime FavoritedTime { get; set; }

        public string RawSource { get; set; }

    }
}
