using System;
using RestSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace ApiAlterToCare_AutomateTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RestClient restClient = new RestClient("http://localhost:51333/api/");


            //RestRequest restRequest = new RestRequest("Configuration/GetBedModelInformation", Method.GET);
            //IRestResponse restResponse = restClient.Execute(restRequest);
            //Assert.AreEqual(true, restResponse.IsSuccessful);

           
        }
        [TestMethod]
        public void check()
        {
            RestClient restClient = new RestClient("http://localhost:51333/api/");

            //Creating request to get data from server
            var restRequest = new RestRequest("Configuration/", Method.POST);
            //  restRequest.AddUrlSegment("{id}", 1);
            //Models.IcuSetUpData icudata = new Model.IcuSetUpData();
            //icudata.BedsCount = 2;
            //icudata.Layout = "Circle";

            //restRequest.AddJsonBody(JsonConvert.SerializeObject(icudata));

            //IRestResponse restResponse = restClient.Execute(restRequest);
            //// return restResponse.IsSuccessful;
            //Assert.AreEqual(true, restResponse.IsSuccessful);
            //Console.WriteLine(restResponse.Content);

        }

    }
}
