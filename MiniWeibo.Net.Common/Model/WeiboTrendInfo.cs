/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboTrendInfo.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-03-31 09:48:32
 * *******************************************************************/

using System.Runtime.Serialization;

namespace MiniWeibo.Net.Common
{
    public class WeiboTrendInfo : IWeiboModel
    {
        [DataMember]
        public int Num { get; set; }

        [DataMember]
        public string Hotword { get; set; }

        [DataMember]
        public long TrendId { get; set; }

        [DataMember]
        public bool IsFollow { get; set; }

        public string RawSource { get; set; }
    }
}
