using GeeksCloudLibrary.Operations;
using GeeksCloudLibrary.Operations.Interfaces;
using GeeksCloudLibrary.Providers;
using GeeksCloudLibrary.Resource.VirtualMachine.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace GeeksCloudLibraryXUnitTest
{
    public class CloudServiceUnitTest
    {
        [Fact]
        public async Task Delete_Infrastructure_Ok()
        {
            ICouldServiceOperation<IVirtualMachine> cloudServiceOperation =
                new CloudServiceOperation<IVirtualMachine> (new Provider
                {
                    Device = @"C:\GeeksCloudService",
                    Name = "IGS"
                });

            await cloudServiceOperation.DeleteAsync ("test");



        }
    }
}
