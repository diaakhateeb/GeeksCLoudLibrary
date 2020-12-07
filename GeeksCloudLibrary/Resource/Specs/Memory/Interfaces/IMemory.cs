using GeeksCloudLibrary.Resource.Specs.SpaceSizeUnit.Enum;

namespace GeeksCloudLibrary.Resource.Specs.Memory.Interfaces
{
    /// <summary>
    /// IMemory interface.
    /// </summary>
    public interface IMemory
    {
        int Size { get; set; }
        SizeUnit SpaceSizeUnit { get; set; }
    }
}
