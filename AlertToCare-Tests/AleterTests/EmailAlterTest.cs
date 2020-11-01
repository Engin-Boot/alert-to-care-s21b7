using System.Net;
using AlertToCare.Alerters;
using AlertToCare.Controllers;
using Xunit;

namespace AlertToCare_Tests.AleterTests
{
    public class EmailAlertTest
    {
        [Fact]
        public void EmailTester()
        {
            var alerterObj = new EmailAlertService();
            var email = new VitalAlertEmailFormat("Ambani", "100", "ICU01", 01, "WARNING");
            var response = alerterObj.SendEmailVitalAlert(email);
            Assert.Equal(HttpStatusCode.OK, response);
        }

        [Fact]
        public void EmailAlertControllerTest()
        {
            var alterter = new EmailAlertService();
            var aleterController = new AlertServiceController(alterter);
            var email = new VitalAlertEmailFormat("Test", "100", "ICU01", 01, "EMERGENCY");
            var response = aleterController.SendEmailAlert(email);
            Assert.Equal(HttpStatusCode.OK, response);

        }
    }
}