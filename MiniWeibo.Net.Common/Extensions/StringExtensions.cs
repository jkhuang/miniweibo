using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniWeibo.Net.Common
{
    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Threading;

    using MiniWeibo.Net.Common.Core;

    internal static class StringExtensions
    {
        public static bool IsNullOrBlank(this string input)
        {
            return string.IsNullOrEmpty(input) || input.Trim().Length == 0;
        }

        public static bool AreNullOrBlank(this IEnumerable<string> values)
        {
            if (values.Count() == 0 || values == null)
            {
                return false;
            }

            return values.Aggregate(true, (current, value) => current & value.IsNullOrBlank());
        }

        ////public static WeiboEntities ParseTwitterageToEntities(this string text)
        ////{
        ////    var entities = new TwitterEntities
        ////    {
        ////        HashTags = new List<TwitterHashTag>(ParseTwitterageToHashTags(text)),
        ////        Mentions = new List<TwitterMention>(ParseTwitterageToMentions(text)),
        ////        Urls = new List<TwitterUrl>(ParseTwitterageToUrls(text))
        ////    };

        ////    return entities;
        ////}

        private const RegexOptions Options =
#if !SILVERLIGHT
 RegexOptions.Compiled | RegexOptions.IgnoreCase;
#else
            RegexOptions.IgnoreCase;
#endif


        private static readonly Regex _parseUrls = new Regex(RegexPattern.Url, Options);

        private static readonly Regex _parseMentions = new Regex(RegexPattern.Mentions, Options);

        private static readonly Regex _parseHashtags = new Regex(RegexPattern.HashTags, Options);

        public static string ParseTwitterageToHtml(this string input)
        {
            if (input.IsNullOrBlank())
            {
                return input;
            }

            foreach (Match match in _parseUrls.Matches(input))
            {
                input = input.Replace(match.Value, string.Format(CultureInfo.InvariantCulture, "<a href=\"{0}\" target=\"_blank\">{0}</a>", match.Value));
            }

            foreach (Match match in _parseMentions.Matches(input))
            {
                if (match.Groups.Count != 3)
                {
                    continue;
                }

                var screenName = match.Groups[2].Value;
                var mention = "@" + screenName;

                input = input.Replace(mention, string.Format(CultureInfo.InvariantCulture, "<a href=\"http://twitter.com/{0}\" target=\"_blank\">{1}</a>", screenName, mention));
            }

            foreach (Match match in _parseHashtags.Matches(input))
            {
                var hashtag = Uri.EscapeDataString(match.Value);
                input = input.Replace(match.Value, string.Format(CultureInfo.InvariantCulture, "<a href=\"http://search.twitter.com/search?q={0}\" target=\"_blank\">{1}</a>", hashtag, match.Value));
            }

            return input;
        }

        ////public static IEnumerable<TwitterUrl> ParseTwitterageToUrls(this string input)
        ////{
        ////    if (input.IsNullOrBlank())
        ////    {
        ////        yield break;
        ////    }

        ////    foreach (Match match in _parseUrls.Matches(input))
        ////    {
        ////        var value = match.Value;

        ////        Uri uri;
        ////        try
        ////        {
        ////            uri = new Uri(value);
        ////        }
        ////        catch (UriFormatException)
        ////        {
        ////            continue;
        ////        }

        ////        var url = new TwitterUrl
        ////        {
        ////            Value = uri.ToString(),
        ////            Indices = new List<int>(new[] { match.Index, match.Index + match.Value.Length })
        ////        };

        ////        if (!match.Value.EndsWith("/") && url.Value.EndsWith("/"))
        ////        {
        ////            url.Value = url.Value.Substring(0, url.Value.Length - 1);
        ////        }

        ////        yield return url;
        ////    }
        ////}

        ////public static IEnumerable<TwitterMention> ParseTwitterageToMentions(this string input)
        ////{
        ////    if (input.IsNullOrBlank())
        ////    {
        ////        yield break;
        ////    }

        ////    foreach (Match match in _parseMentions.Matches(input))
        ////    {
        ////        if (match.Groups.Count != 3)
        ////        {
        ////            continue;
        ////        }

        ////        var screenName = match.Groups[2].Value;
        ////        var startIndex = match.Index + (match.Index == 0 ? 0 : 1);
        ////        var mention = new TwitterMention
        ////        {
        ////            ScreenName = screenName,
        ////            Indices = new[] { startIndex, startIndex + screenName.Length + 1 }
        ////        };

        ////        yield return mention;
        ////    }
        ////}

        ////public static IEnumerable<TwitterHashTag> ParseTwitterageToHashTags(this string input)
        ////{
        ////    if (input.IsNullOrBlank())
        ////    {
        ////        yield break;
        ////    }

        ////    foreach (Match match in _parseHashtags.Matches(input))
        ////    {
        ////        var hashtag = new TwitterHashTag
        ////        {
        ////            Text = match.Value.Substring(1),
        ////            Indices = new[] { match.Index, match.Index + match.Value.Length }
        ////        };

        ////        yield return hashtag;
        ////    }
        ////}


        #region Conversion

        public static int ToInt32(this string txt)
        {
            return ToNumber(txt, Convert.ToInt32, 0);
        }

        public static long ToInt64(this string txt)
        {
            return ToNumber(txt, s => Convert.ToInt64(s), 0);
        }

        public static T ToNumber<T>(string txt, Func<string, T> callback, T defaultValue)
        {
            if (string.IsNullOrEmpty(txt))
            {
                return defaultValue;
            }

            string trimed = txt.Trim().ToLower();

            // Parse $ or the system currency symbol.
            if (trimed.StartsWith("$") || trimed.StartsWith(Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol))
            {
                trimed = trimed.Substring(1);
            }
            return callback(trimed);
        }

        #endregion
    }
}
