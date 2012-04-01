using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniWeibo.Net.Common.Core
{
    public static class RegexPattern
    {
        /// <summary>
        /// Jon Gruber's URL Regex: http://daringfireball.net/2009/11/liberal_regex_for_matching_urls
        /// </summary>
        public const string Url = @"\b(([\w-]+://?|www[.])[^\s()<>]+(?:\([\w\d]+\)|([^\p{P}\s]|/)))";

        /// <summary>
        /// Diego Sevilla's @ Regex: http://stackoverflow.com/questions/529965/how-could-i-combine-these-regex-rules
        /// </summary>
        public const string Mentions = @"(^|\W)@([A-Za-z0-9_]+)";

        /// <summary>
        /// Simon Whatley's # Regex: http://www.simonwhatley.co.uk/parsing-twitter-usernames-hashtags-and-urls-with-javascript
        /// </summary>
        public const string HashTags = @"[#]+[A-Za-z0-9-_]+";
    }
}
