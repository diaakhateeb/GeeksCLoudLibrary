using GeeksCloudLibrary.Resource.Specs.VirtualMachine.MachineInstanceType.Enum;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.Memory.Interfaces;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.NetworkPerformance.Enum;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.OperatingSystem.Interfaces;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.Processor;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.Storage;

namespace GeeksCloudLibrary.Resource.Specs.VirtualMachine.Interfaces
{
    public interface IVirtualMachine
    {
        IOperatingSystem OperatingSystem { get; set; }
        IStorage Storage { get; set; }
        InstanceType InstanceType { get; set; }
        IProcessor Processor { get; set; }
        IMemory Memory { get; set; }
        Performance NetworkPerformance { get; set; }
        string Tag { get; set; }
    }
}
