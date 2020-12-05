using GeeksCloudLibrary.Resource.Specs.VirtualMachine.SpaceSizeUnit.Enum;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.Storage.Enum;

namespace GeeksCloudLibrary.Resource.Specs.VirtualMachine.Storage
{
    public interface IStorage
    {
        int Size { get; set; }
        SizeUnit SpaceSizeUnit { get; set; }
        VolumeType VolumeType { get; set; }
    }
}
