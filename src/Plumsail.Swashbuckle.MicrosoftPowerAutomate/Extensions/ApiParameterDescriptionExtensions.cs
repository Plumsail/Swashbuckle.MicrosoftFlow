using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Interfaces;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Attributes;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Extensions
{
    public static class ApiParameterDescriptionExtensions
    {
        public static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetOperationExtensions(this ApiParameterDescription apiDescription)
        {
            if (apiDescription == null)
            {
                return Enumerable.Empty<KeyValuePair<string, IOpenApiExtension>>();
            }

            var metadataAttribute = apiDescription.CustomAttributes().OfType<MetadataAttribute>().SingleOrDefault();
            var dynamicSchemaAttribute = apiDescription.CustomAttributes().OfType<DynamicSchemaLookupAttribute>().SingleOrDefault();
            var extensions = metadataAttribute.GetSwaggerOperationExtensions();
            return extensions.Concat(dynamicSchemaAttribute.GetSwaggerExtensions());
        }
    }
}