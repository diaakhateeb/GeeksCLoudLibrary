using GeeksCloudLibrary.Resource.DatabaseServer.Interfaces;
using GeeksCloudLibrary.Resource.Interfaces;
using GeeksCloudLibrary.Resource.VirtualMachine.Interfaces;
using System;

namespace GeeksCloudLibrary.Resource
{
    [Serializable]
    public class ResourceConfig : IResourceConfig
    {
        public IVirtualMachine VirtualMachine { get; set; }
        public IDatabaseServer DatabaseServer { get; set; }
    }
}
