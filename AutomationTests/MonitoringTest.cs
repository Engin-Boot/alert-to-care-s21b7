using System.Collections.Generic;
using AlertToCare.Models;
using RestSharp;
using RestSharp.Serialization.Json;
using Xunit;

namespace AutomationTests
{
    public class MonitoringTest
    {
        private readonly RestClient _client;
        private RestRequest _request;
        private readonly JsonDeserializer _deserializer;

        public MonitoringTest()
        {
            _client = new RestClient("http://localhost:5000/api");
            _deserializer = new JsonDeserializer();
        }
        [Fact]
        public void GetAllPatientVitals()
        {
            _request = new RestRequest("Monitor/GeAllPatientVitals", Method.GET){RequestFormat = DataFormat.Json};
            var response = _client.Execute(_request);
            var result = _deserializer.Deserialize<Dictionary<string, PatientVital>>(response);
            Assert.NotNull(result);
        }
    }
}
