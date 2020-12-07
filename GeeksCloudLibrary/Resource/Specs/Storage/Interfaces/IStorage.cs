using GeeksCloudLibrary.Resource.Specs.SpaceSizeUnit.Enum;
using GeeksCloudLibrary.Resource.Specs.Storage.Enum;

namespace GeeksCloudLibrary.Resource.Specs.Storage.Interfaces
{
    /// <summary>
    /// IStorage interface.
    /// </summary>
    public interface IStorage
    {
        int Size { get; set; }
        SizeUnit SpaceSizeUnit { get; set; }
        VolumeType VolumeType { get; set; }
    }
}
