using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Extensions;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Filters
{
    public sealed class RequestBodyFilter : IRequestBodyFilter
    {
        /// <inheritdoc />
        public void Apply(OpenApiRequestBody requestBody, RequestBodyFilterContext context)
        {
            if (requestBody is null || context is null)
                return;

            requestBody.Extensions.AddRange(context.BodyParameterDescription?.GetOperationExtensions());
            requestBody.Extensions.ApplyMetadata(context.BodyParameterDescription?.ParameterDescriptor);

            var parameterInfo = context.BodyParameterDescription?.ParameterInfo();

            // Body parameter name always equals "body" without the code above
            // https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/1478
            if (parameterInfo != null)
            {
                requestBody.Extensions.Add("x-bodyName", new OpenApiString(parameterInfo.Name));
            }
        }
    }
}
