using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Receptiviti.Client.Model
{

    [Serializable]
    public class EmotionalAnalysis
    {

        [JsonProperty("facets")]
        public EmotionalAnalysisFacets Facets { get; set; }

        [JsonProperty("emotional_tone")]
        public EmotionalAnalysisTone Tone { get;set;}

    }

}
