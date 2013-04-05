using System.Runtime.Serialization;

namespace MiniWeibo.Net.Common
{
    public class WeiboLimit : IWeiboModel
    {
        [DataMember]
        public int IpLimit { get; set; }

        [DataMember]
        public string LimitTimeUnit { get; set; }

        [DataMember]
        public int RemainingIpHits { get; set; }

        [DataMember]
        public int RemainingUserHits { get; set; }

        [DataMember]
        public string ResetTime { get; set; }

        [DataMember]
        public int ResetTimeInSeconds { get; set; }

        [DataMember]
        public int UserLimit { get; set; }

        public string RawSource { get; set; }
    }
}
