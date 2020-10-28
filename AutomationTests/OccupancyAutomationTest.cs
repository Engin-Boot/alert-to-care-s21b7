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
        private RestClient Client { get; set; }
        private RestRequest _request;
        private JsonDeserializer Deserializer { get; set; }

        public OccupancyAutomationTests()
        {
            Client = new RestClient("http://localhost:5000/api");
            Deserializer = new JsonDeserializer();
        }

        [Fact]
        public void GetAllPatients()
        {
            _request = new RestRequest("Occupancy/GetAllPatients", Method.GET){RequestFormat = DataFormat.Json};
            var response = Client.Execute(_request);
            var result = Deserializer.Deserialize<Dictionary<string, PatientModel>>(response);
            Assert.NotNull(result);
        }

        [Fact]
        public void GetPatientsInIcu()
        {
            _request = new RestRequest("Occupancy/ICU01", Method.GET) { RequestFormat = DataFormat.Json };
            var response = Client.Execute(_request);
            var result = Deserializer.Deserialize<Dictionary<string, PatientModel>>(response);
            Assert.NotNull(result);
        }

        [Fact]
        public void GetAllBeds()
        {
            _request = new RestRequest("Occupancy/GetBedDetails", Method.GET) { RequestFormat = DataFormat.Json };
            var response = Client.Execute(_request);
            var result = Deserializer.Deserialize<Dictionary<string, PatientModel>>(response);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetBedStatus()
        {
            _request = new RestRequest("Occupancy/GetBedStatus/1", Method.GET) { RequestFormat = DataFormat.Json };
            var response = Client.Execute(_request);
            var result = Deserializer.Deserialize<bool>(response);
            Assert.True(result);
        }
        [Fact]
        public void AddNewPatient()
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
            var response = Client.Execute(_request);
            var result = Deserializer.Deserialize<object>(response);
            Assert.NotNull(result);
            DischargePatient(newPatient.PId);
        }

        private void DischargePatient(string pid)
        {
            _request = new RestRequest($"Occupancy/Discharge/{pid}", Method.DELETE) {RequestFormat = DataFormat.Json};
            var response = Client.Execute(_request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void GetBedStatusFor()
        {
            _request = new RestRequest($"Occupancy/GetBedDetailsForIcu/ICU01", Method.GET) { RequestFormat = DataFormat.Json };
            var response = Client.Execute(_request);
            //var result = Deserializer.Deserialize<List<BedModel>>(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
