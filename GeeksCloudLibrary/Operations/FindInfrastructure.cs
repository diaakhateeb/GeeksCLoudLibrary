using System;
using GeeksCloudLibrary.Operations.Interfaces;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace GeeksCloudLibrary.Operations
{
    public class FindInfrastructure : IFindInfrastructure
    {
        private readonly ILogger _logger;
        public FindInfrastructure(ILogger logger, string rootDevice = @"C:\")
        {
	        RootDevice = rootDevice;
	        _logger = logger;
        }

        public async Task<string> FindInfrastructurePathAsync(string infraName)
        {
	        try
	        {
		        return await Task.Run(() =>
		        {
			        _logger.Information($"Begin of {nameof(FindInfrastructurePathAsync)} method.");

			        var infrastructureDirectory = Directory.GetDirectories(RootDevice,
				        "*.*", SearchOption.AllDirectories).FirstOrDefault(x => x.Contains(infraName));
			        
			        _logger.Information($"End of {nameof(FindInfrastructurePathAsync)} method.");
			        
			        return infrastructureDirectory;
		        });
	        }
			catch (DirectoryNotFoundException directoryNotFoundExp)
	        {
		        _logger.Error(directoryNotFoundExp,
					$"Infrastructure resource directory is not existed. { GetType().Name}.{ nameof(FindInfrastructurePathAsync)}");
		        throw;
	        }
	        catch (UnauthorizedAccessException unauthorizedAccessExp)
	        {
		        _logger.Error(unauthorizedAccessExp,
			        $"Unauthorized access infrastructure resource directory. { GetType().Name}.{ nameof(FindInfrastructurePathAsync)}");
		        throw;
	        }
	        catch (IOException ioExp)
	        {
		        _logger.Error(ioExp,
			        $"Can not access infrastructure resource config file. { GetType().Name}.{ nameof(FindInfrastructurePathAsync)}");
		        throw;
	        }
			catch (Exception exp)
	        {
		        _logger.Error(exp,
			        $"Error finding infrastructure directory. { GetType().Name}.{ nameof(FindInfrastructurePathAsync)}");
		        throw;
	        }
		}

        public async Task<string> FindInfrastructureJsonPathAsync(string infraName)
        {
	        try
	        {
		        _logger.Information($"Begin of {nameof(FindInfrastructureJsonPathAsync)} method.");

				var infraPath = await FindInfrastructurePathAsync(infraName);
				var jsonConfigFilePath = Directory.GetFiles(infraPath,
			        "*.*", SearchOption.AllDirectories).FirstOrDefault();
				
		        _logger.Information($"End of {nameof(FindInfrastructureJsonPathAsync)} method.");

				return jsonConfigFilePath;
	        }
			catch (DirectoryNotFoundException directoryNotFoundExp)
	        {
		        _logger.Error(directoryNotFoundExp,
			        $"Infrastructure resource directory is not existed. { GetType().Name}.{ nameof(FindInfrastructureJsonPathAsync)}");
		        throw;
	        }
	        catch (UnauthorizedAccessException unauthorizedAccessExp)
	        {
		        _logger.Error(unauthorizedAccessExp,
			        $"Unauthorized access to the resource config file. { GetType().Name}.{ nameof(FindInfrastructureJsonPathAsync)}");
		        throw;
	        }
			catch (IOException ioExp)
	        {
		        _logger.Error(ioExp,
			        $"Can not access infrastructure resource config file. { GetType().Name}.{ nameof(FindInfrastructureJsonPathAsync)}");
		        throw;
	        }
	        catch (Exception exp)
	        {
		        _logger.Error(exp,
			        $"Error finding infrastructure resource config file. { GetType().Name}.{ nameof(FindInfrastructureJsonPathAsync)}");
		        throw;
	        }
		}

        public string RootDevice { get; }
    }
}
