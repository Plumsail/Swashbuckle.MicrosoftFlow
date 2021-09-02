using System.Collections.Generic;
using Microsoft.OpenApi.Interfaces;
using SwashBuckle.MicrosoftExtensions.Attributes;
using SwashBuckle.MicrosoftExtensions.Helpers;
using SwashBuckle.MicrosoftExtensions.VendorExtensionEntities;

namespace SwashBuckle.MicrosoftExtensions.Extensions
{
    internal static class DynamicValueLookupCapabilityAttributeExtensions
    {
        internal static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetSwaggerExtensions(this DynamicValueLookupCapabilityAttribute attribute)
        {
            if (attribute is null)
                yield break;

            yield return new KeyValuePair<string, IOpenApiExtension>
            (
                Constants.XMsDynamicValueLookup,
                OpenApiAnyFactory.ForValue(new DynamicValuesCapabilityModel
                (
                    attribute.Capability,
                    attribute.ValuePath,
                    attribute.ValueTitle,
                    ParameterParser.Parse(attribute.Parameters)
                ))
            );
        }
    }
}