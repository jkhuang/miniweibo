/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboUserTags.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-04-05 11:07:24
 * *******************************************************************/

using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MiniWeibo.Net.Common
{
    public class WeiboUserTags : IWeiboModel, IEnumerable<WeiboUserTag> 
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public virtual List<WeiboUserTag> Tags { get; set; }

        public string RawSource { get; set; }

        public WeiboUserTags()
        {
            Initialize();
        }

        private void Initialize()
        {
            Tags = new List<WeiboUserTag>(0);
        }
        public IEnumerator<WeiboUserTag> GetEnumerator()
        {
            return Tags.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
