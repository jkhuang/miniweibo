
// This is the output code from your template
// you only get syntax-highlighting here - not intellisense
using System;
using System.Collections.Generic;
using Hammock;
using Hammock.Web;

namespace MiniWeibo.Net.Common
{
    public partial interface IMiniWeiboService
    {
        #region Sequential Methods
        WeiboAccount GetAccountPrivacy();
        WeiboUser VerifyCredentials();
        #endregion
    }
}

namespace MiniWeibo.Net.Common
{
    public partial class WeiboService
    {
        #region Sequential Methods
        public virtual WeiboAccount GetAccountPrivacy()
        {
            return WithHammock<WeiboAccount>("account/get_privacy", FormatAsString);
        }
        public virtual WeiboUser VerifyCredentials()
        {
            return WithHammock<WeiboUser>("account/verify_credentials", FormatAsString);
        }
        #endregion
    }
}




