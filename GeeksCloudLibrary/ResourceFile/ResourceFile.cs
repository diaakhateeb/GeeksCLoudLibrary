using GeeksCloudLibrary.ResourceFile.Interfaces;
using System;

namespace GeeksCloudLibrary.ResourceFile
{
    public class ResourceFile<T> : IResourceFile<T>
    {
        public string Name { get; set; }
        public T Content { get; set; }
    }
}