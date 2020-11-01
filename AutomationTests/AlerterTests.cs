using System.Net;
using AlertToCare.Alerters;
using RestSharp;
using Xunit;

namespace AutomationTests
{
    public class AlerterTests
    {
        private RestClient Client { get; set; }
        private RestRequest _request;

        public AlerterTests()
        {
            Client = new RestClient("http://localhost:5000/api");
        }
        [Fact]
        public void TestEmailAlert()
        {
            var email = new VitalAlertEmailFormat("TestPatient", "100", "ICU01", 1, "WARNING");
            _request = new RestRequest("AlertService/SendEmailAlert", Method.POST){RequestFormat = DataFormat.Json};
            _request.AddJsonBody(email);
            var response = Client.Execute(_request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
