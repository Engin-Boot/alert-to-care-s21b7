using System.Net;
using AlertToCare.Controllers;
using AlertToCare.Models;
using AlertToCare.Occupancy;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
namespace AlertToCare_Tests.Controller.Tests
{
   public class OccupancyControllerTest
    {
        private readonly BedModel _bedModel = new BedModel()
        {
            BedId = "b0001",
            IcuId = "I0001",
            BedLayout = "Left",
            BedStatus = "Free"
        };

        private readonly PatientModel _patientModel = new PatientModel()
        {
            PId= "p0001",
            Name = "xyz",
            Age=21,
            Gender = "Female",
            Email ="xyz@gmail.com",
            PhoneNumber = "9876543210",
            Address = "Bangalore",
            VitalBpm = 75,
            VitalSpo2 = 75,
            VitalRespRate = 75,
            IcuId  ="I0001",
            BedId = "b0001"

        };



        private readonly OccupancyController _occupancyController;

        public OccupancyControllerTest()
        {
            var occupancyMock = new Mock<IOccupancyService>();
            _occupancyController = new OccupancyController(occupancyMock.Object);
        }

        [Fact]
        public void PatientModelDataGetTest()
        {
            //var patientModel = _occupancyController.Get();
            //var patientModelStatusCode = patientModel as OkObjectResult;
            var patientModel = _occupancyController.GetAllPatients();
            if (patientModel is OkObjectResult patientModelStatusCode)
                Assert.Equal(200, patientModelStatusCode.StatusCode);
        }

        [Fact]
        public void BedDetailsStatusTest()
        {
            //var bedStatus = _occupancyController.GetBedDetails();
            //var bedStatusCode =bedStatus as OkObjectResult;
            var bedStatus = _occupancyController.GetBedDetails();
            if (bedStatus is OkObjectResult bedStatusCode)
                Assert.Equal(200, bedStatusCode.StatusCode);
        }

        [Fact]
        public void CheckBedStatusByIdCheckTest()
        {
            var bedStatusById = _occupancyController.Get(_bedModel.BedId);
            var bedStatusByIdCode = bedStatusById as OkObjectResult;
            Assert.NotNull(bedStatusById);
            if (bedStatusByIdCode != null)
                Assert.Equal(200, bedStatusByIdCode.StatusCode);
        }

        [Fact]
        public void PatientModelDataPostTest()
        {
            var patientModelDataPost = _occupancyController.Post(_patientModel,_bedModel.BedLayout);
            var patientModelDataPostStatusCode = patientModelDataPost as OkObjectResult;
            Assert.NotNull(patientModelDataPost);
            if (patientModelDataPostStatusCode != null)
                Assert.Equal(200, patientModelDataPostStatusCode.StatusCode);
        }

        [Fact]
        public void DischargePatientTest()
        {
            var dischargePatient = _occupancyController.Delete(_patientModel.PId);
            var dischargePatientStatusCode = dischargePatient as OkObjectResult;
            Assert.NotNull(dischargePatient);
            if (dischargePatientStatusCode != null)
                Assert.Equal(200, dischargePatientStatusCode.StatusCode);
        }

        [Fact]
        public void BedDetailsStatusForIcuTest()
        {
            var bedStatus = _occupancyController.GetBedDetailsForIcu("I0001");
            if (bedStatus is OkObjectResult bedStatusCode)
                Assert.Equal(200, bedStatusCode.StatusCode);
        }

        [Fact]
        public void PatientModelDataGetForIcuTest()
        {
            var patientModel = _occupancyController.Get("I0001");
            if (patientModel is OkObjectResult patientModelStatusCode)
                Assert.Equal(200, patientModelStatusCode.StatusCode);
        }

        [Fact]
        public void GetBedStatusTest()
        {
            var status = _occupancyController.GetBedStatus("b0001");
            if (status is OkObjectResult bedStatusCode)
                Assert.Equal(200, bedStatusCode.StatusCode);
        }
    }
}
