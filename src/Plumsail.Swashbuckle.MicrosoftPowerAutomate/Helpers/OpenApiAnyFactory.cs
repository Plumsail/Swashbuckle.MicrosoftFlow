using Microsoft.OpenApi.Any;
using System.Text.Json;

using SwaggerGen = Swashbuckle.AspNetCore.SwaggerGen;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Helpers
{
    public static class OpenApiAnyFactory
    {
        public static IOpenApiAny ForValue(object value)
        {
            return SwaggerGen.OpenApiAnyFactory.CreateFromJson(
                JsonSerializer.Serialize(value));
        }
    }
}