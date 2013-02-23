using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Hammock.Model;
using Newtonsoft.Json;

namespace MiniWeibo.Net.Common
{
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class WeiboGeoLocation : PropertyChangedBase, IEquatable<WeiboGeoLocation>, IWeiboModel
    {
        private string _type;
        private GeoCoordinates _coordinates;
        private static readonly WeiboGeoLocation _none = new WeiboGeoLocation();

        [JsonProperty("type")]
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }

        [JsonProperty("coordinates")]
        public virtual GeoCoordinates Coordinates
        {
            get { return _coordinates; }
            set
            {
                _coordinates = value;
                OnPropertyChanged("Coordinates");
            }
        }

        public static WeiboGeoLocation None
        {
            get { return _none; }
        }

        [Serializable]
        public class GeoCoordinates
        {
            public virtual double Latitude { get; set; }
            public virtual double Longitude { get; set; }

            public static explicit operator double[](GeoCoordinates location)
            {
                return new[] { location.Latitude, location.Longitude };
            }

            public static implicit operator GeoCoordinates(List<double> values)
            {
                return FromEnumerable(values);
            }

            public static implicit operator GeoCoordinates(double[] values)
            {
                return FromEnumerable(values);
            }

            private static GeoCoordinates FromEnumerable(IEnumerable<double> values)
            {

                if (null == values)
                {
                    throw new ArgumentNullException("values");
                }
                var latitude = values.First();
                var longitude = values.Skip(1).Take(1).Single();
                return new GeoCoordinates { Latitude = latitude, Longitude = longitude };
            }
        }

        public WeiboGeoLocation()
        {
        }

        public WeiboGeoLocation(double latitude, double longitude)
        {
            _coordinates = new GeoCoordinates {Latitude = latitude,Longitude = longitude};
        }

        #region IEquatable<TwitterGeoLocation> Members

        public bool Equals(WeiboGeoLocation other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            return other.Coordinates.Latitude == Coordinates.Latitude
                   && other.Coordinates.Longitude == Coordinates.Longitude;
        }

        #endregion


        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public override bool Equals(Object instance)
        {
            if (ReferenceEquals(null, instance))
            {
                return false;
            }

            return instance.GetType() == typeof(WeiboGeoLocation) && Equals(instance);
        }

        public static bool operator ==(WeiboGeoLocation left, WeiboGeoLocation right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }
            if (ReferenceEquals(null, left))
            {
                return false;
            }
            return left.Equals(right);
        }

        public static bool operator !=(WeiboGeoLocation left, WeiboGeoLocation right)
        {
            if (ReferenceEquals(left, right))
            {
                return false;
            }
            if (ReferenceEquals(null, left))
            {
                return true;
            }
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Coordinates.Latitude.GetHashCode() * 397) ^ Coordinates.Longitude.GetHashCode();
            }
        }

        public string RawSource { get; set; }
    }
}
