using GeeksCloudLibrary.Resource.DatabaseServer.Interfaces;
using GeeksCloudLibrary.Resource.VirtualMachine.Interfaces;

namespace GeeksCloudLibrary.Resource.Interfaces
{
    public interface IResourceConfig
    {
        IVirtualMachine VirtualMachine { get; set; }
        IDatabaseServer DatabaseServer { get; set; }
        // load balancer
        // elastic file storage
    }
}
