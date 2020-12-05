using GeeksCloudLibrary.Resource.Specs.VirtualMachine.OperatingSystem.Enum;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.OperatingSystem.Interfaces;

namespace GeeksCloudLibrary.Resource.Specs.VirtualMachine.OperatingSystem
{
    public class LinuxOperatingSystem : IOperatingSystem
    {
        public int Version { get; set; }
        public OperatingSystemArchitecture Architecture { get; set; }
        public string Vendor { get; set; }
    }
}
