/******************************** Module Header ********************************
 * Module Name: IWeiboable.cs
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
 * 2012-3-5 20:27:46 Jackson Huang Created
 * Websiet:
 * http://www.cnblogs.com/rush/
 * *******************************************************************************/

namespace MiniWeibo.Net.Common
{
    using System;

    public interface IWeiboable
    {
        ////long Id { get; }
        ////string Text { get; }
        ////string TextAsHtml { get; }
        ////IWeibo Author { get; }
        ////DateTime CreatedAt { get; }
        ////WeiboEntities Entities { get; }
    }

    public interface IWeibo
    {
        string ScreenName { get; }
        string ProfileImageUrl { get; }
    }
}
