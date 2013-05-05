/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboSuggestionCompany.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-05-05 09:21:29
 * *******************************************************************/
using Newtonsoft.Json;

namespace MiniWeibo.Net.Common
{
    public class WeiboSuggestionCompany : IWeiboModel
    {
        [JsonProperty("suggestion")]
        public string Name { get; set; }

        public string RawSource { get; set; }
    }
}
