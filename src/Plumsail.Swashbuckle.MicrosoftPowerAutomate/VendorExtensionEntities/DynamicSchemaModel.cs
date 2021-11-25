using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.VendorExtensionEntities
{
    public class DynamicSchemaModel
    {
        [JsonPropertyName("operationId")]
        public string OperationId { get; }
        [JsonPropertyName("value-path")]
        public string ValuePath { get; }
        [JsonPropertyName("parameters")]
        public IDictionary<string, object> Parameters { get; }

        internal DynamicSchemaModel(string operationId, string valuePath, IDictionary<string, object> parameters)
        {
            OperationId = operationId;
            ValuePath = valuePath;
            Parameters = parameters;
        }
    }
}