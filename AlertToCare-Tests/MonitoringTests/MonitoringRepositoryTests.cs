using AlertToCare.Monitoring;
using Xunit;

namespace AlertToCare_Tests.MonitoringTests
{
    public class MonitoringTest
    {
        [Fact]
        public void EmailTester()
        {
            var alerterObj = new Alerter.EmailAlert();
            var response = alerterObj.Alert("Test Message");
            Assert.True(response);
        }
    }
}