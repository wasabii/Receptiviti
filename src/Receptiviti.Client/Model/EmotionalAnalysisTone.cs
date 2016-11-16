using Newtonsoft.Json;

namespace Receptiviti.Client.Model
{

    public class EmotionalAnalysisTone
    {

        [JsonProperty("rating")]
        public EmotionalAnalysisToneRating Rating { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

    }

}
