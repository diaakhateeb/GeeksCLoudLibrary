using GeeksCloudLibrary.Infrastructure.Interfaces;
using GeeksCloudLibrary.Providers.Interfaces;
using GeeksCloudLibrary.ResourceFile.Interfaces;
using GeeksCloudLibrary.ResourceInstance.Interfaces;

namespace GeeksCloudLibrary.Operations.Interfaces
{
    /// <summary>
    /// ICloudService interface.
    /// </summary>
    /// <typeparam name="T">Infrastructure generic object type.</typeparam>
    public interface ICloudService<T>
    {
        IProvider Provider { get; set; }
        IInfrastructure Infrastructure { get; set; }
        IResourceInstance ResourceInstance { get; set; }
        IResourceFile<T> ResourceFile { get; set; }
    }
}
