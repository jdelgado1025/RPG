using System.Text.Json.Serialization;

namespace RPG.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight = 1,
        Mage = 2,
        Cleric = 3,
        Ranger = 4,
        Druid = 5
    }
}