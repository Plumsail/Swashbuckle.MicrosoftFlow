using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.VendorExtensionEntities;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Filters;

internal class ConnectorMetadataFilter : IDocumentFilter
{
    private readonly ConnectorMetadataModel _model;

    public ConnectorMetadataFilter(ConnectorMetadataModel model)
    {
        _model = model;
    }

    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        swaggerDoc.Extensions.Add(Constants.XMsConnectorMetadata, new OpenApiArray
        {
            new OpenApiObject
            {
                { Constants.PropertyName, new OpenApiString("Website") },
                { Constants.PropertyValue, new OpenApiString(_model.Website) }
            },
            new OpenApiObject
            {
                { Constants.PropertyName, new OpenApiString("Privacy policy") },
                { Constants.PropertyValue, new OpenApiString(_model.PrivacyPolicy) }
            },
            new OpenApiObject
            {
                { Constants.PropertyName, new OpenApiString("Categories") },
                { Constants.PropertyValue, new OpenApiString(string.Join(';', _model.Categories)) }
            }
        });
        
    }
}