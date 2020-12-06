using GeeksCloudLibrary.Operations;
using GeeksCloudLibrary.Operations.Interfaces;
using GeeksCloudLibrary.Resource.Specs.MachineInstanceType.Enum;
using GeeksCloudLibrary.Resource.Specs.Memory;
using GeeksCloudLibrary.Resource.Specs.NetworkPerformance.Enum;
using GeeksCloudLibrary.Resource.Specs.Processor;
using GeeksCloudLibrary.Resource.Specs.SpaceSizeUnit.Enum;
using GeeksCloudLibrary.Resource.Specs.Storage.Enum;
using GeeksCloudLibrary.Resource.VirtualMachine.Interfaces;
using GeeksCloudLibrary.Shared.Model;
using System.Threading.Tasks;
using Xunit;

namespace GeeksCloudLibraryXUnitTest
{
    public class CloudServiceUnitTest
    {
        private readonly ICouldServiceOperation<IVirtualMachine> cloudServiceOperation;

        public CloudServiceUnitTest()
        {
            cloudServiceOperation = new CloudServiceOperation<IVirtualMachine> ();
        }

        [Fact]
        public async Task Delete_Infrastructure_Ok()
        {
            await cloudServiceOperation.DeleteAsync ("Test");
        }

        [Fact]
        public async Task Load_Infrastructure_Ok()
        {
            var ee = await cloudServiceOperation.LoadAsync ("UAT");

            string y = "";
        }

        [Fact]
        public async Task Update_Infrastructure_Ok()
        {
            var updateModel = new UpdateResourceModel
            {
                InstanceType = InstanceType.Medium,
                Memory = new Memory { Size = 50, SpaceSizeUnit = SizeUnit.GiB },
                NetworkPerformance = Performance.Moderate,
                Processor = new Processor { Cores = 32, Speed = 266 },
                Storage = new GeeksCloudLibrary.Resource.Specs.Storage.Storage { Size = 500, VolumeType = VolumeType.Extension },
                Tag = "New Dev Machine"
            };

            await cloudServiceOperation.UpdateAsync ("UAT", updateModel);
        }
    }
}
