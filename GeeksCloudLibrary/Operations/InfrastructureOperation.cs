using GeeksCloudLibrary.Operations.Interfaces;
using GeeksCloudLibrary.Shared.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GeeksCloudLibrary.Operations
{
    public class InfrastructureOperation : IInfrastructureOperation
    {
        private readonly IFindInfrastructure _findInfrastructure;

        public InfrastructureOperation(IFindInfrastructure findInfrastructure)
        {
            _findInfrastructure = findInfrastructure;
        }

        public async Task InitializeAsync<T>(ICloudService<T> cloudService)
        {
            await Task.Run(() =>
          {
              var instanceConfig = JsonConvert.SerializeObject(cloudService, Formatting.Indented);
              var jsonFilePath = Path.Combine(_findInfrastructure.RootDevice,
                  cloudService.Provider.Name,
                  cloudService.Infrastructure.Name,
                  cloudService.ResourceInstance.Name);

              Directory.CreateDirectory(jsonFilePath);
              File.WriteAllTextAsync(Path.Combine(jsonFilePath, cloudService.ResourceFile.Name),
                  instanceConfig);
          });
        }

        public async Task UpdateAsync(string infraName, UpdateResourceModel model)
        {
            var resourceFileOperation = new ResourceFileOperation();
            var deserializedJson = await LoadAsync(infraName);
            var newJsonContent = resourceFileOperation.UpdateResourceFile(deserializedJson, model);
            var infraJsonPath = await _findInfrastructure.FindInfrastructureJsonPathAsync(infraName);

            await File.WriteAllTextAsync(infraJsonPath, newJsonContent.ToString());
        }

        public async Task<JObject> LoadAsync(string infraName)
        {
            return await Task.Run(async () =>
            {
                var infraFullPath = await _findInfrastructure.FindInfrastructurePathAsync(infraName);
                var resourceFilePath = Directory.GetFiles(infraFullPath,
                    "*.*", SearchOption.AllDirectories).FirstOrDefault();
                var jsonContent = await File.ReadAllTextAsync(resourceFilePath);

                return (JObject)JsonConvert.DeserializeObject(jsonContent);
            });
        }
    }
}
