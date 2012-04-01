namespace MiniWeibo.UnitTests
{
    using System;
    using System.Diagnostics;
    using System.Net;

    using MiniWeibo.Net.Common;

    using NUnit.Framework;

    using TweetSharp;

    public partial class WeiboServiceTests
    {

        [Test]
        public void CanGetRequestToken()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret);
            var requestToken = service.GetRequestToken();

            AssertResultWas(service, HttpStatusCode.OK);
            Assert.NotNull(requestToken);
        }

        [Test]
        public void CanExchangeForAccessToken()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret);
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
            var service = new TwitterService(_consumerKey, _consumerSecret);
            service.AuthenticateWith(_accessToken, _accessTokenSecret);
            var user = service.VerifyCredentials();
            Assert.IsNotNull(user);
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
