/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboSuggestionReason.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-05-09 09:13:48
 * *******************************************************************/
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MiniWeibo.Net.Common
{
    public class WeiboSuggestionReason
    {
        [DataMember]
        public long Uid { get; set; }

        [JsonProperty("h")]
        public RelationSuggestion Following { get; set; }

        [JsonProperty("f")]
        public RelationSuggestion Follower { get; set; }
    }
    public class RelationSuggestion
    {
        [DataMember]
        public List<string> Uid { get; set; }

        [JsonProperty("n")]
        public int Count { get; set; }
    }

}
