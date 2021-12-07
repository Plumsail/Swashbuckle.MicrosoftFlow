using Microsoft.OpenApi.Interfaces;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Extensions
{
    public static class CustomAttributeProviderExtensions
    {
        public static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetParameterExtensions(this ICustomAttributeProvider attributeProvider)
        {
            var extensions = new List<KeyValuePair<string, IOpenApiExtension>>();

            extensions.AddRange(attributeProvider.GetValueLookupProperties());
            extensions.AddRange(attributeProvider.GetListLookupProperties());
            extensions.AddRange(attributeProvider.GetValueLookupCapabilityProperties());
            extensions.AddRange(attributeProvider.GetMetadataProperties());
            extensions.AddRange(attributeProvider.GetSchemaLookupProperties());
            extensions.AddRange(attributeProvider.GetPropertiesLookupProperties());

            return extensions;
        }

        public static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetValueLookupProperties(this ICustomAttributeProvider attributeProvider)
        {
            var attribute = attributeProvider.GetCustomAttributes(typeof(DynamicValueLookupAttribute), true).SingleOrDefault() as DynamicValueLookupAttribute;
            return attribute.GetSwaggerExtensions();
        }

        public static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetListLookupProperties(this ICustomAttributeProvider attributeProvider)
        {
            var attribute = attributeProvider.GetCustomAttributes(typeof(DynamicListLookupAttribute), true).SingleOrDefault() as DynamicListLookupAttribute;
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

        private static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetPropertiesLookupProperties(this ICustomAttributeProvider attributeProvider)
        {
            var attribute = attributeProvider.GetCustomAttributes(typeof(DynamicPropertiesLookupAttribute), true).SingleOrDefault() as DynamicPropertiesLookupAttribute;
            return attribute.GetSwaggerExtensions();
        }
    }
}