using AlertToCare.Controllers;
using AlertToCare.Monitoring;
using Xunit;

namespace AlertToCare_Tests.Controller.Tests
{
  public  class MonitoringControllerTest
    {
       
       [Fact]
        public void GetAllPatientMonitoringData()
        {
            var monitoringObj = new MonitorController(new MonitoringRepository());
            var allPatientsData = monitoringObj.GeAllPatientVitals();
            Assert.NotNull(allPatientsData);
        }

    }
}
