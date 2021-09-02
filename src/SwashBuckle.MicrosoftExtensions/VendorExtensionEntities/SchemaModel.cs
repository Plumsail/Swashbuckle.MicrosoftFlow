using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace SwashBuckle.MicrosoftExtensions.VendorExtensionEntities
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    internal class SchemaModel
    {
        public SchemaModel(OpenApiSchema schema)
        {
            if (schema.Reference != null)
            {
                Ref = schema.Reference.ReferenceV2;
            }

            if (schema.Type != null)
            {
                Type = schema.Type;
            }
        }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("$ref", NullValueHandling = NullValueHandling.Ignore)]
        public string Ref { get; set; }
    }
}
