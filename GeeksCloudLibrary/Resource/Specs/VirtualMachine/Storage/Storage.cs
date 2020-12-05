using GeeksCloudLibrary.Resource.Specs.VirtualMachine.SpaceSizeUnit.Enum;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.Storage.Enum;

namespace GeeksCloudLibrary.Resource.Specs.VirtualMachine.Storage
{
    public class Storage : IStorage
    {
        public int Size { get; set; }
        public SizeUnit SpaceSizeUnit { get; set; }
        public VolumeType VolumeType { get; set; }
    }
}
