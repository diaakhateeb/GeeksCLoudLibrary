using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GeeksCloudLibrary.Resource.Specs.VirtualMachine.SpaceSizeUnit.Enum
{
    [JsonConverter (typeof (StringEnumConverter))]
    public enum SizeUnit
    {
        MiB,
        GiB,
        TeB
    }
}