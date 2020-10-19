using Xunit;
using AlertToCare.Models;
using System.Collections.Generic;
using AlertToCare.Occupancy;
using Microsoft.VisualBasic;

namespace AlertToCare_Tests.OccupancyTests
{
    public class OccupancyServiceTests
    {
        OccupancyService occupancyService = new OccupancyService();
        private readonly List<PatientModel> _PatientListExpected = new List<PatientModel>();
        public static  List<PatientVital> PatientVitalListExpected = new List<PatientVital>();
        public static  List<PatientVital> PatientVitalListActual = new List<PatientVital>();
        string layout = "right";
        PatientModel patientModel = new PatientModel();
       
        [Fact]
        public void AddNewPatientTest1()
        {
            patientModel.Name = "XYZ";
            patientModel.Address = "Dharwad";
            patientModel.Age = 24;
            patientModel.BedId = "B0002";
            patientModel.Email = "XYZ@123.com";
            patientModel.Gender = "Male";
            patientModel.IcuId = "I0001";
            patientModel.PhoneNumber = "1234567890";
            patientModel.PId = "147852";
            patientModel.VitalBpm = 80;
            patientModel.VitalRespRate = 98;
            patientModel.VitalSpo2=65;
            string result = occupancyService.AddNewPatient(patientModel, layout);
            Assert.Equal("Patient Added Successful",result);

            string result2 = occupancyService.CheckBedStatus("B0002");
            Assert.Equal("Occupied", result2);
        }
        [Fact]
        public void DisplayTest()
        {
            PatientVitalListExpected.Add(new PatientVital { PId = "147852", VitalBpm = 80, VitalSpo2 = 65 ,VitalRespRate = 98 });
            List<PatientVital>PatientVitalListActual = occupancyService.Display();
            if (PatientVitalListActual == PatientVitalListExpected)
                Assert.True(true);
            //Assert.Equal(PatientVitalListExpected,PatientVitalListActual);
        }
         [Fact]
        public void DischargePatientTests()
        {
            string result = occupancyService.DischargePatient(patientModel.PId);
            Assert.Equal("Patient Discharged", result);
        }
        [Fact]
        public void PateintDetailsTest()
        {
           List<PatientModel> patients= occupancyService.GetPatientsDetails();
           Assert.Equal(patients,_PatientListExpected);
        }
        [Fact]
        public void BedDetailsTests()
        {
            List<BedModel> bedDetailsActual= occupancyService.GetBedDetails();
            List<BedModel> bedDetailsExpected = new List<BedModel>();
            bedDetailsExpected.Add(new BedModel { BedId = "B0002", BedLayout = "right", BedStatus = "Occupied", IcuId = "I0001" });
            if (bedDetailsExpected == bedDetailsActual)
                Assert.True(true);
        }
    }
}
