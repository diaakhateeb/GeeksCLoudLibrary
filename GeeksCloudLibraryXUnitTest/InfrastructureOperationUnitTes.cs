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
using Xunit;

namespace GeeksCloudLibraryXUnitTest
{
    public class InfrastructureOperationUnitTes
    {
        private readonly IInfrastructureOperation infrastructureOperation;

        public InfrastructureOperationUnitTes()
        {
            infrastructureOperation = new InfrastructureOperation(
                new FindInfrastructure(@"C:\\GeeksCloudService"));
        }

        [Fact]
        public async void Initialize_VirtualMachine_Infrastructure_Same_Provider_Ok()
        {
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
                        Architecture = OperatingSystemArchitecture.SixtyFour
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

            var infrastructureOperation1 = new InfrastructureOperation(
                new FindInfrastructure(@"C:\\GeeksCloudService"));

            await infrastructureOperation1.InitializeAsync(cloudServiceVm);
        }

        [Fact]
        public async void Initialize_Database_Server_Infrastructure_Same_Provider_Ok()
        {
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
                    Storage = new Storage { Size = 100, SpaceSizeUnit = SizeUnit.GiB, VolumeType = VolumeType.Extension },
                    Vendor = "Microsoft",
                    Version = 2016
                }
            };

            var infrastructureOperation2 = new InfrastructureOperation(
                new FindInfrastructure(@"C:\\GeeksCloudService"));

            await infrastructureOperation2.InitializeAsync(cloudServiceDb);
        }

        [Fact]
        public async void Initialize_Two_Infrastructures_Same_Provider_Ok()
        {
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
                        Architecture = OperatingSystemArchitecture.SixtyFour
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

            var infrastructureOperation1 = new InfrastructureOperation(
                new FindInfrastructure(@"C:\\GeeksCloudService"));

            infrastructuresList.Add(infrastructureOperation1.InitializeAsync(cloudServiceVm));
            #endregion

            #region cloudServiceDbServer
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
                    Storage = new Storage { Size = 100, SpaceSizeUnit = SizeUnit.GiB, VolumeType = VolumeType.Extension },
                    Vendor = "Microsoft",
                    Version = 2016
                }
            };

            var infrastructureOperation2 = new InfrastructureOperation(
                new FindInfrastructure(@"C:\\GeeksCloudService"));

            infrastructuresList.Add(infrastructureOperation2.InitializeAsync(cloudServiceDbServer));
            #endregion

            await Task.WhenAll(infrastructuresList);
        }

        [Fact]
        public async void Initialize_Two_Infrastructures_Different_Providers_Ok()
        {
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
                        Architecture = OperatingSystemArchitecture.SixtyFour
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

            var infrastructureOperation1 = new InfrastructureOperation(
                new FindInfrastructure(@"C:\\GeeksCloudService"));

            infrastructuresList.Add(infrastructureOperation1.InitializeAsync(cloudServiceVm));
            #endregion

            #region cloudServiceDbServer
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
                    Storage = new Storage { Size = 100, SpaceSizeUnit = SizeUnit.GiB, VolumeType = VolumeType.Extension },
                    Vendor = "Microsoft",
                    Version = 2016
                }
            };

            var infrastructureOperation2 = new InfrastructureOperation(
                new FindInfrastructure(@"C:\\GeeksCloudService"));

            infrastructuresList.Add(infrastructureOperation2.InitializeAsync(cloudServiceDbServer));
            #endregion

            await Task.WhenAll(infrastructuresList);
        }

        [Fact]
        public async Task Load_Infrastructure_Ok()
        {
            var infrastructureContent = await infrastructureOperation.LoadAsync("UAT");
            await File.WriteAllTextAsync("C:\\uat.json", infrastructureContent.ToString());
        }

        [Fact]
        public async Task Update_Infrastructure_Ok()
        {
            var updateModel = new UpdateResourceModel
            {
                InstanceType = InstanceType.XLarge,
                Memory = new Memory { Size = 100, SpaceSizeUnit = SizeUnit.GiB },
                NetworkPerformance = Performance.High,
                Processor = new Processor { Cores = 64, Speed = 300 },
                Storage = new Storage { Size = 800, VolumeType = VolumeType.Extension },
                Tag = "New Dev Machine 2"
            };

            await infrastructureOperation.UpdateAsync("UAT", updateModel);
        }
    }
}