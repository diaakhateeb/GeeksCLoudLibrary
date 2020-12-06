using GeeksCloudLibrary.Shared.Model;
using Newtonsoft.Json.Linq;

namespace GeeksCloudLibrary.Operations.Interfaces
{
    public interface IResourceFileOperation
    {
        JObject UpdateResourceFile(JObject deserializedJsonContent, UpdateResourceModel updateResourceModel);
    }
}
