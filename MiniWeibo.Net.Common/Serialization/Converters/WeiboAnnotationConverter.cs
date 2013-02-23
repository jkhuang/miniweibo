/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboAnnotationConverter.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-02-04 10:02:14
 * *******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MiniWeibo.Net.Common.Serialization
{
    class WeiboAnnotationConverter : WeiboConverterBase
    {
        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                return serializer.Deserialize<IList<WeiboAnnotation>>(reader);
            }
            else
            {
                var media = serializer.Deserialize<WeiboAnnotation>(reader);
                return new List<WeiboAnnotation>();
            }
        }

        public override bool CanConvert(Type objectType)
        {
            var t = (IsNullableType(objectType))
                        ? Nullable.GetUnderlyingType(objectType)
                        : objectType;
            return typeof(WeiboAnnotation).IsAssignableFrom(t);
        }
    }
}
