using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Receptiviti.Client.Model
{

    [Serializable]
    public class WritingSampleRequest
    {

        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Tags { get; set; }

        [JsonProperty("client_reference_id")]
        public string ClientReferenceId { get; set; }

        [JsonProperty("content_source")]
        public ContentSource ContentSource { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("sample_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? SampleDate { get; set; }

        [JsonProperty("recipient", NullValueHandling = NullValueHandling.Ignore)]
        public string Recipient { get; set; }

        [JsonProperty("custom_fields", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> CustomFields { get; set; }

    }

}
