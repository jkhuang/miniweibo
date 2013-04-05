/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboSchool.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-03-27 09:26:26
 * *******************************************************************/

using System.Runtime.Serialization;

namespace MiniWeibo.Net.Common
{
    public class WeiboSchool : IWeiboModel
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        public string RawSource { get; set; }
    }
}
