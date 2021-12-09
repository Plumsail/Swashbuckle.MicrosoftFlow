using Microsoft.OpenApi.Any;
using System.Text.Json;
using System.Text.Json.Serialization;
using SwaggerGen = Swashbuckle.AspNetCore.SwaggerGen;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Helpers
{
    public static class OpenApiAnyFactory
    {
        public static IOpenApiAny ForValue(object value)
        {
            return SwaggerGen.OpenApiAnyFactory.CreateFromJson(
                JsonSerializer.Serialize(value, new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                }));
        }
    }
}