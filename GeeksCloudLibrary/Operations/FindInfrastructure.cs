using GeeksCloudLibrary.Operations.Interfaces;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GeeksCloudLibrary.Operations
{
    public class FindInfrastructure : IFindInfrastructure
    {
        public async Task<string> FindInfrastructurePathAsync(string infraName)
        {
            return await Task.Run(() =>
            {
                return Directory.GetDirectories("C:\\GeeksCloudService",
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
