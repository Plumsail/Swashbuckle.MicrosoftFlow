﻿using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.VendorExtensionEntities
{
    public class FilePickerOperationModel
    {
        /// <summary>
        /// Lookup operation ID, use swagger operation ID of action to call
        /// </summary>
        [JsonPropertyName("operationId")]
        public string OperationId { get; }

        /// <summary>
        /// Parameter value to pass to lookup operation
        /// </summary>
        [JsonPropertyName("parameters")]
        public Dictionary<string, FilePickerParameterValue> Parameters { get; }

        /// <param name="operationId">
        /// Lookup operation ID, use swagger operation ID of action to call
        /// </param>
        /// <param name="parameters">
        /// Parameter value to pass to operation
        /// Dictionary key - parameter name in lookup operation
        /// Dictionary value - property from object, returned by lookup operation,
        /// whose value will be used
        /// if null - don't generate parameters section in swagger
        /// </param>
        public FilePickerOperationModel(string operationId, Dictionary<string, string> parameters)
        {
            //no operation - dont create parameters
            if (string.IsNullOrEmpty(operationId))
                return;

            OperationId = operationId;
            Parameters = parameters?.ToDictionary(x => x.Key, x => new FilePickerParameterValue(x.Value));
        }
    }

    public class FilePickerParameterValue
    {
        [JsonPropertyName("value-property")]
        public string Value { get; }

        public FilePickerParameterValue(string value)
        {
            Value = value;
        }
    }
}