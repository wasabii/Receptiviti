using System;

using Newtonsoft.Json;

namespace Receptiviti.Client.Model
{

    [Serializable]
    public class CreatePersonResponse :
        Person
    {

        [JsonProperty("contents", NullValueHandling = NullValueHandling.Ignore)]
        public Content[] Contents { get; set; }

    }

}
