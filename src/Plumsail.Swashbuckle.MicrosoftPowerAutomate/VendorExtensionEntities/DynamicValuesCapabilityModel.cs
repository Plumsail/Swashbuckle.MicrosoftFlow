using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.VendorExtensionEntities
{
    public class DynamicValuesCapabilityModel
    {
        [JsonPropertyName("capability")]
        public string Capability { get; }
        [JsonPropertyName("value-path")]
        public string ValuePath { get; }
        [JsonPropertyName("value-title")]
        public string ValueTitle { get; }
        [JsonPropertyName("parameters")]
        public IDictionary<string, object> Parameters { get; }

        internal DynamicValuesCapabilityModel(string capability, string valuePath, string valueTitle, IDictionary<string, object> parameters)
        {
            Capability = capability;
            ValuePath = valuePath;
            ValueTitle = valueTitle;
            Parameters = parameters;
        }
    }
}