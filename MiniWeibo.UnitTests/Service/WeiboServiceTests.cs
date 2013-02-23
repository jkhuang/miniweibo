
namespace MiniWeibo.UnitTests
{
    using System;

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
        private readonly string _iphoneConsumerKey;
        private readonly string _iphoneConsumerSecret;
        private readonly string _iphoneAccessToken;

        public WeiboServiceTests()
        {
            _jkrush = ConfigurationManager.AppSettings["JKRush"];
            _consumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
            _consumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
            _accessToken = ConfigurationManager.AppSettings["AccessToken"];
            _accessTokenSecret = ConfigurationManager.AppSettings["AccessTokenSecret"];
            _appKey = ConfigurationManager.AppSettings["AppKey"];
            _appSecret = ConfigurationManager.AppSettings["AppSecret"];
            _iphoneConsumerKey = ConfigurationManager.AppSettings["IphoneConsumerKey"];
            _iphoneConsumerSecret = ConfigurationManager.AppSettings["IphoneConsumerSecret"];
            _iphoneAccessToken = ConfigurationManager.AppSettings["IphoneAccessToken"];

        }

        private static void AssertResultWas(WeiboService service, HttpStatusCode statusCode)
        {
            Assert.IsNotNull(service.Response);
            Assert.AreEqual(statusCode, service.Response.StatusCode);

            ////var accessToken = service();
        }

        #region "Weibo Status"

        [Test]
        public void Can_Get_Public_Timeline()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            ////var service = new WeiboService(_iphoneConsumerKey, _iphoneConsumerSecret, _iphoneAccessToken);

            var result = service.ListWeibosOnPublicTimeline();

            foreach (var item in result)
            {
                Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ", item.CreatedAt, item.User.ScreenName, item.Text);
                if (item.Annotations != null)
                {
                    foreach (var annotation in item.Annotations)
                    {
                        Console.WriteLine("Fid: {0}", annotation.Fid);
                    }
                }

                if (item.Geo != null)
                {
                    Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", item.Geo.Type, item.Geo.Coordinates.Latitude, item.Geo.Coordinates.Longitude);
                }

                if (item.Visible != null)
                {
                    Console.WriteLine("Type: {0} List id: {1}", item.Visible.Type, item.Visible.ListId);
                }
            }

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumbe);

        }

        [Test]
        public void Can_Get_Home_Timeline()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListWeibosOnFriendsTimeline();

            foreach (var item in result)
            {
                Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ", item.CreatedAt, item.User.ScreenName, item.Text);
                if (item.Annotations != null)
                {
                    foreach (var annotation in item.Annotations)
                    {
                        Console.WriteLine("Fid: {0}", annotation.Fid);
                    }
                }

                if (item.Geo != null)
                {
                    Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", item.Geo.Type, item.Geo.Coordinates.Latitude, item.Geo.Coordinates.Longitude);
                }

                if (item.Visible != null)
                {
                    Console.WriteLine("Type: {0} List id: {1}", item.Visible.Type, item.Visible.ListId);
                }
            }

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumbe);
        }

        [Test]
        public void Can_Get_Friends_Timeline()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListWeibosOnHomeTimeline();

            foreach (var item in result)
            {
                Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ", item.CreatedAt, item.User.ScreenName, item.Text);
                if (item.Annotations != null)
                {
                    foreach (var annotation in item.Annotations)
                    {
                        Console.WriteLine("Fid: {0}", annotation.Fid);
                    }
                }

                if (item.Geo != null)
                {
                    Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", item.Geo.Type, item.Geo.Coordinates.Latitude, item.Geo.Coordinates.Longitude);
                }

                if (item.Visible != null)
                {
                    Console.WriteLine("Type: {0} List id: {1}", item.Visible.Type, item.Visible.ListId);
                }
            }

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumbe);
        }

        [Test]
        public void Can_Get_WeiboIds_Friends_Timeline()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListWeiboIdsOnFriendsTimeline();
            foreach (var item in result.Ids)
            {
                Console.WriteLine("Id: {0}", item);
            }
            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);
        }

        [Test]
        public void Can_Get_User_Timeline()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListWeibosOnUserTimeline(2436053772);  //1748510762

            foreach (var item in result)
            {
                Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} Id: {3}", item.CreatedAt, item.User.ScreenName, item.Text, item.Id);
                if (item.Annotations != null)
                {
                    foreach (var annotation in item.Annotations)
                    {
                        Console.WriteLine("Fid: {0}", annotation.Fid);
                    }
                }

                if (item.Geo != null)
                {
                    Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", item.Geo.Type, item.Geo.Coordinates.Latitude, item.Geo.Coordinates.Longitude);
                }

                if (item.Visible != null)
                {
                    Console.WriteLine("Type: {0} List id: {1}", item.Visible.Type, item.Visible.ListId);
                }
            }

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumbe);
        }

        [Test]
        public void Can_Get_WeiboIds_User_Timeline()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListWeiboIdsOnUserTimeline();
            foreach (var item in result.Ids)
            {
                Console.WriteLine("Id: {0}", item);
            }
            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);
        }

        [Test]
        public void Can_Get_Repost_Timeline()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListWeibosOnRepostTimeline(3481474642286341);

            foreach (var item in result)
            {
                Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ", item.CreatedAt, item.User.ScreenName, item.Text);
                if (item.Annotations != null)
                {
                    foreach (var annotation in item.Annotations)
                    {
                        Console.WriteLine("Fid: {0}", annotation.Fid);
                    }
                }

                if (item.Geo != null)
                {
                    Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", item.Geo.Type, item.Geo.Coordinates.Latitude, item.Geo.Coordinates.Longitude);
                }

                if (item.Visible != null)
                {
                    Console.WriteLine("Type: {0} List id: {1}", item.Visible.Type, item.Visible.ListId);
                }
            }

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumbe);
        }

        [Test]
        public void Can_Get_WeiboIds_Repost_Timeline()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListWeiboIdsOnRepostTimeline(3481474642286341);
            foreach (var item in result.Ids)
            {
                Console.WriteLine("Id: {0}", item);
            }
            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);
        }

        [Test]
        public void Can_Get_Weibo_Repost_By_Me()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListWeiboRepostByMe();
            foreach (var item in result)
            {
                Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ", item.CreatedAt, item.User.ScreenName, item.Text);
                if (item.Annotations != null)
                {
                    foreach (var annotation in item.Annotations)
                    {
                        Console.WriteLine("Fid: {0}", annotation.Fid);
                    }
                }

                if (item.Geo != null)
                {
                    Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", item.Geo.Type, item.Geo.Coordinates.Latitude, item.Geo.Coordinates.Longitude);
                }

                if (item.Visible != null)
                {
                    Console.WriteLine("Type: {0} List id: {1}", item.Visible.Type, item.Visible.ListId);
                }
            }

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumbe);
        }

        [Test]
        public void Can_Get_Weibo_Mention_Me()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListWeiboMentionMe();
            foreach (var item in result)
            {
                Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ", item.CreatedAt, item.User.ScreenName, item.Text);
                if (item.Annotations != null)
                {
                    foreach (var annotation in item.Annotations)
                    {
                        Console.WriteLine("Fid: {0}", annotation.Fid);
                    }
                }

                if (item.Geo != null)
                {
                    Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", item.Geo.Type, item.Geo.Coordinates.Latitude, item.Geo.Coordinates.Longitude);
                }

                if (item.Visible != null)
                {
                    Console.WriteLine("Type: {0} List id: {1}", item.Visible.Type, item.Visible.ListId);
                }
            }

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumbe);
        }

        [Test]
        public void Can_Get_WeiboIds_Mention_Me()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListWeiboIdsMentionMe();
            foreach (var item in result.Ids)
            {
                Console.WriteLine("Id: {0}", item);
            }
            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);
        }

        [Test]
        public void Can_Get_Bilateral_Timeline()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListWeibosOnBilateralTimeline();

            foreach (var item in result)
            {
                Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ", item.CreatedAt, item.User.ScreenName, item.Text);
                if (item.Annotations != null)
                {
                    foreach (var annotation in item.Annotations)
                    {
                        Console.WriteLine("Fid: {0}", annotation.Fid);
                    }
                }

                if (item.Geo != null)
                {
                    Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", item.Geo.Type, item.Geo.Coordinates.Latitude, item.Geo.Coordinates.Longitude);
                }

                if (item.Visible != null)
                {
                    Console.WriteLine("Type: {0} List id: {1}", item.Visible.Type, item.Visible.ListId);
                }
            }

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumbe);

        }

        [Test]
        public void Can_Get_Show()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.GetWeiboShow(3542088886978668);

            Assert.IsNotNull(result);
            Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ", result.CreatedAt, result.User.ScreenName, result.Text);
            if (result.Annotations != null)
            {
                foreach (var annotation in result.Annotations)
                {
                    Console.WriteLine("Fid: {0}", annotation.Fid);
                }
            }

            if (result.Geo != null)
            {
                Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", result.Geo.Type, result.Geo.Coordinates.Latitude, result.Geo.Coordinates.Longitude);
            }

            if (result.Visible != null)
            {
                Console.WriteLine("Type: {0} List id: {1}", result.Visible.Type, result.Visible.ListId);
            }
        }

        [Test]
        public void Can_Mid()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.GetMid(3542088886978668, 1);

            Assert.IsNotNull(result);

            Console.WriteLine("Mid: {0}", result);
        }

        [Test]
        public void Can_Batch_Get_Status_Count()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.BatchGetStatusCount("3481474642286341");

            Assert.IsNotNull(result);

            foreach (var item in result)
            {
                Console.WriteLine("Id : {0} Comments : {1} Reposts : {2} Attitudes : {3}",
                    item.Id, item.Comments, item.Reposts, item.Attitudes);
            }

        }

        [Test]
        public void Can_Go_Status()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.GoToWeiboStatus(1748510762, 3542072722494126);

            Assert.IsNotNull(result);
            Console.WriteLine("Result : {0}", result);

            ////foreach (var item in result)
            ////{
            ////    Console.WriteLine("Id : {0} Comments : {1} Reposts : {2} Attitudes : {3}",
            ////        item.Id, item.Comments, item.Reposts, item.Attitudes);
            ////}

        }

        [Test]
        public void Can_Go_Emotions()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListWeiboEmotions();
            Assert.IsNotNull(result);


            foreach (var item in result)
            {
                Console.WriteLine("Category : {0} Url: {1}", item.Category, item.Url);
            }

        }

        [Test]
        public void Can_Repost_Status()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);

            var result = service.RepostWeiboStatus(3543177183505829, "测试转发微博API");

            Assert.IsNotNull(result);

            Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ", result.CreatedAt, result.User.ScreenName, result.Text);
            if (result.Annotations != null)
            {
                foreach (var annotation in result.Annotations)
                {
                    Console.WriteLine("Fid: {0}", annotation.Fid);
                }
            }

            if (result.Geo != null)
            {
                Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", result.Geo.Type, result.Geo.Coordinates.Latitude, result.Geo.Coordinates.Longitude);
            }

            if (result.Visible != null)
            {
                Console.WriteLine("Type: {0} List id: {1}", result.Visible.Type, result.Visible.ListId);
            }
        }

        [Test]
        public void Can_Delete_Status()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);

            var result = service.DeleteWeiboStatus(3543184674368989);

            Assert.IsNotNull(result);

            Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ", result.CreatedAt, result.User.ScreenName, result.Text);
            if (result.Annotations != null)
            {
                foreach (var annotation in result.Annotations)
                {
                    Console.WriteLine("Fid: {0}", annotation.Fid);
                }
            }

            if (result.Geo != null)
            {
                Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", result.Geo.Type, result.Geo.Coordinates.Latitude, result.Geo.Coordinates.Longitude);
            }

            if (result.Visible != null)
            {
                Console.WriteLine("Type: {0} List id: {1}", result.Visible.Type, result.Visible.ListId);
            }
        }

        [Test]
        public void Can_Post_Status()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);

            var result = service.PostWeiboStatus("测试发送微博API");

            Assert.IsNotNull(result);

            Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} Id: {3}", result.CreatedAt, result.User.ScreenName, result.Text, result.Id);
            if (result.Annotations != null)
            {
                foreach (var annotation in result.Annotations)
                {
                    Console.WriteLine("Fid: {0}", annotation.Fid);
                }
            }

            if (result.Geo != null)
            {
                Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", result.Geo.Type, result.Geo.Coordinates.Latitude, result.Geo.Coordinates.Longitude);
            }

            if (result.Visible != null)
            {
                Console.WriteLine("Type: {0} List id: {1}", result.Visible.Type, result.Visible.ListId);
            }
        }

        [Test]
        public void Can_Upload_Status()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);

            var result = service.UploadImage("永恒万花Chrome~", @"C:\Documents and Settings\Administrator\桌面\chrome.png");

            Assert.IsNotNull(result);

            Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} Id: {3}", result.CreatedAt, result.User.ScreenName, result.Text, result.Id);
            if (result.Annotations != null)
            {
                foreach (var annotation in result.Annotations)
                {
                    Console.WriteLine("Fid: {0}", annotation.Fid);
                }
            }

            if (result.Geo != null)
            {
                Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", result.Geo.Type, result.Geo.Coordinates.Latitude, result.Geo.Coordinates.Longitude);
            }

            if (result.Visible != null)
            {
                Console.WriteLine("Type: {0} List id: {1}", result.Visible.Type, result.Visible.ListId);
            }
        }
        #endregion

        #region "Weibo Comments"

        [Test]
        public void Can_Get_Comments_Show()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            ////var service = new WeiboService(_iphoneConsumerKey, _iphoneConsumerSecret, _iphoneAccessToken);

            var result = service.ListWeiboCommentsShow(3481474642286341);

            foreach (var item in result)
            {
                Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ", item.CreatedAt, item.User.ScreenName, item.Text);
                ////if (item.Annotations != null)
                ////{
                ////    foreach (var annotation in item.Annotations)
                ////    {
                ////        Console.WriteLine("Fid: {0}", annotation.Fid);
                ////    }
                ////}

                if (item.Status.Geo != null)
                {
                    Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", item.Status.Geo.Type, item.Status.Geo.Coordinates.Latitude, item.Status.Geo.Coordinates.Longitude);
                }

                if (item.User != null)
                {
                    Console.WriteLine("Id: {0} Screen name: {1}", item.User.Id, item.User.ScreenName);
                }
            }

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumbe);

        }


        [Test]
        public void Can_Get_Comments_By_Me()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            ////var service = new WeiboService(_iphoneConsumerKey, _iphoneConsumerSecret, _iphoneAccessToken);

            var result = service.ListWeiboCommentsByMe();

            foreach (var item in result)
            {
                Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ", item.CreatedAt, item.User.ScreenName, item.Text);
                ////if (item.Annotations != null)
                ////{
                ////    foreach (var annotation in item.Annotations)
                ////    {
                ////        Console.WriteLine("Fid: {0}", annotation.Fid);
                ////    }
                ////}

                if (item.Status.Geo != null)
                {
                    Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", item.Status.Geo.Type, item.Status.Geo.Coordinates.Latitude, item.Status.Geo.Coordinates.Longitude);
                }

                if (item.User != null)
                {
                    Console.WriteLine("Id: {0} Screen name: {1}", item.User.Id, item.User.ScreenName);
                }
            }

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumbe);

        }
        #endregion

    }
}
