/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboStatus.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-01-15 09:09:57
 * *******************************************************************/

namespace MiniWeibo.Net.Common
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.Serialization;

    using Hammock.Model;

    using Newtonsoft.Json;

    [Serializable]
    [DataContract]
    [DebuggerDisplay("{User.ScreenName}: {Text}")]
    [JsonObject(MemberSerialization.OptIn)]
    public class WeiboStatus : PropertyChangedBase, IComparable<WeiboStatus>, IEquatable<WeiboStatus>, IWeiboModel, IWeiboable
    {
        #region Private fields

        private DateTime? _createdAt;
        private long _id;
        private long? _mid;
        private string _idStr;
        private string _text;
        private string _source;
        private bool? _isFavorited;
        private bool? _isTruncated;
        private long? _inReplyToStatusId;
        private long? _inReplyToUserId;
        private string _inReplyToScreenName;
        private WeiboGeoLocation _geo;
        private WeiboUser _user;
        private List<WeiboAnnotation> _annotations; //= new List<WeiboAnnotation>();
        private int _repostsCount;
        private int _commentsCount;
        private int _attitudesCount;
        private int _mLevel;
        private WeiboVisible _visible;

        /// <summary>
        /// 缩略图
        /// </summary>  
        private string _thumbnailPic;

        /// <summary>
        /// 中型图片
        /// </summary>
        private string _bmiddlePic;

        /// <summary>
        /// 原始图片
        /// </summary>
        private string _originalPic;

        private WeiboStatus _retweetedStatus;

        private string _deleted;

        #endregion

        #region Properties

        [DataMember]
        public virtual long Id
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
                this._id = value;
                this.OnPropertyChanged("Id");
            }
        }

        [DataMember]
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                if (_text == value)
                {
                    return;
                }
                this._text = value;
                this.OnPropertyChanged("Text");
            }
        }

        [DataMember]
        public string TextAsHtml
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        ////[DataMember]
        ////public IWeibo Author
        ////{
        ////    get
        ////    {
        ////        throw new NotImplementedException();
        ////    }
        ////}

        [DataMember]
        public DateTime? CreatedAt
        {
            get
            {
                return _createdAt;
            }
            set
            {
                if (_createdAt == value)
                {
                    return;
                }
                _createdAt = value;
                OnPropertyChanged("CreatedAt");
            }
        }

        [DataMember]
        public WeiboEntities Entities
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        [DataMember]
        public string Source
        {
            get
            {
                return this._source;
            }
            set
            {
                if (_source == value)
                {
                    return;
                }
                this._source = value;
                this.OnPropertyChanged("Source");
            }
        }

        [DataMember]
        public bool? IsFavorited
        {
            get
            {
                return this._isFavorited;
            }
            set
            {
                if (_isFavorited == value)
                {
                    return;
                }
                this._isFavorited = value;
                this.OnPropertyChanged("IsFavorited");
            }
        }

        [DataMember]
        public string InReplyToScreenName
        {
            get
            {
                return this._inReplyToScreenName;
            }
            set
            {
                if (_inReplyToScreenName == value)
                {
                    return;
                }
                this._inReplyToScreenName = value;
                this.OnPropertyChanged("InReplyToScreenName");
            }
        }

        [DataMember]
        public long? InReplyToStatusId
        {
            get
            {
                return this._inReplyToStatusId;
            }
            set
            {
                if (_inReplyToStatusId == value)
                {
                    return;
                }
                this._inReplyToStatusId = value;
                this.OnPropertyChanged("InReplyToStatusId");
            }
        }

        [DataMember]
        public long? InReplyToUserId
        {
            get
            {
                return this._inReplyToUserId;
            }
            set
            {
                if (_inReplyToUserId == value)
                {
                    return;
                }
                this._inReplyToUserId = value;
                this.OnPropertyChanged("InReplyToUserId");
            }
        }

        [DataMember]
        public long? Mid
        {
            get
            {
                return this._mid;
            }
            set
            {
                if (_mid == value)
                {
                    return;
                }
                this._mid = value;
                this.OnPropertyChanged("Mid");
            }
        }

        [DataMember]
        public bool? IsTruncated
        {
            get
            {
                return this._isTruncated;
            }
            set
            {
                if (_isTruncated == value)
                {
                    return;
                }
                this._isTruncated = value;
                this.OnPropertyChanged("IsTruncated");
            }
        }

        [DataMember]
        public WeiboUser User
        {
            get
            {
                return this._user;
            }
            set
            {
                if (_user == value)
                {
                    return;
                }
                this._user = value;
                this.OnPropertyChanged("User");
            }
        }

        [DataMember]
        public WeiboStatus RetweetedStatus
        {
            get
            {
                return this._retweetedStatus;
            }
            set
            {
                if (_retweetedStatus == value)
                {
                    return;
                }
                this._retweetedStatus = value;
                this.OnPropertyChanged("RetweetedStatus");
            }
        }

        /// <summary>
        /// 缩略图
        /// </summary>
        [DataMember]
        public string ThumbnailPic
        {
            get
            {
                return this._thumbnailPic;
            }
            set
            {
                if (_thumbnailPic == value)
                {
                    return;
                }
                this._thumbnailPic = value;
                this.OnPropertyChanged("ThumbnailPic");
            }
        }

        /// <summary>
        /// 中型图片
        /// </summary>
        [DataMember]
        public string BmiddlePic
        {
            get
            {
                return this._bmiddlePic;
            }
            set
            {
                if (_bmiddlePic == value)
                {
                    return;
                }
                this._bmiddlePic = value;
                this.OnPropertyChanged("BmiddlePic");
            }
        }

        /// <summary>
        /// 原始图片
        /// </summary>
        [DataMember]
        public string OriginalPic
        {
            get
            {
                return _originalPic;
            }
            set
            {
                if (_originalPic == value)
                {
                    return;
                }
                _originalPic = value;
                OnPropertyChanged("OriginalPic");
            }
        }

        [DataMember]
        public string IdStr
        {
            get { return _idStr; }
            set { _idStr = value; }
        }

        ////[DataMember]
        public WeiboGeoLocation Geo
        {
            get { return _geo; }
            set { _geo = value; }
        }

        [DataMember]
        public List<WeiboAnnotation> Annotations
        {
            get
            {
                return _annotations;
            }
            set
            {
                if (_annotations == value)
                {
                    return;
                }
                _annotations = value;
                OnPropertyChanged("Annotations");
            }
            ////get { return _annotations; }
            ////set { _annotations = value; }
        }

        [DataMember]
        public int RepostsCount
        {
            get { return _repostsCount; }
            set { _repostsCount = value; }
        }

        [DataMember]
        public int CommentsCount
        {
            get { return _commentsCount; }
            set { _commentsCount = value; }
        }

        [DataMember]
        public int AttitudesCount
        {
            get { return _attitudesCount; }
            set { _attitudesCount = value; }
        }

        [DataMember]
        public int MLevel
        {
            get { return _mLevel; }
            set { _mLevel = value; }
        }

        [DataMember]
        public WeiboVisible Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        #endregion

        #region Members

        ////public WeiboStatus()
        ////{
        ////    _annotations = new List<WeiboAnnotation>();
        ////}

        public override bool Equals(object status)
        {
            if (ReferenceEquals(status, null))
            {
                return false;
            }

            if (ReferenceEquals(status, this))
            {
                return true;
            }

            return status.GetType() == typeof(WeiboStatus) && Equals((WeiboStatus)status);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(WeiboStatus left, WeiboStatus right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WeiboStatus left, WeiboStatus right)
        {
            return !Equals(left, right);
        }
        #endregion

        #region Implementation of IComparable<WeiboStatus>

        public int CompareTo(WeiboStatus other)
        {
            return other.Id == Id ? 0 : other.Id > Id ? -1 : 1;
        }

        #endregion

        #region Implementation of IEquatable<WeiboStatus>

        public bool Equals(WeiboStatus other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return other.Id == Id;
        }

        #endregion

        public string RawSource { get; set; }

        [DataMember]
        public string Deleted
        {
            get { return _deleted; }
            set { _deleted = value; }
        }
    }
}
