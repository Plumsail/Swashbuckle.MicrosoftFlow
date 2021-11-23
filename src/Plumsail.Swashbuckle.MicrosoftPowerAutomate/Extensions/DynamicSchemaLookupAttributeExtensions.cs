using Microsoft.OpenApi.Interfaces;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Attributes;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Helpers;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.VendorExtensionEntities;
using System.Collections.Generic;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Extensions
{
    internal static class DynamicSchemaLookupAttributeExtensions
    {
        internal static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetSwaggerExtensions(this DynamicSchemaLookupAttribute attribute)
        {
            if (attribute is null)
                yield break;

            yield return new KeyValuePair<string, IOpenApiExtension>
            (
                Constants.XMsDynamicSchemaLookup,
                OpenApiAnyFactory.ForValue(new DynamicSchemaModel(attribute.LookupOperation, attribute.ValuePath, ParameterParser.Parse(attribute.Parameters)))
            );
        }
    }
}