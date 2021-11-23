using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Plumsail.SwashBuckle.MicrosoftPowerAutomate.Extensions
{
    public static class OpenApiSchemaExtensions
    {
        public static void ExtendObjectProperties(this OpenApiSchema schema, SchemaFilterContext context, Action<OpenApiSchema, PropertyInfo> extendPropertyAction)
        {
            if (schema.Type != "object")
            {
                return;
            }

            var properties = context.Type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            if (schema.Properties is null)
                return;

            foreach (var schemaProperty in schema.Properties)
            {
                // Try to find real property by JsonPropertyAttribute.
                var realProperty = properties
                    .FirstOrDefault(x => x.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name == schemaProperty.Key);

                realProperty ??= properties.FirstOrDefault(x => x.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName == schemaProperty.Key);

                // Try to find real property by property name
                realProperty ??= properties.First(x => string.Equals(x.Name, schemaProperty.Key, StringComparison.OrdinalIgnoreCase));

                // Property can be named in different way, possible exception
                extendPropertyAction(schemaProperty.Value, realProperty);
            }
        }
    }
}