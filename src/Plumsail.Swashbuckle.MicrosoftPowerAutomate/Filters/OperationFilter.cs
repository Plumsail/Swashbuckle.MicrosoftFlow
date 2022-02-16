using Microsoft.OpenApi.Models;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Attributes;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Extensions;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Filters
{
    internal class OperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation is null || context is null)
                return;

            operation.Extensions.AddRange(context.ApiDescription.GetOperationExtensions());
            operation.Parameters.ApplyMetadata(context.ApiDescription.ActionDescriptor.Parameters);

            ApplyTriggerBatchModeAndResponse(operation, context);
            ApplyBinaryResponse(operation, context);
        }

        private static void ApplyTriggerBatchModeAndResponse(OpenApiOperation operation, OperationFilterContext context)
        {
            var triggerInfo = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                                     .Union(context.MethodInfo.GetCustomAttributes(true))
                                     .OfType<TriggerAttribute>().SingleOrDefault();

            operation.Extensions.AddRange(triggerInfo.GetSwaggerOperationExtensions(context));
            operation.Responses.AddRange(triggerInfo.GetSwaggerOperationResponses(context));
        }

        private static void ApplyBinaryResponse(OpenApiOperation operation, OperationFilterContext context)
        {
            var attribute = context.ApiDescription.CustomAttributes()
                .OfType<BinaryResponseAttribute>()
                .FirstOrDefault();

            if (attribute == null) { return; }

            var responseSchema = new OpenApiSchema
            {
                Title = attribute.Summary,
                Description = attribute.Description,
                Format = "binary",
                Type = "string",
            };
            var responseDescription = !string.IsNullOrEmpty(attribute.Description) ? attribute.Description : attribute.Summary;
            var response = new OpenApiResponse
            {
                Description = responseDescription,
                Content = new Dictionary<string, OpenApiMediaType>
                {
                    [attribute.ContentType] = new()
                    {
                        Schema = responseSchema
                    }
                }
            };

            if (operation.Responses.ContainsKey(attribute.StatusCode.ToString()))
            {
                operation.Responses[attribute.StatusCode.ToString()] = response;
            }
            else
            {
                operation.Responses.Add(attribute.StatusCode.ToString(), response);
            }
        }
    }
}