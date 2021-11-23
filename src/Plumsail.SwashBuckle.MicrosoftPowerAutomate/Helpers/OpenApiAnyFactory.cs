using Microsoft.OpenApi.Any;
using System.Text.Json;

namespace Plumsail.SwashBuckle.MicrosoftPowerAutomate.Helpers
{
    public static class OpenApiAnyFactory
    {
        public static IOpenApiAny ForValue(object value)
        {
            return Swashbuckle.AspNetCore.SwaggerGen.OpenApiAnyFactory.CreateFromJson(
                JsonSerializer.Serialize(value));
        }
    }
}