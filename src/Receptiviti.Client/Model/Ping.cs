using System;
using Newtonsoft.Json;

namespace Receptiviti.Client.Model
{

    [Serializable]
    public class Ping
    {

        [JsonProperty("pong")]
        public string Pong { get; set; }

    }

}
