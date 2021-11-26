using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.VendorExtensionEntities
{
    public class DynamicPropertiesModel
    {
        [JsonPropertyName("operationId")]
        public string OperationId { get; }

        [JsonPropertyName("parameters")]
        public IDictionary<string, object> Parameters { get; }

        [JsonPropertyName("itemValuePath")]
        public string ItemValuePath { get; }

        internal DynamicPropertiesModel(string operationId, string itemValuePath, IDictionary<string, object> parameters)
        {
            OperationId = operationId;
            ItemValuePath = itemValuePath;
            Parameters = parameters;
        }
    }
}