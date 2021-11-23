using Microsoft.AspNetCore.Mvc;
using Plumsail.SwashBuckle.MicrosoftPowerAutomate.Attributes;
using TestApi.Models;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriggerController : ControllerBase
    {
        [HttpPost]
        [Trigger(TriggerType.Subscription, typeof(TriggerAnswerModel), "TriggerFriendlyName")]
        public IActionResult TriggerSubscription()
        {
            return Ok();
        }
    }
}
