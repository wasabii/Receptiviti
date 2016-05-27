using System;
using System.Collections;
using System.Diagnostics.Contracts;

namespace Receptiviti.Client.Util
{

    public static class UriBuilderExtensions
    {

        /// <summary>
        /// Appends the given name and value as query arguments to the <see cref="UriBuilder"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static UriBuilder AppendQuery(this UriBuilder self, string name, string value)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(name != null);

            var p = Uri.EscapeDataString(name) + "=" + Uri.EscapeDataString(value ?? "");

            if (self.Query != null &&
                self.Query.Length > 1)
                self.Query = self.Query.Substring(1) + "&" + p;
            else
                self.Query = p;

            return self;
        }

        /// <summary>
        /// Appends the given name and value query arguments to the <see cref="UriBuilder"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static UriBuilder AppendQuery(this UriBuilder self, string name, object value)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(name != null);

            // string is IEnumerable but takes precedence
            if (value is string)
                return AppendQuery(self, name, (string)value);

            if (value is IEnumerable)
            {
                // append multiple query args with the same name
                foreach (var i in ((IEnumerable)value))
                    AppendQuery(self, name, i.ToString());

                return self;
            }

            // standard operation
            return AppendQuery(self, name, value?.ToString());
        }

        /// <summary>
        /// Appends the given name and value query arguments to the <see cref="UriBuilder"/> if the value is not null.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static UriBuilder AppendQueryIfNotNull(this UriBuilder self, string name, object value)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(name != null);

            if (value != null)
                return AppendQuery(self, name, value);
            else
                return self;
        }

    }

}
