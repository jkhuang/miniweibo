namespace MiniWeibo.Net.Common.Serialization
{
    using System;

    public class WeiboDateTimeConverter : WeiboConverterBase
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            throw new NotImplementedException();
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
