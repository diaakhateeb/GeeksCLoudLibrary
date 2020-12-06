using System;
using GeeksCloudLibrary.Infrastructure.Interfaces;
using GeeksCloudLibrary.Operations.Interfaces;
using GeeksCloudLibrary.Providers.Interfaces;
using GeeksCloudLibrary.ResourceFile.Interfaces;
using GeeksCloudLibrary.ResourceInstance.Interfaces;

namespace GeeksCloudLibrary.Operations
{
    [Serializable]
    public class CloudService<T> : ICloudService<T>
    {
        public IProvider Provider { get; set; }

        public IInfrastructure Infrastructure { get; set; }

        public IResourceInstance ResourceInstance { get; set; }
        public IResourceFile<T> ResourceFile { get; set; }
    }
}
