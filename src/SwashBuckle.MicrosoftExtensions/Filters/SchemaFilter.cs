using System.Collections.Generic;
using System.Reflection;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using SwashBuckle.MicrosoftExtensions.Attributes;
using SwashBuckle.MicrosoftExtensions.Extensions;

namespace SwashBuckle.MicrosoftExtensions.Filters
{
    internal class SchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema model, SchemaFilterContext context)
        {
            if (model is null || context is null)
            {
                return;
            }

            model.Extensions.AddRange(GetClassExtensions(context));

            model.ExtendObjectProperties(context, Extensions.PropertyInfoExtensions.ExtendProperty);
        }

        private IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetClassExtensions(SchemaFilterContext context)
        {
            var attribute = context.Type.GetTypeInfo().GetCustomAttribute<DynamicSchemaLookupAttribute>();
            return attribute.GetSwaggerExtensions();
        }
    }
}