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
            propertyExtensions.AddRange(GetSchemaLookupProperties(property));
            propertyExtensions.AddRange(GetValueLookupCapabilityProperties(property));
        }

        private static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetMetadataExtensions(MemberInfo MemberInfo)
        {
            var attribute = MemberInfo.GetCustomAttribute<MetadataAttribute>(true);
            return attribute.GetSwaggerExtensions();
        }

        private static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetValueLookupProperties(MemberInfo MemberInfo)
        {
            var attribute = MemberInfo.GetCustomAttribute<DynamicValueLookupAttribute>(true);
            return attribute.GetSwaggerExtensions();
        }

        private static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetValueLookupCapabilityProperties(MemberInfo MemberInfo)
        {
            var attribute = MemberInfo.GetCustomAttribute<DynamicValueLookupCapabilityAttribute>(true);
            return attribute.GetSwaggerExtensions();
        }

        private static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetSchemaLookupProperties(MemberInfo MemberInfo)
        {
            var attribute = MemberInfo.GetCustomAttribute<DynamicSchemaLookupAttribute>(true);
            return attribute.GetSwaggerExtensions();
        }
    }
}