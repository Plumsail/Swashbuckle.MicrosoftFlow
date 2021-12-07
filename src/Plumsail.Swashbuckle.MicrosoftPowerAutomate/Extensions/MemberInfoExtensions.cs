using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Attributes;
using System.Collections.Generic;
using System.Reflection;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Extensions
{
    public static class MemberInfoExtensions
    {
        public static void ExtendProperty(OpenApiSchema schema, MemberInfo property)
        {
            var propertyExtensions = schema.Extensions;

            propertyExtensions.AddRange(GetMetadataExtensions(property));
            propertyExtensions.AddRange(GetValueLookupProperties(property));
            propertyExtensions.AddRange(GetListLookupProperties(property));
            propertyExtensions.AddRange(GetSchemaLookupProperties(property));
            propertyExtensions.AddRange(GetValueLookupCapabilityProperties(property));
            propertyExtensions.AddRange(GetPropertiesLookupProperties(property));
            propertyExtensions.AddRange(GetCallbackUrlProperties(property));
        }

        private static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetMetadataExtensions(MemberInfo memberInfo)
        {
            var attribute = memberInfo.GetCustomAttribute<MetadataAttribute>(true);
            return attribute.GetSwaggerExtensions();
        }

        private static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetValueLookupProperties(MemberInfo memberInfo)
        {
            var attribute = memberInfo.GetCustomAttribute<DynamicValueLookupAttribute>(true);
            return attribute.GetSwaggerExtensions();
        }

        private static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetListLookupProperties(MemberInfo memberInfo)
        {
            var attribute = memberInfo.GetCustomAttribute<DynamicListLookupAttribute>(true);
            return attribute.GetSwaggerExtensions();
        }

        private static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetValueLookupCapabilityProperties(MemberInfo memberInfo)
        {
            var attribute = memberInfo.GetCustomAttribute<DynamicValueLookupCapabilityAttribute>(true);
            return attribute.GetSwaggerExtensions();
        }

        private static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetSchemaLookupProperties(MemberInfo memberInfo)
        {
            var attribute = memberInfo.GetCustomAttribute<DynamicSchemaLookupAttribute>(true);
            return attribute.GetSwaggerExtensions();
        }

        private static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetPropertiesLookupProperties(MemberInfo memberInfo)
        {
            var attribute = memberInfo.GetCustomAttribute<DynamicPropertiesLookupAttribute>(true);
            return attribute.GetSwaggerExtensions();
        }

        private static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetCallbackUrlProperties(MemberInfo memberInfo)
        {
            var attribute = memberInfo.GetCustomAttribute<CallbackUrlAttribute>(true);
            return attribute.GetSwaggerExtensions();
        }
    }
}