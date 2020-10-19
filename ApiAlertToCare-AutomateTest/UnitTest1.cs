using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Newtonsoft.Json;
using System.Net;

//namespace ApiAlertToCare_AutomateTest
//{
    //[TestClass]
    //public class UnitTest1
    //{
    //    private static string url = "http://localhost:51333/api/";
        //[TestMethod]
        //public void TestMethod1()
        //{
        //    string bedPostUrl = url + "configuration/PostBedModelData";
        //    IRestClient restClient = new RestClient();
        //   IRestRequest restRequest = new RestRequest()
        //   {
        //    Resource = bedPostUrl,
        //    };
        //    var insertWardInfo = new Models.BedModel()
        //    {
        //        BedId = "b0001",
        //        IcuId = "I0001",
        //        BedLayout = "Left",
        //        BedStatus = "Free"

        //    };
        //    restRequest.AddHeader("Content-Type", "application/json");
        //    restRequest.AddJsonBody(insertWardInfo);
        //    IRestResponse restResponse = restClient.Post(restRequest);
        //    Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.OK);
//        //}
//    }
//}
