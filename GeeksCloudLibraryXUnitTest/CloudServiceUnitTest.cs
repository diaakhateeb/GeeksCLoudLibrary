using GeeksCloudLibrary.Operations;
using GeeksCloudLibrary.Operations.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace GeeksCloudLibraryXUnitTest
{
    public class CloudServiceUnitTest
    {
        private readonly ICloudServiceOperation cloudServiceOperation;

        public CloudServiceUnitTest()
        {
            cloudServiceOperation = new CloudServiceOperation(new FindInfrastructure());
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
        public async Task Delete_Infrastructure_Ok()
        {
            await cloudServiceOperation.DeleteAsync("Test");
        }
    }
}