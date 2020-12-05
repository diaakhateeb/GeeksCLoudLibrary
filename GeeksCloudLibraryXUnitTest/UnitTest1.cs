using GeeksCloudLibrary.Infrastructure;
using GeeksCloudLibrary.Operations;
using GeeksCloudLibrary.Operations.Interfaces;
using GeeksCloudLibrary.Providers;
using GeeksCloudLibrary.Resource.Specs;
using GeeksCloudLibrary.Resource.Specs.DatabaseServer;
using GeeksCloudLibrary.Resource.Specs.Interfaces;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.MachineInstanceType.Enum;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.Memory;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.NetworkPerformance.Enum;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.OperatingSystem;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.OperatingSystem.Enum;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.Processor;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.SpaceSizeUnit.Enum;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.Storage;
using GeeksCloudLibrary.Resource.Specs.VirtualMachine.Storage.Enum;
using GeeksCloudLibrary.ResourceFile;
using GeeksCloudLibrary.ResourceInstance;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GeeksCloudLibraryXUnitTest
{
    public class UnitClass1 : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException ();
        }

        [Fact]
        public async void UnitTest1()
        {
            var infrastructuresList = new List<Task> ();

            #region co1
            var co1 = new CloudService
            {
                Provider = new Provider { Name = "IGS" },
                Infrastructure = new Infrastructure { Name = "UAT" },
                ResourceInstance = new ResourceInstance { Name = "Windows-Dev-VM" }
            };

            co1.ResourceFile = new ResourceFile<IResourceConfig>
            {
                Name = co1.Infrastructure.Name + "_SERVER.json",
                Content = new ResourceConfig
                {
                    VirtualMachine = new VirtualMachine
                    {
                        OperatingSystem = new WindowsOperatingSystem
                        {
                            Version = 10,
                            Vendor = "Microsoft",
                            Architecture = OperatingSystemArchitecture.SixtyFour
                        },
                        Storage = new Storage { Size = 100, SpaceSizeUnit = SizeUnit.GiB, VolumeType = VolumeType.Root },
                        Processor = new Processor { Cores = 8, Speed = 260 },
                        Memory = new Memory { Size = 32, SpaceSizeUnit = SizeUnit.GiB },
                        NetworkPerformance = Performance.High,
                        InstanceType = InstanceType.Large,
                        Tag = "Dev VM"
                    },
                    DatabaseServer = new MsSqlServer
                    {
                        Vendor = "Microsoft",
                        Version = 16
                    }
                }
            };

            var cloudServiceOperation1 = (ICouldServiceOperation)new CloudServiceOperation (co1);
            infrastructuresList.Add (cloudServiceOperation1.InitializeAsync ());
            #endregion

            #region co2
            var co2 = new CloudService
            {
                Provider = new Provider { Name = "SAMS" },
                Infrastructure = new Infrastructure { Name = "XYZ" },
                ResourceInstance = new ResourceInstance { Name = "Linux-Dev-VM" }
            };

            co2.ResourceFile = new ResourceFile<IResourceConfig>
            {
                Name = co2.Infrastructure.Name + "_SERVER.json",
                Content = new ResourceConfig
                {
                    VirtualMachine = new VirtualMachine
                    {
                        OperatingSystem = new LinuxOperatingSystem
                        {
                            Version = 14,
                            Vendor = "Ubuntu",
                            Architecture = OperatingSystemArchitecture.SixtyFour
                        },
                        Storage = new Storage { Size = 200, SpaceSizeUnit = SizeUnit.GiB, VolumeType = VolumeType.Extension },
                        Processor = new Processor { Cores = 16, Speed = 200 },
                        Memory = new Memory { Size = 64, SpaceSizeUnit = SizeUnit.GiB },
                        NetworkPerformance = Performance.High,
                        InstanceType = InstanceType.XLarge,
                        Tag = "Testing VM"
                    }
                }
            };

            var cloudServiceOperation2 = (ICouldServiceOperation)new CloudServiceOperation (co2);
            infrastructuresList.Add (cloudServiceOperation2.InitializeAsync ());
            #endregion

            await Task.WhenAll (infrastructuresList);

            var ee = "";
        }
    }
}
