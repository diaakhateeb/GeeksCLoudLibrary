using GeeksCloudLibrary.Resource.Specs.DatabaseServer.Interfaces;

namespace GeeksCloudLibrary.Resource.Specs.DatabaseServer
{
    public class MsSqlServer : IDatabaseServer
    {
        public int Version { get; set; }
        public string Vendor { get; set; }
    }
}
