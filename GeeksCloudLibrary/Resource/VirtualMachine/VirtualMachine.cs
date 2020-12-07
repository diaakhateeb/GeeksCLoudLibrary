using GeeksCloudLibrary.Resource.Specs.MachineInstanceType.Enum;
using GeeksCloudLibrary.Resource.Specs.Memory.Interfaces;
using GeeksCloudLibrary.Resource.Specs.NetworkPerformance.Enum;
using GeeksCloudLibrary.Resource.Specs.Processor.Interfaces;
using GeeksCloudLibrary.Resource.Specs.Storage.Interfaces;
using GeeksCloudLibrary.Resource.VirtualMachine.Interfaces;
using GeeksCloudLibrary.Resource.VirtualMachine.OperatingSystem.Interfaces;

namespace GeeksCloudLibrary.Resource.VirtualMachine
{
    /// <summary>
    /// Creates VM class.
    /// </summary>
    public class VirtualMachine : IVirtualMachine
    {
        public string Name { get; set; }
        public IOperatingSystem OperatingSystem { get; set; }
        public InstanceType InstanceType { get; set; }
        public IStorage Storage { get; set; }
        public IProcessor Processor { get; set; }
        public IMemory Memory { get; set; }
        public Performance NetworkPerformance { get; set; }
        public string Tag { get; set; }
    }
}
