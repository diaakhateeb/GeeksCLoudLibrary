using GeeksCloudLibrary.Shared.Interfaces;

namespace GeeksCloudLibrary.ResourceFile.Interfaces
{
    public interface IResourceFile<T> : IResourceName
    {
        T Content { get; set; }
    }
}
