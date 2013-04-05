/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboFavoriteTag.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-03-30 10:11:46
 * *******************************************************************/

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MiniWeibo.Net.Common
{
    public class WeiboFavoriteTag : IWeiboModel
    {
        [DataMember]
        public WeiboTags Tags { get; set; }

        public string RawSource { get; set; }
    }
}
