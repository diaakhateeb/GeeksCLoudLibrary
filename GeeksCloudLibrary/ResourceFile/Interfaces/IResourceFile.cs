using GeeksCloudLibrary.Resource.Interfaces;
using GeeksCloudLibrary.Shared.Interfaces;

namespace GeeksCloudLibrary.ResourceFile.Interfaces
{
    public interface IResourceFile<T> : IResourceName where T : IResourceConfig
    {
        T Content { get; set; }
        string Path { get; set; }
    }
}
