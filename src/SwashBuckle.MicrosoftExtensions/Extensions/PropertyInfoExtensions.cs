using System.Collections.Generic;
using System.Reflection;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using SwashBuckle.MicrosoftExtensions.Attributes;

namespace SwashBuckle.MicrosoftExtensions.Extensions
{
    internal static class PropertyInfoExtensions
    {
        internal static void ExtendProperty(OpenApiSchema schema, PropertyInfo property)
        {
            var propertyExtensions = schema.Extensions;

            propertyExtensions.AddRange(GetMetadataExtensions(property));
            propertyExtensions.AddRange(GetValueLookupProperties(property));
            propertyExtensions.AddRange(GetSchemaLookupProperties(property));
            propertyExtensions.AddRange(GetValueLookupCapabilityProperties(property));
        }

        private static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetMetadataExtensions(PropertyInfo propertyInfo)
        {
            var attribute = propertyInfo.GetCustomAttribute<MetadataAttribute>(true);
            return attribute.GetSwaggerExtensions();
        }

        private static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetValueLookupProperties(PropertyInfo propertyInfo)
        {
            var attribute = propertyInfo.GetCustomAttribute<DynamicValueLookupAttribute>(true);
            return attribute.GetSwaggerExtensions();
        }

        private static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetValueLookupCapabilityProperties(PropertyInfo propertyInfo)
        {
            var attribute = propertyInfo.GetCustomAttribute<DynamicValueLookupCapabilityAttribute>(true);
            return attribute.GetSwaggerExtensions();
        }

        private static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetSchemaLookupProperties(PropertyInfo propertyInfo)
        {
            var attribute = propertyInfo.GetCustomAttribute<DynamicSchemaLookupAttribute>(true);
            return attribute.GetSwaggerExtensions();
        }
    }
}