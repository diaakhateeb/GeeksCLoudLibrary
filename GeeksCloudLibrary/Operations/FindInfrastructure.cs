using GeeksCloudLibrary.Operations.Interfaces;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GeeksCloudLibrary.Operations
{
    public class FindInfrastructure : IFindInfrastructure
    {
        private readonly string _device;

        public FindInfrastructure(string device)
        {
            _device = device;
        }

        public async Task<string> FindInfrastructurePathAsync(string infraName)
        {
            return await Task.Run(() =>
            {
                return Directory.GetDirectories(_device,
                        "*.*", SearchOption.AllDirectories).
                    FirstOrDefault(x => x.Contains(infraName));
            });
        }

        public async Task<string> FindInfrastructureJsonPathAsync(string infraName)
        {
            var infraPath = await FindInfrastructurePathAsync(infraName);

            return Directory.GetFiles(infraPath,
                "*.*", SearchOption.AllDirectories).FirstOrDefault();
        }
    }
}
