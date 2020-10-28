using System;
using System.Collections.Generic;
using System.Text;
using AlertToCare.Models;
using RestSharp;
using RestSharp.Serialization.Json;
using Xunit;

namespace AutomationTests
{
    public class MonitoringTest
    {
        private RestClient Client { get; set; }
        private RestRequest _request;
        private JsonDeserializer Deserializer { get; set; }

        public MonitoringTest()
        {
            Client = new RestClient("http://localhost:5000/api");
            Deserializer = new JsonDeserializer();
        }
        [Fact]
        public void GetAllPatientVitals()
        {
            _request = new RestRequest("Monitor/GeAllPatientVitals", Method.GET){RequestFormat = DataFormat.Json};
            var response = Client.Execute(_request);
            var result = Deserializer.Deserialize<Dictionary<string, PatientVital>>(response);
            Assert.NotNull(result);
        }
    }
}
