using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Receptiviti.Client.Model
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum EmotionalAnalysisToneRating
    {

        [EnumMember(Value = "Positive")]
        Positive,

        [EnumMember(Value = "Negative")]
        Negative

    }

}
