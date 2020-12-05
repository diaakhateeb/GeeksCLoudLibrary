using GeeksCloudLibrary.Resource.Specs.VirtualMachine.SpaceSizeUnit.Enum;

namespace GeeksCloudLibrary.Resource.Specs.VirtualMachine.Memory.Interfaces
{
    public interface IMemory
    {
        int Size { get; set; }
        SizeUnit SpaceSizeUnit { get; set; }
    }
}
