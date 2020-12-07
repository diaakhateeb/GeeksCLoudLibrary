using GeeksCloudLibrary.Shared.Interfaces;
using GeeksCloudLibrary.Shared.Model;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace GeeksCloudLibrary.Operations.Interfaces
{
    /// <summary>
    /// IInfrastructureOperation interface.
    /// </summary>
    public interface IInfrastructureOperation
    {
        /// <summary>
        /// Initializes new infrastructure.
        /// </summary>
        /// <typeparam name="T">Resource type.</typeparam>
        /// <param name="cloudService">CloudService type.</param>
        /// <returns>Returns awaitable Task.</returns>
        Task InitializeAsync<T>(ICloudService<T> cloudService);
        
        /// <summary>
        /// Updates infrastructure.
        /// </summary>
        /// <param name="providerName">Provider name.</param>
        /// <param name="infraName">Infrastructure name.</param>
        /// <param name="model">The update model.</param>
        /// <returns>Returns awaitable Task.</returns>
        Task UpdateAsync(string providerName, string infraName, UpdateResourceModel model);
        
        /// <summary>
        /// Loads infrastructure Json configuration file.
        /// </summary>
        /// <param name="providerName">Provider Name</param>
        /// <param name="infraName">Infrastructure name</param>
        /// <returns>Returns Task of JObject object.</returns>
        Task<JObject> LoadAsync(string providerName, string infraName);
    }
}
