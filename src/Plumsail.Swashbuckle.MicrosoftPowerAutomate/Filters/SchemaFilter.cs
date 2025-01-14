﻿using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Attributes;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Extensions;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Reflection;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Filters
{
    public class SchemaFilter : ISchemaFilter
    {
        private readonly ISerializerDataContractResolver _serializerDataContractResolver;

        public SchemaFilter(ISerializerDataContractResolver serializerDataContractResolver)
        {
            _serializerDataContractResolver = serializerDataContractResolver;
        }

        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema is null || context is null)
            {
                return;
            }

            schema.Extensions.AddRange(GetDynamicSchemaExtensions(context));
            schema.Extensions.AddRange(GetDynamicPropertiesExtensions(context));

            schema.ExtendObjectProperties(context, Extensions.MemberInfoExtensions.ExtendProperty, _serializerDataContractResolver);
        }

        private static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetDynamicSchemaExtensions(SchemaFilterContext context)
        {
            var attribute = context.Type.GetTypeInfo().GetCustomAttribute<DynamicSchemaLookupAttribute>();
            return attribute.GetSwaggerExtensions();
        }

        private IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetDynamicPropertiesExtensions(SchemaFilterContext context)
        {
            var attribute = context.Type.GetTypeInfo().GetCustomAttribute<DynamicPropertiesLookupAttribute>();
            return attribute.GetSwaggerExtensions();
        }
    }
}