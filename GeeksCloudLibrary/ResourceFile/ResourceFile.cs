using GeeksCloudLibrary.ResourceFile.Interfaces;
using System;
using GeeksCloudLibrary.Resource.Interfaces;

namespace GeeksCloudLibrary.ResourceFile
{
    [Serializable]
    public class ResourceFile<T> : IResourceFile<T> where T : IResourceConfig
    {
        public string Name { get; set; }
        public T Content { get; set; }
        public string Path { get; set; }
    }
}