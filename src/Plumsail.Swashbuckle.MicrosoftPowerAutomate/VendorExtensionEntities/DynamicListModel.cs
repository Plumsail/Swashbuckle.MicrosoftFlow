using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.VendorExtensionEntities
{
    public class DynamicListModel
    {
        [JsonPropertyName("operationId")]
        public string OperationId { get; }
        [JsonPropertyName("itemValuePath")]
        public string ItemValuePath { get; }
        [JsonPropertyName("itemTitlePath")]
        public string ItemTitlePath { get; }
        [JsonPropertyName("itemsPath")]
        public string ItemsPath { get; }
        [JsonPropertyName("parameters")]
        public IDictionary<string, object> Parameters { get; }

        internal DynamicListModel(string operationId, string itemValuePath, string itemTitlePath, string itemsPath, IDictionary<string, object> parameters)
        {
            OperationId = operationId;
            ItemValuePath = itemValuePath;
            ItemTitlePath = itemTitlePath;
            ItemsPath = itemsPath;
            Parameters = parameters;
        }
    }
}