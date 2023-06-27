using Newtonsoft.Json;

namespace Geovenci.Data.Entities
{
    public class Modification
    {
        [JsonProperty(PropertyName="propertyName")]
        public string? PropertyName { get; set; }

        [JsonProperty(PropertyName = "originalValue")]

        public string? OriginalValue { get; set; }

        [JsonProperty(PropertyName = "currentValue")]
        public string? CurrentValue { get; set; }

    }
}
