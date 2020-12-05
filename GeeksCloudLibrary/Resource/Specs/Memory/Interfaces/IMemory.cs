using GeeksCloudLibrary.Resource.Specs.SpaceSizeUnit.Enum;

namespace GeeksCloudLibrary.Resource.Specs.Memory.Interfaces
{
    public interface IMemory
    {
        int Size { get; set; }
        SizeUnit SpaceSizeUnit { get; set; }
    }
}
