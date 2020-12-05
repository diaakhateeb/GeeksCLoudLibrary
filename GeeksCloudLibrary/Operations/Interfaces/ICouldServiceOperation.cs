using System.Threading.Tasks;

namespace GeeksCloudLibrary.Operations.Interfaces
{
    public interface ICouldServiceOperation<T>
    {
        Task<ICloudService<T>> InitializeAsync();

        Task<ICloudService<T>> UpdateAsync(ICloudService<T> updatedCloudService);

        Task<bool> DeleteAsync(string infraName);

        Task<ICloudService<T>> LoadAsync(string infraName);
    }
}
