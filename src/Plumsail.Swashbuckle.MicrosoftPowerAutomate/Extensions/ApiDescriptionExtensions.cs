using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Interfaces;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Attributes;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Extensions
{
    public static class ApiDescriptionExtensions
    {
        public static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetOperationExtensions(this ApiDescription apiDescription)
        {
            var metadataAttribute = apiDescription.CustomAttributes().OfType<MetadataAttribute>().SingleOrDefault();
            var dynamicSchemaAttribute = apiDescription.CustomAttributes().OfType<DynamicSchemaLookupAttribute>().SingleOrDefault();
            var dynaminPropertiesAttribute = apiDescription.CustomAttributes().OfType<DynamicPropertiesLookupAttribute>().SingleOrDefault();

            return metadataAttribute.GetSwaggerOperationExtensions()
                .Concat(dynamicSchemaAttribute.GetSwaggerExtensions())
                .Concat(dynaminPropertiesAttribute.GetSwaggerExtensions());
        }
    }
}