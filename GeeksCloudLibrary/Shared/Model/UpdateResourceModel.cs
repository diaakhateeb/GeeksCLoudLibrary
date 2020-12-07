using GeeksCloudLibrary.Resource.Specs.MachineInstanceType.Enum;
using GeeksCloudLibrary.Resource.Specs.Memory;
using GeeksCloudLibrary.Resource.Specs.NetworkPerformance.Enum;
using GeeksCloudLibrary.Resource.Specs.Processor;
using GeeksCloudLibrary.Resource.Specs.Storage;

namespace GeeksCloudLibrary.Shared.Model
{
    /// <summary>
    /// Update resource Model.
    /// </summary>
    public class UpdateResourceModel
    {
        public InstanceType InstanceType { get; set; }
        public string Tag { get; set; }
        public Performance NetworkPerformance { get; set; }
        public Storage Storage { get; set; }
        public Processor Processor { get; set; }
        public Memory Memory { get; set; }
    }
}
