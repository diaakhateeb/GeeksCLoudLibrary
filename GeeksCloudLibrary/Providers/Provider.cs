using GeeksCloudLibrary.Providers.Interfaces;

namespace GeeksCloudLibrary.Providers
{
    public class Provider : IProvider
    {
        public string Name { get; set; }
        public string Device { get; set; }
    }
}
