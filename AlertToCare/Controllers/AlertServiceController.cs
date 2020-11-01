using System.Net;
using AlertToCare.Alerters;
using Microsoft.AspNetCore.Mvc;

namespace AlertToCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertServiceController : ControllerBase
    {
        private readonly IEmailAlerter _alerter;
        public AlertServiceController(IEmailAlerter alerter)
        {
            _alerter = alerter;
        }

        [HttpPost]
        [Route("[action]")]
        public object SendEmailAlert(VitalAlertEmailFormat email)
        {
            return email!=null ? _alerter.SendEmailVitalAlert(email) : HttpStatusCode.BadRequest;
        }

    }
}
