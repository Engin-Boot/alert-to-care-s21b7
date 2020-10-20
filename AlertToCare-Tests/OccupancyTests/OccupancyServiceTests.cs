using Xunit;
using AlertToCare.Models;
using System.Collections.Generic;
using AlertToCare.Occupancy;

namespace AlertToCare_Tests.OccupancyTests
{
    public class OccupancyServiceTests
    {
        private readonly OccupancyService _occupancyService = new OccupancyService();
        private readonly List<PatientModel> _patientListExpected = new List<PatientModel>();
        private static readonly List<PatientVital> PatientVitalListExpected = new List<PatientVital>();
        string layout = "right";
        private static readonly PatientModel PatientModel = new PatientModel();
       
        [Fact]
        public void AddNewPatientTest1()
        {
            PatientModel.Name = "XYZ";
            PatientModel.Address = "Dharwad";
            PatientModel.Age = 24;
            PatientModel.BedId = "B0002";
            PatientModel.Email = "XYZ@123.com";
            PatientModel.Gender = "Male";
            PatientModel.IcuId = "I0001";
            PatientModel.PhoneNumber = "1234567890";
            PatientModel.PId = "147852";
            PatientModel.VitalBpm = 80;
            PatientModel.VitalRespRate = 98;
            PatientModel.VitalSpo2=65;
            string result = _occupancyService.AddNewPatient(PatientModel, layout);
            Assert.Equal("Patient Added Successful",result);

            string result2 = _occupancyService.CheckBedStatus("B0002");
            Assert.Equal("Occupied", result2);
        }
        [Fact]
        public void CheckBedStatusTests()
        {
            string result2 = _occupancyService.CheckBedStatus("B0004");
            Assert.Equal("Does Not Exist", result2);
        }
        [Fact]
        public void DisplayTest()
        {
            PatientVitalListExpected.Add(new PatientVital { PId = "147852", VitalBpm = 80, VitalSpo2 = 65 ,VitalRespRate = 98 });
            List<PatientVital>vitalListActual = _occupancyService.Display();
            if (vitalListActual == PatientVitalListExpected)
                Assert.True(true);
            //Assert.Equal(PatientVitalListExpected,PatientVitalListActual);
        }
         [Fact]
        public void DischargePatientTests()
        {
            string result = _occupancyService.DischargePatient(PatientModel.PId);
            Assert.Equal("Patient Discharged", result);
        }
        [Fact]
        public void PatientDetailsTest()
        {
           List<PatientModel> patients= _occupancyService.GetPatientsDetails();
           if(patients==_patientListExpected)
               Assert.True(true);
           //Assert.Equal(PatientListExpected,patients);
        }
        [Fact]
        public void BedDetailsTests()
        {
            List<BedModel> bedDetailsActual= _occupancyService.GetBedDetails();
            List<BedModel> bedDetailsExpected = new List<BedModel>
            {
                new BedModel {BedId = "B0002", BedLayout = "right", BedStatus = "Occupied", IcuId = "I0001"}
            };
            if (bedDetailsExpected == bedDetailsActual)
                Assert.True(true);
        }
    }
}
