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

    using Newtonsoft.Json; 

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
                return this._customSerializer;
            }
            set
            {
                this._customSerializer = value;
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
                    VersionPath = string.Empty, ////"1",
                    Serializer = _json as ISerializer,
                    Deserializer = _json as IDeserializer,
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
                VersionPath = string.Empty, ////"2",
                Serializer = _json as ISerializer,
                Deserializer = _json as IDeserializer,
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
                VersionPath = string.Empty,////"1",
                Serializer = _json as ISerializer,
                Deserializer = _json as IDeserializer,
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
            IncludeEntities = true;
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
            else
            {
                _client.Authority = Constant.RestAPIAuthority;

                //// Sina Weibo has two version (null and 2).
                _client.VersionPath = string.Empty;
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
            if (string.IsNullOrEmpty(_token) || string.IsNullOrEmpty(_tokenSecret))
            {
                request = _noAuthQuery.Invoke();
            }
            else
            {
                var args = new FunctionArguments
                {
                    ConsumerKey = _consumerKey,
                    ConsumerSecret = _consumerSecret,
                    Token = _token,
                    TokenSecret = _tokenSecret
                };
                request = _protectedResourceQuery.Invoke(args);
            }
            request.Path = path;

            SetTwitterClientInfo(request);

            return request;
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
        Json
    }
}