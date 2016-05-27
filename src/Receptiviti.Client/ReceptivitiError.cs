using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Receptiviti.Client
{

    [Serializable]
    public class ReceptivitiError
    {

        /// <summary>
        /// Error message.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Suggested resolution.
        /// </summary>
        [JsonProperty("resolution")]
        public string Resolution { get; set; }

        /// <summary>
        /// Specific errors.
        /// </summary>
        [JsonProperty("errors")]
        public Dictionary<string, string> Errors { get; set; }

    }

}
