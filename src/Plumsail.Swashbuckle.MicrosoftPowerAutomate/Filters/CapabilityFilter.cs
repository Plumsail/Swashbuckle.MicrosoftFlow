using Microsoft.OpenApi.Models;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.VendorExtensionEntities;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Filters
{
    internal class CapabilityFilter : IDocumentFilter
    {
        private readonly FilePickerCapabilityModel m_filePickerCapability;

        public CapabilityFilter(FilePickerCapabilityModel capability)
        {
            m_filePickerCapability = capability;
        }

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            AddFilePickerCapabilityExtension(swaggerDoc);
        }

        private void AddFilePickerCapabilityExtension(OpenApiDocument swaggerDoc)
        {
            swaggerDoc.Extensions.Add
            (
                Constants.XMsCapabilities,
                Helpers.OpenApiAnyFactory.ForValue(new Dictionary<string, object> { { Constants.FilePicker, m_filePickerCapability } })
            );
        }
    }
}