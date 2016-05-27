using System;

using Newtonsoft.Json;

namespace Receptiviti.Client.Model
{

    [Serializable]
    public class PersonProfile
    {

        [JsonProperty("liwc_scores")]
        public LiwcScores LiwcScores { get; set; }

        [JsonProperty("receptiviti_scores")]
        public ReceptivitiScores ReceptivitiScores { get; set; }

        [JsonProperty("personality_snapshot")]
        public PersonalitySnapshot[] PersonalitySnapshot { get; set; }

    }

}
