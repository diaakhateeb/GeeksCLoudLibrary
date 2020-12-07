using GeeksCloudLibrary.Operations.Interfaces;
using Serilog;
using System;
using System.IO;
using System.Threading.Tasks;
using GeeksCloudLibrary.Providers.Interfaces;
using System.Linq;

namespace GeeksCloudLibrary.Operations
{
	public class CloudServiceOperation : ICloudServiceOperation
	{
		private readonly IFindInfrastructure _findInfrastructure;
		private readonly ILogger _logger;
		private readonly IProvider _provider;

		public CloudServiceOperation(IProvider provider, IFindInfrastructure findInfrastructure, ILogger logger)
		{
			_provider = provider;
			_findInfrastructure = findInfrastructure;
			_logger = logger;
		}

		public async Task DeleteAsync(string infraName)
		{
			try
			{
				_logger.Information($"Deleting infrastructure: {infraName} - {GetType().Name}.{nameof(DeleteAsync)}");

				if (_provider == null || string.IsNullOrEmpty(_provider.Name))
				{
					throw new ArgumentNullException("Provider object is null.");
				}
				
				if (string.IsNullOrEmpty(infraName))
				{
					throw new ArgumentNullException("InfraName parameter has no value.");
				}

				var infraFullPaths = await _findInfrastructure.FindInfrastructurePathsAsync(infraName);
				var infraFullPath = infraFullPaths.FirstOrDefault(x => x.Contains(_provider.Name) && x.Contains(infraName));
				
				Parallel.ForEach(Directory.GetDirectories(infraFullPath),
					directory =>
					{
						Directory.Delete(directory, true);
					});

				_logger.Information($"Done deleting infrastructure: {infraName} - {GetType().Name}.{nameof(DeleteAsync)}");
			}
			catch (DirectoryNotFoundException directoryNotFoundExp)
			{
				_logger.Error(directoryNotFoundExp, $"Infrastructure resource is not existed. { GetType().Name}.{ nameof(DeleteAsync)}");
				throw;
			}
			catch (IOException ioExp)
			{
				_logger.Error(ioExp, $"Can not access infrastructure resource to delete. { GetType().Name}.{ nameof(DeleteAsync)}");
				throw;
			}
			catch (Exception exp)
			{
				_logger.Error(exp, $"Error deleting infrastructure. { GetType().Name}.{ nameof(DeleteAsync)}");
				throw;
			}
		}
	}
}