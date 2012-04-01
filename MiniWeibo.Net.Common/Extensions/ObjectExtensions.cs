/******************************** Module Header ********************************
 * Module Name: ObjectExtensions.cs
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
 * 2012-1-29 12:18:54 Jackson Huang Created
 * Websiet:
 * http://www.cnblogs.com/rush/
 * *******************************************************************************/

namespace MiniWeibo.Net.Common
{
    using System;
    using System.Linq;

    /// <summary>
    /// The object extension.
    /// </summary>
    internal static class ObjectExtensions
    {
        /// <summary>
        /// Equalses any.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public static bool EqualsAny(this object instance, params object[] args)
        {
            return args.Aggregate(false, (current, arg) => current | instance.Equals(arg));
        }

        public static bool Implements(this object instance, Type interfaceType)
        {
            return interfaceType.IsGenericTypeDefinition
                       ? instance.ImplementsGeneric(interfaceType)
                       : interfaceType.IsAssignableFrom(instance.GetType());
        }

        public static bool Implements<T>(this object instance)
        {
            var type = instance.GetType();
            var interfaceType = typeof(T);
            return interfaceType.IsGenericTypeDefinition
                       ? instance.ImplementsGeneric(interfaceType)
                       : interfaceType.IsAssignableFrom(type);
        }

        private static bool ImplementsGeneric(this Type type, Type targetType)
        {
            var interfaceTypes = type.GetInterfaces();
            foreach (var interfaceType in interfaceTypes)
            {
                if (!interfaceType.IsGenericType)
                {
                    continue;
                }

                if (interfaceType.GetGenericTypeDefinition() == targetType)
                {
                    return true;
                }
            }

            var baseType = type.BaseType;
            if (baseType == null)
            {
                return false;
            }

            return baseType.IsGenericType
                       ? baseType.GetGenericTypeDefinition() == targetType
                       : baseType.ImplementsGeneric(targetType);
        }

        private static bool ImplementsGeneric(this object instance, Type targetType)
        {
            return instance.GetType().ImplementsGeneric(targetType);
        }

        public static Type GetDeclaredTypeForGeneric(this object instance, Type interfaceType)
        {
            return instance.GetType().GetDeclaredTypeForGeneric(interfaceType);
        }

        public static Type GetDeclaredTypeForGeneric(this Type baseType, Type interfaceType)
        {
            var type = default(Type);

            if (baseType.ImplementsGeneric(interfaceType))
            {
                var generic = baseType.GetInterface(interfaceType.FullName, true);
                if (generic.IsGenericType)
                {
                    var args = generic.GetGenericArguments();
                    if (args.Length == 1)
                    {
                        type = args[0];
                    }
                }
            }

            return type;
        }
    }
}
