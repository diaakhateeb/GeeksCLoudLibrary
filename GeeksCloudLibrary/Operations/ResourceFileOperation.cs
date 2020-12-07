using System;
using System.IO;
using GeeksCloudLibrary.Operations.Interfaces;
using GeeksCloudLibrary.Shared.Model;
using Newtonsoft.Json.Linq;
using System.Linq;
using Newtonsoft.Json;
using Serilog;

namespace GeeksCloudLibrary.Operations
{
    public class ResourceFileOperation : IResourceFileOperation
    {
        private JObject _deserializedJsonContent;
        private UpdateResourceModel _updateResourceModel;
        private JToken resourceFileToken;
        private readonly ILogger _logger;

        public ResourceFileOperation(ILogger logger)
        {
	        _logger = logger;
        }

        public JObject UpdateResourceFile(JObject deserializedJsonContent, UpdateResourceModel updateResourceModel)
        {
	        try
	        {
		        _logger.Information($"Begin of {nameof(UpdateResourceFile)} method.");

                _deserializedJsonContent = deserializedJsonContent;
		        _updateResourceModel = updateResourceModel;
		        resourceFileToken = _deserializedJsonContent.Property("ResourceFile").First()
			        .Last().Children().FirstOrDefault();

		        UpdateInstanceType();
		        UpdateStorage();
		        UpdateProcessor();
		        UpdateMemory();
		        UpdateNetwork();
		        UpdateTag();
                
		        _logger.Information($"End of {nameof(UpdateResourceFile)} method.");

                return _deserializedJsonContent;
	        }
	        catch (ArgumentNullException argumentNullExp)
	        {
		        _logger.Error(argumentNullExp,
			        $"One or more argument is null. {GetType().Name}.{nameof(UpdateResourceFile)}");
		        throw;
	        }
	        catch (ArgumentException argumentExp)
	        {
		        _logger.Error(argumentExp,
			        $"Arguments error. {GetType().Name}.{nameof(UpdateResourceFile)}");
		        throw;
	        }
	        catch (DirectoryNotFoundException directoryNotFoundExp)
	        {
		        _logger.Error(directoryNotFoundExp,
			        $"Infrastructure resource directory is not existed. {GetType().Name}.{nameof(UpdateResourceFile)}");
		        throw;
	        }
	        catch (IOException ioExp)
	        {
		        _logger.Error(ioExp,
			        $"Can not access infrastructure resource config file. { GetType().Name}.{ nameof(UpdateResourceFile)}");
		        throw;
	        }
	        catch (Exception exp)
	        {
		        _logger.Error(exp,
			        $"Error finding infrastructure resource config file. { GetType().Name}.{ nameof(UpdateResourceFile)}");
		        throw;
	        }
        }

        private void UpdateInstanceType()
        {
            if (!string.IsNullOrEmpty(_updateResourceModel.InstanceType.ToString().Trim()))
            {
                resourceFileToken.SelectToken("InstanceType").Replace(_updateResourceModel.InstanceType.ToString().Trim());
            }
        }

        private void UpdateStorage()
        {
            if (_updateResourceModel.Storage == null) return;

            var storage = resourceFileToken.SelectToken("Storage");

            if (storage.SelectToken("Size") != null)
            {
                storage.SelectToken("Size").Replace(_updateResourceModel.Storage.Size);
            }

            if (storage.SelectToken("SpaceSizeUnit") != null)
            {
                storage.SelectToken("SpaceSizeUnit")
                    .Replace(_updateResourceModel.Storage.SpaceSizeUnit.ToString().Trim());
            }

            if (storage.SelectToken("VolumeType") != null)
            {
                storage.SelectToken("VolumeType")
                    .Replace(_updateResourceModel.Storage.VolumeType.ToString().Trim());
            }
        }

        private void UpdateProcessor()
        {
            if (_updateResourceModel.Processor == null) return;

            var processor = resourceFileToken.SelectToken("Processor");

            if (processor.SelectToken("Speed") != null)
            {
                processor.SelectToken("Speed").Replace(_updateResourceModel.Processor.Speed);
            }

            if (processor.SelectToken("Cores") != null)
            {
                processor.SelectToken("Cores").Replace(_updateResourceModel.Processor.Cores);
            }
        }

        private void UpdateMemory()
        {
            if (_updateResourceModel.Memory == null) return;

            var memory = resourceFileToken.SelectToken("Memory");

            if (memory.SelectToken("Size") != null)
            {
                memory.SelectToken("Size").Replace(_updateResourceModel.Memory.Size);
            }

            if (memory.SelectToken("SpaceSizeUnit") != null)
            {
                memory.SelectToken("SpaceSizeUnit")
                    .Replace(_updateResourceModel.Memory.SpaceSizeUnit.ToString().Trim());
            }
        }

        private void UpdateNetwork()
        {
            if (!string.IsNullOrEmpty(_updateResourceModel.NetworkPerformance.ToString().Trim()))
            {
                resourceFileToken.SelectToken("NetworkPerformance").
                    Replace(_updateResourceModel.NetworkPerformance.ToString().Trim());
            }
        }

        private void UpdateTag()
        {
            if (!string.IsNullOrEmpty(_updateResourceModel.Tag.Trim()))
            {
                resourceFileToken.SelectToken("Tag").Replace(_updateResourceModel.Tag.Trim());
            }
        }
    }
}