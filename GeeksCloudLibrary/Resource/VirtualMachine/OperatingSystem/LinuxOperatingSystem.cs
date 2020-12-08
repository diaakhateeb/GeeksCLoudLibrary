using System.Collections.Generic;
using GeeksCloudLibrary.Resource.VirtualMachine.OperatingSystem.Enum;
using GeeksCloudLibrary.Resource.VirtualMachine.OperatingSystem.Interfaces;

namespace GeeksCloudLibrary.Resource.VirtualMachine.OperatingSystem
{
    /// <summary>
    /// Linux Operating System class.
    /// </summary>
    public class LinuxOperatingSystem : IOperatingSystem
    {
        public int Version { get; set; }
        public OperatingSystemArchitecture Architecture { get; set; }
        public string Vendor { get; set; }
        public IList<string> Applications { get; set; }
        public string Name { get; set; }
    }
}
