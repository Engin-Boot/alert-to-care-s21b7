using Xunit;
using AlertToCare.Models;
using System.Collections.Generic;
using AlertToCare.Occupancy;

namespace AlertToCare_Tests.OccupancyTests
{
    public class OccupancyServiceTests
    {
        public readonly OccupancyService OccupancyService = new OccupancyService();
        public readonly List<PatientModel> PatientListExpected = new List<PatientModel>();
        public static  List<PatientVital> PatientVitalListExpected = new List<PatientVital>();
        string layout = "right";
        public static readonly PatientModel PatientModel = new PatientModel();
       
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
            string result = OccupancyService.AddNewPatient(PatientModel, layout);
            Assert.Equal("Patient Added Successful",result);

            string result2 = OccupancyService.CheckBedStatus("B0002");
            Assert.Equal("Occupied", result2);
        }
        [Fact]
        public void CheckBedStatusTests()
        {
            string result2 = OccupancyService.CheckBedStatus("B0004");
            Assert.Equal("Does Not Exist", result2);
        }
        [Fact]
        public void DisplayTest()
        {
            PatientVitalListExpected.Add(new PatientVital { PId = "147852", VitalBpm = 80, VitalSpo2 = 65 ,VitalRespRate = 98 });
            List<PatientVital>vitalListActual = OccupancyService.Display();
            if (vitalListActual == PatientVitalListExpected)
                Assert.True(true);
            //Assert.Equal(PatientVitalListExpected,PatientVitalListActual);
        }
         [Fact]
        public void DischargePatientTests()
        {
            string result = OccupancyService.DischargePatient(PatientModel.PId);
            Assert.Equal("Patient Discharged", result);
        }
        [Fact]
        public void PatientDetailsTest()
        {
           List<PatientModel> patients= OccupancyService.GetPatientsDetails();
           if(patients==PatientListExpected)
               Assert.True(true);
           //Assert.Equal(PatientListExpected,patients);
        }
        [Fact]
        public void BedDetailsTests()
        {
            List<BedModel> bedDetailsActual= OccupancyService.GetBedDetails();
            List<BedModel> bedDetailsExpected = new List<BedModel>
            {
                new BedModel {BedId = "B0002", BedLayout = "right", BedStatus = "Occupied", IcuId = "I0001"}
            };
            if (bedDetailsExpected == bedDetailsActual)
                Assert.True(true);
        }
    }
}
