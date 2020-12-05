namespace GeeksCloudLibrary.Resource.Specs.DatabaseServer.Interfaces
{
    public interface IDatabaseServer
    {
        int Version { get; set; }
        string Vendor { get; set; }
    }
}
