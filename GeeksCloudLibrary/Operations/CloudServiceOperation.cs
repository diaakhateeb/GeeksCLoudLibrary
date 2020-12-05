using GeeksCloudLibrary.Operations.Interfaces;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GeeksCloudLibrary.Operations
{
    public class CloudServiceOperation<T> : ICouldServiceOperation<T>
    {
        private readonly ICloudService<T> _cloudService;

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
                var jsonPath = Path.Combine (@"c:\",
                    _cloudService.Provider.Name,
                    _cloudService.Infrastructure.Name,
                    _cloudService.ResourceInstance.Name);
                Directory.CreateDirectory (jsonPath);
                File.WriteAllText (jsonPath + @"\" + _cloudService.ResourceFile.Name, config2);

                return _cloudService;
            });
        }

        public Task<ICloudService<T>> UpdateAsync(ICloudService<T> updatedCloudService)
        {
            throw new NotImplementedException ();
        }

        public Task<bool> DeleteAsync(string infraName)
        {
            throw new NotImplementedException ();
        }

        public Task<ICloudService<T>> LoadAsync(string infraName)
        {
            throw new NotImplementedException ();
        }
    }
}
