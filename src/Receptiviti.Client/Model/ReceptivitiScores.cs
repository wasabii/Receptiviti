using System;

using Newtonsoft.Json;

namespace Receptiviti.Client.Model
{

    [Serializable]
    public class ReceptivitiScores
    {

        [JsonProperty("raw_scores")]
        public ReceptivitiScoreSet Raw { get; set; }

        [JsonProperty("percentiles")]
        public ReceptivitiScoreSet Percentile { get; set; }

    }

}
