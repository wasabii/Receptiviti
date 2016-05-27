using System;

using Newtonsoft.Json;

namespace Receptiviti.Client.Model
{

    [Serializable]
    public class LsmScoreResult
    {

        [JsonProperty("lsm_score")]
        public double LsmScore { get; set; }

    }

}
