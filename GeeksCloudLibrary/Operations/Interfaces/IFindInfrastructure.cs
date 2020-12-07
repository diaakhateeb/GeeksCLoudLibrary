using System.Threading.Tasks;

namespace GeeksCloudLibrary.Operations.Interfaces
{
    /// <summary>
    /// IFindInfrastructure interface.
    /// </summary>
    public interface IFindInfrastructure
    {
        /// <summary>
        /// Finds infrastructure directory physical path.
        /// </summary>
        /// <param name="providerName">Provider name.</param>
        /// <param name="infraName">Infrastructure name.</param>
        /// <returns>Returns physical directory path.</returns>
        Task<string> FindInfrastructurePathAsync(string providerName, string infraName);

        /// <summary>
        /// Finds infrastructure directory physical path.
        /// </summary>
        /// <param name="infraName">Infrastructure name.</param>
        /// <returns>Returns array of physical directories where infrastructure name is included.</returns>
        Task<string[]> FindInfrastructurePathsAsync(string infraName);

        /// <summary>
        /// Finds infrastructure resource Json file physical path.
        /// </summary>
        /// <param name="infraName">Infrastructure name.</param>
        /// <returns>Returns physical Json file path.</returns>
        public Task<string> FindInfrastructureJsonPathAsync(string providerName, string infraName);

        /// <summary>
        /// Gets or Sets Root device path.
        /// </summary>
        string RootDevice { get; }
    }
}