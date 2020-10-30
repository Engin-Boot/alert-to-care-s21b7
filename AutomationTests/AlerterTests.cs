using System;
using System.Collections.Generic;
using System.Text;
using AlertToCare.Alerters;
using RestSharp;
using RestSharp.Serialization.Json;
using Xunit;

namespace AutomationTests
{
    public class AlerterTests
    {
        private RestClient Client { get; set; }
        private RestRequest _request;
        private JsonDeserializer Deserializer { get; set; }

        public AlerterTests()
        {
            Client = new RestClient("http://localhost:5000/api");
            Deserializer = new JsonDeserializer();
        }
        [Fact]
        public void TestEmailAlert()
        {
            var email = new VitalAlertEmailFormat("TestPatient", "100", "ICU01", 1, "WARNING");
            _request = new RestRequest("AlertService/SendEmailAlert", Method.POST){RequestFormat = DataFormat.Json};
            _request.AddJsonBody(email);
            var response = Client.Execute(_request);
            Assert.NotNull(response);
        }
    }
}
