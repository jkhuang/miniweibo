/******************************** Module Header ********************************
 * Module Name: WeiboService.OAuth.cs
 * Project:     MiniWeibo.Net.Common
 * Copyright (c) Jackson Huang.
 * 
 * Code Logic:
 * 
 * 
 * Corresponding Source:
 * http://tools.ietf.org/html/rfc3986
 * 
 * History:
 * 2012-1-28 11:24:30 Jackson Huang Created
 * Websiet:
 * http://www.cnblogs.com/rush/
 * *******************************************************************************/

using Newtonsoft.Json.Linq;

namespace MiniWeibo.Net.Common
{
    using System;
    using System.Compat.Web;

    using Hammock;
    using Hammock.Authentication.OAuth;
    using Hammock.Web;

    public partial class WeiboService
    {
        private class FunctionArguments
        {
            public string ConsumerKey { get; set; }

            public string ConsumerSecret { get; set; }

            public string Token { get; set; }

            public string TokenSecret { get; set; }

            public string AccessToken { get; set; }

            public string Verifier { get; set; }

            public string Username { get; set; }

            public string Password { get; set; }

            public string CallbackUrl { get; set; }

            public GrantType Type { get; set; }
        }

        private readonly Func<FunctionArguments, RestRequest> _authorizationCodeQuery = args =>
            {
                var request = new RestRequest
                    {
                        Credentials = new OAuthCredentials()
                            {
                                ConsumerKey = args.ConsumerKey,
                                ConsumerSecret = args.ConsumerSecret,
                                CallbackUrl = args.CallbackUrl
                            },
                        Method = WebMethod.Get,
                        Path = "/oauth2/authorize"
                    };
                return request;
            };

        private readonly Func<FunctionArguments, RestRequest> _requestTokenQuery = args =>
            {
                var request = new RestRequest
                    {
                        Credentials =
                            new OAuthCredentials
                                {
                                    ConsumerKey = args.ConsumerKey,
                                    ConsumerSecret = args.ConsumerSecret,
                                    ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
                                    SignatureMethod = OAuthSignatureMethod.HmacSha1,
                                    Type = OAuthType.RequestToken
                                },
                        Method = WebMethod.Get,
                        Path = "/oauth2/authorize"
                    };
                return request;
            };

        private readonly Func<FunctionArguments, RestRequest> _accessTokenQuery = args =>
            {
                var request = new RestRequest
                    {
                        ////Credentials =
                        ////    new OAuthCredentials
                        ////        {
                        ////            ConsumerKey = args.ConsumerKey,
                        ////            ConsumerSecret = args.ConsumerSecret,
                        ////            Token = args.Token,
                        ////            TokenSecret = args.TokenSecret,
                        ////            Verifier = args.Verifier,
                        ////            ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
                        ////            SignatureMethod = OAuthSignatureMethod.HmacSha1,
                        ////            Type = OAuthType.AccessToken
                        ////        },
                        Method = WebMethod.Post,
                        Path = "/oauth2/access_token"
                    };
                return request;
            };


        private readonly Func<FunctionArguments, RestRequest> _protectedResourceQuery = args =>
    {
        var request = new RestRequest
        {
            Credentials = new OAuthCredentials
            {
                Type = OAuthType.ProtectedResource,
                ////SignatureMethod = OAuthSignatureMethod.HmacSha1,
                ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
                ConsumerKey = args.ConsumerKey,
                ConsumerSecret = args.ConsumerSecret,
                Token = args.AccessToken,
                TokenSecret = args.AccessToken,
            }
        };
        return request;
    };

        private readonly Func<FunctionArguments, RestRequest> _xAuthQuery = args =>
    {
        var request = new RestRequest
        {
            Credentials = new OAuthCredentials
            {
                Type = OAuthType.ClientAuthentication,
                SignatureMethod = OAuthSignatureMethod.HmacSha1,
                ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
                ConsumerKey = args.ConsumerKey,
                ConsumerSecret = args.ConsumerSecret,
                ClientUsername = args.Username,
                ClientPassword = args.Password
            },
            Method = WebMethod.Post,
            Path = "/oauth/access_token"
        };
        return request;
    };

        private readonly RestClient _oauth;

        public virtual void AuthenticateWith(string token, string tokenSecret)
        {
            _token = token;
            _tokenSecret = tokenSecret;
        }

        public virtual void AuthenticateWith(string consumerKey, string consumerSecret, string token, string tokenSecret)
        {
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
            _token = token;
            _tokenSecret = tokenSecret;
        }

        /// <summary>
        /// Gets the authorization URI base on oauth_token,
        /// then direct user to service provider.
        /// </summary>
        /// <param name="oauth">The oauth.</param>
        /// <returns>The direct uri.</returns>
        public virtual Uri GetAuthorizationUri(OAuthRequestToken oauth)
        {
            return new Uri("http://api.t.sina.com.cn/oauth/authorize?oauth_token=" + oauth.Token);
        }

        public virtual OAuthRequestToken GetRequestToken(string callback)
        {
            var args = new FunctionArguments
            {
                ConsumerKey = _consumerKey,
                ConsumerSecret = _consumerSecret
            };

            var request = _requestTokenQuery.Invoke(args);
            if (!callback.IsNullOrBlank())
            {
                request.AddParameter("client_id", _consumerKey);
                request.AddParameter("redirect_uri", callback);
            }

            var response = _oauth.Request(request);

            SetResponse(response);

            ////var query = HttpUtility.ParseQueryString(response.Content);

            var query = JObject.Parse(response.Content);
            var oauth = new OAuthRequestToken
            {
                ////Token = query["oauth_token"] ?? "?",
                ////TokenSecret = query["oauth_token_secret"] ?? "?",
                ////OAuthCallbackConfirmed = Convert.ToBoolean(query["oauth_callback_confirmed"] ?? "false")
            };

            return oauth;
        }

        public virtual OAuthAccessToken GetAccessToken(string code, GrantType grantType)
        {
            var args = new FunctionArguments
                {
                    ConsumerKey = _consumerKey,
                    ConsumerSecret = _consumerSecret,
                };

            var request = _accessTokenQuery.Invoke(args);
            request.AddParameter("client_id", _consumerKey);
            request.AddParameter("client_secret", _consumerSecret);
            request.AddParameter("grant_type ", grantType.ToString());

            if (grantType == GrantType.AuthorizationCode)
            {
                request.AddParameter("code", code);
                request.AddParameter("redirect_uri", _callbackUrl);
            }
            else
            {
                request.AddParameter("username", _userName);
                request.AddParameter("password", _passWord);
            }

            var response = _oauth.Request(request);

            SetResponse(response);

            ////var query = HttpUtility.ParseQueryString(response.Content);
            var query = JObject.Parse(response.Content);
            var oauth = new OAuthAccessToken()
            {
                Token = query["access_token"].ToString() ?? string.Empty,
                ExpiresIn = query["expires_in"].ToString().ToInt32(),
                UserId = query["uid"].ToString().ToInt64()
            };

            return oauth;
        }

        public virtual OAuthAccessToken GetAccessToken(OAuthRequestToken requestToken, string verifier)
        {
            var args = new FunctionArguments
                {
                    ConsumerKey = _consumerKey,
                    ConsumerSecret = _consumerSecret,
                    Token = requestToken.Token,
                    TokenSecret = requestToken.TokenSecret,
                    Verifier = verifier
                };

            // Invokes a delegate.
            var request = _accessTokenQuery.Invoke(args);

            // Gets the server response.
            var response = _oauth.Request(request);

            SetResponse(response);

            // Convert the reserver char to readable text, for instance
            // &nbsp;，&lt;，&gt; and &quot.
            var query = HttpUtility.ParseQueryString(response.Content);

            var accessToken = new OAuthAccessToken
                {
                    Token = query["oauth_token"] ?? "?",
                    TokenSecret = query["oauth_token_secret"] ?? "?",
                    UserId = query["user_id"].ToInt64(),
                    ScreenName = /*query["screen_name"] ??*/ "?"
                };

            return accessToken;
        }

        public virtual OAuthRequestToken GetRequestToken()
        {
            return GetRequestToken(null);
        }

        public virtual string GetAuthorizationCode()
        {
            return string.Empty;
        }

        public virtual Uri GetRedirectUri(string callback)
        {
        
            if (_callbackUrl.IsNullOrBlank())
            {
                _callbackUrl = callback;
            }
            var args = new FunctionArguments
            {
                ConsumerKey = _consumerKey,
                ConsumerSecret = _consumerSecret,
                CallbackUrl = _callbackUrl
            };

            ////var request = _requestTokenQuery.Invoke(args);
            return new Uri("https://api.weibo.com/oauth2/authorize" + "?client_id=" + _consumerKey + "&redirect_uri=" + _callbackUrl);
            
            ////////if (!CallbackUrl.IsNullOrBlank())
            ////////{
            ////request.AddParameter("client_id", _consumerKey);
            ////request.AddParameter("redirect_uri", _callbackUrl);
            ////////}

            ////var response = _oauth.Request(request);

            ////SetResponse(response);
            ////return null;
        }
    }
}