using System;
using GeeksCloudLibrary.Infrastructure;
using GeeksCloudLibrary.Operations;
using GeeksCloudLibrary.Operations.Interfaces;
using GeeksCloudLibrary.Providers;
using GeeksCloudLibrary.Resource.DatabaseServer;
using GeeksCloudLibrary.Resource.DatabaseServer.Interfaces;
using GeeksCloudLibrary.Resource.Specs.MachineInstanceType.Enum;
using GeeksCloudLibrary.Resource.Specs.Memory;
using GeeksCloudLibrary.Resource.Specs.NetworkPerformance.Enum;
using GeeksCloudLibrary.Resource.Specs.Processor;
using GeeksCloudLibrary.Resource.Specs.SpaceSizeUnit.Enum;
using GeeksCloudLibrary.Resource.Specs.Storage;
using GeeksCloudLibrary.Resource.Specs.Storage.Enum;
using GeeksCloudLibrary.Resource.VirtualMachine;
using GeeksCloudLibrary.Resource.VirtualMachine.Interfaces;
using GeeksCloudLibrary.Resource.VirtualMachine.OperatingSystem;
using GeeksCloudLibrary.Resource.VirtualMachine.OperatingSystem.Enum;
using GeeksCloudLibrary.ResourceFile;
using GeeksCloudLibrary.ResourceInstance;
using GeeksCloudLibrary.Shared.Model;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Serilog;
using Xunit;

namespace GeeksCloudLibraryXUnitTest
{
	public class InfrastructureOperationUnitTests
	{
		private readonly IInfrastructureOperation infrastructureOperation;

		public InfrastructureOperationUnitTests()
		{
			Log.Logger = new LoggerConfiguration().
				WriteTo.
				File(@"C:\GeeksCloudService\CloudService_.log", rollingInterval: RollingInterval.Day).
				CreateLogger();
			infrastructureOperation = new InfrastructureOperation(
				new FindInfrastructure(Log.Logger, @"C:\\GeeksCloudService"),
				Log.Logger);
		}

		[Fact]
		public async void Initialize_VirtualMachine_Infrastructure()
		{
			Log.Logger.Information($"Begin of Initialize_VirtualMachine_Infrastructure()." +
			                       $"{Environment.NewLine}Construct CloudService VM.");
			//Arrange
			var cloudServiceVm = new CloudService<IVirtualMachine>
			{
				Provider = new Provider { Name = "IGS" },
				Infrastructure = new Infrastructure { Name = "UAT" },
				ResourceInstance = new ResourceInstance { Name = "Windows-Dev-VM" }
			};

			Log.Logger.Information($"Set ResourceFile property of CloudService VM.");
			cloudServiceVm.ResourceFile = new ResourceFile<IVirtualMachine>
			{
				Name = cloudServiceVm.Infrastructure.Name + "_SERVER.json",
				Content = new VirtualMachine
				{
					Name = "Windows Server 2016 R2 Dev. Virtual Machine",
					OperatingSystem = new WindowsOperatingSystem
					{
						Name = "Windows Server 2016 R2",
						Version = 10,
						Vendor = "Microsoft",
						Architecture = OperatingSystemArchitecture.SixtyFour,
						Applications = new List<string> { "MS Office", "Visual Studio", "Firefox", "IIS" }
					},
					Storage = new Storage
					{
						Size = 100,
						SpaceSizeUnit = SizeUnit.GiB,
						VolumeType = VolumeType.Root
					},
					Processor = new Processor
					{
						Cores = 8,
						Speed = 260
					},
					Memory = new Memory
					{
						Size = 32,
						SpaceSizeUnit = SizeUnit.GiB
					},
					NetworkPerformance = Performance.High,
					InstanceType = InstanceType.Large,
					Tag = "Dev VM"
				}
			};

			var infrastructureOperationVm = new InfrastructureOperation(
				new FindInfrastructure(Log.Logger, @"C:\\GeeksCloudService"), Log.Logger);

			Log.Logger.Information($"Begin of InitializeAsync method() of unit testing.");

			//Act
			await infrastructureOperationVm.InitializeAsync(cloudServiceVm);

			Log.Logger.Information($"End of InitializeAsync method() of unit testing.");
		}

		[Fact]
		public async void Initialize_Database_Server_Infrastructure()
		{
			Log.Logger.Information($"Begin of Initialize_Database_Server_Infrastructure()." +
			                       $"{Environment.NewLine}Construct CloudService DB server.");

			var cloudServiceDb = new CloudService<IDatabaseServer>
			{
				Provider = new Provider { Name = "IGS" },
				Infrastructure = new Infrastructure { Name = "Test" },
				ResourceInstance = new ResourceInstance { Name = "SQL Server Test" }
			};

			cloudServiceDb.ResourceFile = new ResourceFile<IDatabaseServer>
			{
				Name = cloudServiceDb.Infrastructure.Name + "_SERVER.json",
				Content = new MsSqlServer
				{
					Name = "MS SQL Server for Pre-Production Testing",
					InstanceType = InstanceType.Large,
					Memory = new Memory { Size = 64, SpaceSizeUnit = SizeUnit.GiB },
					NetworkPerformance = Performance.High,
					Storage = new Storage
					{ Size = 100, SpaceSizeUnit = SizeUnit.GiB, VolumeType = VolumeType.Extension },
					Vendor = "Microsoft",
					Version = 2016
				}
			};

			var infrastructureOperationSqlServer = new InfrastructureOperation(
				new FindInfrastructure(Log.Logger, @"C:\\GeeksCloudService"), Log.Logger);

			Log.Logger.Information($"Begin of InitializeAsync method() of unit testing.");

			await infrastructureOperationSqlServer.InitializeAsync(cloudServiceDb);

			Log.Logger.Information($"End of InitializeAsync method() of unit testing.");
		}

		[Fact]
		public async void Initialize_Two_Infrastructures_Same_Provider()
		{

			Log.Logger.Information($"Begin of Initialize_Two_Infrastructures_Same_Provider()." +
			                       $"{Environment.NewLine}Construct CloudService VM.");

			var infrastructuresList = new List<Task>();

			#region cloudServiceVm

			var cloudServiceVm = new CloudService<IVirtualMachine>
			{
				Provider = new Provider { Name = "IGS" },
				Infrastructure = new Infrastructure { Name = "UAT" },
				ResourceInstance = new ResourceInstance { Name = "Windows-Dev-VM" }
			};

			cloudServiceVm.ResourceFile = new ResourceFile<IVirtualMachine>
			{
				Name = cloudServiceVm.Infrastructure.Name + "_SERVER.json",
				Content = new VirtualMachine
				{
					Name = "Windows Server 2016 R2 Dev. Virtual Machine",
					OperatingSystem = new WindowsOperatingSystem
					{
						Name = "Windows Server 2016 R2",
						Version = 10,
						Vendor = "Microsoft",
						Architecture = OperatingSystemArchitecture.SixtyFour,
						Applications = new List<string> { "MS Office", "Visual Studio", "Firefox", "IIS" }
					},
					Storage = new Storage
					{
						Size = 100,
						SpaceSizeUnit = SizeUnit.GiB,
						VolumeType = VolumeType.Root
					},
					Processor = new Processor
					{
						Cores = 8,
						Speed = 260
					},
					Memory = new Memory
					{
						Size = 32,
						SpaceSizeUnit = SizeUnit.GiB
					},
					NetworkPerformance = Performance.High,
					InstanceType = InstanceType.Large,
					Tag = "Dev VM"
				}
			};

			var infrastructureOperationVM = new InfrastructureOperation(
				new FindInfrastructure(Log.Logger, @"C:\\GeeksCloudService"), Log.Logger);

			Log.Logger.Information($"Begin of InitializeAsync method() of unit testing.");

			infrastructuresList.Add(infrastructureOperationVM.InitializeAsync(cloudServiceVm));

			Log.Logger.Information($"End of InitializeAsync method() of unit testing.");

			#endregion

			#region cloudServiceDbServer

			Log.Logger.Information($"Construct CloudService Sql Server.");
			var cloudServiceDbServer = new CloudService<IDatabaseServer>
			{
				Provider = new Provider { Name = "IGS" },
				Infrastructure = new Infrastructure { Name = "Test" },
				ResourceInstance = new ResourceInstance { Name = "SQL Server Test" }
			};

			cloudServiceDbServer.ResourceFile = new ResourceFile<IDatabaseServer>
			{
				Name = cloudServiceDbServer.Infrastructure.Name + "_SERVER.json",
				Content = new MsSqlServer
				{
					Name = "MS SQL Server for Pre-Production Testing",
					InstanceType = InstanceType.Large,
					Memory = new Memory { Size = 64, SpaceSizeUnit = SizeUnit.GiB },
					NetworkPerformance = Performance.High,
					Storage = new Storage
					{ Size = 100, SpaceSizeUnit = SizeUnit.GiB, VolumeType = VolumeType.Extension },
					Vendor = "Microsoft",
					Version = 2016
				}
			};

			var infrastructureOperationSqlServer = new InfrastructureOperation(
				new FindInfrastructure(Log.Logger, @"C:\\GeeksCloudService"), Log.Logger);

			Log.Logger.Information($"Begin of InitializeAsync method() of unit testing.");

			infrastructuresList.Add(infrastructureOperationSqlServer.InitializeAsync(cloudServiceDbServer));

			Log.Logger.Information($"End of InitializeAsync method() of unit testing.");

			#endregion

			await Task.WhenAll(infrastructuresList);

		}

		[Fact]
		public async void Initialize_Two_Infrastructures_Different_Providers()
		{
			Log.Logger.Information($"Begin of Initialize_Two_Infrastructures_Different_Providers()." +
			                       $"{Environment.NewLine}Construct CloudService VM.");

			var infrastructuresList = new List<Task>();

			#region cloudServiceVm

			var cloudServiceVm = new CloudService<IVirtualMachine>
			{
				Provider = new Provider { Name = "IGS" },
				Infrastructure = new Infrastructure { Name = "UAT" },
				ResourceInstance = new ResourceInstance { Name = "Windows-Dev-VM" }
			};

			cloudServiceVm.ResourceFile = new ResourceFile<IVirtualMachine>
			{
				Name = cloudServiceVm.Infrastructure.Name + "_SERVER.json",
				Content = new VirtualMachine
				{
					Name = "Windows Server 2016 R2 Dev. Virtual Machine",
					OperatingSystem = new WindowsOperatingSystem
					{
						Name = "Windows Server 2016 R2",
						Version = 10,
						Vendor = "Microsoft",
						Architecture = OperatingSystemArchitecture.SixtyFour,
						Applications = new List<string> { "MS Office", "Visual Studio", "Firefox", "IIS" }
					},
					Storage = new Storage
					{
						Size = 100,
						SpaceSizeUnit = SizeUnit.GiB,
						VolumeType = VolumeType.Root
					},
					Processor = new Processor
					{
						Cores = 8,
						Speed = 260
					},
					Memory = new Memory
					{
						Size = 32,
						SpaceSizeUnit = SizeUnit.GiB
					},
					NetworkPerformance = Performance.High,
					InstanceType = InstanceType.Large,
					Tag = "Dev VM"
				}
			};

			Log.Logger.Information($"Begin of InitializeAsync method() of unit testing.");
			var infrastructureOperationVM = new InfrastructureOperation(
				new FindInfrastructure(Log.Logger, @"C:\\GeeksCloudService"), Log.Logger);
			Log.Logger.Information($"End of InitializeAsync method() of unit testing.");

			infrastructuresList.Add(infrastructureOperationVM.InitializeAsync(cloudServiceVm));

			#endregion

			#region cloudServiceDbServer

			Log.Logger.Information($"Construct CloudService Sql Server.");
			var cloudServiceDbServer = new CloudService<IDatabaseServer>
			{
				Provider = new Provider { Name = "SAMS" },
				Infrastructure = new Infrastructure { Name = "Test" },
				ResourceInstance = new ResourceInstance { Name = "SQL Server Test" }
			};

			cloudServiceDbServer.ResourceFile = new ResourceFile<IDatabaseServer>
			{
				Name = cloudServiceDbServer.Infrastructure.Name + "_SERVER.json",
				Content = new MsSqlServer
				{
					Name = "MS SQL Server for Pre-Production Testing",
					InstanceType = InstanceType.Large,
					Memory = new Memory { Size = 64, SpaceSizeUnit = SizeUnit.GiB },
					NetworkPerformance = Performance.High,
					Storage = new Storage
					{ Size = 100, SpaceSizeUnit = SizeUnit.GiB, VolumeType = VolumeType.Extension },
					Vendor = "Microsoft",
					Version = 2016
				}
			};

			var infrastructureOperationSqlServer = new InfrastructureOperation(
				new FindInfrastructure(Log.Logger, @"C:\\GeeksCloudService"), Log.Logger);

			Log.Logger.Information($"Begin of InitializeAsync method() of unit testing.");
			infrastructuresList.Add(infrastructureOperationSqlServer.InitializeAsync(cloudServiceDbServer));
			Log.Logger.Information($"End of InitializeAsync method() of unit testing.");

			#endregion

			await Task.WhenAll(infrastructuresList);
		}

		[Fact]
		public async Task Load_Infrastructure_Ok()
		{
			Log.Logger.Information($"Begin of Load_Infrastructure_Ok()");

			var infrastructureContent = await infrastructureOperation.LoadAsync("IGS","UAT");
			await File.WriteAllTextAsync("C:\\UAT.json", infrastructureContent.ToString());

			Log.Logger.Information($"End of Load_Infrastructure_Ok()");
		}

		[Fact]
		public async Task Load_Infrastructure_Exception()
		{
			Log.Logger.Information($"Begin of Load_Infrastructure_Exception() unit test.");

			var infrastructureContent = infrastructureOperation.LoadAsync("ABC", "UAT");
			var exception = await Assert.ThrowsAnyAsync<Exception>(() => infrastructureContent);
			Log.Error(exception, "Infrastructure does not exist.");

			Log.Logger.Information($"End of Load_Infrastructure_Exception() unit test.");
		}

		[Fact]
		public async Task Update_Infrastructure()
		{
			Log.Logger.Information($"Begin of Update_Infrastructure()");

			var updateModel = new UpdateResourceModel
			{
				InstanceType = InstanceType.XLarge,
				Memory = new Memory { Size = 100, SpaceSizeUnit = SizeUnit.GiB },
				NetworkPerformance = Performance.High,
				Processor = new Processor { Cores = 64, Speed = 300 },
				Storage = new Storage { Size = 800, VolumeType = VolumeType.Extension },
				Tag = "New Dev Machine 2"
			};

			Log.Logger.Information($"Begin of UpdateAsync()");

			await infrastructureOperation.UpdateAsync("IGS","UAT", updateModel);

			Log.Logger.Information($"End of UpdateAsync()");
		}
		
		[Fact]
		public async Task Update_Infrastructure_Exception()
		{
			Log.Logger.Information($"Begin of Update_Infrastructure_Exception() unit test.");

			var updateModel = new UpdateResourceModel
			{
				InstanceType = InstanceType.XLarge,
				Memory = new Memory { Size = 100, SpaceSizeUnit = SizeUnit.GiB },
				NetworkPerformance = Performance.High,
				Processor = new Processor { Cores = 64, Speed = 300 },
				Storage = new Storage { Size = 800, VolumeType = VolumeType.Extension },
				Tag = "New Dev Machine 2"
			};

			Log.Logger.Information($"Begin of UpdateAsync()");

			var updateTask = infrastructureOperation.UpdateAsync("ABC", "UAT", updateModel);
			var exception = await Assert.ThrowsAnyAsync<Exception>(() => updateTask);
			Log.Error(exception, "Error updating infrastructure.");

			Log.Logger.Information($"End of UpdateAsync()");
		}
	}
}