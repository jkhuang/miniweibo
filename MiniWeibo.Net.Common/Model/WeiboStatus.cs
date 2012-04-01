


namespace MiniWeibo.Net.Common
{
    using System;
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
        ////private DateTime _createdDate;
        ////private long _id;
        ////private string _text;
        ////private string _source;

        ////private bool? _isFavorited;

        ////private bool? _isTruncated;
        ////private string _geo;

        ////private long _recipientStatusId;
        ////private long _recipientUserId;
        ////private string _recipientScreenName;

        ////private long _mid;

        ////private long _senderId;

        ////private string _senderScreenName;

        ////        private TwitterUser _sender;
        ////private TwitterEntities _entities;


        private DateTime _createdDate;
        private long _id;
        private string _text;
        private string _source;
        private bool? _isFavorited;
        private bool? _isTruncated;
        private string _inReplyToScreenName;
        private long? _inReplyToStatusId;
        private long? _inReplyToUserId;


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

        private long _mid;

        private WeiboStatus _retweetedStatus;
        private WeiboUser _user;

        ////private TwitterGeoLocation _location;
        ////private TwitterEntities _entities;
        ////private bool? _isPossiblySensitive;
        ////private TwitterPlace _place;

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

        [DataMember]
        public IWeibo Author
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        [DataMember]
        public DateTime CreatedDate
        {
            get
            {
                return _createdDate;
            }
            set
            {
                if (_createdDate == value)
                {
                    return;
                }
                this._createdDate = value;
                this.OnPropertyChanged("CreatedDate");
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
        public long Mid
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
                return this._originalPic;
            }
            set
            {
                if (_originalPic == value)
                {
                    return;
                }
                this._originalPic = value;
                this.OnPropertyChanged("OriginalPic");
            }
        }

        #endregion

        #region Members

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
    }
}
