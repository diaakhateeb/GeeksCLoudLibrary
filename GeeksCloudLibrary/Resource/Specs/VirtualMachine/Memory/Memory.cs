using GeeksCloudLibrary.Resource.Specs.VirtualMachine.Memory.Interfaces;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.SpaceSizeUnit.Enum;

namespace GeeksCloudLibrary.Resource.Specs.VirtualMachine.Memory
{
    public class Memory : IMemory
    {
        public int Size { get; set; }
        public SizeUnit SpaceSizeUnit { get; set; }
    }
}
