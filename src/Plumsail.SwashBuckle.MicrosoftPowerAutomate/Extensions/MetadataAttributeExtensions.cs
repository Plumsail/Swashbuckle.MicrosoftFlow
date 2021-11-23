using System.Collections.Generic;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Plumsail.SwashBuckle.MicrosoftPowerAutomate;
using Plumsail.SwashBuckle.MicrosoftPowerAutomate.Attributes;

namespace Plumsail.SwashBuckle.MicrosoftPowerAutomate.Extensions
{
    internal static class MetadataAttributeExtensions
    {
        internal static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetSwaggerExtensions(this MetadataAttribute attribute)
        {
            if (attribute is null)
                yield break;

            if (attribute.Visibility != VisibilityType.Default)
                yield return new KeyValuePair<string, IOpenApiExtension>(Constants.XMsVisibility, new OpenApiString(attribute.Visibility.ToString().ToLowerInvariant()));
            if (attribute.Summary != null)
                yield return new KeyValuePair<string, IOpenApiExtension>(Constants.XMsSummary, new OpenApiString(attribute.Summary));
            if (attribute.Description != null)
                yield return new KeyValuePair<string, IOpenApiExtension>(Constants.Description, new OpenApiString(attribute.Description));
        }

        internal static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetSwaggerOperationExtensions(this MetadataAttribute attribute)
        {
            if (attribute is null)
                yield break;

            if (attribute.Visibility != VisibilityType.Default)
                yield return new KeyValuePair<string, IOpenApiExtension>(Constants.XMsVisibility, new OpenApiString(attribute.Visibility.ToString().ToLowerInvariant()));
            if (attribute.Summary != null)
                yield return new KeyValuePair<string, IOpenApiExtension>(Constants.Summary, new OpenApiString(attribute.Summary));
            if (attribute.Description != null)
                yield return new KeyValuePair<string, IOpenApiExtension>(Constants.Description, new OpenApiString(attribute.Description));
        }
    }
}