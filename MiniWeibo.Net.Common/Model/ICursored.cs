/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : ICursored.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-01-14 09:37:09
 * *******************************************************************/

namespace MiniWeibo.Net.Common
{
    interface ICursored
    {
        long? NextCursor { get; set; }
        long? PreviousCursor { get; set; }
    }
}
