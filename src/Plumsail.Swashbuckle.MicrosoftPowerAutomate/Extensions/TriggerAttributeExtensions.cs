using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Attributes;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Helpers;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.VendorExtensionEntities;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Extensions
{
    internal static class TriggerAttributeExtensions
    {
        internal static IEnumerable<KeyValuePair<string, OpenApiResponse>> GetSwaggerOperationResponses(this TriggerAttribute attribute, OperationFilterContext context)
        {
            if (attribute is null || attribute.Pattern == TriggerType.Subscription)
            {
                yield break;
            }

            var schema = null != attribute.DataType
                ? context.SchemaGenerator.GenerateSchema(attribute.DataType, context.SchemaRepository)
                : null;

            var dataResponse = JsonOpenApiResponseFactory.Create(attribute.DataFriendlyName, schema);
            var acceptedResponse = JsonOpenApiResponseFactory.Create(Constants.AcceptedDescription, null);

            yield return new KeyValuePair<string, OpenApiResponse>(Constants.HappyPollWithDataResponseCode, dataResponse);
            yield return new KeyValuePair<string, OpenApiResponse>(Constants.HappyPollNoDataResponseCode, acceptedResponse);
        }

        internal static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetSwaggerOperationExtensions(this TriggerAttribute attribute, OperationFilterContext context)
        {
            if (attribute is null)
            {
                yield break;
            }

            var batchMode = Constants.Single;
            switch (attribute.Pattern)
            {
                case TriggerType.PollingBatched:
                    batchMode = Constants.Batch;
                    break;
                case TriggerType.PollingSingle:
                    break;
                case TriggerType.Subscription:
                    yield return new KeyValuePair<string, IOpenApiExtension>(Constants.XMsNotificationContent, GetCallbackType(context, attribute.DataType, attribute.DataFriendlyName));
                    break;
            }

            yield return new KeyValuePair<string, IOpenApiExtension>(Constants.XMsTrigger, new OpenApiString(batchMode.ToLowerInvariant()));
        }

        private static NotificationContentExtension GetCallbackType(OperationFilterContext context, Type callbackType, string description)
        {
            var schemaInfo = context.SchemaGenerator.GenerateSchema(callbackType, context.SchemaRepository);

            var notificationData = new NotificationContentExtension
            {
                Description = description,
                Schema = schemaInfo
            };

            return notificationData;
        }
    }
}