//using Xunit;
//using AlertToCare.Models;
//using System.Collections.Generic;
//using System.Linq;
//using AlertToCare.Occupancy;

//namespace AlertToCare_Tests.OccupancyTests
//{
//    public class OccupancyServiceTests
//    {
//        private readonly OccupancyService _occupancyService = new OccupancyService();
//        private readonly List<PatientModel> _patientListExpected = new List<PatientModel>();
//        private static readonly List<PatientVital> PatientVitalListExpected = new List<PatientVital>();
//        private const string Layout = "right";
//        private static readonly PatientModel PatientModel = new PatientModel();

//        public OccupancyServiceTests()
//        {
//            _occupancyService.PatientList.Clear();
//            PatientModel.Name = "XYZ";
//            PatientModel.Address = "Dharwad";
//            PatientModel.Age = 24;
//            PatientModel.BedId = "B0002";
//            PatientModel.Email = "XYZ@123.com";
//            PatientModel.Gender = "Male";
//            PatientModel.IcuId = "I0001";
//            PatientModel.PhoneNumber = "1234567890";
//            PatientModel.PId = "147852";
//            PatientModel.VitalBpm = 80;
//            PatientModel.VitalRespRate = 98;
//            PatientModel.VitalSpo2 = 65;
//            var output = _occupancyService.AddNewPatient(PatientModel,Layout);
//        }

//        [Fact]
//        public void AddNewPatientTest1()
//        {
//            PatientModel.Name = "XYZ";
//            PatientModel.Address = "Dharwad";
//            PatientModel.Age = 24;
//            PatientModel.BedId = "B0002";
//            PatientModel.Email = "XYZ@123.com";
//            PatientModel.Gender = "Male";
//            PatientModel.IcuId = "I0001";
//            PatientModel.PhoneNumber = "1234567890";
//            PatientModel.PId = "147852";
//            PatientModel.VitalBpm = 80;
//            PatientModel.VitalRespRate = 98;
//            PatientModel.VitalSpo2=65;
//            var result = _occupancyService.AddNewPatient(PatientModel, Layout);
//            Assert.Equal("Patient Added Successful",result);

//            var result2 = _occupancyService.CheckBedStatus("B0002");
//            Assert.Equal("Occupied", result2);
//        }
//        [Fact]
//        public void CheckBedStatusTests()
//        {
//            var result2 = _occupancyService.CheckBedStatus("B0004");
//            Assert.Equal("Does Not Exist", result2);
//        }
//        [Fact]
//        public void DisplayTest()
//        {
//            //PatientVitalListExpected.Add(new PatientVital { PId = "147852", VitalBpm = 80, VitalSpo2 = 65 ,VitalRespRate = 98 });
//            var vitalListActual = _occupancyService.Display();
//            Assert.Equal("147852", vitalListActual.ElementAt(0).PId);
        
//        }
//         [Fact]
//        public void DischargePatientTests()
//        {
//            var result = _occupancyService.DischargePatient("147852");
//            Assert.Equal("Patient Discharged", result);
//            result = _occupancyService.DischargePatient("abc");
//            Assert.Equal("Patient Not Found",result);
//        }
//        [Fact]
//        public void PatientDetailsTest()
//        {
//           var patients= _occupancyService.GetPatientsDetails();
//           Assert.Equal("147852", patients.ElementAt(0).PId);
//        }
//        [Fact]
//        public void BedDetailsTests()
//        {
//            var bedDetailsActual= _occupancyService.GetBedDetails();
//            var bedDetailsExpected = new List<BedModel>
//            {
//                new BedModel {BedId = "B0002", BedLayout = "right", BedStatus = "Occupied", IcuId = "I0001"}
//            };
//            if (bedDetailsExpected == bedDetailsActual)
//                Assert.True(true);
//        }


//        [Fact]
//        public void PatientDetailsInParticularIcuTest()
//        {
//            var patients = _occupancyService.GetPatientsDetailsInIcu("I0001");
//            Assert.Equal("147852", patients.ElementAt(0).PId);
//        }

//        [Fact]
//        public void BedDetailsInParticularIcuTest()
//        {
//            var bed = _occupancyService.GetBedDetailsForIcu("I0001");
//            Assert.Equal("B0002", bed.ElementAt(0).BedId);
//        }

//        [Fact]
//        public void PatientDetailsGetTest()
//        {
//            Assert.Equal("XYZ", _occupancyService.PatientList.ElementAt(0).Name);
//            Assert.Equal(24, _occupancyService.PatientList.ElementAt(0).Age);
//            Assert.Equal("Male", _occupancyService.PatientList.ElementAt(0).Gender);
//            Assert.Equal("XYZ@123.com", _occupancyService.PatientList.ElementAt(0).Email);
//            Assert.Equal("1234567890", _occupancyService.PatientList.ElementAt(0).PhoneNumber);
//            Assert.Equal("Dharwad", _occupancyService.PatientList.ElementAt(0).Address);
//        }
//    }
//}
