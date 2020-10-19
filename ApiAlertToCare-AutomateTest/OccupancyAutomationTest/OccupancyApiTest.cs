using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

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
            var patientModel = new Models.PatientModel()
            {

                PId = "p0001",
                Name = "xyz",
                Age = 21,
                Gender = "Female",
                Email = "xyz@gmail.com",
                PhoneNumber = "9876543210",
                Address = "Bangalore",
                VitalBpm = 75,
                VitalSpo2 = 75,
                VitalRespRate = 75,
                IcuId = "I0001",
                BedId = "b0001"

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
