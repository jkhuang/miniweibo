namespace MiniWeibo.UnitTests
{
    using System.Configuration;
    using System.Net;

    using MiniWeibo.Net.Common;

    using NUnit.Framework;

    [TestFixture]
    public partial class WeiboServiceTests
    {
        private readonly string _jkrush;
        private readonly string _consumerKey;
        private readonly string _consumerSecret;
        private readonly string _accessToken;
        private readonly string _accessTokenSecret;
        private readonly string _appKey;
        private readonly string _appSecret;

        public WeiboServiceTests()
        {
            _jkrush = ConfigurationManager.AppSettings["JKRush"];
            _consumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
            _consumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
            _accessToken = ConfigurationManager.AppSettings["AccessToken"];
            _accessTokenSecret = ConfigurationManager.AppSettings["AccessTokenSecret"];
            _appKey = ConfigurationManager.AppSettings["AppKey"];
            _appSecret = ConfigurationManager.AppSettings["AppSecret"];

        }

        private static void AssertResultWas(WeiboService service, HttpStatusCode statusCode)
        {
            Assert.IsNotNull(service.Response);
            Assert.AreEqual(statusCode, service.Response.StatusCode);

            ////var accessToken = service();
        }
    }
}
