﻿using System;
using System.Diagnostics.Contracts;

namespace Receptiviti.Client.Util
{

    static class UriExtensions
    {

        /// <summary>
        /// Combines the given path with the URI.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Uri Combine(this Uri self, string path)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentOutOfRangeException>(self.IsAbsoluteUri);
            Contract.Requires<ArgumentNullException>(path != null);

            if (!self.ToString().EndsWith("/"))
                self = new Uri(self.ToString() + "/");

            return new Uri(self, path);
        }

        /// <summary>
        /// Combines the given paths with the URI.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="paths"></param>
        /// <returns></returns>
        public static Uri Combine(this Uri self, params string[] paths)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentOutOfRangeException>(self.IsAbsoluteUri);
            Contract.Requires<ArgumentNullException>(paths != null);

            foreach (var p in paths)
                self = self.Combine(p);

            return self;
        }

    }

}
