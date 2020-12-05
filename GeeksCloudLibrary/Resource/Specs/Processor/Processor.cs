using GeeksCloudLibrary.Resource.Specs.Processor.Interfaces;

namespace GeeksCloudLibrary.Resource.Specs.Processor
{
    public class Processor : IProcessor
    {
        public float Speed { get; set; }
        public int Cores { get; set; }
    }
}
