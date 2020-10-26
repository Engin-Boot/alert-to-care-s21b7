using Xunit;
using AlertToCare.Models;
using System.IO;
using System.Net;
using System.Reflection;
using AlertToCare.Occupancy;

namespace AlertToCare_Tests.OccupancyTests
{
    public class OccupancyServiceTests
    {
        private static string GetDbPathForTesting()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var dbPath = Path.GetFullPath(Path.Combine(path ?? string.Empty, @"..\..\..\Hospital.db"));
            return dbPath;
        }

        private OccupancyService GetOccupancyObject()
        {
            return new OccupancyService();
        }
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

        [Fact]
        public void AddNewPatientTest1()
        {
            var dbPath = GetDbPathForTesting();
            var newPatient = new PatientModel()
            {
                PId = "P1001",
                Name = "Ashok1",
                Address = "Bangalore",
                Age = 10,
                BedId = 1,
                Email = "ashok.111@gmail.com",
                Gender = "Male",
                IcuId = "ICU01",
                PhoneNumber = "9999898999"
            };
            var occupancyObj = GetOccupancyObject();
            Assert.Equal(HttpStatusCode.OK, occupancyObj.AddNewPatient(newPatient, dbPath));
            Assert.True(HttpStatusCode.OK.Equals(occupancyObj.DischargePatient("P1001", dbPath)));
        }

        [Fact]
        public void CheckIfBedIfFree()
        {
            var occupancyObj = GetOccupancyObject();
            Assert.True(occupancyObj.IsBedFree(1, GetDbPathForTesting()));
        }

        [Fact]
        public void GetAllBedsTest()
        {
            var occupancyObj = GetOccupancyObject();
            var allBeds = occupancyObj.GetBedDetails(GetDbPathForTesting());
            Assert.NotNull(allBeds);
        }

        [Fact]
        public void GetPatientsForGivenIcu()
        {
            var occupancyObj = GetOccupancyObject();
            var allPatientsInIcu = occupancyObj.GetPatientsDetailsInIcu("ICU01", GetDbPathForTesting());
            Assert.NotNull(allPatientsInIcu);
        }


        [Fact]
        public void WhenIcuDetailsAreProvidedGetAllBedsWithinIcu()
        {
            var occupancyObj = GetOccupancyObject();
            var result = occupancyObj.GetBedDetailsForIcu("ICU01", GetDbPathForTesting());
            Assert.NotNull(result);
        }
    }



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
}
