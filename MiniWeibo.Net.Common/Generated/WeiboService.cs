 
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
							IEnumerable<WeiboSchool> ListOfSchool(string keyword);	
							WeiboLimit WeiboAccountLimit();	
							long GetAuthorizationUid();	
							WeiboUser WeiboSignOut();	
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
							WeiboCursorList<WeiboComment> ListWeiboCommentsToMe();	
							WeiboCursorList<WeiboComment> ListWeiboCommentsTimeline();	
							WeiboCursorList<WeiboComment> ListWeiboCommentsMentionsMe();	
							WeiboCursorList<WeiboComment> BatchGetWeiboCommentsShow(string cids);	
							WeiboComment CreateWeiboComment(string comment, long id);	
							WeiboComment DeleteWeiboComment(long cid);	
							IEnumerable<WeiboComment> BatchDeleteWeiboComments(string cids);	
							WeiboComment ReplyWeiboComments(long cid, long id, string comment);	
							WeiboUser WeiboUsersShow(long uid);	
							WeiboUser WeiboUsersShow(string screenName);	
							WeiboUser WeiboUsersDomainShow(string domain);	
							IEnumerable<WeiboCount> WeiboUsersCounts(string uids);	
							WeiboUserRank WeiboUsersRank(long uid);	
							WeiboUserTopStatus WeiboUsersTopStatus(long uid);	
							WeiboUserTopStatus WeiboUsersTopStatus(string source, long uid);	
							WeiboCursorList<WeiboUser> ListWeiboFriendships(long uid);	
							IEnumerable<WeiboFriendRemark> BatchGetWeiboFriendsRemark(long uids);	
							IEnumerable<WeiboFriendRemark> BatchGetWeiboFriendsRemark(string source, string uids);	
							WeiboCursorList<WeiboUser> ListWeiboFriendsInCommon(long uid, long suid);	
							WeiboCursorList<WeiboUser> ListWeiboFriendsBilateral(long uid);	
							WeiboCursorList<long> ListWeiboFriendsBilateralIds(long uid);	
							WeiboCursorList<long> ListWeiboFriendsIds(long uid);	
							WeiboCursorList<WeiboUser> ListWeiboFriendshipsFollowers(long uid);	
							WeiboCursorList<long> ListWeiboFriendshipsFollowersIds(long uid);	
							WeiboCursorList<WeiboUser> ListWeiboFriendshipsActiveFollowers(long uid);	
							WeiboCursorList<WeiboUser> ListWeiboFriendshipsFriendsChain(long uid);	
							WeiboRelation WeiboFriendshipsShow(long sourceId, long targetId);	
							WeiboUser WeiboFriendshipsCreate(string screenName);	
							WeiboUser WeiboFriendshipsDelete(string screenName);	
							WeiboUser WeiboFriendshipsFollowersDelete(string source, long uid);	
							WeiboUser WeiboFriendshipsRemarkUpdate(long uid, string remark);	
							WeiboCursorList<WeiboUser> WeiboFriendshipsGroups();	
							WeiboCursorList<WeiboStatus> ListWeibosOnGroupsTimeline(long listId);	
							WeiboCursorList<WeiboFavorite> ListOfWeiboFavorites();	
							WeiboCursorList<WeiboFavoriteId> ListOfWeiboFavoriteIds();	
							WeiboFavorite WeiboFavoriteShow(long id);	
							WeiboCursorList<WeiboFavorite> ListOfWeiboFavoritesByTag(long tid);	
							WeiboCursorList<WeiboTags> ListOfWeiboFavoriteTags();	
							WeiboCursorList<WeiboFavoriteId> ListOfWeiboFavoriteIdsByTag(long tid);	
							WeiboFavorite AddFavorite(long id);	
							WeiboFavorite DeleteFavorite(long id);	
							bool BatchDeleteFavorite(string ids);	
							WeiboFavorite UpdateFavoritesTags(long id, string tags);	
							WeiboTags BatchUpdateFavoritesTags(long tid, string tag);	
							bool BatchDeleteFavoritesTags(long tid);	
							IEnumerable<WeiboTrendInfo> ListOfWeiboTrendsInfo(long uid);	
							WeiboTrendInfo IsFollowTrends(string trendName);	
							WeiboTrends ListOfHourlyTrends();	
							WeiboTrends ListOfDailyTrends();	
							WeiboTrends ListOfWeeklyTrends();	
							long FollowTrends(string trendName);	
							bool UnfollowTrends(long trendId);	
							IEnumerable<WeiboUserTag> ListOfUserTags(long uid);	
							IEnumerable<WeiboUserTags> BatchGetUserTags(string uids);	
							IEnumerable<Dictionary<string,string>> ListOfSuggestionTags();	
							string[] CreateUserTags(string tags);	
							int DeleteUserTags(long tagId);	
							string[] BatchDeleteUserTags(string ids);	
							WeiboRegister VerifyNickname(string nickname);	
							IEnumerable<WeiboSuggestionUser> GetSuggestionUsers(string q);	
							IEnumerable<WeiboSuggestionSchool> GetSuggestionSchools(string q);	
							IEnumerable<WeiboSuggestionCompany> GetSuggestionCompanys(string q);	
							IEnumerable<WeiboSuggestionApp> GetSuggestionApps(string q);	
							IEnumerable<WeiboSuggestionUser> GetSuggestionAtUsers(string q, int type);	
							WeiboCursorList<WeiboStatus> GetTopics(string source, string q);	
							IEnumerable<WeiboUser> GetSuggestionUsers();	
							IEnumerable<WeiboInterestedUser> GetInterestedUser();	
							WeiboCursorList<WeiboUser> ListWeiboSuggestionUsers(string content);	
							WeiboCursorList<WeiboStatus> ListSuggestionStatusesOnFriendTimeline(int section);	
							IEnumerable<WeiboStatus> GetSuggestionHotFavorites();	
							WeiboUser IdentifyUserAsNotInterested(string uid);	
							WeiboRemindCount GetUnreadRemindCount(long uid);	
							bool ClearUnreadRemindCount(string type);	
							WeiboCursorList<WeiboUrl> ShortenUrl(params object[] urlLong);	
							WeiboCursorList<WeiboUrl> ShortenUrl(List<string> urlLong);	
							WeiboCursorList<WeiboUrl> ExpandShortUrl(string urlShort);	
							WeiboCursorList<WeiboShortUrlCount> GetShareShortUrlCount(string urlShort);	
							WeiboCursorList<WeiboStatus> GetWeiboStatus(string urlShort);	
							WeiboCursorList<WeiboShortUrlCount> GetShortUrlCommentCount(string urlShort);	
							WeiboCursorList<WeiboShortUrl> GetShortUrlInfo(string source, string urlShort);	
							IEnumerable<Dictionary<string,string>> GetLocation(string codes);	
							IEnumerable<Dictionary<string,string>> GetCity(string province);	
							IEnumerable<Dictionary<string,string>> GetProvince(string country);	
							IEnumerable<Dictionary<string,string>> GetCountry(string capital);	
							Dictionary<string,string> GetTimezone();	
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
									public virtual IEnumerable<WeiboSchool> ListOfSchool(string keyword)
						{
							return WithHammock<IEnumerable<WeiboSchool>>("account/profile/school_list", FormatAsString, "?keyword=", keyword);
						}
									public virtual WeiboLimit WeiboAccountLimit()
						{
							return WithHammock<WeiboLimit>("account/rate_limit_status", FormatAsString);
						}
									public virtual long GetAuthorizationUid()
						{
							return WithHammock<long>("account/get_uid", FormatAsString);
						}
									public virtual WeiboUser WeiboSignOut()
						{
							return WithHammock<WeiboUser>("account/end_session", FormatAsString);
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
									public virtual WeiboCursorList<WeiboComment> ListWeiboCommentsToMe()
						{
							return WithHammock<WeiboCursorList<WeiboComment>>("comments/to_me", FormatAsString);
						}
									public virtual WeiboCursorList<WeiboComment> ListWeiboCommentsTimeline()
						{
							return WithHammock<WeiboCursorList<WeiboComment>>("comments/timeline", FormatAsString);
						}
									public virtual WeiboCursorList<WeiboComment> ListWeiboCommentsMentionsMe()
						{
							return WithHammock<WeiboCursorList<WeiboComment>>("comments/mentions", FormatAsString);
						}
									public virtual WeiboCursorList<WeiboComment> BatchGetWeiboCommentsShow(string cids)
						{
							return WithHammock<WeiboCursorList<WeiboComment>>("comments/show_batch", FormatAsString, "?cids=", cids);
						}
									public virtual WeiboComment CreateWeiboComment(string comment, long id)
						{
							return WithHammock<WeiboComment>(WebMethod.Post, "comments/create", FormatAsString, "?comment=", comment, "&id=", id);
						}
									public virtual WeiboComment DeleteWeiboComment(long cid)
						{
							return WithHammock<WeiboComment>(WebMethod.Post, "comments/destroy", FormatAsString, "?cid=", cid);
						}
									public virtual IEnumerable<WeiboComment> BatchDeleteWeiboComments(string cids)
						{
							return WithHammock<IEnumerable<WeiboComment>>(WebMethod.Post, "comments/destroy_batch", FormatAsString, "?cids=", cids);
						}
									public virtual WeiboComment ReplyWeiboComments(long cid, long id, string comment)
						{
							return WithHammock<WeiboComment>(WebMethod.Post, "comments/reply", FormatAsString, "?cid=", cid, "&id=", id, "&comment=", comment);
						}
									public virtual WeiboUser WeiboUsersShow(long uid)
						{
							return WithHammock<WeiboUser>("users/show", FormatAsString, "?uid=", uid);
						}
									public virtual WeiboUser WeiboUsersShow(string screenName)
						{
							return WithHammock<WeiboUser>("users/show", FormatAsString, "?screen_name=", screenName);
						}
									public virtual WeiboUser WeiboUsersDomainShow(string domain)
						{
							return WithHammock<WeiboUser>("users/domain_show", FormatAsString, "?domain=", domain);
						}
									public virtual IEnumerable<WeiboCount> WeiboUsersCounts(string uids)
						{
							return WithHammock<IEnumerable<WeiboCount>>("users/counts", FormatAsString, "?uids=", uids);
						}
									public virtual WeiboUserRank WeiboUsersRank(long uid)
						{
							return WithHammock<WeiboUserRank>("users/show_rank", FormatAsString, "?uid=", uid);
						}
									public virtual WeiboUserTopStatus WeiboUsersTopStatus(long uid)
						{
							return WithHammock<WeiboUserTopStatus>("users/get_top_status", FormatAsString, "?uid=", uid);
						}
									public virtual WeiboUserTopStatus WeiboUsersTopStatus(string source, long uid)
						{
							return WithHammock<WeiboUserTopStatus>("users/get_top_status", FormatAsString, "?source=", source, "&uid=", uid);
						}
									public virtual WeiboCursorList<WeiboUser> ListWeiboFriendships(long uid)
						{
							return WithHammock<WeiboCursorList<WeiboUser>>("friendships/friends", FormatAsString, "?uid=", uid);
						}
									public virtual IEnumerable<WeiboFriendRemark> BatchGetWeiboFriendsRemark(long uids)
						{
							return WithHammock<IEnumerable<WeiboFriendRemark>>("friendships/friends/remark_batch", FormatAsString, "?uids=", uids);
						}
									public virtual IEnumerable<WeiboFriendRemark> BatchGetWeiboFriendsRemark(string source, string uids)
						{
							return WithHammock<IEnumerable<WeiboFriendRemark>>("friendships/friends/remark_batch", FormatAsString, "?source=", source, "&uids=", uids);
						}
									public virtual WeiboCursorList<WeiboUser> ListWeiboFriendsInCommon(long uid, long suid)
						{
							return WithHammock<WeiboCursorList<WeiboUser>>("friendships/friends/in_common", FormatAsString, "?uid=", uid, "&suid=", suid);
						}
									public virtual WeiboCursorList<WeiboUser> ListWeiboFriendsBilateral(long uid)
						{
							return WithHammock<WeiboCursorList<WeiboUser>>("friendships/friends/bilateral", FormatAsString, "?uid=", uid);
						}
									public virtual WeiboCursorList<long> ListWeiboFriendsBilateralIds(long uid)
						{
							return WithHammock<WeiboCursorList<long>>("friendships/friends/bilateral/ids", FormatAsString, "?uid=", uid);
						}
									public virtual WeiboCursorList<long> ListWeiboFriendsIds(long uid)
						{
							return WithHammock<WeiboCursorList<long>>("friendships/friends/ids", FormatAsString, "?uid=", uid);
						}
									public virtual WeiboCursorList<WeiboUser> ListWeiboFriendshipsFollowers(long uid)
						{
							return WithHammock<WeiboCursorList<WeiboUser>>("friendships/followers", FormatAsString, "?uid=", uid);
						}
									public virtual WeiboCursorList<long> ListWeiboFriendshipsFollowersIds(long uid)
						{
							return WithHammock<WeiboCursorList<long>>("friendships/followers/ids", FormatAsString, "?uid=", uid);
						}
									public virtual WeiboCursorList<WeiboUser> ListWeiboFriendshipsActiveFollowers(long uid)
						{
							return WithHammock<WeiboCursorList<WeiboUser>>("friendships/followers/active", FormatAsString, "?uid=", uid);
						}
									public virtual WeiboCursorList<WeiboUser> ListWeiboFriendshipsFriendsChain(long uid)
						{
							return WithHammock<WeiboCursorList<WeiboUser>>("friendships/friends_chain/followers", FormatAsString, "?uid=", uid);
						}
									public virtual WeiboRelation WeiboFriendshipsShow(long sourceId, long targetId)
						{
							return WithHammock<WeiboRelation>("friendships/show", FormatAsString, "?source_id=", sourceId, "&target_id=", targetId);
						}
									public virtual WeiboUser WeiboFriendshipsCreate(string screenName)
						{
							return WithHammock<WeiboUser>(WebMethod.Post, "friendships/create", FormatAsString, "?screen_name=", screenName);
						}
									public virtual WeiboUser WeiboFriendshipsDelete(string screenName)
						{
							return WithHammock<WeiboUser>(WebMethod.Post, "friendships/destroy", FormatAsString, "?screen_name=", screenName);
						}
									public virtual WeiboUser WeiboFriendshipsFollowersDelete(string source, long uid)
						{
							return WithHammock<WeiboUser>(WebMethod.Post, "friendships/followers/destroy", FormatAsString, "?source=", source, "&uid=", uid);
						}
									public virtual WeiboUser WeiboFriendshipsRemarkUpdate(long uid, string remark)
						{
							return WithHammock<WeiboUser>(WebMethod.Post, "friendships/remark/update", FormatAsString, "?uid=", uid, "&remark=", remark);
						}
									public virtual WeiboCursorList<WeiboUser> WeiboFriendshipsGroups()
						{
							return WithHammock<WeiboCursorList<WeiboUser>>("friendships/groups", FormatAsString);
						}
									public virtual WeiboCursorList<WeiboStatus> ListWeibosOnGroupsTimeline(long listId)
						{
							return WithHammock<WeiboCursorList<WeiboStatus>>("friendships/groups/timeline", FormatAsString, "?list_id=", listId);
						}
									public virtual WeiboCursorList<WeiboFavorite> ListOfWeiboFavorites()
						{
							return WithHammock<WeiboCursorList<WeiboFavorite>>("favorites", FormatAsString);
						}
									public virtual WeiboCursorList<WeiboFavoriteId> ListOfWeiboFavoriteIds()
						{
							return WithHammock<WeiboCursorList<WeiboFavoriteId>>("favorites/ids", FormatAsString);
						}
									public virtual WeiboFavorite WeiboFavoriteShow(long id)
						{
							return WithHammock<WeiboFavorite>("favorites/show", FormatAsString, "?id=", id);
						}
									public virtual WeiboCursorList<WeiboFavorite> ListOfWeiboFavoritesByTag(long tid)
						{
							return WithHammock<WeiboCursorList<WeiboFavorite>>("favorites/by_tags", FormatAsString, "?tid=", tid);
						}
									public virtual WeiboCursorList<WeiboTags> ListOfWeiboFavoriteTags()
						{
							return WithHammock<WeiboCursorList<WeiboTags>>("favorites/tags", FormatAsString);
						}
									public virtual WeiboCursorList<WeiboFavoriteId> ListOfWeiboFavoriteIdsByTag(long tid)
						{
							return WithHammock<WeiboCursorList<WeiboFavoriteId>>("favorites/by_tags/ids", FormatAsString, "?tid=", tid);
						}
									public virtual WeiboFavorite AddFavorite(long id)
						{
							return WithHammock<WeiboFavorite>(WebMethod.Post, "favorites/create", FormatAsString, "?id=", id);
						}
									public virtual WeiboFavorite DeleteFavorite(long id)
						{
							return WithHammock<WeiboFavorite>(WebMethod.Post, "favorites/destroy", FormatAsString, "?id=", id);
						}
									public virtual bool BatchDeleteFavorite(string ids)
						{
							return WithHammock<bool>(WebMethod.Post, "favorites/destroy_batch", FormatAsString, "?ids=", ids);
						}
									public virtual WeiboFavorite UpdateFavoritesTags(long id, string tags)
						{
							return WithHammock<WeiboFavorite>(WebMethod.Post, "favorites/tags/update", FormatAsString, "?id=", id, "&tags=", tags);
						}
									public virtual WeiboTags BatchUpdateFavoritesTags(long tid, string tag)
						{
							return WithHammock<WeiboTags>(WebMethod.Post, "favorites/tags/update_batch", FormatAsString, "?tid=", tid, "&tag=", tag);
						}
									public virtual bool BatchDeleteFavoritesTags(long tid)
						{
							return WithHammock<bool>(WebMethod.Post, "favorites/tags/destroy_batch", FormatAsString, "?tid=", tid);
						}
									public virtual IEnumerable<WeiboTrendInfo> ListOfWeiboTrendsInfo(long uid)
						{
							return WithHammock<IEnumerable<WeiboTrendInfo>>("trends", FormatAsString, "?uid=", uid);
						}
									public virtual WeiboTrendInfo IsFollowTrends(string trendName)
						{
							return WithHammock<WeiboTrendInfo>("trends/is_follow", FormatAsString, "?trend_name=", trendName);
						}
									public virtual WeiboTrends ListOfHourlyTrends()
						{
							return WithHammock<WeiboTrends>("trends/hourly", FormatAsString);
						}
									public virtual WeiboTrends ListOfDailyTrends()
						{
							return WithHammock<WeiboTrends>("trends/daily", FormatAsString);
						}
									public virtual WeiboTrends ListOfWeeklyTrends()
						{
							return WithHammock<WeiboTrends>("trends/weekly", FormatAsString);
						}
									public virtual long FollowTrends(string trendName)
						{
							return WithHammock<long>(WebMethod.Post, "trends/follow", FormatAsString, "?trend_name=", trendName);
						}
									public virtual bool UnfollowTrends(long trendId)
						{
							return WithHammock<bool>(WebMethod.Post, "trends/destroy", FormatAsString, "?trend_id=", trendId);
						}
									public virtual IEnumerable<WeiboUserTag> ListOfUserTags(long uid)
						{
							return WithHammock<IEnumerable<WeiboUserTag>>("tags", FormatAsString, "?uid=", uid);
						}
									public virtual IEnumerable<WeiboUserTags> BatchGetUserTags(string uids)
						{
							return WithHammock<IEnumerable<WeiboUserTags>>("tags/tags_batch", FormatAsString, "?uids=", uids);
						}
									public virtual IEnumerable<Dictionary<string,string>> ListOfSuggestionTags()
						{
							return WithHammock<IEnumerable<Dictionary<string,string>>>("tags/suggestions", FormatAsString);
						}
									public virtual string[] CreateUserTags(string tags)
						{
							return WithHammock<string[]>(WebMethod.Post, "tags/create", FormatAsString, "?tags=", tags);
						}
									public virtual int DeleteUserTags(long tagId)
						{
							return WithHammock<int>(WebMethod.Post, "tags/destroy", FormatAsString, "?tag_id=", tagId);
						}
									public virtual string[] BatchDeleteUserTags(string ids)
						{
							return WithHammock<string[]>(WebMethod.Post, "tags/destroy_batch", FormatAsString, "?ids=", ids);
						}
									public virtual WeiboRegister VerifyNickname(string nickname)
						{
							return WithHammock<WeiboRegister>("register/verify_nickname", FormatAsString, "?nickname=", nickname);
						}
									public virtual IEnumerable<WeiboSuggestionUser> GetSuggestionUsers(string q)
						{
							return WithHammock<IEnumerable<WeiboSuggestionUser>>("search/suggestions/users", FormatAsString, "?q=", q);
						}
									public virtual IEnumerable<WeiboSuggestionSchool> GetSuggestionSchools(string q)
						{
							return WithHammock<IEnumerable<WeiboSuggestionSchool>>("search/suggestions/schools", FormatAsString, "?q=", q);
						}
									public virtual IEnumerable<WeiboSuggestionCompany> GetSuggestionCompanys(string q)
						{
							return WithHammock<IEnumerable<WeiboSuggestionCompany>>("search/suggestions/companies", FormatAsString, "?q=", q);
						}
									public virtual IEnumerable<WeiboSuggestionApp> GetSuggestionApps(string q)
						{
							return WithHammock<IEnumerable<WeiboSuggestionApp>>("search/suggestions/apps", FormatAsString, "?q=", q);
						}
									public virtual IEnumerable<WeiboSuggestionUser> GetSuggestionAtUsers(string q, int type)
						{
							return WithHammock<IEnumerable<WeiboSuggestionUser>>("search/suggestions/at_users", FormatAsString, "?q=", q, "&type=", type);
						}
									public virtual WeiboCursorList<WeiboStatus> GetTopics(string source, string q)
						{
							return WithHammock<WeiboCursorList<WeiboStatus>>("search/topics", FormatAsString, "?source=", source, "&q=", q);
						}
									public virtual IEnumerable<WeiboUser> GetSuggestionUsers()
						{
							return WithHammock<IEnumerable<WeiboUser>>("suggestions/users/hot", FormatAsString);
						}
									public virtual IEnumerable<WeiboInterestedUser> GetInterestedUser()
						{
							return WithHammock<IEnumerable<WeiboInterestedUser>>("suggestions/users/may_interested", FormatAsString);
						}
									public virtual WeiboCursorList<WeiboUser> ListWeiboSuggestionUsers(string content)
						{
							return WithHammock<WeiboCursorList<WeiboUser>>("suggestions/users/by_status", FormatAsString, "?content=", content);
						}
									public virtual WeiboCursorList<WeiboStatus> ListSuggestionStatusesOnFriendTimeline(int section)
						{
							return WithHammock<WeiboCursorList<WeiboStatus>>("suggestions/statuses/reorder", FormatAsString, "?section=", section);
						}
									public virtual IEnumerable<WeiboStatus> GetSuggestionHotFavorites()
						{
							return WithHammock<IEnumerable<WeiboStatus>>("suggestions/favorites/hot", FormatAsString);
						}
									public virtual WeiboUser IdentifyUserAsNotInterested(string uid)
						{
							return WithHammock<WeiboUser>(WebMethod.Post, "suggestions/users/not_interested", FormatAsString, "?uid=", uid);
						}
									public virtual WeiboRemindCount GetUnreadRemindCount(long uid)
						{
							return WithHammock<WeiboRemindCount>("remind/unread_count", FormatAsString, "?uid=", uid);
						}
									public virtual bool ClearUnreadRemindCount(string type)
						{
							return WithHammock<bool>("remind/set_count", FormatAsString, "?type=", type);
						}
									public virtual WeiboCursorList<WeiboUrl> ShortenUrl(params object[] urlLong)
						{
							return WithHammock<WeiboCursorList<WeiboUrl>>("short_url/shorten", FormatAsString, "?url_long=", urlLong);
						}
									public virtual WeiboCursorList<WeiboUrl> ShortenUrl(List<string> urlLong)
						{
							return WithHammock<WeiboCursorList<WeiboUrl>>("short_url/shorten", FormatAsString, "?url_long=", urlLong);
						}
									public virtual WeiboCursorList<WeiboUrl> ExpandShortUrl(string urlShort)
						{
							return WithHammock<WeiboCursorList<WeiboUrl>>("short_url/expand", FormatAsString, "?url_short=", urlShort);
						}
									public virtual WeiboCursorList<WeiboShortUrlCount> GetShareShortUrlCount(string urlShort)
						{
							return WithHammock<WeiboCursorList<WeiboShortUrlCount>>("short_url/share/counts", FormatAsString, "?url_short=", urlShort);
						}
									public virtual WeiboCursorList<WeiboStatus> GetWeiboStatus(string urlShort)
						{
							return WithHammock<WeiboCursorList<WeiboStatus>>("short_url/share/statuses", FormatAsString, "?url_short=", urlShort);
						}
									public virtual WeiboCursorList<WeiboShortUrlCount> GetShortUrlCommentCount(string urlShort)
						{
							return WithHammock<WeiboCursorList<WeiboShortUrlCount>>("short_url/comment/counts", FormatAsString, "?url_short=", urlShort);
						}
									public virtual WeiboCursorList<WeiboShortUrl> GetShortUrlInfo(string source, string urlShort)
						{
							return WithHammock<WeiboCursorList<WeiboShortUrl>>("short_url/info", FormatAsString, "?source=", source, "&url_short=", urlShort);
						}
									public virtual IEnumerable<Dictionary<string,string>> GetLocation(string codes)
						{
							return WithHammock<IEnumerable<Dictionary<string,string>>>("common/code_to_location", FormatAsString, "?codes=", codes);
						}
									public virtual IEnumerable<Dictionary<string,string>> GetCity(string province)
						{
							return WithHammock<IEnumerable<Dictionary<string,string>>>("common/get_city", FormatAsString, "?province=", province);
						}
									public virtual IEnumerable<Dictionary<string,string>> GetProvince(string country)
						{
							return WithHammock<IEnumerable<Dictionary<string,string>>>("common/get_province", FormatAsString, "?country=", country);
						}
									public virtual IEnumerable<Dictionary<string,string>> GetCountry(string capital)
						{
							return WithHammock<IEnumerable<Dictionary<string,string>>>("common/get_country", FormatAsString, "?capital=", capital);
						}
									public virtual Dictionary<string,string> GetTimezone()
						{
							return WithHammock<Dictionary<string,string>>("common/get_timezone", FormatAsString);
						}
					#endregion
	}
}



 
