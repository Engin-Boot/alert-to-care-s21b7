using System.Collections.Generic;
using System.Net;
using AlertToCare.Models;
using RestSharp;
using RestSharp.Serialization.Json;
using Xunit;

namespace AutomationTests
{
    public class ConfigurationAutomationTest
    {
        private RestClient Client { get; set; }
        private RestRequest _request;
        private JsonDeserializer Deserializer { get; set; }

        public ConfigurationAutomationTest()
        {
            Client = new RestClient("http://localhost:5000/api");
            Deserializer = new JsonDeserializer();
        }

        [Fact]
        public void GetBedModelInfoTest()
        {
            _request = new RestRequest("Configuration/GetBedModelInformation", Method.GET) { RequestFormat = DataFormat.Json };
            var response = Client.Execute(_request);
            var result = Deserializer.Deserialize<Dictionary<int, BedModel>>(response);
            Assert.NotNull(result);
        }

        [Fact]
        public void GetIcuModelInfoTest()
        {
            _request = new RestRequest("Configuration/GetIcuModelInformation", Method.GET) { RequestFormat = DataFormat.Json };
            var response = Client.Execute(_request);
            var result = Deserializer.Deserialize<Dictionary<string, IcuModel>>(response);
            Assert.NotNull(result);
        }

        [Fact]
        public void AddBedTest()
        {
            var bedModel = new BedModel()
            {
                BedId = 1234,
                BedNumber = "101",
                BedLayout = "MIDDLE",
                IcuId = "ICU01"
            };
            _request = new RestRequest("Configuration/PostBedModelData", Method.POST) { RequestFormat = DataFormat.Json };
            _request.AddJsonBody(bedModel);
            var response = Client.Execute(_request);
            var result = Deserializer.Deserialize<object>(response);
            Assert.NotNull(result);
            RemoveBed(bedModel.BedId);
        }

        private void RemoveBed(int bedId)
        {
            _request = new RestRequest($"Configuration/RemoveBed/{bedId}", Method.DELETE) { RequestFormat = DataFormat.Json };
            var response = Client.Execute(_request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void AddIcuTest()
        {
            var icuModel = new IcuModel()
            {
                IcuId = "Dummy",
                BedCount = 10
            };
            _request = new RestRequest("Configuration/PostIcuModelData", Method.POST) { RequestFormat = DataFormat.Json };
            _request.AddJsonBody(icuModel);
            var response = Client.Execute(_request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            RemoveIcu(icuModel.IcuId);
        }

        private void RemoveIcu(string icuId)
        {
            _request = new RestRequest($"Configuration/RemoveIcu/{icuId}", Method.DELETE) { RequestFormat = DataFormat.Json };
            var response = Client.Execute(_request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void GetAllBedLayoutsTest()
        {
            _request = new RestRequest("Configuration/GetAllBedLayouts", Method.GET) { RequestFormat = DataFormat.Json };
            var response = Client.Execute(_request);
            //var result = Deserializer.Deserialize<List<string>>(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
