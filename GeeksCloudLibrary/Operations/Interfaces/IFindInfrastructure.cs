using System.Threading.Tasks;

namespace GeeksCloudLibrary.Operations.Interfaces
{
    public interface IFindInfrastructure
    {
        Task<string> FindInfrastructurePathAsync(string infraName);
        Task<string> FindInfrastructureJsonPathAsync(string infraName);
    }
}
