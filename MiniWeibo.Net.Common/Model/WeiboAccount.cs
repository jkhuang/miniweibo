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

        private bool _isCommented;
        private bool _isDm;

        private bool _discoverableByRealName;
        private bool _geoEnabled;

        private bool _badge;

        public virtual bool IsCommented
        {
            get
            {
                return this._isCommented;
            }
            set
            {
                if (_isCommented == value)
                {
                    return;
                }

                _isCommented = value;
                OnPropertyChanged("IsCommented");
            }
        }

        public virtual bool IsDm
        {
            get
            {
                return this._isDm;
            }
            set
            {
                if (_isDm == value)
                {
                    return;
                }

                _isDm = value;
                OnPropertyChanged("IsDm");
            }
        }

        public virtual bool DiscoverableByRealName
        {
            get
            {
                return this._discoverableByRealName;
            }
            set
            {
                if (_discoverableByRealName == value)
                {
                    return;
                }

                _discoverableByRealName = value;
                OnPropertyChanged("DiscoverableByRealName");
            }
        }

        public virtual bool GeoEnabled
        {
            get
            {
                return this._geoEnabled;
            }
            set
            {
                if (_geoEnabled == value)
                {
                    return;
                }

                _geoEnabled = value;
                OnPropertyChanged("GeoEnabled");
            }
        }

        public virtual bool Badge
        {
            get
            {
                return this._badge;
            }
            set
            {
                if (_badge == value)
                {
                    return;
                }

                _badge = value;
                OnPropertyChanged("Badge");
            }
        }

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
    }
}
