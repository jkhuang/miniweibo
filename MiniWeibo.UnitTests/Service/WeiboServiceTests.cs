
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

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);

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

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);
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

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);
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

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);
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

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);
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

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);
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

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);
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

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);

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
            ////var result = service.g(1748510762, 3542072722494126);

            ////Assert.IsNotNull(result);
            ////Console.WriteLine("Result : {0}", result);

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

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);

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

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);

        }

        [Test]
        public void Can_Get_Comments_To_Me()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            ////var service = new WeiboService(_iphoneConsumerKey, _iphoneConsumerSecret, _iphoneAccessToken);

            var result = service.ListWeiboCommentsToMe();

            foreach (var item in result)
            {
                Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ", item.CreatedAt, item.User.ScreenName, item.Text);

                if (item.Status.Geo != null)
                {
                    Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", item.Status.Geo.Type, item.Status.Geo.Coordinates.Latitude, item.Status.Geo.Coordinates.Longitude);
                }

                if (item.User != null)
                {
                    Console.WriteLine("Id: {0} Screen name: {1}", item.User.Id, item.User.ScreenName);
                }
            }

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);

        }

        [Test]
        public void Can_Get_Comments_Timeline()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            ////var service = new WeiboService(_iphoneConsumerKey, _iphoneConsumerSecret, _iphoneAccessToken);

            var result = service.ListWeiboCommentsTimeline();

            foreach (var item in result)
            {
                Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ", item.CreatedAt, item.User.ScreenName, item.Text);

                if (item.Status.Geo != null)
                {
                    Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", item.Status.Geo.Type, item.Status.Geo.Coordinates.Latitude, item.Status.Geo.Coordinates.Longitude);
                }

                if (item.User != null)
                {
                    Console.WriteLine("Id: {0} Screen name: {1}", item.User.Id, item.User.ScreenName);
                }
            }

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);

        }

        [Test]
        public void Can_Get_Comments_Mentions_Me()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            ////var service = new WeiboService(_iphoneConsumerKey, _iphoneConsumerSecret, _iphoneAccessToken);

            var result = service.ListWeiboCommentsMentionsMe();

            foreach (var item in result)
            {
                Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ", item.CreatedAt, item.User.ScreenName, item.Text);

                if (item.Status.Geo != null)
                {
                    Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", item.Status.Geo.Type, item.Status.Geo.Coordinates.Latitude, item.Status.Geo.Coordinates.Longitude);
                }

                if (item.User != null)
                {
                    Console.WriteLine("Id: {0} Screen name: {1}", item.User.Id, item.User.ScreenName);
                }
            }

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);

        }

        [Test]
        public void Can_Batch_Get_Comments_Show()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            ////var service = new WeiboService(_iphoneConsumerKey, _iphoneConsumerSecret, _iphoneAccessToken);

            var result = service.BatchGetWeiboCommentsShow("3486200088153858,3486199517447154,3486198749848122");

            foreach (var item in result)
            {
                Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ", item.CreatedAt, item.User.ScreenName, item.Text);

                if (item.Status.Geo != null)
                {
                    Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", item.Status.Geo.Type, item.Status.Geo.Coordinates.Latitude, item.Status.Geo.Coordinates.Longitude);
                }

                if (item.User != null)
                {
                    Console.WriteLine("Id: {0} Screen name: {1}", item.User.Id, item.User.ScreenName);
                }
            }

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);

        }

        [Test]
        public void Can_Create_Comment()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            ////var service = new WeiboService(_iphoneConsumerKey, _iphoneConsumerSecret, _iphoneAccessToken);

            var result = service.CreateWeiboComment("Test", 3552962389950241);

            Assert.IsNotNull(result);
            Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} Id: {3}", result.CreatedAt, result.User.ScreenName, result.Text, result.Id);
            if (result.Status.Annotations != null)
            {
                foreach (var annotation in result.Status.Annotations)
                {
                    Console.WriteLine("Fid: {0}", annotation.Fid);
                }
            }

            if (result.Status.Geo != null)
            {
                Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", result.Status.Geo.Type, result.Status.Geo.Coordinates.Latitude, result.Status.Geo.Coordinates.Longitude);
            }

            if (result.Status.Visible != null)
            {
                Console.WriteLine("Type: {0} List id: {1}", result.Status.Visible.Type, result.Status.Visible.ListId);
            }

        }

        [Test]
        public void Can_Delete_Comment()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            ////var service = new WeiboService(_iphoneConsumerKey, _iphoneConsumerSecret, _iphoneAccessToken);

            var result = service.DeleteWeiboComment(3552964960714467);

            Assert.IsNotNull(result);
            Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ", result.CreatedAt, result.User.ScreenName, result.Text);
            if (result.Status.Annotations != null)
            {
                foreach (var annotation in result.Status.Annotations)
                {
                    Console.WriteLine("Fid: {0}", annotation.Fid);
                }
            }

            if (result.Status.Geo != null)
            {
                Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", result.Status.Geo.Type, result.Status.Geo.Coordinates.Latitude, result.Status.Geo.Coordinates.Longitude);
            }

            if (result.Status.Visible != null)
            {
                Console.WriteLine("Type: {0} List id: {1}", result.Status.Visible.Type, result.Status.Visible.ListId);
            }

        }

        [Test]
        public void Can_Batch_Delete_Comments()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            ////var service = new WeiboService(_iphoneConsumerKey, _iphoneConsumerSecret, _iphoneAccessToken);

            var result = service.BatchDeleteWeiboComments("3552966789325484,3552966986503266");

            Assert.IsNotNull(result);

            foreach (var item in result)
            {
                Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ", item.CreatedAt, item.User.ScreenName, item.Text);

                if (item.Status.Geo != null)
                {
                    Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", item.Status.Geo.Type, item.Status.Geo.Coordinates.Latitude, item.Status.Geo.Coordinates.Longitude);
                }

                if (item.User != null)
                {
                    Console.WriteLine("Id: {0} Screen name: {1}", item.User.Id, item.User.ScreenName);
                }
            }

            ////Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);

        }

        [Test]
        public void Can_Reply_Comment()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            ////var service = new WeiboService(_iphoneConsumerKey, _iphoneConsumerSecret, _iphoneAccessToken);

            var result = service.ReplyWeiboComments(3552970048292491, 3552962389950241, "test2");

            Assert.IsNotNull(result);
            Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ", result.CreatedAt, result.User.ScreenName, result.Text);
            if (result.Status.Annotations != null)
            {
                foreach (var annotation in result.Status.Annotations)
                {
                    Console.WriteLine("Fid: {0}", annotation.Fid);
                }
            }

            if (result.Status.Geo != null)
            {
                Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", result.Status.Geo.Type, result.Status.Geo.Coordinates.Latitude, result.Status.Geo.Coordinates.Longitude);
            }

            if (result.Status.Visible != null)
            {
                Console.WriteLine("Type: {0} List id: {1}", result.Status.Visible.Type, result.Status.Visible.ListId);
            }

        }

        #endregion

        #region "Weibo Users"

        [Test]
        public void Can_Get_Users_Show()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);

            var result = service.WeiboUsersShow("JKhuang23");
            Assert.IsNotNull(result);
            Console.WriteLine("Id: {0} Screen name: {1} Location: {2}", result.Id, result.ScreenName, result.Location);
        }


        [Test]
        public void Can_Get_Users_Domain_Show()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);

            var result = service.WeiboUsersDomainShow("jkrush");
            Assert.IsNotNull(result);
            Console.WriteLine("Id: {0} Screen name: {1} Location: {2}", result.Id, result.ScreenName, result.Location);
        }

        [Test]
        public void Can_Get_Users_Counts()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);

            var result = service.WeiboUsersCounts("1904178193,1870632073,2436053772");
            Assert.IsNotNull(result);

            foreach (var item in result)
            {
                Console.WriteLine("Id: {0} followers: {1} friends: {2} statuses: {3}",
       item.Id, item.FollowersCount, item.FriendsCount, item.StatusesCount);
            }

        }

        [Test]
        public void Can_Get_Users_Rank()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.WeiboUsersRank(2436053772);
            Assert.IsNotNull(result);
            Console.WriteLine("Uid: {0} Rank: {1}", result.Uid, result.Rank);
        }

        // Need to authorization api.
        [Test]
        public void Can_Get_Users_Top_Status()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret);
            var result = service.WeiboUsersTopStatus("5786724301", 2436053772);
            Assert.IsNotNull(result);
            Console.WriteLine("Uid: {0} Mid: {1} Use: {2} Create at: {3}",
                result.Uid, result.Mid, result.IsUse, result.CreateAt);
        }

        #endregion

        #region "Weibo Friendships"

        [Test]
        public void Can_Get_Friendships_Friend()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);

            var result = service.ListWeiboFriendships(2436053772);
            Assert.IsNotNull(result);

            foreach (var item in result)
            {
                Console.WriteLine("Id: {0} Screen name: {1} location: {2} Status: {3}",
       item.Id, item.ScreenName, item.Location, item.StatusesCount);
            }
            Console.WriteLine("Previous cursor: {0} Next cursor: {1} Total number: {2}",
                 result.PreviousCursor, result.NextCursor, result.TotalNumber);
        }


        /// <summary>
        /// TODO:Insufficient app permissions
        /// </summary>
        [Test]
        public void Can_Batch_Get_Friendships_Remark()
        {
            var service = new WeiboService("5786724301", _consumerSecret);
            var result = service.BatchGetWeiboFriendsRemark("5786724301", "1748510762");
            Assert.IsNotNull(result);
        }

        [Test]
        public void Can_Batch_Get_Friendships_Friends_In_Common()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListWeiboFriendsInCommon(1904178193, 1870632073);

            foreach (var item in result)
            {
                Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ",
                    item.CreatedAt, item.ScreenName, item.Description);
            }

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}",
                result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);

        }

        [Test]
        public void Can_Batch_Get_Friendships_Friends_Bilateral()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListWeiboFriendsBilateral(1904178193);

            foreach (var item in result)
            {
                Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ",
                    item.CreatedAt, item.ScreenName, item.Description);
            }

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}",
                result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);
        }

        [Test]
        public void Can_Batch_Get_Friendships_Friends_Bilateral_Ids()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListWeiboFriendsBilateralIds(1904178193);

            foreach (var item in result)
            {
                Console.WriteLine("Id: {0}", item);
            }

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}",
                result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);
        }

        [Test]
        public void Can_Batch_Get_Friendships_Friends_Ids()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListWeiboFriendsIds(1904178193);

            foreach (var item in result)
            {
                Console.WriteLine("Id: {0}", item);
            }

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}",
                result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);
        }


        [Test]
        public void Can_Batch_Get_Friendships_Followers()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListWeiboFriendshipsFollowers(1904178193);

            foreach (var item in result)
            {
                Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ",
                    item.CreatedAt, item.ScreenName, item.Description);
            }

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}",
                result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);
        }

        [Test]
        public void Can_Batch_Get_Friendships_Follower_Ids()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListWeiboFriendshipsFollowersIds(1904178193);

            foreach (var item in result)
            {
                Console.WriteLine("Id: {0}", item);
            }

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}",
                result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);
        }

        [Test]
        public void Can_Batch_Get_Friendships_Active_Followers()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListWeiboFriendshipsActiveFollowers(1904178193);

            foreach (var item in result)
            {
                Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ",
                    item.CreatedAt, item.ScreenName, item.Description);
            }
        }


        [Test]
        public void Can_Batch_Get_Friendships_Friends_Chain()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListWeiboFriendshipsFriendsChain(1748510762);

            foreach (var item in result)
            {
                Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ",
                    item.CreatedAt, item.ScreenName, item.Description);
            }

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}",
                result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);
        }

        [Test]
        public void Can_Get_Friendships_Show()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.WeiboFriendshipsShow(1748510762, 1904178193);

            Console.WriteLine("Id: {0} Screen name: {1} Followed by: {2} Following: {3} Notifications enabled: {4}",
                    result.Target.Id, result.Target.ScreenName, result.Target.FollowedBy, result.Target.Following, result.Target.NotificationsEnabled);


            Console.WriteLine("Id: {0} Screen name: {1} Followed by: {2} Following: {3} Notifications enabled: {4}",
                               result.Source.Id, result.Source.ScreenName, result.Source.FollowedBy, result.Source.Following, result.Source.NotificationsEnabled);
        }

        [Test]
        public void Can_Create_Friendships()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.WeiboFriendshipsCreate("姚晨");

            Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ",
                result.CreatedAt, result.ScreenName, result.Description);
        }

        [Test]
        public void Can_Delete_Friendships()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.WeiboFriendshipsDelete("姚晨");

            Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ",
                result.CreatedAt, result.ScreenName, result.Description);
        }

        /// <summary>
        /// TODO:Insufficient app permissions
        /// </summary>
        [Test]
        public void Can_Delete_Friendships_Follower()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.WeiboFriendshipsFollowersDelete("5786724301", 2436053772);

            Assert.IsNotNull(result);

            Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ",
                result.CreatedAt, result.ScreenName, result.Description);
        }

        [Test]
        public void Can_Update_Friendships_Remark()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.WeiboFriendshipsRemarkUpdate(1748510762, "+丽");

            Assert.IsNotNull(result);

            Console.WriteLine("Create at: {0} Screen name: {1} Text: {2} ",
                result.CreatedAt, result.ScreenName, result.Description);
        }

        /// <summary>
        /// TODO:Insufficient app permissions
        /// </summary>
        [Test]
        public void Can_Get_Friendships_Groups()
        {

        }

        [Test]
        public void Can_Get_Weibo_On_Groups_Timeline()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListWeibosOnGroupsTimeline(11);
            Assert.IsNotNull(result);

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

            Console.WriteLine("HasVisual: {0} Previous cursor: {1} Next cursor: {2} Total number: {3}", result.HasVisible, result.PreviousCursor, result.NextCursor, result.TotalNumber);
        }

        #endregion

        #region "Weibo Accounts"

        [Test]
        public void Can_Get_Account_Groups()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.GetAccountPrivacy();
            Assert.IsNotNull(result);
            Console.WriteLine("Badge: {0} Comment: {1} Geo: {2} Message: {3} Mobile: {4} Realname: {5}",
                result.Badge, result.Comment, result.Geo, result.Message, result.Mobile, result.Realname);
        }


        [Test]
        public void Can_Get_Account_Schools()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListOfSchool("中山");
            Assert.IsNotNull(result);

            foreach (var item in result)
            {
                Console.WriteLine("Id: {0} Name: {1}", item.Id, item.Name);
            }
        }

        [Test]
        public void Can_Get_Account_API()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.WeiboAccountLimit();
            Assert.IsNotNull(result);
            Console.WriteLine("IpLimit : {0} LimitTimeUnit: {1} RemainingIpHits: {2} RemainingUserHits: {3} ResetTime: {4} ResetTimeInSeconds: {5} UserLimit: {6}",
                result.IpLimit, result.LimitTimeUnit, result.RemainingIpHits, result.RemainingUserHits, result.ResetTime, result.ResetTimeInSeconds, result.UserLimit);

        }


        [Test]
        public void Can_Get_Account_Uid()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.GetAuthorizationUid();
            Assert.IsNotNull(result);
            Console.WriteLine("Uid: {0}", result);

        }

        [Test]
        public void Can_Get_Account_SignOut()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.WeiboSignOut();
            Assert.IsNotNull(result);

            Console.WriteLine("Id: {0} followers: {1} friends: {2} statuses: {3}",
   result.Id, result.FollowersCount, result.FriendsCount, result.StatusesCount);

        }
        #endregion

        #region "Weibo Favorites"

        [Test]
        public void Can_Get_Favorites()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListOfWeiboFavorites();
            Assert.IsNotNull(result);

            foreach (var item in result)
            {
                Console.WriteLine("Create at: {0} Text: {1} ", item.Status.CreatedAt, item.Status.Text);
                if (!string.Equals(item.Status.Deleted, "1") && item.Status.Annotations != null)
                {
                    Console.WriteLine("Screen name: {0}", item.Status.User.ScreenName);
                    foreach (var annotation in item.Status.Annotations)
                    {
                        Console.WriteLine("Fid: {0}", annotation.Fid);
                    }
                }

                if (item.Status.Geo != null)
                {
                    Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", item.Status.Geo.Type, item.Status.Geo.Coordinates.Latitude, item.Status.Geo.Coordinates.Longitude);
                }

                if (item.Status.Visible != null)
                {
                    Console.WriteLine("Type: {0} List id: {1}", item.Status.Visible.Type, item.Status.Visible.ListId);
                }

                if (item.Tags != null)
                {
                    foreach (var tag in item.Tags)
                        Console.WriteLine("Id: {0} Tag: {1} Count: {2}", tag.Id, tag.Tag, tag.Count);

                }

            }

            Console.WriteLine("Total number: {0}", result.TotalNumber);
        }

        [Test]
        public void Can_Get_Favorite_Id()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListOfWeiboFavoriteIds();
            Assert.IsNotNull(result);

            foreach (var item in result)
            {
                Console.WriteLine("Stauts: {0}", item.Status);

                if (item.Tags != null)
                {
                    foreach (var tag in item.Tags)
                        Console.WriteLine("Id: {0} Tag: {1} Count: {2}", tag.Id, tag.Tag, tag.Count);

                }

                Console.WriteLine("Favorited time: {0}", item.FavoritedTime);

            }
            Console.WriteLine("Total number: {0}", result.TotalNumber);
        }


        [Test]
        public void Can_Get_Favorites_Show()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.WeiboFavoriteShow(3468084620952666);
            Assert.IsNotNull(result);

            ////foreach (var item in result)
            ////{
            Console.WriteLine("Create at: {0} Text: {1} ", result.Status.CreatedAt, result.Status.Text);
            if (!string.Equals(result.Status.Deleted, "1") && result.Status.Annotations != null)
            {
                Console.WriteLine("Screen name: {0}", result.Status.User.ScreenName);
                foreach (var annotation in result.Status.Annotations)
                {
                    Console.WriteLine("Fid: {0}", annotation.Fid);
                }
            }

            if (result.Status.Geo != null)
            {
                Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", result.Status.Geo.Type, result.Status.Geo.Coordinates.Latitude, result.Status.Geo.Coordinates.Longitude);
            }

            if (result.Status.Visible != null)
            {
                Console.WriteLine("Type: {0} List id: {1}", result.Status.Visible.Type, result.Status.Visible.ListId);
            }

            if (result.Tags != null)
            {
                foreach (var tag in result.Tags)
                    Console.WriteLine("Id: {0} Tag: {1} Count: {2}", tag.Id, tag.Tag, tag.Count);

            }

            ////}

            ////Console.WriteLine("Total number: {0}", result.TotalNumber);
        }

        [Test]
        public void Can_Get_Favorites_By_Tag()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListOfWeiboFavoritesByTag(273771);
            Assert.IsNotNull(result);

            foreach (var item in result)
            {
                Console.WriteLine("Create at: {0} Text: {1} ", item.Status.CreatedAt, item.Status.Text);
                if (!string.Equals(item.Status.Deleted, "1") && item.Status.Annotations != null)
                {
                    Console.WriteLine("Screen name: {0}", item.Status.User.ScreenName);
                    foreach (var annotation in item.Status.Annotations)
                    {
                        Console.WriteLine("Fid: {0}", annotation.Fid);
                    }
                }

                if (item.Status.Geo != null)
                {
                    Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", item.Status.Geo.Type, item.Status.Geo.Coordinates.Latitude, item.Status.Geo.Coordinates.Longitude);
                }

                if (item.Status.Visible != null)
                {
                    Console.WriteLine("Type: {0} List id: {1}", item.Status.Visible.Type, item.Status.Visible.ListId);
                }

                if (item.Tags != null)
                {
                    foreach (var tag in item.Tags)
                        Console.WriteLine("Id: {0} Tag: {1} Count: {2}", tag.Id, tag.Tag, tag.Count);

                }

            }

            Console.WriteLine("Total number: {0}", result.TotalNumber);
        }


        [Test]
        public void Can_Get_Favorites_Tag()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListOfWeiboFavoriteTags();
            Assert.IsNotNull(result);

            foreach (var item in result)
            {
                Console.WriteLine("Id: {0} Tag: {1} Count: {2}", item.Id, item.Tag, item.Count);
            }

            Console.WriteLine("Total number: {0}", result.TotalNumber);
        }

        [Test]
        public void Can_Get_Favorite_Ids_By_Tag()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListOfWeiboFavoriteIdsByTag(273771);
            Assert.IsNotNull(result);

            foreach (var item in result)
            {
                Console.WriteLine("Stauts: {0}", item.Status);

                if (item.Tags != null)
                {
                    foreach (var tag in item.Tags)
                        Console.WriteLine("Id: {0} Tag: {1} Count: {2}", tag.Id, tag.Tag, tag.Count);

                }

                Console.WriteLine("Favorited time: {0}", item.FavoritedTime);

            }
            Console.WriteLine("Total number: {0}", result.TotalNumber);
        }

        [Test]
        public void Can_Add_Favorites()
        {
            ////            Id: 3561979086589796
            ////Id: 3561979082394559
            ////Id: 3561979074004851
            ////Id: 3561979074004627
            ////Id: 3561979068930955
            ////Id: 3561979065072325
            ////Id: 3561979056771525
            ////Id: 3561979052576401
            ////Id: 3561979036249361
            ////Id: 3561978964398816
            ////Id: 3561978570605039
            ////Id: 3561978372607207
            ////Id: 3561978091561167
            ////Id: 3561978083171511
            ////Id: 3561978079312219
            ////Id: 3561978075594014
            ////Id: 3561978067023849
            ////Id: 3561978066392784
            ////Id: 3561978066392665
            ////Id: 3561978058813683
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.AddFavorite(3561979074004627);
            Assert.IsNotNull(result);

            ////foreach (var item in result)
            ////{
            Console.WriteLine("Create at: {0} Text: {1} ", result.Status.CreatedAt, result.Status.Text);
            if (!string.Equals(result.Status.Deleted, "1") && result.Status.Annotations != null)
            {
                Console.WriteLine("Screen name: {0}", result.Status.User.ScreenName);
                foreach (var annotation in result.Status.Annotations)
                {
                    Console.WriteLine("Fid: {0}", annotation.Fid);
                }
            }

            if (result.Status.Geo != null)
            {
                Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", result.Status.Geo.Type, result.Status.Geo.Coordinates.Latitude, result.Status.Geo.Coordinates.Longitude);
            }

            if (result.Status.Visible != null)
            {
                Console.WriteLine("Type: {0} List id: {1}", result.Status.Visible.Type, result.Status.Visible.ListId);
            }

            if (result.Tags != null)
            {
                foreach (var tag in result.Tags)
                    Console.WriteLine("Id: {0} Tag: {1} Count: {2}", tag.Id, tag.Tag, tag.Count);

            }

            ////}

            Console.WriteLine("Favorited time: {0}", result.FavoritedTime);
        }

        [Test]
        public void Can_Delete_Favorites()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.DeleteFavorite(3444517204329764);
            Assert.IsNotNull(result);

            ////foreach (var item in result)
            ////{
            Console.WriteLine("Create at: {0} Text: {1} ", result.Status.CreatedAt, result.Status.Text);
            if (!string.Equals(result.Status.Deleted, "1") && result.Status.Annotations != null)
            {
                Console.WriteLine("Screen name: {0}", result.Status.User.ScreenName);
                foreach (var annotation in result.Status.Annotations)
                {
                    Console.WriteLine("Fid: {0}", annotation.Fid);
                }
            }

            if (result.Status.Geo != null)
            {
                Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", result.Status.Geo.Type, result.Status.Geo.Coordinates.Latitude, result.Status.Geo.Coordinates.Longitude);
            }

            if (result.Status.Visible != null)
            {
                Console.WriteLine("Type: {0} List id: {1}", result.Status.Visible.Type, result.Status.Visible.ListId);
            }

            if (result.Tags != null)
            {
                foreach (var tag in result.Tags)
                    Console.WriteLine("Id: {0} Tag: {1} Count: {2}", tag.Id, tag.Tag, tag.Count);

            }

            ////}

            Console.WriteLine("Favorited time: {0}", result.FavoritedTime);
        }

        [Test]
        public void Can_Batch_Delete_Favorites()
        {

            ////            Id: 3561979086589796
            ////Id: 3561979082394559
            ////Id: 3561979074004851
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.BatchDeleteFavorite("3561979074004627");
            Assert.IsNotNull(result);
            Console.WriteLine("Result: {0}", result);
        }

        [Test]
        public void Can_Update_Favorites_Tags()
        {
            ////            Id: 3561979086589796
            ////Id: 3561979082394559
            ////Id: 3561979074004851
            ////Id: 3561979074004627
            ////Id: 3561979068930955
            ////Id: 3561979065072325
            ////Id: 3561979056771525
            ////Id: 3561979052576401
            ////Id: 3561979036249361
            ////Id: 3561978964398816
            ////Id: 3561978570605039
            ////Id: 3561978372607207
            ////Id: 3561978091561167
            ////Id: 3561978083171511
            ////Id: 3561978079312219
            ////Id: 3561978075594014
            ////Id: 3561978067023849
            ////Id: 3561978066392784
            ////Id: 3561978066392665
            ////Id: 3561978058813683
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.UpdateFavoritesTags(3561979074004851, "English,xx");
            Assert.IsNotNull(result);

            ////foreach (var item in result)
            ////{
            Console.WriteLine("Create at: {0} Text: {1} ", result.Status.CreatedAt, result.Status.Text);
            if (!string.Equals(result.Status.Deleted, "1") && result.Status.Annotations != null)
            {
                Console.WriteLine("Screen name: {0}", result.Status.User.ScreenName);
                foreach (var annotation in result.Status.Annotations)
                {
                    Console.WriteLine("Fid: {0}", annotation.Fid);
                }
            }

            if (result.Status.Geo != null)
            {
                Console.WriteLine("Type: {0} Latitude: {1} Longitude: {2}", result.Status.Geo.Type, result.Status.Geo.Coordinates.Latitude, result.Status.Geo.Coordinates.Longitude);
            }

            if (result.Status.Visible != null)
            {
                Console.WriteLine("Type: {0} List id: {1}", result.Status.Visible.Type, result.Status.Visible.ListId);
            }

            if (result.Tags != null)
            {
                foreach (var tag in result.Tags)
                    Console.WriteLine("Id: {0} Tag: {1} Count: {2}", tag.Id, tag.Tag, tag.Count);

            }

            ////}

            Console.WriteLine("Favorited time: {0}", result.FavoritedTime);
        }

        [Test]
        public void Can_Batch_Update_Favorites_Tags()
        {
            ////            Id: 3561979086589796
            ////Id: 3561979082394559
            ////Id: 3561979074004851
            ////Id: 3561979074004627
            ////Id: 3561979068930955
            ////Id: 3561979065072325
            ////Id: 3561979056771525
            ////Id: 3561979052576401
            ////Id: 3561979036249361
            ////Id: 3561978964398816
            ////Id: 3561978570605039
            ////Id: 3561978372607207
            ////Id: 3561978091561167
            ////Id: 3561978083171511
            ////Id: 3561978079312219
            ////Id: 3561978075594014
            ////Id: 3561978067023849
            ////Id: 3561978066392784
            ////Id: 3561978066392665
            ////Id: 3561978058813683
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.BatchUpdateFavoritesTags(887221, "Favorites");
            Assert.IsNotNull(result);


            Console.WriteLine("Id: {0} Tag: {1} Count: {2}", result.Id, result.Tag, result.Count);


        }

        [Test]
        public void Can_Batch_Delete_Favorites_Tags()
        {
            ////            Id: 3561979086589796
            ////Id: 3561979082394559
            ////Id: 3561979074004851
            ////Id: 3561979074004627
            ////Id: 3561979068930955
            ////Id: 3561979065072325
            ////Id: 3561979056771525
            ////Id: 3561979052576401
            ////Id: 3561979036249361
            ////Id: 3561978964398816
            ////Id: 3561978570605039
            ////Id: 3561978372607207
            ////Id: 3561978091561167
            ////Id: 3561978083171511
            ////Id: 3561978079312219
            ////Id: 3561978075594014
            ////Id: 3561978067023849
            ////Id: 3561978066392784
            ////Id: 3561978066392665
            ////Id: 3561978058813683
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.BatchDeleteFavoritesTags(887221);
            Assert.IsNotNull(result);

            Console.WriteLine("Result: {0}", result);
        }


        #endregion

        #region "Weibo Trends"

        [Test]
        public void Can_Trends()
        {
            ////            Id: 3561979086589796
            ////Id: 3561979082394559
            ////Id: 3561979074004851
            ////Id: 3561979074004627
            ////Id: 3561979068930955
            ////Id: 3561979065072325
            ////Id: 3561979056771525
            ////Id: 3561979052576401
            ////Id: 3561979036249361
            ////Id: 3561978964398816
            ////Id: 3561978570605039
            ////Id: 3561978372607207
            ////Id: 3561978091561167
            ////Id: 3561978083171511
            ////Id: 3561978079312219
            ////Id: 3561978075594014
            ////Id: 3561978067023849
            ////Id: 3561978066392784
            ////Id: 3561978066392665
            ////Id: 3561978058813683
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListOfWeiboTrendsInfo(1642909335);
            Assert.IsNotNull(result);

            foreach (var item in result)
            {
                Console.WriteLine("Number: {0} Hot word: {1} Trend id: {2}", item.Num, item.Hotword, item.TrendId);
            }

            
        }

        [Test]
        public void Can_Get_Trends_Follow()
        {
            ////            Id: 3561979086589796
            ////Id: 3561979082394559
            ////Id: 3561979074004851
            ////Id: 3561979074004627
            ////Id: 3561979068930955
            ////Id: 3561979065072325
            ////Id: 3561979056771525
            ////Id: 3561979052576401
            ////Id: 3561979036249361
            ////Id: 3561978964398816
            ////Id: 3561978570605039
            ////Id: 3561978372607207
            ////Id: 3561978091561167
            ////Id: 3561978083171511
            ////Id: 3561978079312219
            ////Id: 3561978075594014
            ////Id: 3561978067023849
            ////Id: 3561978066392784
            ////Id: 3561978066392665
            ////Id: 3561978058813683
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.IsFollowTrends("仙剑奇侠传");
            Assert.IsNotNull(result);



            Console.WriteLine("Trend id: {0} Is follow: {1}", result.TrendId, result.IsFollow);
       

        }

        [Test]
        public void Can_Get_Hourly_Trends()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListOfHourlyTrends();
            Assert.IsNotNull(result);

            foreach (var item in result.Trends)
            {
                Console.WriteLine("Trend id: {0} Query: {1} Amount: {2} Delta: {3}", item.Name, item.Query, item.Amount, item.Delta);
                Console.WriteLine("Time: {0}", item.TrendingAsOf);
            }

            Console.WriteLine("As of: {0}", result.AsOf);
        }

        [Test]
        public void Can_Get_Daily_Trends()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListOfDailyTrends();
            Assert.IsNotNull(result);

            foreach (var item in result.Trends)
            {
                Console.WriteLine("Trend id: {0} Query: {1} Amount: {2} Delta: {3}", item.Name, item.Query, item.Amount, item.Delta);
                Console.WriteLine("Time: {0}", item.TrendingAsOf);
            }

            Console.WriteLine("As of: {0}", result.AsOf);
        }

        [Test]
        public void Can_Get_Weekly_Trends()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListOfWeeklyTrends();
            Assert.IsNotNull(result);

            foreach (var item in result.Trends)
            {
                Console.WriteLine("Trend id: {0} Query: {1} Amount: {2} Delta: {3}", item.Name, item.Query, item.Amount, item.Delta);
                Console.WriteLine("Time: {0}", item.TrendingAsOf);
            }

            Console.WriteLine("As of: {0}", result.AsOf);
        }

        [Test]
        public void Can_Follow_Trends()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.FollowTrends("厨子戏子痞子");
            Assert.IsNotNull(result);
            Console.WriteLine("Topicid: {0}", result);
        }

        [Test]
        public void Can_Unfollow_Trends()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.UnfollowTrends(20744608);
            Assert.IsNotNull(result);
            Console.WriteLine("Result: {0}", result);
        }

        #endregion

        #region "Weibo Tags"

        [Test]
        public void Can_Get_User_Tags()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.ListOfUserTags(1748510762);
            Assert.IsNotNull(result);

            foreach (var item in result)
            {
                Console.WriteLine("Tag id: {0} Tag Number: {1} Weight: {2}", item.UserTagId, item.UserTagName, item.Weight);
            }


        }

        [Test]
        public void Can_Batch_Get_User_Tags()
        {
            var service = new WeiboService(_consumerKey, _consumerSecret, _accessToken);
            var result = service.BatchGetUserTags("1904178193,1287611181");
            Assert.IsNotNull(result);

            ////foreach (var item in result)
            ////{
            ////    Console.WriteLine("Tag id: {0} Tag Number: {1} Weight: {2}", item.UserTagId, item.UserTagName, item.Weight);
            ////}


        }

        #endregion
    }
}
