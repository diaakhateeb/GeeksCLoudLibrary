using GeeksCloudLibrary.Resource.VirtualMachine.OperatingSystem.Enum;
using GeeksCloudLibrary.Shared.Interfaces;

namespace GeeksCloudLibrary.Resource.VirtualMachine.OperatingSystem.Interfaces
{
    public interface IOperatingSystem : IResourceName
    {
        int Version { get; set; }
        OperatingSystemArchitecture Architecture { get; set; }
        string Vendor { get; set; }
    }
}
