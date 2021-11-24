using Microsoft.OpenApi.Models;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Attributes;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Extensions;
using Swashbuckle.AspNetCore.SwaggerGen;
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
        }

        private static void ApplyTriggerBatchModeAndResponse(OpenApiOperation operation, OperationFilterContext context)
        {
            var triggerInfo = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                                     .Union(context.MethodInfo.GetCustomAttributes(true))
                                     .OfType<TriggerAttribute>().SingleOrDefault();

            operation.Extensions.AddRange(triggerInfo.GetSwaggerOperationExtensions(context));
            operation.Responses.AddRange(triggerInfo.GetSwaggerOperationResponses(context));
        }
    }
}