
using System.Text.Json.Serialization;

namespace asp.net.Models {
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight,
        Mage,
        Cleric

    }
}