using Microsoft.OpenApi.Interfaces;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Attributes;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Helpers;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.VendorExtensionEntities;
using System.Collections.Generic;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Extensions
{
    internal static class DynamicListLookupAttributeExtensions
    {
        internal static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetSwaggerExtensions(this DynamicListLookupAttribute attribute)
        {
            if (attribute is null)
                yield break;

            yield return new KeyValuePair<string, IOpenApiExtension>
            (
                Constants.XMsDynamicListLookup,
                OpenApiAnyFactory.ForValue(new DynamicListModel
                (
                    attribute.LookupOperation,
                    attribute.ItemValuePath,
                    attribute.ItemTitlePath,
                    attribute.ItemsPath,
                    ParameterParser.ParseProperties(attribute.Parameters)
                ))
            );

        }


    }
}