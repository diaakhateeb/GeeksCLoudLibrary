using GeeksCloudLibrary.Resource.Interfaces;
using GeeksCloudLibrary.ResourceFile.Interfaces;
using System;

namespace GeeksCloudLibrary.ResourceFile
{
    [Serializable]
    public class ResourceFile<T> : IResourceFile<T> where T : IResourceConfig
    {
        public string Name { get; set; }
        public T Content { get; set; }
    }
}