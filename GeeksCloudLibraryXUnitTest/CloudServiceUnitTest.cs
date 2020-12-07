using System;
using System.IO;
using GeeksCloudLibrary.Operations;
using GeeksCloudLibrary.Operations.Interfaces;
using Serilog;
using System.Threading.Tasks;
using GeeksCloudLibrary.Providers;
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

			cloudServiceOperation = new CloudServiceOperation(new Provider{Name = "IGS"},
				new FindInfrastructure(Log.Logger, @"C:\\GeeksCloudService"),
				Log.Logger);
		}

		[Fact]
		public async Task Delete_Infrastructure()
		{
			Log.Logger = new LoggerConfiguration().
				WriteTo.
				File(@"C:\GeeksCloudService\UnitTests-logs_.log", rollingInterval: RollingInterval.Day).
				CreateLogger();

			Log.Logger.Information($"Begin of Delete_Infrastructure()");

			await cloudServiceOperation.DeleteAsync("Test");

			Log.Logger.Information($"End of Delete_Infrastructure()");
		}
	}
}