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
            infrastructureOperation = new InfrastructureOperation(new FindInfrastructure());
            //new CloudService<IVirtualMachine>
            //{
            //    Infrastructure = new Infrastructure { Name = "UT" },
            //    Provider = new Provider { Name = "Self-Provider", Device = @"C:\GeeksCloudService" },
            //    ResourceInstance = new ResourceInstance { Name = "UnitTest" },
            //    ResourceFile = new ResourceFile<IVirtualMachine>
            //    {
            //        Name = "Test VM",
            //        Content = new VirtualMachine
            //        {
            //            Name = "VM for Pre-production",
            //            InstanceType = InstanceType.Large,
            //            Memory = new Memory { Size = 128, SpaceSizeUnit = SizeUnit.GiB },
            //            NetworkPerformance = Performance.High,
            //            OperatingSystem = new LinuxOperatingSystem
            //            {
            //                Architecture = OperatingSystemArchitecture.SixtyFour,
            //                Name = "Linux Image",
            //                Vendor = "Slackware",
            //                Version = 15
            //            },
            //            Processor = new Processor
            //            {
            //                Cores = 16,
            //                Speed = 280
            //            },
            //            Storage = new Storage
            //            {
            //                Size = 500,
            //                SpaceSizeUnit = SizeUnit.GiB,
            //                VolumeType = VolumeType.Root
            //            },
            //            Tag = "Linux Image for staging"
            //        }
            //    }
            //},
            //new ResourceFileOperation());
        }

        [Fact]
        public async void Initialize_Infrastructure_Ok()
        {
            var infrastructuresList = new List<Task>();

            #region co1
            var co1 = new CloudService<IVirtualMachine>
            {
                Provider = new Provider { Name = "IGS", Device = @"C:\GeeksCloudService" },
                Infrastructure = new Infrastructure { Name = "UAT" },
                ResourceInstance = new ResourceInstance { Name = "Windows-Dev-VM" }
            };

            co1.ResourceFile = new ResourceFile<IVirtualMachine>
            {
                Name = co1.Infrastructure.Name + "_SERVER.json",
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

            var infrastructureOperation1 = new InfrastructureOperation(new FindInfrastructure());

            infrastructuresList.Add(infrastructureOperation1.InitializeAsync(co1));
            #endregion

            #region co2
            var co2 = new CloudService<IDatabaseServer>
            {
                Provider = new Provider { Name = "IGS", Device = @"C:\GeeksCloudService" },
                Infrastructure = new Infrastructure { Name = "Test" },
                ResourceInstance = new ResourceInstance { Name = "SQL Server Test" }
            };

            co2.ResourceFile = new ResourceFile<IDatabaseServer>
            {
                Name = co2.Infrastructure.Name + "_SERVER.json",
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

            var infrastructureOperation2 = new InfrastructureOperation(new FindInfrastructure());

            infrastructuresList.Add(infrastructureOperation2.InitializeAsync(co2));
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