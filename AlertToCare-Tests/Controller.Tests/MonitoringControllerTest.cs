using AlertToCare.Controllers;
using AlertToCare.Monitoring;
using Moq;

namespace AlertToCare_Tests.Controller.Tests
{
  public  class MonitoringControllerTest
    {
       
        private readonly MonitorController _monitorController;

        public MonitoringControllerTest()
        {
            var monitorMock = new Mock<IMonitoringRepository>();
           _monitorController = new MonitorController(monitorMock.Object);
        }

        //[Fact]
        //public void PatientVitalGetTest()
        //{
        //    var patientVitalModel = _monitorController.GeAllPatientVitals();
        //    var patientVitalModelStatusCode = patientVitalModel as OkObjectResult;
        //    Assert.NotNull(patientVitalModel);
        //    if (patientVitalModelStatusCode != null)
        //        Assert.Equal(200, patientVitalModelStatusCode.StatusCode);
        //}


        //[Fact]
        //public void PatientVitalUpdateDataTest()
        //{
        //    var vitalUpdateOfPatient = _monitorController.Get();
        //    var vitalUpdateOfPatientStatusCode = vitalUpdateOfPatient as OkObjectResult;
        //    Assert.NotNull(vitalUpdateOfPatient);
        //    if (vitalUpdateOfPatientStatusCode != null)
        //        Assert.Equal(200, vitalUpdateOfPatientStatusCode.StatusCode);

        //}

    }
}
