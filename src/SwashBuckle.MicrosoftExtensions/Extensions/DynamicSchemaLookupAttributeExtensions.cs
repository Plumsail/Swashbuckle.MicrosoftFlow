using System.Collections.Generic;
using Microsoft.OpenApi.Interfaces;
using SwashBuckle.MicrosoftExtensions.Attributes;
using SwashBuckle.MicrosoftExtensions.Helpers;
using SwashBuckle.MicrosoftExtensions.VendorExtensionEntities;

namespace SwashBuckle.MicrosoftExtensions.Extensions
{
    internal static class DynamicSchemaLookupAttributeExtensions
    {
        internal static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetSwaggerExtensions (this DynamicSchemaLookupAttribute attribute)
        {
            if(attribute is null)
                yield break;

            yield return new KeyValuePair<string, IOpenApiExtension>
            (
                Constants.XMsDynamicSchemaLookup,
                OpenApiAnyFactory.ForValue(new DynamicSchemaModel(attribute.LookupOperation, attribute.ValuePath, ParameterParser.Parse(attribute.Parameters)))
            );
        }
    }
}