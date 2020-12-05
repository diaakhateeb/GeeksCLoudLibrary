using System.Threading.Tasks;

namespace GeeksCloudLibrary.Operations.Interfaces
{
    public interface ICouldServiceOperation
    {
        Task<ICloudService> InitializeAsync();

        Task<ICloudService> UpdateAsync(ICloudService updatedCloudService);

        Task<bool> DeleteAsync(string infraName);

        Task<ICloudService> LoadAsync(string infraName);
    }
}
