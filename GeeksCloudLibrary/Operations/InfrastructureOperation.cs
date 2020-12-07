using System;
using GeeksCloudLibrary.Operations.Interfaces;
using GeeksCloudLibrary.Shared.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace GeeksCloudLibrary.Operations
{
    public class InfrastructureOperation : IInfrastructureOperation
    {
        private readonly IFindInfrastructure _findInfrastructure;
        private readonly ILogger _logger;

        public InfrastructureOperation(IFindInfrastructure findInfrastructure, ILogger logger)
        {
	        _findInfrastructure = findInfrastructure;
	        _logger = logger;
        }

        public async Task InitializeAsync<T>(ICloudService<T> cloudService)
        {
	        try
	        {
		        if (string.IsNullOrEmpty(await _findInfrastructure.FindInfrastructurePathAsync(cloudService.Infrastructure.Name)))
		        {
			        _logger.Error($"InitializeAsync() failed. Infrastructure with such name is already existed. {GetType().Name}.{nameof(InitializeAsync)}");
			        throw new ApplicationException("InitializeAsync() failed. Infrastructure with such name is already existed.");
		        }

				await Task.Run(async () =>
		        {
			        _logger.Information($"Begin of {nameof(InitializeAsync)} method.");

			        if (!string.IsNullOrEmpty(
				        await _findInfrastructure.FindInfrastructurePathAsync(cloudService.Infrastructure.Name)))
			        {
				        _logger.Error($"InitializeAsync() failed. Infrastructure with such name is already existed. {GetType().Name}.{nameof(InitializeAsync)}");
				        throw new ApplicationException("InitializeAsync() failed. Infrastructure with such name is already existed.");
			        }

			        var instanceConfig = JsonConvert.SerializeObject(cloudService, Formatting.Indented);
			        var jsonFilePath = Path.Combine(_findInfrastructure.RootDevice,
				        cloudService.Provider.Name,
				        cloudService.Infrastructure.Name,
				        cloudService.ResourceInstance.Name);

			        Directory.CreateDirectory(jsonFilePath);
			        await File.WriteAllTextAsync(Path.Combine(jsonFilePath, cloudService.ResourceFile.Name),
				        instanceConfig);

			        _logger.Information($"End of {nameof(InitializeAsync)} method.");
		        });
	        }
	        catch (ArgumentNullException argumentNullExp)
	        {
		        _logger.Error(argumentNullExp,
			        $"CloudService argument is null. {GetType().Name}.{nameof(InitializeAsync)}");
		        throw;
	        }
	        catch (ArgumentException argumentExp)
	        {
		        _logger.Error(argumentExp,
			        $"Error CloudService argument. {GetType().Name}.{nameof(InitializeAsync)}");
		        throw;
	        }
	        catch (JsonSerializationException jsonSerializationExp)
	        {
		        _logger.Error(jsonSerializationExp,
			        $"Error serializing cloud resource to Json. {GetType().Name}.{nameof(InitializeAsync)}");
		        throw;
	        }
	        catch (DirectoryNotFoundException directoryNotFoundExp)
	        {
		        _logger.Error(directoryNotFoundExp,
			        $"Infrastructure resource directory is not existed. {GetType().Name}.{nameof(InitializeAsync)}");
		        throw;
	        }
			catch (IOException ioExp)
	        {
		        _logger.Error(ioExp,
			        $"Can not access infrastructure resource config file. { GetType().Name}.{ nameof(InitializeAsync)}");
		        throw;
	        }
	        catch (Exception exp)
	        {
		        _logger.Error(exp,
			        $"Error finding infrastructure resource config file. { GetType().Name}.{ nameof(InitializeAsync)}");
		        throw;
	        }
		}

        public async Task UpdateAsync(string infraName, UpdateResourceModel model)
        {
	        try
	        {
		        _logger.Information($"Begin of {nameof(UpdateAsync)} method.");

				var resourceFileOperation = new ResourceFileOperation(_logger);
		        var deserializedJson = await LoadAsync(infraName);
		        var newJsonContent = resourceFileOperation.UpdateResourceFile(deserializedJson, model);
		        var infraJsonPath = await _findInfrastructure.FindInfrastructureJsonPathAsync(infraName);

		        await File.WriteAllTextAsync(infraJsonPath, newJsonContent.ToString());

		        _logger.Information($"End of {nameof(UpdateAsync)} method.");
			}
	        catch (ArgumentNullException argumentNullExp)
	        {
		        _logger.Error(argumentNullExp,
			        $"One or more argument is null. {GetType().Name}.{nameof(UpdateAsync)}");
		        throw;
	        }
	        catch (ArgumentException argumentExp)
	        {
		        _logger.Error(argumentExp,
			        $"Arguments error. {GetType().Name}.{nameof(UpdateAsync)}");
		        throw;
	        }
	        catch (JsonReaderException jsonReaderExp)
	        {
		        _logger.Error(jsonReaderExp,
			        $"Error reading Json resource config file. {GetType().Name}.{nameof(UpdateAsync)}");
		        throw;
	        }
	        catch (DirectoryNotFoundException directoryNotFoundExp)
	        {
		        _logger.Error(directoryNotFoundExp,
			        $"Infrastructure resource directory is not existed. {GetType().Name}.{nameof(UpdateAsync)}");
		        throw;
	        }
	        catch (IOException ioExp)
	        {
		        _logger.Error(ioExp,
			        $"Can not access infrastructure resource config file. { GetType().Name}.{ nameof(UpdateAsync)}");
		        throw;
	        }
	        catch (Exception exp)
	        {
		        _logger.Error(exp,
			        $"Error finding infrastructure resource config file. { GetType().Name}.{ nameof(UpdateAsync)}");
		        throw;
	        }
		}

        public async Task<JObject> LoadAsync(string infraName)
        {
	        try
	        {
		        return await Task.Run(async () =>
		        {
			        _logger.Information($"Begin of {nameof(LoadAsync)} method.");

			        var infraFullPath = await _findInfrastructure.FindInfrastructurePathAsync(infraName);
			        var resourceFilePath = Directory.GetFiles(infraFullPath,
				        "*.*", SearchOption.AllDirectories).FirstOrDefault();
			        var jsonContent = await File.ReadAllTextAsync(resourceFilePath);
			        var jsonResourceConfig = (JObject) JsonConvert.DeserializeObject(jsonContent);

			        _logger.Information($"End of {nameof(LoadAsync)} method.");

			        return jsonResourceConfig;

		        });
	        }
			catch (ArgumentNullException argumentNullExp)
	        {
		        _logger.Error(argumentNullExp,
			        $"One or more argument is null. {GetType().Name}.{nameof(LoadAsync)}");
		        throw;
	        }
	        catch (ArgumentException argumentExp)
	        {
		        _logger.Error(argumentExp,
			        $"Arguments error. {GetType().Name}.{nameof(LoadAsync)}");
		        throw;
	        }
	        catch (DirectoryNotFoundException directoryNotFoundExp)
	        {
		        _logger.Error(directoryNotFoundExp,
			        $"Infrastructure resource directory is not existed. {GetType().Name}.{nameof(LoadAsync)}");
		        throw;
	        }
	        catch (IOException ioExp)
	        {
		        _logger.Error(ioExp,
			        $"Can not access infrastructure resource config file. { GetType().Name}.{ nameof(LoadAsync)}");
		        throw;
	        }
	        catch (Exception exp)
	        {
		        _logger.Error(exp,
			        $"Error finding infrastructure resource config file. { GetType().Name}.{ nameof(LoadAsync)}");
		        throw;
	        }
		}
    }
}
