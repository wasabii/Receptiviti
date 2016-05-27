using Newtonsoft.Json;

namespace Receptiviti.Client.Model
{

    public class LiwcScores
    {
        
        [JsonProperty("wc")]
        public int WordCount { get; set; }
        
        [JsonProperty("sixLtr")]
        public int WordsGreaterThan6Letters { get; set; }
        
        [JsonProperty("clout")]
        public double Clout { get; set; }
        
        [JsonProperty("wps")]
        public double WordsPerSentence { get; set; }
        
        [JsonProperty("analytic")]
        public double Analytic { get; set; }
        
        [JsonProperty("tone")]
        public double Tone { get; set; }
        
        [JsonProperty("dic")]
        public double DictionaryWords { get; set; }
        
        [JsonProperty("authentic")]
        public double Authentic { get; set; }
        
        [JsonProperty("categories")]
        public LiwcCategories Categories { get; set; }

    }

}
