using System.Threading.Tasks;

namespace GeeksCloudLibrary.Operations.Interfaces
{
    /// <summary>
    /// ICloudServiceOperation interface.
    /// </summary>
    public interface ICloudServiceOperation
    {
        /// <summary>
        /// Deletes infrastructure.
        /// </summary>
        /// <param name="infraName">Infrastructure name.</param>
        /// <returns>Returns awaitable Task.</returns>
        Task DeleteAsync(string infraName);
    }
}
