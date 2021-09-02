using Microsoft.OpenApi.Any;
using Newtonsoft.Json;

namespace SwashBuckle.MicrosoftExtensions.Helpers
{
    public class OpenApiAnyFactory
    {
        public static IOpenApiAny ForValue(object value)
        {
            return Swashbuckle.AspNetCore.SwaggerGen.OpenApiAnyFactory.CreateFromJson(
                JsonConvert.SerializeObject(value, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Include
                }));
        }
    }
}