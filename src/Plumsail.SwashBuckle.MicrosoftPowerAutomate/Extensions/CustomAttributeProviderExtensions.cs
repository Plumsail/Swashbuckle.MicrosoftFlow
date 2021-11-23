using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.OpenApi.Interfaces;
using Plumsail.SwashBuckle.MicrosoftPowerAutomate.Attributes;

namespace Plumsail.SwashBuckle.MicrosoftPowerAutomate.Extensions
{
    public static class CustomAttributeProviderExtensions
    {
        public static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetParameterExtensions(this ICustomAttributeProvider attributeProvider)
        {
            var extensions = new List<KeyValuePair<string, IOpenApiExtension>>();

            extensions.AddRange(attributeProvider.GetValueLookupProperties());
            extensions.AddRange(attributeProvider.GetValueLookupCapabilityProperties());
            extensions.AddRange(attributeProvider.GetMetadataProperties());
            extensions.AddRange(attributeProvider.GetSchemaLookupProperties());

            return extensions;
        }

        public static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetValueLookupProperties(this ICustomAttributeProvider attributeProvider)
        {
            var attribute = attributeProvider.GetCustomAttributes(typeof(DynamicValueLookupAttribute), true).SingleOrDefault() as DynamicValueLookupAttribute;
            return attribute.GetSwaggerExtensions();
        }

        public static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetValueLookupCapabilityProperties(this ICustomAttributeProvider attributeProvider)
        {
            var attribute = attributeProvider.GetCustomAttributes(typeof(DynamicValueLookupCapabilityAttribute), true).SingleOrDefault() as DynamicValueLookupCapabilityAttribute;
            return attribute.GetSwaggerExtensions();
        }

        public static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetMetadataProperties(this ICustomAttributeProvider attributeProvider)
        {
            var attribute = attributeProvider.GetCustomAttributes(typeof(MetadataAttribute), true).SingleOrDefault() as MetadataAttribute;
            return attribute.GetSwaggerExtensions();
        }

        public static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetSchemaLookupProperties(this ICustomAttributeProvider attributeProvider)
        {
            var attribute = attributeProvider.GetCustomAttributes(typeof(DynamicSchemaLookupAttribute), true).SingleOrDefault() as DynamicSchemaLookupAttribute;
            return attribute.GetSwaggerExtensions();
        }
    }
}