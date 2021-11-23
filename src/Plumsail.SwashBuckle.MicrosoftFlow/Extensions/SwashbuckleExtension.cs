using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Plumsail.SwashBuckle.MicrosoftPowerAutomate.Filters;
using Plumsail.SwashBuckle.MicrosoftPowerAutomate.VendorExtensionEntities;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

namespace Plumsail.SwashBuckle.MicrosoftPowerAutomate.Extensions
{
    /// <summary>
    /// Swagger generation opetions extensions
    /// </summary>
    public static class SwashbuckleExtension
    {
        /// <summary>
        /// Enables microsoft extension generation
        /// </summary>
        /// <param name="filePicker">File picker capability used for microsoft extension generation</param>
        public static void GenerateMicrosoftExtensions(this SwaggerGenOptions options, FilePickerCapabilityModel filePicker = null)
        {
            options.OperationFilter<OperationFilter>();
            options.SchemaFilter<SchemaFilter>();
            options.RequestBodyFilter<RequestBodyFilter>();
            options.DocumentFilter<DocumentFilter>();

            if (filePicker != null)
                options.DocumentFilter<CapabilityFilter>(filePicker);
        }

        /// <summary>
        /// No type for enums in query parameters (using SerializeAsV2)
        /// https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/1329
        /// </summary>
        /// <param name="options"></param>
        public static void MapEnumsAsV2(this SwaggerGenOptions options)
        {
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var t in a.GetTypes())
                {
                    if (t.IsEnum)
                    {
                        options.MapType(t, () => new OpenApiSchema
                        {
                            Type = "string",
                            Enum = t.GetEnumNames().Select(name => new OpenApiString(name)).Cast<IOpenApiAny>().ToList(),
                            Nullable = true
                        });
                    }
                }
            }
        }
    }
}