using Microsoft.OpenApi;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.VendorExtensionEntities
{
    internal class NotificationContentExtension : IOpenApiExtension
    {

        public string Description { get; set; }
        public OpenApiSchema Schema { get; set; }

        public void Write(IOpenApiWriter writer, OpenApiSpecVersion specVersion)
        {
            writer.WriteStartObject();

            writer.WriteProperty("description", Description);

            writer.WritePropertyName("schema");

            if (Schema.Reference != null)
            {
                switch (specVersion)
                {
                    case OpenApiSpecVersion.OpenApi2_0:
                        Schema.Reference.SerializeAsV2(writer);
                        break;
                    case OpenApiSpecVersion.OpenApi3_0:
                        Schema.Reference.SerializeAsV3(writer);
                        break;
                }
            }
            else if (Schema.Type != null)
            {
                writer.WriteStartObject();
                writer.WriteProperty("type", Schema.Type);
                writer.WriteEndObject();
            }

            writer.WriteEndObject();
        }
    }
}
