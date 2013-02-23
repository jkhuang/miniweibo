/******************************** Module Header ********************************
 * Module Name: OAuthAccessToken.cs
 * Project:     MiniWeibo.Net.Common
 * Copyright (c) Jackson Huang.
 * 
 * Code Logic:
 * 
 * 
 * Corresponding Source:
 * 
 * 
 * History:
 * 2012-1-29 17:08:14 Jackson Huang Created
 * Websiet:
 * http://www.cnblogs.com/rush/
 * *******************************************************************************/

namespace MiniWeibo.Net.Common
{
    public class OAuthAccessToken
    {
        public virtual string Token { get; set; }
        public virtual string TokenSecret { get; set; }
        public virtual long UserId { get; set; }
        public virtual string ScreenName { get; set; }
        public virtual int ExpiresIn { get; set; }
    }

    public enum GrantType
    {
        AuthorizationCode,
        Password,
        RefreshToken
    }
}
