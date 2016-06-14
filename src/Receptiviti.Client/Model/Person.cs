using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Receptiviti.Client.Model
{

    [Serializable]
    [KnownType(typeof(CreatePersonRequest))]
    [KnownType(typeof(CreatePersonResponse))]
    public class Person
    {

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("updated")]
        public DateTimeOffset Updated { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("client_reference_id")]
        public string ClientReferenceId { get; set; }

        [JsonProperty("gender")]
        public Gender Gender { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("writing_samples_count")]
        public int WritingSamplesCount { get; set; }

        [JsonProperty("custom_fields", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> CustomFields { get; set; } = new Dictionary<string, string>();

    }

}
