/******************************** Module Header ********************************
 * Module Name: WeiboUser.cs
 * Project:     MiniWeibo.Net.Common
 * Copyright (c) Jackson Huang.
 * 
 * Code Logic:
 * 
 * 
 * Corresponding Source:
 * http://open.weibo.com/wiki/User
 * 
 * History:
 * 2012-3-31 16:41:09 Jackson Huang Created
 * Websiet:
 * http://www.cnblogs.com/rush/
 * *******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniWeibo.Net.Common
{
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    using Hammock.Model;

    using Newtonsoft.Json;

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [DataContract]
    [DebuggerDisplay("{ScreenName}")]
    [JsonObject(MemberSerialization.OptIn)]
    public class WeiboUser : PropertyChangedBase, IComparable<WeiboUser>, IEquatable<WeiboUser>, IWeiboModel, IWeibo
    {
        #region Private fields

        /// <summary>
        /// Weibo ID.
        /// </summary>
        private int _id;

        /// <summary>
        /// Weibo nickname.
        /// </summary>
        private string _screenName;

        /// <summary>
        /// 友好显示名称，如Bill Gates(此特性暂不支持)
        /// </summary>
        private string _name;

        /// <summary>
        /// 省份编码（参考省份编码表）
        /// </summary>
        private int _province;

        /// <summary>
        /// 城市编码（参考城市编码表）
        /// </summary>
        private int _city;

        /// <summary>
        /// 地址
        /// </summary>
        private string _location;

        /// <summary>
        /// The description of individual.
        /// </summary>
        private string _description;

        /// <summary>
        /// 用户博客地址
        /// </summary>
        private string _blogUrl;

        /// <summary>
        /// 自定义图像
        /// </summary>
        private string _profileImageUrl;

        /// <summary>
        /// 用户个性化URL
        /// </summary>
        private string _domain;

        /// <summary>
        /// 性别,m--男，f--女,n--未知
        /// </summary>
        private string _gender;

        /// <summary>
        /// 粉丝数
        /// </summary>
        private int _followersCount;

        /// <summary>
        /// 关注数
        /// </summary>
        private int _friendsCount;

        /// <summary>
        /// 微博数
        /// </summary>
        private int _statusesCount;

        /// <summary>
        /// 收藏数
        /// </summary>
        private int _favouritesCount;

        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime _createdAt;

        /// <summary>
        /// 是否已关注(此特性暂不支持)
        /// </summary>
        private bool? _isFollowing;

        /// <summary>
        /// verified: 加V标示，是否微博认证用户
        /// </summary>
        private bool? _isVerified;

        private bool? _allowAllActMsg;

        private bool? _isGeoEnabled;

        private WeiboStatus _status;

        ////private bool? _isProtected;
        ////private string _location;
        ////private string _name;
        ////private string _profileImageUrl;
        ////private string _screenName;
        ////private TwitterStatus _status;
        ////private string _url;
        ////private DateTime _createdDate;
        ////private bool? _isVerified;
        ////private bool? _isGeoEnabled;
        ////private bool _isProfileBackgroundTiled;
        ////private string _profileBackgroundColor;
        ////private string _profileBackgroundImageUrl;
        ////private string _profileLinkColor;
        ////private string _profileSidebarBorderColor;
        ////private string _profileSidebarFillColor;
        ////private string _profileTextColor;
        ////private int _statusesCount;
        ////private int _friendsCount;
        ////private int _favouritesCount;
        ////private int _listedCount;
        ////private string _timeZone;
        ////private string _utcOffset;
        ////private string _language;
        ////private bool? _showAllInlineMedia;
        ////private bool? _followRequestSent;
        ////private bool? _isTranslator;
        ////private bool? _contributorsEnabled;
        ////private bool? _defaultProfile;
        ////private string _profileBackgroundImageUrlHttps;
        ////private string _profileImageUrlHttps;
  
        #endregion

        #region Propeties

        [DataMember]
        public virtual string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description == value)
                {
                    return;
                }

                _description = value;
                OnPropertyChanged("Description");
            }
        }

        [DataMember]
        public virtual int FollowersCount
        {
            get
            {
                return _followersCount;
            }
            set
            {
                if (_followersCount == value)
                {
                    return;
                }

                _followersCount = value;
                OnPropertyChanged("FollowersCount");
            }
        }

        [DataMember]
        public virtual int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id == value)
                {
                    return;
                }

                _id = value;
                OnPropertyChanged("Id");
            }
        }

        [DataMember]
        public virtual string ScreenName
        {
            get
            {
                return _screenName;
            }
            set
            {
                if (_screenName == value)
                {
                    return;
                }
                _screenName = value;
                this.OnPropertyChanged("ScreenName");
            }
        }

        /// <summary>
        /// 友好显示名称，如Bill Gates(此特性暂不支持)
        /// </summary>
        [DataMember]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (_name == value)
                {
                    return;
                }
                this._name = value;
                this.OnPropertyChanged("Name");
            }
        }

        [DataMember]
        public virtual string ProfileImageUrl
        {
            get
            {
                return _profileImageUrl;
            }

            set
            {
                if (_profileImageUrl == value)
                {
                    return;
                }
                this._profileImageUrl = value;
                OnPropertyChanged("ProfileImageUrl");
            }
        }

        /// <summary>
        /// 友好显示名称，如Bill Gates(此特性暂不支持)
        /// </summary>
        /// private string _name;
        /// <summary>
        /// 省份编码（参考省份编码表）
        /// </summary>
        [DataMember]
        public virtual int Province
        {
            get
            {
                return this._province;
            }
            set
            {
                if (_province == value)
                {
                    return;
                }
                this._province = value;
                this.OnPropertyChanged("Province");
            }
        }

        /// <summary>
        /// 城市编码（参考城市编码表）
        /// </summary>
        [DataMember]
        public virtual int City
        {
            get
            {
                return this._city;
            }
            set
            {
                if (_city == value)
                {
                    return;
                }

                this._city = value;
                this.OnPropertyChanged("City");
            }
        }

        /// <summary>
        /// 地址
        /// </summary>
        [DataMember]
        public string Location
        {
            get
            {
                return this._location;
            }
            set
            {
                if (_location == value)
                {
                    return;
                }
                this._location = value;
                this.OnPropertyChanged("Location");
            }
        }

        /// <summary>
        /// 用户博客地址
        /// </summary>
        [DataMember]
        public string BlogUrl
        {
            get
            {
                return this._blogUrl;
            }
            set
            {
                if (_blogUrl == value)
                {
                    return;
                }
                this._blogUrl = value;
                this.OnPropertyChanged("BlogUrl");
            }
        }

        /// <summary>
        /// 用户个性化URL
        /// </summary>
        [DataMember]
        public string Domain
        {
            get
            {
                return this._domain;
            }
            set
            {
                if (_domain == value)
                {
                    return;
                }

                this._domain = value;
                this.OnPropertyChanged("Domain");
            }
        }

        /// <summary>
        /// 性别,m--男，f--女,n--未知
        /// </summary>
        [DataMember]
        public string Gender
        {
            get
            {
                return this._gender;
            }
            set
            {
                if (_gender == value)
                {
                    return;
                }
                this._gender = value;
                this.OnPropertyChanged("Gender");
            }
        }

        /// <summary>
        /// 关注数
        /// </summary>
        [DataMember]
        public int FriendsCount
        {
            get
            {
                return this._friendsCount;
            }
            set
            {
                if (_friendsCount == value)
                {
                    return;
                }
                this._friendsCount = value;
                this.OnPropertyChanged("FriendsCount");
            }
        }

        /// <summary>
        /// 微博数
        /// </summary>
        [DataMember]
        public int StatusesCount
        {
            get
            {
                return this._statusesCount;
            }
            set
            {
                if (_statusesCount == value)
                {
                    return;
                }
                this._statusesCount = value;
                this.OnPropertyChanged("StatusesCount");
            }
        }

        /// <summary>
        /// 收藏数
        /// </summary>
        [DataMember]
        public int FavouritesCount
        {
            get
            {
                return this._favouritesCount;
            }
            set
            {
                if (_favouritesCount == value)
                {
                    return;
                }
                this._favouritesCount = value;
                this.OnPropertyChanged("FavouritesCount");
            }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt
        {
            get
            {
                return this._createdAt;
            }

            set
            {
                if (_createdAt == value)
                {
                    return;
                }
                _createdAt = value;
                this.OnPropertyChanged("CreatedAt");
            }
        }

        /// <summary>
        /// 是否已关注(此特性暂不支持)
        /// </summary>
        ////private bool? _isFollowing;
        /// <summary>
        /// verified: 加V标示，是否微博认证用户
        /// </summary>
        [DataMember]
        public virtual bool? IsVerified
        {
            get
            {
                return this._isVerified;
            }
            set
            {
                if (this._isVerified == true)
                {
                    return;
                }

                this._isVerified = value;
                this.OnPropertyChanged("IsVerified");
            }
        }

        /// <summary>
        /// 是否已关注(此特性暂不支持)
        /// </summary>
        [DataMember]
        public bool? IsFollowing
        {
            get
            {
                return this._isFollowing;
            }
            set
            {
                if (this._isFollowing == value)
                {
                    return;
                }
                this._isFollowing = value;
                this.OnPropertyChanged("IsFollowing");
            }
        }

        [DataMember]
        public bool? AllowAllActMsg
        {
            get
            {
                return this._allowAllActMsg;
            }
            set
            {
                if (_allowAllActMsg == value)
                {
                    return;
                }
                this._allowAllActMsg = value;
                this.OnPropertyChanged("AllowAllActMsg");
            }
        }

        [DataMember]
        public bool? IsGeoEnabled
        {
            get
            {
                return this._isGeoEnabled;
            }
            set
            {
                if (_isGeoEnabled == value)
                {
                    return;
                }
                this._isGeoEnabled = value;
                this.OnPropertyChanged("IsGeoEnabled");
            }
        }

        public WeiboStatus Status
        {
            get
            {
                return this._status;
            }
            set
            {
                if (_status == value)
                {
                    return;
                }
                this._status = value;
                this.OnPropertyChanged("Status");
            }
        }

        #endregion

        #region Members

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="user">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object user)
        {
            if (ReferenceEquals(null, user))
            {
                return false;
            }

            if (ReferenceEquals(this, user))
            {
                return true;
            }
            return user.GetType() == typeof(WeiboUser) && Equals((WeiboUser)user);
        }
        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(WeiboUser left, WeiboUser right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(WeiboUser left, WeiboUser right)
        {
            return !Equals(left, right);
        }

        #endregion

        #region Implementation of IComparable<WeiboUser>

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. 
        /// The return value has the following meanings: 
        /// Less than zero: This object is less than the <paramref name="user"/> parameter.
        /// Zero: This object is equal to <paramref name="user"/>. 
        /// Greater than zero: This object is greater than <paramref name="user"/>.
        /// </returns>
        public int CompareTo(WeiboUser user)
        {
            return user.Id == Id ? 0 : user.Id > Id ? -1 : 1;
        }

        #endregion

        #region Implementation of IEquatable<WeiboUser>

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="user"/> parameter or Id; otherwise, false.
        /// </returns>
        public bool Equals(WeiboUser user)
        {
            if (ReferenceEquals(null, user))
            {
                return false;
            }
            if (ReferenceEquals(this, user))
            {
                return true;
            }
            return user.Id == Id;
        }

        #endregion

    }
}