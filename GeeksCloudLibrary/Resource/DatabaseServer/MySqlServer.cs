using GeeksCloudLibrary.Resource.DatabaseServer.Interfaces;
using GeeksCloudLibrary.Resource.Specs.MachineInstanceType.Enum;
using GeeksCloudLibrary.Resource.Specs.Memory.Interfaces;
using GeeksCloudLibrary.Resource.Specs.NetworkPerformance.Enum;
using GeeksCloudLibrary.Resource.Specs.Storage.Interfaces;

namespace GeeksCloudLibrary.Resource.DatabaseServer
{
    /// <summary>
    /// MySQL Server class.
    /// </summary>
    public class MySqlServer : IDatabaseServer
    {
        public string Name { get; set; }
        public int Version { get; set; }
        public string Vendor { get; set; }
        public IStorage Storage { get; set; }
        public InstanceType InstanceType { get; set; }
        public IMemory Memory { get; set; }
        public Performance NetworkPerformance { get; set; }
    }
}
