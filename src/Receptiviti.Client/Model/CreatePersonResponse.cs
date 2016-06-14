using System;

using Newtonsoft.Json;

namespace Receptiviti.Client.Model
{

    [Serializable]
    public class CreatePersonResponse :
        Person
    {

        [JsonProperty("writing_samples", NullValueHandling = NullValueHandling.Ignore)]
        public WritingSample[] WritingSamples { get; set; }

    }

}
