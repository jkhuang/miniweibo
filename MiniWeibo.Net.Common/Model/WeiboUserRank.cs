/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboUserRank.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-03-11 09:47:58
 * *******************************************************************/

using System;
using System.Runtime.Serialization;

namespace MiniWeibo.Net.Common
{
    [Serializable]
    [DataContract]
    public class WeiboUserRank : IWeiboModel
    {
        [DataMember]
        public Int64 Uid { get; set; }

        [DataMember]
        public int Rank { get; set; }

        public string RawSource { get; set; }
    }
}
