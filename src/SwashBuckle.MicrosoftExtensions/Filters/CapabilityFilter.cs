using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using SwashBuckle.MicrosoftExtensions.VendorExtensionEntities;

namespace SwashBuckle.MicrosoftExtensions.Filters
{
    internal class CapabilityFilter : IDocumentFilter
    {
        private readonly FilePickerCapabilityModel m_filePickerCapability;

        public CapabilityFilter (FilePickerCapabilityModel capability)
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