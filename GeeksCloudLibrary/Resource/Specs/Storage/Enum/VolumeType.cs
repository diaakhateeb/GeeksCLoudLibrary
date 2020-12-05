using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GeeksCloudLibrary.Resource.Specs.Storage.Enum
{
    [JsonConverter (typeof (StringEnumConverter))]
    public enum VolumeType
    {
        Root,
        Extension
    }
}
