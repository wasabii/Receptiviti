using System;

using Newtonsoft.Json;

namespace Receptiviti.Client.Model
{

    [Serializable]
    public class UpdateWritingSampleTagsRequest
    {

        /// <summary>
        /// Tags.
        /// </summary>
        [JsonProperty("tags")]
        public string[] Tags { get; set; }

    }

}
