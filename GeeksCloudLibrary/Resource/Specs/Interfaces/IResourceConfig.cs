using GeeksCloudLibrary.Resource.Specs.DatabaseServer.Interfaces;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.Interfaces;

namespace GeeksCloudLibrary.Resource.Specs.Interfaces
{
    public interface IResourceConfig
    {
        IVirtualMachine VirtualMachine { get; set; }
        IDatabaseServer DatabaseServer { get; set; }
        // load balancer
        // elastic file storage
    }
}
