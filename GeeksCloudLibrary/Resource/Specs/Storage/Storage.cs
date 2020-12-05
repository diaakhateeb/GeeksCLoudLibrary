using GeeksCloudLibrary.Resource.Specs.SpaceSizeUnit.Enum;
using GeeksCloudLibrary.Resource.Specs.Storage.Enum;
using GeeksCloudLibrary.Resource.Specs.Storage.Interfaces;

namespace GeeksCloudLibrary.Resource.Specs.Storage
{
    public class Storage : IStorage
    {
        public int Size { get; set; }
        public SizeUnit SpaceSizeUnit { get; set; }
        public VolumeType VolumeType { get; set; }
    }
}
