using Microsoft.AspNetCore.Mvc;
using Plumsail.Swashbuckle.MicrosoftPowerAutomate.Attributes;
using System;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinaryResponseController : ControllerBase
    {
        [HttpGet]
        [BinaryResponse(200, "BinaryResponseSummary", "application/octet-stream", "BinaryResponseDescription")]
        public IActionResult BinaryResponse()
        {
            return File(Array.Empty<byte>(), "application/octet-stream");
        }
    }
}
