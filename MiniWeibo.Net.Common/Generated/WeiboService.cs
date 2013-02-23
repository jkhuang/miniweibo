 
// This is the output code from your template
// you only get syntax-highlighting here - not intellisense
using System;
using System.Collections.Generic;
using Hammock;
using Hammock.Web;

namespace MiniWeibo.Net.Common
{
    public partial interface IMiniWeiboService
	{
		#region Sequential Methods
							WeiboAccount GetAccountPrivacy();	
							WeiboUser VerifyCredentials();	
							WeiboCursorList<WeiboStatus> ListWeibosOnPublicTimeline();	
							WeiboCursorList<WeiboStatus> ListWeibosOnPublicTimeline(int count);	
							WeiboCursorList<WeiboStatus> ListWeibosOnPublicTimeline(string source, string accessToken, int count);	
							WeiboCursorList<WeiboStatus> ListWeibosOnFriendsTimeline();	
							WeiboCursorList<WeiboStatus> ListWeibosOnHomeTimeline();	
							WeiboIdInfo ListWeiboIdsOnFriendsTimeline();	
							WeiboCursorList<WeiboStatus> ListWeibosOnUserTimeline(long uid);	
							WeiboCursorList<WeiboStatus> ListWeibosOnUserTimeline(string screenName);	
							WeiboIdInfo ListWeiboIdsOnUserTimeline();	
							WeiboCursorList<WeiboStatus> ListWeibosOnRepostTimeline(long id);	
							WeiboIdInfo ListWeiboIdsOnRepostTimeline(long id);	
							WeiboCursorList<WeiboStatus> ListWeiboRepostByMe();	
							WeiboCursorList<WeiboStatus> ListWeiboMentionMe();	
							WeiboIdInfo ListWeiboIdsMentionMe();	
							WeiboCursorList<WeiboStatus> ListWeibosOnBilateralTimeline();	
							WeiboStatus GetWeiboShow(long id);	
							string GetMid(long id, int type);	
							IEnumerable<WeiboStatusCount> BatchGetStatusCount(string ids);	
							string GoToWeiboStatus(long uid, long id);	
							IEnumerable<WeiboEmotion> ListWeiboEmotions();	
							WeiboStatus RepostWeiboStatus(long id);	
							WeiboStatus RepostWeiboStatus(long id, string status);	
							WeiboStatus DeleteWeiboStatus(long id);	
							WeiboStatus PostWeiboStatus(string status);	
							WeiboStatus UploadImage(string status, string pic);	
							WeiboCursorList<WeiboComment> ListWeiboCommentsShow(long id);	
							WeiboCursorList<WeiboComment> ListWeiboCommentsByMe();	
					#endregion
	}
}

namespace MiniWeibo.Net.Common
{
	public partial class WeiboService
	{
		#region Sequential Methods
									public virtual WeiboAccount GetAccountPrivacy()
						{
							return WithHammock<WeiboAccount>("account/get_privacy", FormatAsString);
						}
									public virtual WeiboUser VerifyCredentials()
						{
							return WithHammock<WeiboUser>("account/verify_credentials", FormatAsString);
						}
									public virtual WeiboCursorList<WeiboStatus> ListWeibosOnPublicTimeline()
						{
							return WithHammock<WeiboCursorList<WeiboStatus>>("statuses/public_timeline", FormatAsString);
						}
									public virtual WeiboCursorList<WeiboStatus> ListWeibosOnPublicTimeline(int count)
						{
							return WithHammock<WeiboCursorList<WeiboStatus>>("statuses/public_timeline", FormatAsString, "?count=", count);
						}
									public virtual WeiboCursorList<WeiboStatus> ListWeibosOnPublicTimeline(string source, string accessToken, int count)
						{
							return WithHammock<WeiboCursorList<WeiboStatus>>("statuses/public_timeline", FormatAsString, "?source=", source, "&access_token=", accessToken, "&count=", count);
						}
									public virtual WeiboCursorList<WeiboStatus> ListWeibosOnFriendsTimeline()
						{
							return WithHammock<WeiboCursorList<WeiboStatus>>("statuses/friends_timeline", FormatAsString);
						}
									public virtual WeiboCursorList<WeiboStatus> ListWeibosOnHomeTimeline()
						{
							return WithHammock<WeiboCursorList<WeiboStatus>>("statuses/home_timeline", FormatAsString);
						}
									public virtual WeiboIdInfo ListWeiboIdsOnFriendsTimeline()
						{
							return WithHammock<WeiboIdInfo>("statuses/friends_timeline/ids", FormatAsString);
						}
									public virtual WeiboCursorList<WeiboStatus> ListWeibosOnUserTimeline(long uid)
						{
							return WithHammock<WeiboCursorList<WeiboStatus>>("statuses/user_timeline", FormatAsString, "?uid=", uid);
						}
									public virtual WeiboCursorList<WeiboStatus> ListWeibosOnUserTimeline(string screenName)
						{
							return WithHammock<WeiboCursorList<WeiboStatus>>("statuses/user_timeline", FormatAsString, "?screen_name=", screenName);
						}
									public virtual WeiboIdInfo ListWeiboIdsOnUserTimeline()
						{
							return WithHammock<WeiboIdInfo>("statuses/user_timeline/ids", FormatAsString);
						}
									public virtual WeiboCursorList<WeiboStatus> ListWeibosOnRepostTimeline(long id)
						{
							return WithHammock<WeiboCursorList<WeiboStatus>>("statuses/repost_timeline", FormatAsString, "?id=", id);
						}
									public virtual WeiboIdInfo ListWeiboIdsOnRepostTimeline(long id)
						{
							return WithHammock<WeiboIdInfo>("statuses/repost_timeline/ids", FormatAsString, "?id=", id);
						}
									public virtual WeiboCursorList<WeiboStatus> ListWeiboRepostByMe()
						{
							return WithHammock<WeiboCursorList<WeiboStatus>>("statuses/repost_by_me", FormatAsString);
						}
									public virtual WeiboCursorList<WeiboStatus> ListWeiboMentionMe()
						{
							return WithHammock<WeiboCursorList<WeiboStatus>>("statuses/mentions", FormatAsString);
						}
									public virtual WeiboIdInfo ListWeiboIdsMentionMe()
						{
							return WithHammock<WeiboIdInfo>("statuses/mentions/ids", FormatAsString);
						}
									public virtual WeiboCursorList<WeiboStatus> ListWeibosOnBilateralTimeline()
						{
							return WithHammock<WeiboCursorList<WeiboStatus>>("statuses/bilateral_timeline", FormatAsString);
						}
									public virtual WeiboStatus GetWeiboShow(long id)
						{
							return WithHammock<WeiboStatus>("statuses/show", FormatAsString, "?id=", id);
						}
									public virtual string GetMid(long id, int type)
						{
							return WithHammock<string>("statuses/querymid", FormatAsString, "?id=", id, "&type=", type);
						}
									public virtual IEnumerable<WeiboStatusCount> BatchGetStatusCount(string ids)
						{
							return WithHammock<IEnumerable<WeiboStatusCount>>("statuses/count", FormatAsString, "?ids=", ids);
						}
									public virtual string GoToWeiboStatus(long uid, long id)
						{
							return WithHammock<string>("statuses/go", FormatAsString, "?uid=", uid, "&id=", id);
						}
									public virtual IEnumerable<WeiboEmotion> ListWeiboEmotions()
						{
							return WithHammock<IEnumerable<WeiboEmotion>>("emotions", FormatAsString);
						}
									public virtual WeiboStatus RepostWeiboStatus(long id)
						{
							return WithHammock<WeiboStatus>(WebMethod.Post, "statuses/repost", FormatAsString, "?id=", id);
						}
									public virtual WeiboStatus RepostWeiboStatus(long id, string status)
						{
							return WithHammock<WeiboStatus>(WebMethod.Post, "statuses/repost", FormatAsString, "?id=", id, "&status=", status);
						}
									public virtual WeiboStatus DeleteWeiboStatus(long id)
						{
							return WithHammock<WeiboStatus>(WebMethod.Post, "statuses/destroy", FormatAsString, "?id=", id);
						}
									public virtual WeiboStatus PostWeiboStatus(string status)
						{
							return WithHammock<WeiboStatus>(WebMethod.Post, "statuses/update", FormatAsString, "?status=", status);
						}
									public virtual WeiboStatus UploadImage(string status, string pic)
						{
							return WithHammock<WeiboStatus>(WebMethod.Post, "statuses/upload", FormatAsString, "?status=", status, "&pic=", pic);
						}
									public virtual WeiboCursorList<WeiboComment> ListWeiboCommentsShow(long id)
						{
							return WithHammock<WeiboCursorList<WeiboComment>>("comments/show", FormatAsString, "?id=", id);
						}
									public virtual WeiboCursorList<WeiboComment> ListWeiboCommentsByMe()
						{
							return WithHammock<WeiboCursorList<WeiboComment>>("comments/by_me", FormatAsString);
						}
					#endregion
	}
}



 
