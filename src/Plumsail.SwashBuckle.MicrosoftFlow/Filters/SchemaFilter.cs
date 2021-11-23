using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using Plumsail.SwashBuckle.MicrosoftPowerAutomate.Attributes;
using Plumsail.SwashBuckle.MicrosoftPowerAutomate.Extensions;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Reflection;

namespace Plumsail.SwashBuckle.MicrosoftPowerAutomate.Filters
{
    internal class SchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema is null || context is null)
            {
                return;
            }

            schema.Extensions.AddRange(GetClassExtensions(context));

            schema.ExtendObjectProperties(context, Extensions.PropertyInfoExtensions.ExtendProperty);
        }

        private static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetClassExtensions(SchemaFilterContext context)
        {
            var attribute = context.Type.GetTypeInfo().GetCustomAttribute<DynamicSchemaLookupAttribute>();
            return attribute.GetSwaggerExtensions();
        }
    }
}