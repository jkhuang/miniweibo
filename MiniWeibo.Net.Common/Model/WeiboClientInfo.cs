using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniWeibo.Net.Common
{
    using Hammock.Web;

    public class WeiboClientInfo : IWebQueryInfo
    {
        public virtual string ClientName { get; set; }
        public virtual string ClientVersion { get; set; }
        public virtual string ClientUrl { get; set; }
        public virtual string ConsumerKey { get; set; }
        public virtual string ConsumerSecret { get; set; }
        public virtual bool IncludeEntities { get; set; }
    }
}
