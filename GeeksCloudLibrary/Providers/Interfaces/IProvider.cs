using GeeksCloudLibrary.Shared.Interfaces;

namespace GeeksCloudLibrary.Providers.Interfaces
{
    public interface IProvider : IResourceName
    {
        string Device { get; set; }
    }
}
