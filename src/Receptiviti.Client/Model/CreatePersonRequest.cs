using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Receptiviti.Client.Model
{

    [Serializable]
    public class CreatePersonRequest
    {

        /// <summary>
        /// Name of Person to be analyzed.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Tags.
        /// </summary>
        [JsonProperty("person_tags", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Tags { get; set; }

        /// <summary>
        /// Gender.
        /// </summary>
        [JsonProperty("gender")]
        public Gender Gender { get; set; }

        /// <summary>
        /// A handle for the person. Contact/Customer ID from calling software.
        /// </summary>
        [JsonProperty("person_handle")]
        public string Handle { get; set; }

        /// <summary>
        /// Initial content to create.
        /// </summary>
        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public ContentRequest Content { get; set; }

        /// <summary>
        /// Custom Fields.
        /// </summary>
        [JsonProperty("custom_fields", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> CustomFields { get; set; } = new Dictionary<string, string>();

    }

}
