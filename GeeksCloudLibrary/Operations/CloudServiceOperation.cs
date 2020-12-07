using GeeksCloudLibrary.Operations.Interfaces;
using Serilog;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GeeksCloudLibrary.Operations
{
    public class CloudServiceOperation : ICloudServiceOperation
    {
        private readonly IFindInfrastructure _findInfrastructure;
        private readonly ILogger _logger;

        public CloudServiceOperation(IFindInfrastructure findInfrastructure, ILogger logger)
        {
            _findInfrastructure = findInfrastructure;
            _logger = logger;
        }

        public async Task DeleteAsync(string infraName)
        {
            try
            {
                await Task.Run(async () =>
                {
                    _logger.Information($"Deleting infrastructure: {infraName} - {GetType().Name}.{nameof(DeleteAsync)}");

                    var infraFullPath = await _findInfrastructure.FindInfrastructurePathAsync(infraName);

                    Parallel.ForEach(Directory.GetDirectories(infraFullPath),
                        directory => { Directory.Delete(directory, true); });

                    _logger.Information($"Done deleting infrastructure: {infraName} - {GetType().Name}.{nameof(DeleteAsync)}");
                });
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