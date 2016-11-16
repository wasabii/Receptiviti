using System;
using System.Collections.Generic;
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

        [JsonProperty("warnings")]
        public Dictionary<string, string[]> Warnings { get; set; }

    }

}
