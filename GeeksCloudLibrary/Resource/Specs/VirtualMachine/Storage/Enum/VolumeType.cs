using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GeeksCloudLibrary.Resource.Specs.VirtualMachine.Storage.Enum
{
    [JsonConverter (typeof (StringEnumConverter))]
    public enum VolumeType
    {
        Root,
        Extension
    }
}
