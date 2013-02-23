/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboIdInfo.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-02-03 04:47:48
 * *******************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MiniWeibo.Net.Common
{
    [Serializable]
    [DataContract]
    [DebuggerDisplay("{User.ScreenName}: {Text}")]
    [JsonObject(MemberSerialization.OptIn)]
    public class WeiboIdInfo : IWeiboModel, IWeiboable
    {
        [DataMember]
        public IList<string> Ids { get; set; }

        [DataMember]
        public bool HasVisible { get; set; }

        [DataMember]
        public long PreviousCursor { get; set; }

        [DataMember]
        public long NextCursor { get; set; }

        [DataMember]
        public int TotalNumber { get; set; }

        public WeiboIdInfo()
        {
            Ids = new List<string>();
        }

        public string RawSource { get; set; }
    }    
}
