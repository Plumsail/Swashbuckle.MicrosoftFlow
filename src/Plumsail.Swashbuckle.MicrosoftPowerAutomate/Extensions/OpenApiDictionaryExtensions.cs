﻿using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Interfaces;
using System.Collections.Generic;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Extensions
{
    public static class OpenApiDictionaryExtensions
    {
        public static void ApplyMetadata(this IDictionary<string, IOpenApiExtension> extensions, ParameterDescriptor parameterDescriptor)
        {
            switch (parameterDescriptor)
            {
                case ControllerParameterDescriptor controllerParameterDescriptor:
                    extensions.AddRange(controllerParameterDescriptor.ParameterInfo.GetParameterExtensions());
                    break;
                case ControllerBoundPropertyDescriptor controllerBoundPropertyDescriptor:
                    extensions.AddRange(controllerBoundPropertyDescriptor.PropertyInfo.GetParameterExtensions());
                    break;
            }
        }
    }
}