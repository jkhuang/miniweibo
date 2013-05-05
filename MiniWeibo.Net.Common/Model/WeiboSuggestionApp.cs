/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboSuggestionApp.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-05-05 09:24:46
 * *******************************************************************/

using System.Runtime.Serialization;

namespace MiniWeibo.Net.Common
{
    public class WeiboSuggestionApp : IWeiboModel
    {
        [DataMember]
        public string AppsName { get; set; }

        [DataMember]
        public int MembersCount { get; set; }

        public string RawSource { get; set; }
    }
}
