using Newtonsoft.Json;

namespace Receptiviti.Client.Model
{

    public class EmotionalAnalysisFacets
    {

        [JsonProperty("anger")]
        public double Anger { get; set; }

        [JsonProperty("fear")]
        public double Fear { get; set; }

        [JsonProperty("sad")]
        public double Sad { get; set; }

    }

}
