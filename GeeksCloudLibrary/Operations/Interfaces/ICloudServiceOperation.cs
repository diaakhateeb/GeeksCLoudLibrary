using System.Threading.Tasks;

namespace GeeksCloudLibrary.Operations.Interfaces
{
    public interface ICloudServiceOperation
    {
        Task DeleteAsync(string infraName);
    }
}
