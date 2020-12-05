using GeeksCloudLibrary.Resource.Specs.VirtualMachine.Interfaces;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.MachineInstanceType.Enum;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.Memory.Interfaces;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.NetworkPerformance.Enum;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.OperatingSystem.Interfaces;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.Processor;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.Storage;

namespace GeeksCloudLibrary.Resource.Specs.VirtualMachine
{
    public class VirtualMachine : IVirtualMachine
    {
        public IOperatingSystem OperatingSystem { get; set; }
        public InstanceType InstanceType { get; set; }
        public IStorage Storage { get; set; }
        public IProcessor Processor { get; set; }
        public IMemory Memory { get; set; }
        public Performance NetworkPerformance { get; set; }
        public string Tag { get; set; }
    }
}
