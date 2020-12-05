using GeeksCloudLibrary.Resource.VirtualMachine.OperatingSystem.Enum;

namespace GeeksCloudLibrary.Resource.VirtualMachine.OperatingSystem.Interfaces
{
    public interface IOperatingSystem
    {
        int Version { get; set; }
        OperatingSystemArchitecture Architecture { get; set; }
        string Vendor { get; set; }
    }
}
