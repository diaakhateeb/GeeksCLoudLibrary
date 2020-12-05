using GeeksCloudLibrary.Resource.Specs.Memory.Interfaces;
using GeeksCloudLibrary.Resource.Specs.SpaceSizeUnit.Enum;

namespace GeeksCloudLibrary.Resource.Specs.Memory
{
    public class Memory : IMemory
    {
        public int Size { get; set; }
        public SizeUnit SpaceSizeUnit { get; set; }
    }
}
