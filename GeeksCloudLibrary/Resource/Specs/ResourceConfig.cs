using GeeksCloudLibrary.Resource.Specs.DatabaseServer.Interfaces;
using GeeksCloudLibrary.Resource.Specs.Interfaces;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.Interfaces;
using System;

namespace GeeksCloudLibrary.Resource.Specs
{
    [Serializable]
    public class ResourceConfig : IResourceConfig
    {
        public IVirtualMachine VirtualMachine { get; set; }
        public IDatabaseServer DatabaseServer { get; set; }
    }
}
