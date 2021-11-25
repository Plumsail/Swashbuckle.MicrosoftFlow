using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;
using System.Reflection;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Extensions
{
    public static class OpenApiSchemaExtensions
    {
        public static void ExtendObjectProperties(this OpenApiSchema schema,
            SchemaFilterContext context,
            Action<OpenApiSchema, MemberInfo> extendPropertyAction,
            ISerializerDataContractResolver serializerDataContractResolver)
        {
            if (schema.Type != "object")
            {
                return;
            }

            if (schema.Properties is null)
                return;

            var dataContract = serializerDataContractResolver.GetDataContractForType(context.Type);


            foreach (var schemaProperty in schema.Properties)
            {
                var realProperty = dataContract.ObjectProperties.First(p => p.Name == schemaProperty.Key).MemberInfo;

                // Property can be named in different way, possible exception
                extendPropertyAction(schemaProperty.Value, realProperty);
            }
        }
    }
}