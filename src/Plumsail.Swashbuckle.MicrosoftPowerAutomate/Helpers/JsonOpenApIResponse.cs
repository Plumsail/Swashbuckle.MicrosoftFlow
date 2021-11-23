using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Helpers
{
    public static class JsonOpenApiResponseFactory
    {
        public static OpenApiResponse Create(string description, OpenApiSchema schema)
        {
            return new()
            {
                Content = new Dictionary<string, OpenApiMediaType>
                {
                    ["application/json"] = new()
                    {
                        Schema = schema
                    }
                },
                Description = description
            };
        }
    }
}
