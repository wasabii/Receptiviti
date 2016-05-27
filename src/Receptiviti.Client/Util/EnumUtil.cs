using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Receptiviti.Client.Util
{

    static class EnumUtil
    {

        /// <summary>
        /// Gets the string value specified by the <see cref="EnumMemberAttribute"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static string ToEnumString<T>(this T instance)
        {
            Contract.Requires<ArgumentNullException>(instance != null);

            return typeof(T).GetField(Enum.GetName(typeof(T), instance))
                .GetCustomAttributes<EnumMemberAttribute>(true)
                .Select(i => i.Value)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the enum value assigned by the <see cref="EnumMemberAttribute"/> to the given value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(string value)
        {
            Contract.Requires<ArgumentNullException>(value != null);

            return Enum.GetNames(typeof(T))
                .Where(i => typeof(T)
                    .GetField(i)
                    .GetCustomAttributes<EnumMemberAttribute>(true)
                    .Any(j => j.Value == value))
                .Select(i => (T)Enum.Parse(typeof(T), i))
                .FirstOrDefault();
        }

    }

}
