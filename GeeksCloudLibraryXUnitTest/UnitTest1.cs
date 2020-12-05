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
            var co1 = new CloudService<IVirtualMachine>
            {
                Provider = new Provider { Name = "IGS" },
                Infrastructure = new Infrastructure { Name = "UAT" },
                ResourceInstance = new ResourceInstance { Name = "Windows-Dev-VM" }
            };

            co1.ResourceFile = new ResourceFile<IVirtualMachine>
            {
                Name = co1.Infrastructure.Name + "_SERVER.json",
                Content = new VirtualMachine
                {

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

            var cloudServiceOperation1 = 
                (ICouldServiceOperation<IVirtualMachine>)new CloudServiceOperation<IVirtualMachine>(co1);
            infrastructuresList.Add (cloudServiceOperation1.InitializeAsync ());
            #endregion

            #region co2
            var co2 = new CloudService<IDatabaseServer>
            {
                Provider = new Provider { Name = "SAMS" },
                Infrastructure = new Infrastructure { Name = "XYZ" },
                ResourceInstance = new ResourceInstance { Name = "SQL Server Test" }
            };

            co2.ResourceFile = new ResourceFile<IDatabaseServer>
            {
                Name = co2.Infrastructure.Name + "_SERVER.json",
                Content = new MsSqlServer
                {
                    InstanceType = InstanceType.Large,
                    Memory = new Memory { Size = 64, SpaceSizeUnit = SizeUnit.GiB },
                    NetworkPerformance = Performance.High,
                    Storage = new Storage { Size = 100, SpaceSizeUnit = SizeUnit.GiB, VolumeType = VolumeType.Extension },
                    Vendor = "Microsoft",
                    Version = 2016
                }
            };

            var cloudServiceOperation2 = 
                (ICouldServiceOperation<IDatabaseServer>)new CloudServiceOperation<IDatabaseServer> (co2);
            infrastructuresList.Add (cloudServiceOperation1.InitializeAsync ());
            #endregion

            await Task.WhenAll (infrastructuresList);

            var ee = "";
        }
    }
}
