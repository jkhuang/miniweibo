/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboFavorite.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-03-28 09:20:59
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
    public class WeiboFavorite : IWeiboModel
    {
        [DataMember]
        public WeiboStatus Status { get; set; }

        private List<WeiboTags> _tags; //= new List<WeiboTags>();

        ////[DataMember(Name = "NeverNull")]
        [DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<WeiboTags> Tags
        {
            get { return _tags; }
            set
            {
                if (_tags == value)
                {
                    return;
                }
                _tags = value;
            }
        }

        ////public WeiboFavorite()
        ////{
        ////    Initialize();
        ////}

        ////[OnDeserialized]
        ////public void OnDeserialized(StreamingContext context)
        ////{
        ////    if (Tags == null) Tags = new List<WeiboTags>();
        ////}

        ////private void Initialize()
        ////{
        ////    _tags = new List<WeiboTags>(0);
        ////}

        [DataMember]
        public DateTime FavoritedTime { get; set; }

        public string RawSource { get; set; }


    }
}
