using GeeksCloudLibrary.Operations.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace GeeksCloudLibrary.Operations
{
    public class CloudServiceOperation : ICloudServiceOperation
    {
        private readonly IFindInfrastructure _findInfrastructure;

        public CloudServiceOperation(IFindInfrastructure findInfrastructure)
        {
            _findInfrastructure = findInfrastructure;
        }

        public async Task DeleteAsync(string infraName)
        {
            await Task.Run (async () =>
             {
                 var infraFullPath = await _findInfrastructure.FindInfrastructurePathAsync (infraName);

                 Parallel.ForEach (Directory.GetDirectories (infraFullPath), directory =>
                 {
                     Directory.Delete (directory, true);
                 });
             });
        }
    }
}