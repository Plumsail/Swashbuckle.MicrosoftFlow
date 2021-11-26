using Microsoft.OpenApi.Interfaces;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Attributes;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Helpers;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.VendorExtensionEntities;
using System.Collections.Generic;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Extensions
{
    internal static class DynamicPropertiesLookupAttributeExtensions
    {
        internal static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetSwaggerExtensions(this DynamicPropertiesLookupAttribute lookupAttribute)
        {
            if (lookupAttribute is null)
            {
                yield break;
            }

            yield return new KeyValuePair<string, IOpenApiExtension>
            (
                Constants.XMsDynamicPropertiesLookup,
                OpenApiAnyFactory.ForValue(new DynamicPropertiesModel(lookupAttribute.LookupOperation, lookupAttribute.ItemValuePath, ParameterParser.ParseProperties(lookupAttribute.Parameters)))
            );
        }
    }
}