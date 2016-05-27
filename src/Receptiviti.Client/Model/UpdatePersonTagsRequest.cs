using System;

using Newtonsoft.Json;

namespace Receptiviti.Client.Model
{

    [Serializable]
    public class UpdatePersonTagsRequest
    {

        /// <summary>
        /// Tags.
        /// </summary>
        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Tags { get; set; }

    }

}
