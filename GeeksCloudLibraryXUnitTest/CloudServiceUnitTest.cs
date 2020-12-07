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
            cloudServiceOperation = new CloudServiceOperation(
                new FindInfrastructure(@"C:\\GeeksCloudService"));
        }

        [Fact]
        public async Task Delete_Infrastructure_Ok()
        {
            await cloudServiceOperation.DeleteAsync("Test");
        }
    }
}