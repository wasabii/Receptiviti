using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Receptiviti.Client.Model
{

    /// <summary>
    /// Represents an enumeration of multiple items.
    /// </summary>
    /// <typeparam name="TElement"></typeparam>
    [Serializable]
    public class Many<TElement> :
        List<TElement>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="totalCount"></param>
        public Many(IEnumerable<TElement> items, int totalCount)
            : base(items)
        {
            Contract.Requires<ArgumentOutOfRangeException>(totalCount >= 0);

            TotalCount = totalCount;
        }

        /// <summary>
        /// Total amount of items that exist.
        /// </summary>
        public int TotalCount { get; set; }

    }

}
