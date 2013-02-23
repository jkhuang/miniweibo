/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboService.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-01-17 08:46:57
 * *******************************************************************/

using System.IO;
using Hammock.Web;
using MiniWeibo.Net.Common.Serialization;

namespace MiniWeibo.Net.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Text;

    using Hammock;
    using Hammock.Serialization;

    public partial class WeiboService
    {
        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether [trace enabled].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [trace enabled]; otherwise, <c>false</c>.
        /// </value>
        public bool TraceEnabled { get; set; }

        public string Proxy { get; set; }

        public bool IncludeEntities { get; set; }

        public IDeserializer Deserializer
        {
            get
            {
                return this._customDeserializer;
            }
            set
            {
                this._customDeserializer = value;
            }
        }

        public ISerializer Serializer
        {
            get
            {
                if (_customSerializer != null)
                {
                    return _customSerializer;
                }
                switch (Format)
                {
                    case WeiboServiceFormat.Json:
                        return (ISerializer)_json;
////#if !SILVERLIGHT
////                    case WeiboServiceFormat.Xml:
////                        return _xml;
////#endif
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            set { _customSerializer = value; }
        }

        public WeiboServiceFormat Format
        {
            get { return _format; }
            set
            {
                if (_format == value)
                {
                    return;
                }
                _format = value;
                FormatAsString = string.Concat(".", Format.ToString().ToLowerInvariant());
                switch (Format)
                {
                    case WeiboServiceFormat.Json:
                        if (_customSerializer == null)
                        {
                            _client.Serializer = _json;
                        }
                        if (_customDeserializer == null)
                        {
                            _client.Deserializer = _json;
                        }
                        break;
////#if !SILVERLIGHT
////                    case WeiboServiceFormat.Xml:

////                        if (_customSerializer == null)
////                        {
////                            _client.Serializer = _xml;
////                        }
////                        if (_customDeserializer == null)
////                        {
////                            _client.Deserializer = _xml;
////                        }
////                        break;
////#endif
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        #endregion

        private WeiboServiceFormat _format;

        private readonly RestClient _client;

        private readonly JsonSerializer _json;

////#if !SILVERLIGHT
////        private readonly XmlSerializer _xml;
////#endif

        private string _consumerKey;

        private string _consumerSecret;

        private string _token;

        private string _tokenSecret;

        private string _accessToken;

        private string _callbackUrl;

        private string _userName;
        private string _passWord;

        private IDeserializer _customDeserializer;
        private ISerializer _customSerializer;

        private readonly WeiboClientInfo _clientInfo;

        private readonly WeiboClientInfo _info;


        ////public string FormatAsString { get; private set; }

        public WeiboService()
        {
            _json = new JsonSerializer();
////#if !SILVERLIGHT
////            _xml = new XmlSerializer();
////#endif

            FormatAsString = ".json";

            _client = new RestClient
                {
                    Authority = Constant.RestAPIAuthority,
                    QueryHandling = QueryHandling.AppendToParameters,
                    VersionPath = "2",
                    Serializer = _json,
                    Deserializer = _json,
                    DecompressionMethods = DecompressionMethods.GZip,
                    UserAgent = "MiniWeibo",
                    Proxy = Proxy,
#if !SILVERLIGHT
                    FollowRedirects = true,
#endif
#if SILVERLIGHT
                    HasElevatedPermissions = true
#endif
                };

            _oauth = new RestClient
            {
                Authority = Constant.RestAPIAuthority,
                Proxy = Proxy,
                UserAgent = "MiniWeibo",
            };

            _userStreamingClient = new RestClient
            {
                Authority = Constant.UserStreamingAPIAuthority,
                Proxy = Proxy,
                VersionPath = "2",
                Serializer = _json,
                Deserializer = _json,
                DecompressionMethods = DecompressionMethods.GZip,
                UserAgent = "MiniWeibo",
#if !SILVERLIGHT
                FollowRedirects = true,
#endif
#if SILVERLIGHT
                  HasElevatedPermissions = true
#endif
            };

            _searchStreamingClient = new RestClient
            {
                Authority = Constant.SearchStreamingAPIAuthority,
                Proxy = Proxy,
                VersionPath = "2",
                Serializer = _json,
                Deserializer = _json,
                DecompressionMethods = DecompressionMethods.GZip,
                UserAgent = "MiniWeibo",
#if !SILVERLIGHT
                FollowRedirects = true,
#endif
#if SILVERLIGHT
                HasElevatedPermissions = true
#endif
            };

            InitializeService();
        }

        public WeiboService(string consumerKey, string consumerSecret)
            : this()
        {
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
        }

        ////public WeiboService(string consumerKey, string consumerSecret, string callbackUrl)
        ////    : this()
        ////{
        ////    _consumerKey = consumerKey;
        ////    _consumerSecret = consumerSecret;
        ////    _callbackUrl = callbackUrl;
        ////}

        public WeiboService(string consumerKey, string consumerSecret, string accessToken)
            : this()
        {
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
            _accessToken = accessToken;
        }

        public WeiboService(string consumerKey, string consumerSecret, string token, string tokenSecret)
            : this()
        {
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
            _token = token;
            _tokenSecret = tokenSecret;
        }

        public WeiboService(WeiboClientInfo info)
            : this()
        {
            _consumerKey = info.ConsumerKey;
            _consumerSecret = info.ConsumerSecret;
            IncludeEntities = info.IncludeEntities;

            _info = info;
        }

        private void InitializeService()
        {
            ////IncludeEntities = true;
        }

        public virtual WeiboResponse Response { get; private set; }

        private void SetResponse(RestResponseBase response)
        {
            Response = new WeiboResponse(response, null);
        }

        internal string FormatAsString { get; private set; }

        private string ResolveUrlSegments(string path, List<object> segments)
        {
            if (segments == null) throw new ArgumentNullException("segments");

            //// Support alternate client authorities here

            if (path.Equals("search"))
            {
                _client.Authority = Constant.SearchAPIAuthority;
                _client.VersionPath = null;
            }
            else if (path.Equals("statuses/upload"))
            {
                _client.Authority = Constant.UploadAPIAuthority;
                _client.VersionPath = "2";
            }
            else
            {
                _client.Authority = Constant.RestAPIAuthority;

                //// Sina Weibo has two version (null and 2).
                _client.VersionPath = "2";
            }

            for (var i = 0; i < segments.Count; i++)
            {
                // Currently only trends takes DateTimes
                if (segments[i] is DateTime)
                {
                    segments[i] = ((DateTime)segments[i]).ToString("yyyy-MM-dd");
                }

                if (typeof(IEnumerable).IsAssignableFrom(segments[i].GetType()) && !(segments[i] is string))
                {
                    ResolveEnumerableUrlSegments(segments, i);
                }
            }

            path = PathHelpers.ReplaceUriTemplateTokens(segments, path);

            PathHelpers.EscapeDataContainingUrlSegments(segments);

            if (IncludeEntities)// && !path.Contains("/lists"))
            {
                segments.Add(segments.Count() > 1 ? "&include_entities=" : "?include_entities=");
                segments.Add("1");
            }

            segments.Insert(0, path);

            return string.Concat(segments.ToArray()).ToString(CultureInfo.InvariantCulture);
        }

        private static void ResolveEnumerableUrlSegments(IList<object> segments, int i)
        {
            // [DC] Enumerable segments will be typed, but we only care about string values
            var collection = (from object item in (IEnumerable)segments[i] select item.ToString()).ToList();
            var total = collection.Count();
            var sb = new StringBuilder();
            var count = 0;
            foreach (var item in collection)
            {
                sb.Append(item);
                if (count < total - 1)
                {
                    sb.Append(",");
                }
                count++;
            }
            segments[i] = sb.ToString();
        }

        private void SetTwitterClientInfo(RestBase request)
        {
            if (_info == null) return;
            if (!_info.ClientName.IsNullOrBlank())
            {
                request.AddHeader("X-Twitter-Name", _info.ClientName);
                request.UserAgent = _info.ClientName;
            }
            if (!_info.ClientVersion.IsNullOrBlank())
            {
                request.AddHeader("X-Twitter-Version", _info.ClientVersion);
            }
            if (!_info.ClientUrl.IsNullOrBlank())
            {
                request.AddHeader("X-Twitter-URL", _info.ClientUrl);
            }
        }

        private readonly Func<RestRequest> _noAuthQuery = () =>
            {
                var request = new RestRequest();
                return request;
            };

        private RestRequest PrepareHammockQuery(string path)
        {
            RestRequest request;
            // TODO:
            //if (string.IsNullOrEmpty(_token) || string.IsNullOrEmpty(_tokenSecret))
            //{
            //    request = _noAuthQuery.Invoke();
            //}
            ////else
            ////{
                var args = new FunctionArguments
                {
                    ConsumerKey = _consumerKey,
                    ConsumerSecret = _consumerSecret,
                    ////Token = _token,
                    ////TokenSecret = _tokenSecret,
                    AccessToken = _accessToken
                };
                request = _protectedResourceQuery.Invoke(args);
            ////}
            request.Path = path;

            SetTwitterClientInfo(request);

            // A little hack
            if (path.Contains("statuses/upload"))
            {
                PrepareUpload(request, path);
            }


            return request;
        }

        private static void PrepareUpload(RestBase request, string path)
        {
            var startIndex = path.IndexOf("?status=", StringComparison.Ordinal) + 8;
            var endIndex = path.IndexOf("&pic=", StringComparison.Ordinal);
            request.Method = WebMethod.Post;

            string status = path.Substring(startIndex, endIndex - startIndex);
            request.AddField("status", status);

            // https://upload.api.weibo.com/2/statuses/upload.json
            startIndex = path.IndexOf("&pic=", StringComparison.Ordinal) + 5;
            endIndex = path.Trim().Length;

            var uri = path.Substring(startIndex, endIndex - startIndex);
            path = path.Remove(path.IndexOf("?status="));
            request.Path = path;

            var file = new FileStream(Uri.UnescapeDataString(uri), FileMode.Open);
            request.AddFile("pic", Path.GetFileName(Uri.UnescapeDataString(uri)), file, "image/jpeg");
            
        }

        private T WithHammock<T>(string path)
        {
            var request = PrepareHammockQuery(path);

            return WithHammockImpl<T>(request);
        }

        private T WithHammock<T>(string path, params object[] segments)
        {
            return WithHammock<T>(ResolveUrlSegments(path, segments.ToList()));
        }

        private T WithHammock<T>(WebMethod method, string path)
        {
            var request = PrepareHammockQuery(path);
            request.Method = method;

            return WithHammockImpl<T>(request);
        }

        private T WithHammock<T>(WebMethod method, string path, params object[] segments)
        {
            return WithHammock<T>(method, ResolveUrlSegments(path, segments.ToList()));
        }

        private T WithHammockImpl<T>(RestRequest request)
        {
            var response = _client.Request<T>(request);

            SetResponse(response);

            var entity = response.ContentEntity;
            return entity;
        }
    }

    public enum WeiboServiceFormat
    {
        Json,
        Xml
    }
}