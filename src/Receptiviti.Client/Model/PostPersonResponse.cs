using System;

using Newtonsoft.Json;

namespace Receptiviti.Client.Model
{

    [Serializable]
    public class PostPersonResponse :
        Person
    {

        [JsonProperty("writing_samples", NullValueHandling = NullValueHandling.Ignore)]
        public WritingSample[] WritingSamples { get; set; }

    }

}
