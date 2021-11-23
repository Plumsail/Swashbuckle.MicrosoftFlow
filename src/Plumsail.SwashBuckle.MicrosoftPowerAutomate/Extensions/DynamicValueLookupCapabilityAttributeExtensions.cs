using Microsoft.OpenApi.Interfaces;
using Plumsail.SwashBuckle.MicrosoftPowerAutomate.Attributes;
using Plumsail.SwashBuckle.MicrosoftPowerAutomate.Helpers;
using Plumsail.SwashBuckle.MicrosoftPowerAutomate.VendorExtensionEntities;
using System.Collections.Generic;

namespace Plumsail.SwashBuckle.MicrosoftPowerAutomate.Extensions
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