/*********************************************************************
 * Project Name : Weibo SDK
 * File Name    : WeiboServiceTests.OAuth.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-01-13 08:31:49
 * *******************************************************************/

using System.Configuration;

namespace MiniWeibo.UnitTests
{
    using System;
    using System.Diagnostics;
    using System.Net;

    using Net.Common;

    using NUnit.Framework;

    public partial class WeiboServiceTests
    {

        [Test]
        public void CanGetRequestToken()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret);
            var requestToken = service.GetRequestToken("www.google.com.hk");

            AssertResultWas(service, HttpStatusCode.OK);
            Assert.NotNull(requestToken);
        }

        [Test]
        public void CanGetRedirectUri()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret);
            var redirectUri = service.GetRedirectUri("http://www.google.com.hk/");
            Assert.NotNull(redirectUri);
            Process.Start(redirectUri.ToString());
        }

        public void CanGetAuthorizationCode()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret);
            var redirectUri = service.GetRedirectUri("http://www.google.com.hk/");
            Assert.NotNull(redirectUri);
            Process.Start(redirectUri.ToString());
            string code = "157e795b052e1605a0456040ee9529e2";
        }

        [Test]
        public void CanGetAccessToken()
        {
            ////var service = new WeiboService(_consumerKey, _consumerSecret);
            var service = new WeiboService(_iphoneConsumerKey, _iphoneConsumerSecret);
            var redirectUri = service.GetRedirectUri("https://api.weibo.com/oauth2/default.html");  //http://www.google.com.hk/
            Assert.NotNull(redirectUri);
            Process.Start(redirectUri.ToString());
            string code = "7f4b0a4ddb364215a4e614732f9e8439";
            var accessToken = service.GetAccessToken(code, GrantType.AuthorizationCode);
            Assert.NotNull(accessToken);
            Assert.IsNotNullOrEmpty(accessToken.Token);

            var fileMap = new ExeConfigurationFileMap {ExeConfigFilename = @"app.config"};
            // relative path names possible

            // Open another config file
            Configuration config =
               ConfigurationManager.OpenMappedExeConfiguration(fileMap,
               ConfigurationUserLevel.None);

            //read/write from it as usual
            ConfigurationSection mySection = config.GetSection("appSettings");
            ////mySection.
            ////    config.SectionGroups.Clear(); // make changes to it

            config.Save(ConfigurationSaveMode.Full);  // Save changes
        }

        [Test]
        public void CanExchangeForAccessToken()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret);

            ////var service = new WeiboService(_iphoneConsumerKey, _iphoneConsumerSecret);

            var requestToken = service.GetRequestToken();

            AssertResultWas(service, HttpStatusCode.OK);
            Assert.NotNull(requestToken);

            var uri = service.GetAuthorizationUri(requestToken);
            Process.Start(uri.ToString());

            Console.WriteLine("Press the any key when you have confirmation of your code transmission.");

            string verifier = "233312";
            var accessToken = service.GetAccessToken(requestToken, verifier);
            AssertResultWas(service, HttpStatusCode.OK);
            Assert.IsNotNull(accessToken);
        }

        [Test]
        public void Can_make_protected_resource_request_with_access_token()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret);
            var requestToken = service.GetRequestToken();

            AssertResultWas(service, HttpStatusCode.OK);
            Assert.NotNull(requestToken);

            var uri = service.GetAuthorizationUri(requestToken);
            Process.Start(uri.ToString());

            Console.WriteLine("Press the any key when you have confirmation of your code transmission.");

            string verifier = "394973";
            var accessToken = service.GetAccessToken(requestToken, verifier);
            AssertResultWas(service, HttpStatusCode.OK);
            Assert.IsNotNull(accessToken);

            service.AuthenticateWith(accessToken.Token, accessToken.TokenSecret);
            ////var mentions = service

        }

        [Test]
        public void Can_verify_credentials()
        {
            ////var service = new WeiboService(_consumerKey, _consumerSecret);
            ////service.AuthenticateWith(_accessToken, _accessTokenSecret);
            ////var user = service.VerifyCredentials();
            ////Assert.IsNotNull(user);
            ////var service = new TwitterService(_consumerKey, _consumerSecret);
            ////service.AuthenticateWith(_accessToken, _accessTokenSecret);
            ////var user = service.VerifyCredentials();
            ////Assert.IsNotNull(user);
        }

        [Test]
        public void Can_verify_credentials2()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret);
            service.AuthenticateWith(_accessToken, _accessTokenSecret);
            var user = service.VerifyCredentials();
            Assert.IsNotNull(user);
        }


    }
}
