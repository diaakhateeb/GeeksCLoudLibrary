using GeeksCloudLibrary.Infrastructure.Interfaces;
using GeeksCloudLibrary.Operations.Interfaces;
using GeeksCloudLibrary.Providers.Interfaces;
using GeeksCloudLibrary.Resource.Interfaces;
using GeeksCloudLibrary.ResourceFile.Interfaces;
using GeeksCloudLibrary.ResourceInstance.Interfaces;

namespace GeeksCloudLibrary.Operations
{
    public class CloudService : ICloudService
    {
        public IProvider Provider { get; set; }

        public IInfrastructure Infrastructure { get; set; }

        public IResourceInstance ResourceInstance { get; set; }
        public IResourceFile<IResourceConfig> ResourceFile { get; set; }
    }
}
