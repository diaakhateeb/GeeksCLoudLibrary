using GeeksCloudLibrary.Infrastructure.Interfaces;
using GeeksCloudLibrary.Providers.Interfaces;
using GeeksCloudLibrary.Resource.Interfaces;
using GeeksCloudLibrary.ResourceFile.Interfaces;
using GeeksCloudLibrary.ResourceInstance.Interfaces;

namespace GeeksCloudLibrary.Operations.Interfaces
{
    public interface ICloudService
    {
        IProvider Provider { get; set; }
        IInfrastructure Infrastructure { get; set; }
        IResourceInstance ResourceInstance { get; set; }
        IResourceFile<IResourceConfig> ResourceFile { get; set; }
    }
}
