﻿using Microsoft.AspNetCore.Mvc;
using Plumsail.SwashBuckle.MicrosoftPowerAutomate.Attributes;
using TestApi.Models;

namespace TestApi.Controllers
{
    public class DynamicValueCapabilityController : Controller
    {
        [HttpGet]
        [Route("api/capability")]
        public DynamicValueLookupCapabilityClass Get
        (
            [DynamicValueLookupCapability("capabilityName", "id", "name", parameters: "isFolder=true&test=static&test2={dynamic}")]
            string dynamicValue
        )
        {
            return null;
        }
    }
}