using System;

using Newtonsoft.Json;

namespace Receptiviti.Client.Model
{

    [Serializable]
    public class Content
    {

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("updated")]
        public DateTimeOffset Updated { get; set; }

        [JsonProperty("content_source")]
        public ContentSource Source { get; set; }

        [JsonProperty("content_date")]
        public DateTime Date { get; set; }

        [JsonProperty("content_tags")]
        public string[] Tags { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        public Language? Language { get; set; }

        [JsonProperty("person")]
        public string Person { get; set; }

        [JsonProperty("liwc_scores")]
        public LiwcScores LiwcScores { get; set; }

        [JsonProperty("receptiviti_scores")]
        public ReceptivitiScores ReceptivitiScores { get; set; }

        [JsonProperty("personality_snapshot")]
        public PersonalitySnapshot[] PersonalitySnapshots { get; set; }

    }

}
