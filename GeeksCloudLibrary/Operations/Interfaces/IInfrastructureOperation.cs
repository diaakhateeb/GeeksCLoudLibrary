using GeeksCloudLibrary.Shared.Interfaces;
using GeeksCloudLibrary.Shared.Model;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace GeeksCloudLibrary.Operations.Interfaces
{
    public interface IInfrastructureOperation
    {
        Task InitializeAsync<T>(ICloudService<T> cloudService) where T : IResource;
        Task UpdateAsync(string infraName, UpdateResourceModel model);
        Task<JObject> LoadAsync(string infraName);
    }
}
