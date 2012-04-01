namespace MiniWeibo.Net.Common.Serialization
{    
    using System;
    using System.Collections.Generic;

    using Hammock;
    using Hammock.Serialization;
    using Newtonsoft.Json;

    internal abstract partial class SerializerBase : Utf8Serializer, ISerializer, IDeserializer
    {
        private readonly JsonSerializer _jsonSerializer;

        protected SerializerBase()
            : this(new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Include,
                    ContractResolver = new JsonConventionResolver(),
                    Converters = new List<JsonConverter>
                                        {
                                            new TwitterDateTimeConverter(),
                                            new TwitterWonkyBooleanConverter(),
                                            new TwitterGeoConverter()
                                        }
                })
        {
            
        }

        protected SerializerBase(JsonSerializerSettings settings)
        {
            _jsonSerializer = new JsonSerializer
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

        public string Serialize(object instance, Type type)
        {
            throw new NotImplementedException();
        }

        public string ContentType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Implementation of IDeserializer

        public object Deserialize(RestResponseBase response, Type type)
        {
            throw new NotImplementedException();
        }

        public T Deserialize<T>(RestResponseBase response)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
