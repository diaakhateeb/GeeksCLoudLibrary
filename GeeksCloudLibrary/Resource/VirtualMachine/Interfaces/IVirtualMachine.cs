using GeeksCloudLibrary.Resource.Specs.MachineInstanceType.Enum;
using GeeksCloudLibrary.Resource.Specs.Memory.Interfaces;
using GeeksCloudLibrary.Resource.Specs.NetworkPerformance.Enum;
using GeeksCloudLibrary.Resource.Specs.Processor.Interfaces;
using GeeksCloudLibrary.Resource.Specs.Storage.Interfaces;
using GeeksCloudLibrary.Resource.VirtualMachine.OperatingSystem.Interfaces;
using GeeksCloudLibrary.Shared.Interfaces;

namespace GeeksCloudLibrary.Resource.VirtualMachine.Interfaces
{
    public interface IVirtualMachine : IResource
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
