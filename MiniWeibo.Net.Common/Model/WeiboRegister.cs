/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboRegister.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-05-05 08:38:57
 * *******************************************************************/
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MiniWeibo.Net.Common
{
    public class WeiboRegister : IWeiboModel
    {
        [DataMember]
        public bool IsLegal { get; set; }

        [DataMember]
        public List<string> SuggestNickname { get; set; }

        public string RawSource { get; set; }
    }
}
