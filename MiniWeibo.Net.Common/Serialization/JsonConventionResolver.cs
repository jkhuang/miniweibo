/******************************** Module Header ********************************
 * Module Name: JsonConventionResolver.cs
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
 * 2012-4-1 18:42:52 Jackson Huang Created
 * Websiet:
 * http://www.cnblogs.com/rush/
 * *******************************************************************************/

namespace MiniWeibo.Net.Common.Serialization
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    internal class JsonConventionResolver : DefaultContractResolver
    {
        public class ToStringComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                return x.ToString().CompareTo(y.ToString());
            }
        }

        /// <summary>
        /// Creates properties for the given <see cref="T:Newtonsoft.Json.Serialization.JsonContract"/>.
        /// </summary>
        /// <param name="type">The type to create properties for.</param>
        /// <param name="memberSerialization">The member serialization mode for the type.</param>
        /// <returns>
        /// Properties for the given <see cref="T:Newtonsoft.Json.Serialization.JsonContract"/>.
        /// </returns>
        /// ///
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);

            foreach (var property in properties)
            {
                property.PropertyName = PascalCaseToElement(property.PropertyName);
            }

            var result = properties;
            return result;
        }

        /// <summary>
        /// Pascals the case to element.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        private static string PascalCaseToElement(string input)
        {
            if (input.Length > 0 && char.IsLower(input[0]))
            {
                return input;
            }

            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            var result = new StringBuilder();
            result.Append(char.ToLowerInvariant(input[0]));

            for (var i = 1; i < input.Length; i++)
            {
                if (char.IsLower(input[i]))
                {
                    result.Append(input[i]);
                }
                else
                {
                    result.Append("_");
                    result.Append(char.ToLowerInvariant(input[i]));
                }
            }

            return result.ToString();
        }
    }
}
