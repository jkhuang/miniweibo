/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboSuggestionSchool.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-05-05 09:09:27
 * *******************************************************************/
using System.Runtime.Serialization;

namespace MiniWeibo.Net.Common
{
    public class WeiboSuggestionSchool : IWeiboModel
    {
        [DataMember]
        public string SchoolName { get; set; }

        [DataMember]
        public int Location { get; set; }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int Type { get; set; }

        public string RawSource { get; set; }
    }
}
