using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Attributes;
using System.Collections.Generic;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Extensions
{
    internal static class CallbackUrlAttributeExtensions
    {
        internal static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetSwaggerExtensions(this CallbackUrlAttribute attribute)
        {
            if (attribute is null)
            {
                yield break;
            }


            yield return new KeyValuePair<string, IOpenApiExtension>(
                Constants.XMsNotificationUrl,
                new OpenApiBoolean(true)
            );
        }
    }
}