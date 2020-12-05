using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GeeksCloudLibrary.Resource.Specs.VirtualMachine.MachineInstanceType.Enum
{
    [JsonConverter (typeof (StringEnumConverter))]
    public enum InstanceType
    {
        Nano,
        Small,
        Medium,
        Large,
        XLarge
    }
}
