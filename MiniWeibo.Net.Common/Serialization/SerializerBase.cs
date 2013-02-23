/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : SerializerBase.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-01-18 08:44:11
 * *******************************************************************/

using System.IO;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace MiniWeibo.Net.Common.Serialization
{    
    using System;
    using System.Collections.Generic;

    using Hammock;
    using Hammock.Serialization;
    using Newtonsoft.Json;

    internal abstract partial class SerializerBase : Utf8Serializer, ISerializer, IDeserializer
    {
        private readonly Newtonsoft.Json.JsonSerializer _jsonSerializer;

        protected SerializerBase()
            : this(new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Include,
                    ContractResolver = new JsonConventionResolver(),
                    Converters = new List<JsonConverter>
                                        {
                                            new WeiboDateTimeConverter()
                                            ////new WeiboAnnotationConverter()
                                            ////new TwitterWonkyBooleanConverter(),
                                            ////new TwitterGeoConverter()
                                        }
                })
        {
            
        }

        protected SerializerBase(JsonSerializerSettings settings)
        {
            _jsonSerializer = new Newtonsoft.Json.JsonSerializer
                {
                    ConstructorHandling = settings.ConstructorHandling,
                    ContractResolver = settings.ContractResolver,
                    ObjectCreationHandling = settings.ObjectCreationHandling,
                    MissingMemberHandling = settings.MissingMemberHandling,
                    DefaultValueHandling = settings.DefaultValueHandling,
                    NullValueHandling = settings.NullValueHandling
                };

            foreach (var converter in settings.Converters)
            {
                _jsonSerializer.Converters.Add(converter);
            }
        }

        #region Implementation of ISerializer

        public abstract string Serialize(object instance, Type type);

        public abstract string ContentType { get; }

        #endregion

        #region Implementation of IDeserializer

        public abstract object Deserialize(RestResponseBase response, Type type);

        public abstract T Deserialize<T>(RestResponseBase response);

        #endregion

        public virtual object DeserializeJson(string content, Type type)
        {
            using (var stringReader = new StringReader(content))
            {
                using (var jsonTextReader = new JsonTextReader(stringReader))
                {
                    return _jsonSerializer.Deserialize(jsonTextReader, type);
                }
            }
        }

        public virtual T DeserializeJson<T>(string content)
        {
            using (var stringReader = new StringReader(content))
            {
                using (var jsonTextReader = new JsonTextReader(stringReader))
                {
                    return _jsonSerializer.Deserialize<T>(jsonTextReader);
                }
            }
        }

        public virtual string SerializeJson(object instance, Type type)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonTextWriter.QuoteChar = '"';

                    _jsonSerializer.Serialize(jsonTextWriter, instance);

                    var result = stringWriter.ToString();
                    return result;
                }
            }
        } 
    }
}
