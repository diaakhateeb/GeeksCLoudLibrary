using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GeeksCloudLibrary.Resource.Specs.NetworkPerformance.Enum
{
    [JsonConverter (typeof (StringEnumConverter))]
    public enum Performance
    {
        Low,
        Moderate,
        High
    }
}
