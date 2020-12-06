using GeeksCloudLibrary.Operations.Interfaces;
using GeeksCloudLibrary.Shared.Interfaces;
using GeeksCloudLibrary.Shared.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GeeksCloudLibrary.Operations
{
    public class CloudServiceOperation<T> : ICouldServiceOperation<T> where T : IResource
    {
        private readonly ICloudService<T> _cloudService;

        public CloudServiceOperation()
        {

        }

        public CloudServiceOperation(ICloudService<T> cloudService)
        {
            _cloudService = cloudService;
        }

        public async Task<ICloudService<T>> InitializeAsync()
        {
            return await Task.Run (async () =>
            {
                await SaveResourceConfigurationsToDisk (_cloudService);

                return _cloudService;
            });
        }

        public async Task UpdateAsync(string infraName, UpdateResourceModel model)
        {
            var infraFullPath = FindInfrastructure (infraName);
            var resourceFilePath = Directory.GetFiles (infraFullPath,
                "*.*", SearchOption.AllDirectories).FirstOrDefault ();
            var jsonContent = await File.ReadAllTextAsync (resourceFilePath);
            var deserializeJsonContent = (JObject)JsonConvert.DeserializeObject (jsonContent);

            var resourceFileToken = deserializeJsonContent?.Property ("ResourceFile").First ().
                Last ().Children ().FirstOrDefault ();

            if (resourceFileToken != null)
            {
                if (!string.IsNullOrEmpty (model.InstanceType.ToString ().Trim()))
                {
                    resourceFileToken.SelectToken ("InstanceType").Replace (model.InstanceType.ToString ().Trim());
                }

                if (model.Storage != null)
                {
                    var storage = resourceFileToken.SelectToken ("Storage");

                    if (storage.SelectToken ("Size") != null)
                    {
                        storage.SelectToken ("Size").Replace (model.Storage.Size);
                    }
                    if (storage.SelectToken ("SpaceSizeUnit") != null)
                    {
                        storage.SelectToken ("SpaceSizeUnit").Replace (model.Storage.SpaceSizeUnit.ToString().Trim());
                    }
                    if (storage.SelectToken ("VolumeType") != null)
                    {
                        storage.SelectToken ("VolumeType").Replace (model.Storage.VolumeType.ToString ().Trim());
                    }
                }

                if (model.Processor != null)
                {
                    var processor = resourceFileToken.SelectToken ("Processor");

                    if (processor.SelectToken ("Speed") != null)
                    {
                        processor.SelectToken ("Speed").Replace (model.Processor.Speed);
                    }
                    if (processor.SelectToken ("Cores") != null)
                    {
                        processor.SelectToken ("Cores").Replace (model.Processor.Cores);
                    }
                }

                if (model.Memory != null)
                {
                    var memory = resourceFileToken.SelectToken ("Memory");

                    if (memory.SelectToken ("Size") != null)
                    {
                        memory.SelectToken ("Size").Replace (model.Memory.Size);
                    }
                    if (memory.SelectToken ("SpaceSizeUnit") != null)
                    {
                        memory.SelectToken ("SpaceSizeUnit").Replace (model.Memory.SpaceSizeUnit.ToString().Trim());
                    }
                }

                if (!string.IsNullOrEmpty (model.NetworkPerformance.ToString().Trim()))
                {
                    resourceFileToken.SelectToken ("NetworkPerformance").Replace (model.NetworkPerformance.ToString().Trim());
                }

                if (!string.IsNullOrEmpty (model.Tag.Trim()))
                {
                    resourceFileToken.SelectToken ("Tag").Replace (model.Tag.Trim());
                }
            }

            await File.WriteAllTextAsync (resourceFilePath, deserializeJsonContent.ToString ());
        }

        public async Task DeleteAsync(string infraName)
        {
            await Task.Run (() =>
             {
                 var infraFullPath = FindInfrastructure (infraName);

                 Parallel.ForEach (Directory.GetDirectories (infraFullPath), directory =>
                 {
                     Directory.Delete (directory, true);
                 });
             });
        }

        public async Task<ICloudService<T>> LoadAsync(string infraName)
        {
            return await Task.Run (async () =>
            {
                var infraFolderPath = FindInfrastructure (infraName);

                var resourceFilePath = Directory.GetFiles (infraFolderPath,
                    "*.*", SearchOption.AllDirectories).FirstOrDefault ();

                var jsonContent = await File.ReadAllTextAsync (resourceFilePath);

                return JsonConvert.DeserializeObject<ICloudService<T>> (jsonContent,
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Objects
                    }
                );
            });
        }

        public string FindInfrastructure(string infraName)
        {
            var infrastructurePath = Directory.GetDirectories ("C:\\GeeksCloudService",
                "*.*", SearchOption.AllDirectories).
                FirstOrDefault (x => x.Contains (infraName));

            if (infrastructurePath != null)
            {
                return infrastructurePath;
            }

            //if (_provider != null)
            //{
            //    return Path.Combine (_provider.Device, _provider.Name, infraName);
            //}

            throw new NullReferenceException ("Provider object is null.");
        }

        async Task SaveResourceConfigurationsToDisk(ICloudService<T> cloudService)
        {
            var instanceConfig = JsonConvert.SerializeObject (cloudService, Formatting.Indented,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple

                }
            );
            var jsonFilePath = Path.Combine (_cloudService.Provider.Device,
                _cloudService.Provider.Name,
                _cloudService.Infrastructure.Name,
                _cloudService.ResourceInstance.Name);
            Directory.CreateDirectory (jsonFilePath);
            await File.WriteAllTextAsync (Path.Combine (jsonFilePath, _cloudService.ResourceFile.Name),
                instanceConfig);



        }
    }
}
