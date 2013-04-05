/******************************** Module Header ********************************
 * Module Name: WeiboAccount.cs
 * Project:     MiniWeibo.Net.Common
 * Copyright (c) Jackson Huang.
 * 
 * Code Logic:
 * 
 * 
 * Corresponding Source:
 * http://open.weibo.com/wiki/Account/get_privacy
 * 
 * History:
 * 2012-3-31 11:38:52 Jackson Huang Created
 * Websiet:
 * http://www.cnblogs.com/rush/
 * *******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniWeibo.Net.Common
{
    using System.Runtime.Serialization;

    using Hammock.Model;

    using Newtonsoft.Json;


    /// <summary>
    /// Weibo account entity.
    /// </summary>
    [Serializable]
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class WeiboAccount : PropertyChangedBase,
                                  IComparable<WeiboAccount>,
                                  IEquatable<WeiboAccount>,
                                  IWeiboModel
    {

        [DataMember]
        public int Badge { get; set; }

        [DataMember]
        public int Comment { get; set; }

        [DataMember]
        public int Geo { get; set; }

        [DataMember]
        public int Message { get; set; }

        [DataMember]
        public int Mobile { get; set; }

        [DataMember]
        public int Realname { get; set; }

        #region Implementation of IComparable<WeiboAccount>

        public int CompareTo(WeiboAccount other)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IEquatable<WeiboAccount>

        public bool Equals(WeiboAccount other)
        {
            throw new NotImplementedException();
        }

        #endregion

        public string RawSource { get; set; }
    }
}
