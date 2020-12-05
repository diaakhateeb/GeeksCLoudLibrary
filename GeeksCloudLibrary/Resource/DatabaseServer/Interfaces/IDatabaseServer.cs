using GeeksCloudLibrary.Resource.Specs.MachineInstanceType.Enum;
using GeeksCloudLibrary.Resource.Specs.Memory.Interfaces;
using GeeksCloudLibrary.Resource.Specs.NetworkPerformance.Enum;
using GeeksCloudLibrary.Resource.Specs.Storage.Interfaces;

namespace GeeksCloudLibrary.Resource.DatabaseServer.Interfaces
{
    public interface IDatabaseServer
    {
        int Version { get; set; }
        string Vendor { get; set; }
        IStorage Storage { get; set; }
        InstanceType InstanceType { get; set; }
        IMemory Memory { get; set; }
        Performance NetworkPerformance { get; set; }
    }
}
