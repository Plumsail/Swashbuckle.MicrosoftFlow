using Microsoft.OpenApi.Interfaces;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Attributes;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Helpers;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.VendorExtensionEntities;
using System.Collections.Generic;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Extensions
{
    internal static class DynamicValueLookupAttributeExtensions
    {
        internal static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetSwaggerExtensions(this DynamicValueLookupAttribute attribute)
        {
            if (attribute is null)
                yield break;

            yield return new KeyValuePair<string, IOpenApiExtension>
            (
                Constants.XMsDynamicValueLookup,
                OpenApiAnyFactory.ForValue(new DynamicValuesModel
                (
                    attribute.LookupOperation,
                    attribute.ValuePath,
                    attribute.ValueTitle,
                    attribute.ValueCollection,
                    ParameterParser.Parse(attribute.Parameters)
                ))
            );

        }


    }
}