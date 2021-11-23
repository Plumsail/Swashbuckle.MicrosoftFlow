using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Extensions
{
    public static class OpenApiOperationExtensions
    {
        public static void ApplyMetadata(this IEnumerable<OpenApiParameter> parameters, IList<ParameterDescriptor> parameterDescriptions)
        {
            if (parameters is null)
            {
                return;
            }

            foreach (var operationParameter in parameters)
            {
                var parameterDescription = parameterDescriptions.FirstOrDefault(x => x.Name == operationParameter.Name);
                operationParameter.Extensions.ApplyMetadata(parameterDescription);
            }
        }
    }
}