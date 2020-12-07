using GeeksCloudLibrary.Shared.Interfaces;

namespace GeeksCloudLibrary.ResourceFile.Interfaces
{
    /// <summary>
    /// IResourceFile class.
    /// </summary>
    /// <typeparam name="T">Generic resource file (e.g. VirtualMachine, Database).</typeparam>
    public interface IResourceFile<T> : IResource
    {
        T Content { get; set; }
    }
}
