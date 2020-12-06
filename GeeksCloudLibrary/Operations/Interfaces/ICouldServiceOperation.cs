using GeeksCloudLibrary.Shared.Model;
using System.Threading.Tasks;

namespace GeeksCloudLibrary.Operations.Interfaces
{
    public interface ICouldServiceOperation<T>
    {
        Task<ICloudService<T>> InitializeAsync();

        Task UpdateAsync(string infraName, UpdateResourceModel model);

        Task DeleteAsync(string infraName);

        Task<ICloudService<T>> LoadAsync(string infraName);
        string FindInfrastructure(string infraName);
    }
}
