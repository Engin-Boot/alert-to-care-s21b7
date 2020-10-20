using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace ApiAlertToCare_AutomateTest.MonitoringAutomationTest
{
    [TestClass]
    public class MonitoringApiTest
    {
        private static string _url = "http://localhost:51333/api/";
        [TestMethod]
        public void PatientDataGetUrlTest()
        {

            RestClient restClient = new RestClient(_url);


            RestRequest restRequest = new RestRequest("Monitor", Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);


            Assert.AreEqual(true, restResponse.IsSuccessful);
        }

        [TestMethod]
        public void AllPatientVitalGetUrlTest()
        {

            RestClient restClient = new RestClient(_url);


            RestRequest restRequest = new RestRequest("Monitor/GeAllPatientVitals", Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);


            Assert.AreEqual(true, restResponse.IsSuccessful);
        }
    }
}
