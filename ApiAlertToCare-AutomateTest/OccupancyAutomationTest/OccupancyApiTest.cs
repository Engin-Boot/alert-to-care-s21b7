using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Net;

namespace ApiAlertToCare_AutomateTest.OccupancyAutomationTest
{
    [TestClass]
    public class OccupancyApiTest
    {
        private static string _url = "http://localhost:51333/api/";
        [TestMethod]
        public void PatientDataModelGetUrlTest()
        {

            RestClient restClient = new RestClient(_url);


            RestRequest restRequest = new RestRequest("Occupancy", Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);


            Assert.AreEqual(true, restResponse.IsSuccessful);
        }

        [TestMethod]
        public void BedDetailGetUrlTest()
        {

            RestClient restClient = new RestClient(_url);


            RestRequest restRequest = new RestRequest("Occupancy/GetBedDetails", Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);


            Assert.AreEqual(true, restResponse.IsSuccessful);
        }

        [TestMethod]
        public void PatientModelDataPostTest()
        {
            string icuPostUrl = _url + "Occupancy/Center";
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest()
            {
                Resource = icuPostUrl,
            };
            var patientModel = new Model.PatientModel()
            {

                PId1 = "p0002",
                Name1 = "abc",
                Age1 = 21,
                Gender1 = "Female",
                Email1 = "abc@gmail.com",
                PhoneNumber1 = "9876543240",
                Address1 = "Mysore",
                VitalBpm1 = 85,
                VitalSpo21 = 85,
                VitalRespRate1 = 85,
                IcuId1 = "i0002",
                BedId1 = "b0002"

            };
            restRequest.AddJsonBody(patientModel);
            IRestResponse restResponse = restClient.Post(restRequest);
            Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.OK);
        }
        [TestMethod]
        public void BedStatusGetUrlTest()
        {

            RestClient restClient = new RestClient(_url);


            RestRequest restRequest = new RestRequest("Occupancy/b0001", Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);


            Assert.AreEqual(true, restResponse.IsSuccessful);
        }

        [TestMethod]
        public void DischargePatientDeleteUrlTest()
        {

            RestClient restClient = new RestClient(_url);


            RestRequest restRequest = new RestRequest("Occupancy/p0001", Method.DELETE);

            IRestResponse restResponse = restClient.Execute(restRequest);


            Assert.AreEqual(true, restResponse.IsSuccessful);
        }

    }
}
