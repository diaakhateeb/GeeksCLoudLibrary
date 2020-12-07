using System;
using System.IO;
using GeeksCloudLibrary.Operations;
using GeeksCloudLibrary.Operations.Interfaces;
using Serilog;
using System.Threading.Tasks;
using Xunit;

namespace GeeksCloudLibraryXUnitTest
{
    public class CloudServiceUnitTest
    {
        private readonly ICloudServiceOperation cloudServiceOperation;
        
        public CloudServiceUnitTest()
        {
            Log.Logger = new LoggerConfiguration().
	            WriteTo.
	            File(@"C:\GeeksCloudService\CloudService_.log", rollingInterval: RollingInterval.Day).
	            CreateLogger();

            cloudServiceOperation = new CloudServiceOperation(
                new FindInfrastructure(Log.Logger, @"C:\\GeeksCloudService"),
                Log.Logger);
        }

        [Fact]
        public async Task Delete_Infrastructure_Ok()
        {
	        Log.Logger = new LoggerConfiguration().
		        WriteTo.
		        File(@"C:\GeeksCloudService\UnitTests-logs_.log", rollingInterval: RollingInterval.Day).
		        CreateLogger();

            try
	        {
		        await cloudServiceOperation.DeleteAsync("Test");
	        }
	        catch (DirectoryNotFoundException directoryNotFoundExp)
	        {
		        Log.Logger.Error(directoryNotFoundExp, "Directory is not found to delete.");
		        throw;
	        }
	        catch (Exception exp)
	        {
		        Log.Logger.Error(exp, "Error in deleting infrastructure.");
                throw;
	        }
        }
    }
}