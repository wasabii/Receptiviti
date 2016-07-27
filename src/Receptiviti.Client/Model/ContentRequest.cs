using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Receptiviti.Client.Model
{

    [Serializable]
    public class ContentRequest
    {

        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        public Language? Language { get; set; }

        [JsonProperty("content_tags", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Tags { get; set; }

        [JsonProperty("content_handle", NullValueHandling = NullValueHandling.Ignore)]
        public string Handle { get; set; }

        [JsonProperty("content_source")]
        public ContentSource Source { get; set; }

        [JsonProperty("language_content")]
        public string Content { get; set; }

        [JsonProperty("content_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? Date { get; set; }

        [JsonProperty("recipient_id", NullValueHandling = NullValueHandling.Ignore)]
        public string RecipientId { get; set; }

        [JsonProperty("custom_fields", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> CustomFields { get; set; } = new Dictionary<string, string>();

    }

}
