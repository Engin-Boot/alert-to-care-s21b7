using System.Collections.Generic;
using System.Net;
using AlertToCare.Models;
using RestSharp;
using RestSharp.Serialization.Json;
using Xunit;

namespace AutomationTests
{
    public class OccupancyAutomationTests
    {
        private readonly RestClient _client;
        private RestRequest _request;
        private readonly JsonDeserializer _deserializer;

        public OccupancyAutomationTests()
        {
            _client = new RestClient("http://localhost:5000/api");
            _deserializer = new JsonDeserializer();
        }

        [Fact]
        public void WhenQueryServerToGetAllPatientsAssertNoException()
        {
            _request = new RestRequest("Occupancy/GetAllPatients", Method.GET){RequestFormat = DataFormat.Json};
            var response = _client.Execute(_request);
            var result = _deserializer.Deserialize<Dictionary<string, PatientModel>>(response);
            Assert.NotNull(result);
        }

        [Fact]
        public void WhenQueryServerToGetAllPatientsInParticularIcuAssertNoException()
        {
            _request = new RestRequest("Occupancy/ICU01", Method.GET) { RequestFormat = DataFormat.Json };
            var response = _client.Execute(_request);
            var result = _deserializer.Deserialize<Dictionary<string, PatientModel>>(response);
            Assert.NotNull(result);
        }

        [Fact]
        public void WhenQueryServerToGetAllBedsAssertNotEmpty()
        {
            _request = new RestRequest("Occupancy/GetBedDetails", Method.GET) { RequestFormat = DataFormat.Json };
            var response = _client.Execute(_request);
            var result = _deserializer.Deserialize<Dictionary<string, PatientModel>>(response);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void WhenQueryServerToCheckBedStatusOfOccupiedBedReturnFalse()
        {
            _request = new RestRequest("Occupancy/GetBedStatus/1", Method.GET) { RequestFormat = DataFormat.Json };
            var response = _client.Execute(_request);
            var result = _deserializer.Deserialize<bool>(response);
            Assert.False(result);
        }
        [Fact]
        public void WhenQueryServerToAddAndRemoveAddedPatientAssertNoException()
        {
            var newPatient = new PatientModel()
            {
                Address = "Dummy",
                Age = 10,
                BedId = 1,
                Email = "bkskdjj",
                Gender = "Male",
                IcuId = "ICU01",
                Name = "Abcd",
                PhoneNumber = "9999999999",
                PId = "778"
            };
            _request = new RestRequest("Occupancy", Method.POST) { RequestFormat = DataFormat.Json };
            _request.AddJsonBody(newPatient);
            //_request.AddQueryParameter("newPatient", newPatient.ToString());
            var response = _client.Execute(_request);
            var result = _deserializer.Deserialize<object>(response);
            Assert.NotNull(result);
            DischargePatient(newPatient.PId);
        }

        private void DischargePatient(string pid)
        {
            _request = new RestRequest($"Occupancy/Discharge/{pid}", Method.DELETE) {RequestFormat = DataFormat.Json};
            var response = _client.Execute(_request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void WhenQueryServerToBedBedDetailsForGivenIcuAssertHttpStatusOk()
        {
            _request = new RestRequest("Occupancy/GetBedDetailsForIcu/ICU01", Method.GET) { RequestFormat = DataFormat.Json };
            var response = _client.Execute(_request);
            //var result = Deserializer.Deserialize<List<BedModel>>(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
