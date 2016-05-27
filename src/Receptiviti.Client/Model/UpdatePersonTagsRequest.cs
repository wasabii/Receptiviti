using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Receptiviti.Client.Model
{

    [Serializable]
    public class UpdatePersonTagsRequest
    {

        /// <summary>
        /// Tags.
        /// </summary>
        [JsonProperty("tags")]
        public string[] Tags { get; set; }

    }

}
