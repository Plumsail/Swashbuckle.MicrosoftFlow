using Microsoft.OpenApi.Models;
using Plumsail.SwashBuckle.MicrosoftPowerAutomate;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Plumsail.SwashBuckle.MicrosoftPowerAutomate.Filters
{
    public class DocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            // This iterates through the paths and "moves up" any x-ms-notification-content
            // vendor extension values to the path level where the designer expects them to live
            foreach (var path in swaggerDoc.Paths.Keys)
            {
                var currentPath = swaggerDoc.Paths[path];

                var postOperation = currentPath.Operations.ContainsKey(OperationType.Post) ? currentPath.Operations[OperationType.Post] : null;

                if (postOperation?.Extensions == null || !postOperation.Extensions.ContainsKey(Constants.XMsNotificationContent))
                {
                    continue;
                }

                currentPath.Extensions[Constants.XMsNotificationContent] = postOperation.Extensions[Constants.XMsNotificationContent];
                postOperation.Extensions.Remove(Constants.XMsNotificationContent);
            }
        }
    }
}