namespace MiniWeibo.Net.Common.Serialization
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// The weibo converter.
    /// </summary>
    public abstract class WeiboConverterBase : JsonConverter
    {
        /// <summary>
        /// Determines whether the specified type is nullable.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   <c>true</c> if the specified type is nullable; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullable(Type type)
        {
            return type != null && (!type.IsValueType || IsNullableType(type));
        }

        /// <summary>
        /// Determines whether [is nullable type] [the specified type].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   <c>true</c> if [is nullable type] [the specified type]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullableType(Type type)
        {
            return type != null && (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
    }
}
