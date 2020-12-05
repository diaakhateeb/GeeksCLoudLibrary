using GeeksCloudLibrary.Operations.Interfaces;
using GeeksCloudLibrary.Providers.Interfaces;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GeeksCloudLibrary.Operations
{
    public class CloudServiceOperation<T> : ICouldServiceOperation<T>
    {
        private readonly ICloudService<T> _cloudService;
        private readonly IProvider _provider;

        public CloudServiceOperation(IProvider provider)
        {
            _provider = provider;
        }

        public CloudServiceOperation(ICloudService<T> cloudService)
        {
            _cloudService = cloudService;
        }

        public async Task<ICloudService<T>> InitializeAsync()
        {
            var config = new
            {
                _cloudService.Provider,
                _cloudService.Infrastructure,
                _cloudService.ResourceInstance,
                _cloudService.ResourceFile
            };

            return await Task.Run (() =>
            {
                var config2 = JsonConvert.SerializeObject (config);
                var jsonPath = Path.Combine (_cloudService.Provider.Device,
                    _cloudService.Provider.Name,
                    _cloudService.Infrastructure.Name,
                    _cloudService.ResourceInstance.Name);
                Directory.CreateDirectory (jsonPath);
                File.WriteAllText (Path.Combine (jsonPath, _cloudService.ResourceFile.Name), config2);

                return _cloudService;
            });
        }

        public Task<ICloudService<T>> UpdateAsync(ICloudService<T> updatedCloudService)
        {
            throw new NotImplementedException ();
        }

        public Task<bool> DeleteAsync(string infraName)
        {
            var infraPath2 = Path.Combine (_provider.Device,
                _provider.Name,
                infraName);

            Parallel.ForEach (Directory.GetDirectories (infraPath2), d =>
              {
                  Directory.Delete (d, true);
              });

            return Task.Run (() => true);
        }

        public async Task<ICloudService<T>> LoadAsync(string infraName)
        {
            return await Task.Run(() => new CloudService<T>());

        }

        public string FindInfrastructure(string infraName)
        {
            return "";
        }
    }
}
