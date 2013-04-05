/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboUserTopStatus.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-03-11 10:04:26
 * *******************************************************************/

using System;
using System.Runtime.Serialization;

namespace MiniWeibo.Net.Common
{
    public class WeiboUserTopStatus : IWeiboModel
    {
        [DataMember]
        public long Uid { get; set; }

        [DataMember]
        public long Mid { get; set; }

        [DataMember]
        public bool IsUse { get; set; }

        [DataMember]
        public DateTime CreateAt { get; set; }

        public string RawSource { get; set; }
    }
}
