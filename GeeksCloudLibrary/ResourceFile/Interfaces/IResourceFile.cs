using GeeksCloudLibrary.Shared.Interfaces;

namespace GeeksCloudLibrary.ResourceFile.Interfaces
{
    public interface IResourceFile<T> : IResource
    {
        T Content { get; set; }
    }
}
