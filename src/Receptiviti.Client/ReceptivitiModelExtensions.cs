using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

using Receptiviti.Client.Model;

namespace Receptiviti.Client
{

    public static class ReceptivitiModelExtensions
    {

        /// <summary>
        /// Get contents.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="api"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        public static async Task<Many<Content>> GetContents(this Person person, ReceptivitiClient api, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            Contract.Requires<ArgumentNullException>(person != null);
            Contract.Requires<ArgumentNullException>(person.Id != null);
            Contract.Requires<ArgumentNullException>(api != null);

            return await api.GetPersonContents(person.Id, fromDate, toDate, tags);
        }

    }

}
