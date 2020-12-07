using GeeksCloudLibrary.Shared.Model;
using Newtonsoft.Json.Linq;

namespace GeeksCloudLibrary.Operations.Interfaces
{
    /// <summary>
    /// IResourceFileOperation interface.
    /// </summary>
    public interface IResourceFileOperation
    {
        /// <summary>
        /// Updates resource Json file.
        /// </summary>
        /// <param name="deserializedJsonContent">JObject object where data is loaded in.</param>
        /// <param name="updateResourceModel">Resource model.</param>
        /// <returns>Returns updated JObject object.</returns>
        JObject UpdateResourceFile(JObject deserializedJsonContent, UpdateResourceModel updateResourceModel);
    }
}
