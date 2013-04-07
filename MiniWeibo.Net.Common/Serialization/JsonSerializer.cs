using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using Hammock;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MiniWeibo.Net.Common.Serialization
{
    internal class JsonSerializer : SerializerBase
    {
        public override string Serialize(object instance, Type type)
        {
            throw new NotImplementedException();
        }

        public override string ContentType
        {
            get { throw new NotImplementedException(); }
        }

        public override object Deserialize(RestResponseBase response, Type type)
        {
            throw new NotImplementedException();
        }

        public object Deserialize(string content, Type type)
        {
            return DeserializeJson(content, type);
        }

        public override T Deserialize<T>(RestResponseBase response)
        {
            if (null == response)
            {
                return default(T);
            }
            if ((int)response.StatusCode >= 500)
            {
                return default(T);
            }

            var content = response.Content;

            return DeserializeContent<T>(content);
        }

        internal T DeserializeContent<T>(string content)
        {

            if (typeof(T) == typeof(WeiboTrends))
            {
                return DeserializeTrends<T>(content);
            }

            if (typeof(T) == typeof(IEnumerable<WeiboUserTag>) || typeof(T) == typeof(IEnumerable<WeiboUserTags>))
            {
                return DeserializeTags<T>(content);
            }

            if (typeof(T) == typeof(WeiboIdInfo))
            {
                return DeserializeIds<T>(content);
            }

            if (typeof(T) == typeof(string))
            {
                JObject o = JObject.Parse(content);
                ////var result = o["mid"].ToString();
                IList<string> keys = o.Properties().Select(p => p.Name).ToList();
                var result = o[keys[0]].ToString();
                if (string.IsNullOrEmpty(result))
                {
                    result = o["result"].ToString();
                }
                return (T)(object)result;
            }

            if (typeof(T) == typeof(long))
            {
                JObject o = JObject.Parse(content);
                ////var uid = o["uid"].ToString();
                //// http://snowm.blog.163.com/blog/static/20707720020124833032178/
                IList<string> keys = o.Properties().Select(p => p.Name).ToList();
                var result = o[keys[0]].ToString();
                return (T)Convert.ChangeType(result, typeof(T));
            }

            if (typeof(T) == typeof(bool))
            {
                JObject o = JObject.Parse(content);
                IList<string> keys = o.Properties().Select(p => p.Name).ToList();
                var result = o[keys[0]].ToString();
                //// http://snowm.blog.163.com/blog/static/20707720020124833032178/
                return (T)Convert.ChangeType(result, typeof(T));
            }

            if (typeof (T) == typeof (Dictionary<long, string>))
            {
                var result = JsonConvert.DeserializeObject<Dictionary<long, string>>(content);
                return (T)(object)result;
            }

            var wantsCollection = typeof(IEnumerable).IsAssignableFrom(typeof(T));

            var deserialized = wantsCollection
                                   ? DeserializeCollection<T>(content)
                                   : DeserializeSingle<T>(content);

            return deserialized;
        }

        private T DeserializeCollection<T>(string content)
        {

            if (typeof(T) == typeof(string[]))
            {
                ////var binary = (IEnumerable)Encoding.UTF8.GetBytes(content);
                ////var deserialized = (T)binary;
                ////return deserialized;
                ////JArray array = null;
                JArray array = JArray.Parse(content);
                ////string[] tempArray = array.ToArray();
                var ids = (IEnumerable)(array.Select(item => item.ToString()).ToArray());
                var deserialized = (T)ids;
                return deserialized;
            }

            ////if (typeof(T) == typeof(WeiboFavorites))
            ////{
            ////    return DeserializeFavorites<T>(content);
            ////}

            IList collection;
            var type = ConstructCollection<T>(out collection);

            Type cursor = null;
            var generics = typeof(T).GetGenericArguments();
            if (generics.Length > 0)
            {
                var inner = generics[0];
                cursor = typeof(WeiboCursorList<>).MakeGenericType(inner);
            }

            try
            {
                JArray array = null;
                JObject instance = null;

                // To fix empty json array issue.
                // Due to Json.net deserizes an empty json array with exception.
                // For instacne Annotations is empty.
                // Reference: http://stackoverflow.com/questions/13204663/parsing-nested-json-objects-with-json-net
                // http://publib.boulder.ibm.com/infocenter/dmndhelp/v6r1mx/index.jsp?topic=/com.ibm.wbit.610.help.config.doc/topics/rjsonnullunsempprops.html
                ////content = content.Replace("[]", "{}");
                instance = ParseInnerContent<T>("statuses", content, cursor, instance, ref array);
                instance = ParseInnerContent<T>("reposts", content, cursor, instance, ref array);
                instance = ParseInnerContent<T>("comments", content, cursor, instance, ref array);
                instance = ParseInnerContent<T>("users", content, cursor, instance, ref array);
                instance = ParseInnerContent<T>("ids", content, cursor, instance, ref array);
                instance = ParseInnerContent<T>("favorites", content, cursor, instance, ref array);
                instance = ParseInnerContent<T>("tags", content, cursor, instance, ref array);


                if (null == array)
                {
                    array = JArray.Parse(content);
                }

                var model = typeof(IWeiboModel).IsAssignableFrom(type);
                var items = array.Select(item => item.ToString());
                if (model)
                {
                    foreach (var c in items)
                    {
                        AddDeserializedItem(c, type, collection);
                    }
                }
                else
                {
                    foreach (var c in items)
                    {
                        AddDeserializedItemWithoutRawSource(c, type, collection);
                    }
                }

                var deserialized = typeof(T) == cursor
                                       ? BindDeserializedItemsIntoCursorCollection<T>(collection, cursor, instance)
                                       : BindDeserializedItemsIntoCollection<T>(collection);

                return deserialized;

            }
            catch (Exception ex)
            {

                throw;
            }
        }



        private T DeserializeTags<T>(string content)
        {
            if (typeof(T) == typeof(IEnumerable<WeiboUserTag>))
            {
                var result = DeserializeCollection<T>(content);
                var tags = result as IEnumerable<WeiboUserTag>;
                if (tags != null)
                {
                    foreach (var item in tags)
                    {
                        var instance = JObject.Parse(item.RawSource);
                        foreach (JToken child in instance.First.Children())
                        {

                            item.UserTagId = long.Parse(child.Path);
                            item.UserTagName = child.ToString();
                        }
                    }
                }
                return (T)tags;
            }
            ////var result = DeserializeCollection<WeiboUserTag>(content);
            var jsonArray = JArray.Parse(content);
            if (jsonArray != null)
            {
                var result = new List<WeiboUserTags>();

                foreach (var item in jsonArray)
                {
                    var first = (JProperty)item.First;
                    var last = (JProperty)item.Last;
                    var userTag = DeserializeCollection<IEnumerable<WeiboUserTag>>(last.Value.ToString());
                    if (userTag != null)
                    {
                        foreach (var tag in userTag)
                        {
                            var instance = JObject.Parse(tag.RawSource);
                            foreach (JToken child in instance.First.Children())
                            {

                                tag.UserTagId = long.Parse(child.Path);
                                tag.UserTagName = child.ToString();
                            }
                        }
                    }
                    result.Add(new WeiboUserTags{Id = long.Parse(first.Value.ToString()),
                    Tags = userTag as List<WeiboUserTag>
                    });
                }
                return (T)(IEnumerable)result;
            }
            return default(T);
        }

        private T DeserializeTrends<T>(string content)
        {
            var instance = JObject.Parse(content);
            var inner = instance["trends"];
            if (inner != null)
            {
                var result = new WeiboTrends { RawSource = content };

                var asOf = instance["as_of"] != null ? instance["as_of"].ToString() : "0";
                result.AsOf = Convert.ToInt64(asOf).FromUnixTime();

                var dateBuckets = inner.Children();

                foreach (var dateBucket in dateBuckets.OfType<JProperty>())
                {
                    var date = dateBucket.Name;
                    var value = dateBucket.Value.ToString();

                    var trends = DeserializeCollection<IEnumerable<WeiboTrend>>(value);
                    foreach (var trend in trends)
                    {
                        trend.TrendingAsOf = Convert.ToDateTime(date);
                    }

                    result.Trends.AddRange(trends);
                }

                return (T)(IEnumerable)result;
            }

            return DeserializeSingle<T>(content);
        }

        private T DeserializeFavorites<T>(string content)
        {
            ////var instance = JObject.Parse(content);
            ////var inner = instance["favorites"];
            ////if (inner != null)
            ////{
            ////    var result = new WeiboFavorites(){ RawSource = content };

            ////    var asOf = instance["favorited_time"] != null ? instance["favorited_time"].ToString() : "0";
            ////    result.FavoritedTime = Convert.ToInt64(asOf).FromUnixTime();

            ////    var dateBuckets = inner.Children();

            ////    foreach (var dateBucket in dateBuckets.OfType<JProperty>())
            ////    {
            ////        var date = dateBucket.Name;
            ////        var value = dateBucket.Value.ToString();

            ////        var trends = DeserializeCollection<IEnumerable<WeiboFavorite>>(value);
            ////        foreach (var trend in trends)
            ////        {
            ////            ////trend.TrendingAsOf = Convert.ToDateTime(date);
            ////        }

            ////        result.Favorites.AddRange(trends);
            ////    }

            ////    return (T)(IEnumerable)result;
            ////}

            ////return DeserializeSingle<T>(content);
            return default(T);
        }

        private T DeserializeIds<T>(string content)
        {
            var instance = JObject.Parse(content);
            var inner = instance["statuses"];
            if (inner != null)
            {
                var next = instance["next_cursor"];
                var previous = instance["previous_cursor"];
                var totalNumber = instance["total_number"];
                var hasVisible = instance["hasvisible"];
                var result = new WeiboIdInfo
                {
                    RawSource = content,
                    NextCursor = (long)next,
                    PreviousCursor = (long)previous,
                    TotalNumber = (int)totalNumber,
                    HasVisible = (bool)hasVisible
                };

                var ids = DeserializeCollection<string[]>(instance["statuses"].ToString());

                foreach (var id in ids)
                {
                    result.Ids.Add(id);
                }

                var deserialized = (T)(object)result;
                return deserialized;
            }

            return default(T);
        }

        private void AddDeserializedItem(string c, Type type, IList collection)
        {
            var d = Deserialize(c, type);
            ((IWeiboModel)d).RawSource = c;
            collection.Add(d);
        }

        private void AddDeserializedItemWithoutRawSource(string c, Type type, IList collection)
        {
            var d = Deserialize(c, type);
            collection.Add(d);
        }

        private static T BindDeserializedItemsIntoCursorCollection<T>(IEnumerable collection, Type cursor,
                                                                      JObject instance)
        {
            var list = Activator.CreateInstance(
                cursor, 0, null, new object[] { collection }, CultureInfo.InvariantCulture);

            if (instance != null)
            {
                var next = instance["next_cursor"];
                var previous = instance["previous_cursor"];
                var totalNumber = instance["total_number"];
                var hasVisible = instance["hasvisible"];
                ((ICursored)list).NextCursor = (long?)next;
                ((ICursored)list).PreviousCursor = (long?)previous;
                ((INumbered)list).TotalNumber = (long?)totalNumber;

                if (((IVisiable)list).HasVisible != null)
                {
                    ((IVisiable)list).HasVisible = false;
                    bool restult;
                    if (bool.TryParse(hasVisible.ToString(), out restult))
                    {
                        ((IVisiable)list).HasVisible = restult;
                    }
                }
            }

            var deserialized = (T)list;
            return deserialized;
        }

        private static T BindDeserializedItemsIntoCollection<T>(IList collection)
        {
            var deserialized = (T)collection;
            return deserialized;
        }
        private static JObject ParseInnerContent<T>(string entity, string content, Type cursor, JObject instance, ref JArray array)
        {
            if (!content.Contains(string.Format("\"{0}\"", entity)) || !content.StartsWith(string.Format("{{\"{0}\"", entity)))
            {
                return instance;
            }
            instance = JObject.Parse(content);
            array = ParseFromCursorListOrObject<T>(entity, content, cursor, instance);
            return instance;
        }


        private static JArray ParseFromCursorListOrObject<T>(string type, string content, Type cursor, JObject instance)
        {
            JArray array;
            if (cursor != null && typeof(T) == cursor)
            {
                array = instance != null
                            ? ((JArray)instance[type] ?? JArray.Parse(content))
                            : JArray.Parse(content);
            }
            else
            {
                // [DC]: We need to go one level deeper than "result" in the case of places
                if (type.Equals("result"))
                {
                    instance = JObject.Parse(content);
                    var inner = instance["result"]["places"].ToString();
                    array = JArray.Parse(inner);
                }
                else
                {
                    array = JArray.Parse(content);
                }
            }
            return array;
        }

        private T DeserializeSingle<T>(string content)
        {
            var deserialized = DeserializeJson<T>(content);
            return deserialized;
        }

        private static Type ConstructCollection<T>(out IList collection)
        {
            var type = typeof(T).GetGenericArguments()[0];
            var collectionType = typeof(List<>).MakeGenericType(type);
            collection = (IList)Activator.CreateInstance(collectionType);
            return type;
        }
    }
}
