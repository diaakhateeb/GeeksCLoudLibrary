using GeeksCloudLibrary.Shared.Interfaces;

namespace GeeksCloudLibrary.Providers.Interfaces
{
    public interface IProvider : IResource
    {
        string Device { get; set; }
    }
}
