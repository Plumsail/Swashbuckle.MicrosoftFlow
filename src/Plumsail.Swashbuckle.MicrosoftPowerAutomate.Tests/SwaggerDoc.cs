﻿using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Swashbuckle.MicrosoftExtensions.Tests
{
    public class SwaggerDocument
    {
        public IDictionary<string, Schema> Definitions;
        public Info Info;
        public IDictionary<string, Parameter> Parameters;
        public IDictionary<string, PathItem> Paths;
        [JsonExtensionData]
        public Dictionary<string, object> VendorExtensions;
    }

    public class Schema
    {
        public string[] Required;
        public string Type;
        public string Description;
        public Dictionary<string, Schema> Properties;
        [JsonExtensionData]
        public Dictionary<string, object> Extensions;
    }

    public class Info
    {
        public string Title;
        public string Version;
        [JsonExtensionData]
        public Dictionary<string, object> VendorExtensions;
    }

    public class Parameter
    {
        public string Name;
        public string In;
        public string Type;
        [JsonExtensionData]
        public Dictionary<string, object> VendorExtensions;
    }

    public class PathItem
    {
        public Operation Get;
        public Operation Post;
        public Operation Put;
        [JsonExtensionData]
        public Dictionary<string, object> VendorExtensions;
    }

    public class Operation
    {
        public IList<Parameter> Parameters;
        public IDictionary<string, Response> Responses;
        [JsonExtensionData]
        public Dictionary<string, object> VendorExtensions;
    }

    public class Response
    {
        public string Description;
        public OpenApiSchema Schema;
    }
}