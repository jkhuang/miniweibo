using Newtonsoft.Json;

namespace MiniWeibo.Net.Common.Serialization
{
    using System;

    public class WeiboDateTimeConverter : WeiboConverterBase
    {
        public override bool CanConvert(Type objectType)
        {
            var t = (IsNullableType(objectType))
                        ? Nullable.GetUnderlyingType(objectType)
                        : objectType;
#if !Smartphone && !NET20
            return typeof(DateTime).IsAssignableFrom(t) || typeof(DateTimeOffset).IsAssignableFrom(t);
#else
            return typeof (DateTime).IsAssignableFrom(t);
#endif
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var value = reader.Value.ToString();
            var date = WeiboDateTime.ConvertToDateTime(value);

            return date;
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (value is WeiboDateTime)
            {
                writer.WriteValue(value.ToString());
            }

            if (value is DateTime)
            {
                var dateTime = (DateTime)value;


            }
        }
    }
}
