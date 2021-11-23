using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.VendorExtensionEntities
{
    public class DynamicValuesModel
    {
        [JsonPropertyName("operationId")]
        public string OperationId { get; }
        [JsonPropertyName("value-path")]
        public string ValuePath { get; }
        [JsonPropertyName("value-title")]
        public string ValueTitle { get; }
        [JsonPropertyName("value-collection")]
        public string ValueCollection { get; }
        [JsonPropertyName("parameters")]
        public IDictionary<string, object> Parameters { get; }

        internal DynamicValuesModel(string operationId, string valuePath, string valueTitle, string valueCollection, IDictionary<string, object> parameters)
        {
            OperationId = operationId;
            ValuePath = valuePath;
            ValueTitle = valueTitle;
            ValueCollection = valueCollection;
            Parameters = parameters;
        }
    }
}