using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiAlertToCare_AutomateTest.ConfigurationAutomationTest
{
    [TestClass]
  public  class ConfigurationApiTest
    {
        private static string _url = "http://localhost:51333/api/";
        [TestMethod]
        public void BedModelDataPostTest()
        {
            string bedPostUrl = _url + "configuration/PostBedModelData";
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest()
            {
                Resource = bedPostUrl,
            };
            var bedModel = new Models.BedModel()
            {
                BedId = "b0001",
                IcuId = "I0001",
                BedLayout = "Left",
                BedStatus = "Free"

            };
           restRequest.AddJsonBody(bedModel);
            IRestResponse restResponse = restClient.Post(restRequest);
            Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public void IcuModelDataPostTest()
        {
            string icuPostUrl = _url + "configuration/PostIcuModelData";
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest()
            {
                Resource = icuPostUrl,
            };
            var icuModel = new Models.IcuModel()
            {
                
                IcuId = "I0001",
                 BedCount=10,

            };
            restRequest.AddJsonBody(icuModel);
            IRestResponse restResponse = restClient.Post(restRequest);
            Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.OK);
        }
        [TestMethod]
        public void BedModelDataGetUrlTest()
        {
            RestClient restClient = new RestClient(_url);

            
            RestRequest restRequest = new RestRequest("configuration/GetBedModelInformation", Method.GET);
         
            IRestResponse restResponse = restClient.Execute(restRequest);

            
            Assert.AreEqual(true, restResponse.IsSuccessful);
        }

        [TestMethod]
        public void IcuModelDataGetUrlTest()
        {
            RestClient restClient = new RestClient(_url);


            RestRequest restRequest = new RestRequest("configuration/GetIcuModelInformation", Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);


            Assert.AreEqual(true, restResponse.IsSuccessful);
        }

        [TestMethod]
        public void RemoveBedDeleteUrlTest()
        {
            RestClient restClient = new RestClient(_url);


            RestRequest restRequest = new RestRequest("configuration/RemoveBedAndUpdateBedCountInIcu", Method.DELETE);

            IRestResponse restResponse = restClient.Execute(restRequest);


            Assert.AreEqual(true, restResponse.IsSuccessful);
        }
    }
}
