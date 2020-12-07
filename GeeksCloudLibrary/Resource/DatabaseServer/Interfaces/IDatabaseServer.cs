using GeeksCloudLibrary.Resource.Specs.MachineInstanceType.Enum;
using GeeksCloudLibrary.Resource.Specs.Memory.Interfaces;
using GeeksCloudLibrary.Resource.Specs.NetworkPerformance.Enum;
using GeeksCloudLibrary.Resource.Specs.Storage.Interfaces;
using GeeksCloudLibrary.Shared.Interfaces;

namespace GeeksCloudLibrary.Resource.DatabaseServer.Interfaces
{
    /// <summary>
    /// IDatabaseServer interface.
    /// </summary>
    public interface IDatabaseServer : IResource
    {
        int Version { get; set; }
        string Vendor { get; set; }
        IStorage Storage { get; set; }
        InstanceType InstanceType { get; set; }
        IMemory Memory { get; set; }
        Performance NetworkPerformance { get; set; }
    }
}
