﻿using System;
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
        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Tags { get; set; }

        /// <summary>
        /// Gender.
        /// </summary>
        [JsonProperty("gender")]
        public Gender Gender { get; set; }

        /// <summary>
        /// A reference id for the person. Contact/Customer ID from calling software.
        /// </summary>
        [JsonProperty("client_reference_id")]
        public string ClientReferenceId { get; set; }

        /// <summary>
        /// Initial writing sample to create.
        /// </summary>
        [JsonProperty("writing_sample", NullValueHandling = NullValueHandling.Ignore)]
        public WritingSampleRequest WritingSample { get; set; }

        /// <summary>
        /// Custom Fields.
        /// </summary>
        [JsonProperty("custom_fields", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> CustomFields { get; set; } = new Dictionary<string, string>();

    }

}
