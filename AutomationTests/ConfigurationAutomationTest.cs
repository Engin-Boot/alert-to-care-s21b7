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
        private readonly RestClient _client;
        private RestRequest _request;
        private readonly JsonDeserializer _deserializer;

        public ConfigurationAutomationTest()
        {
            _client = new RestClient("http://localhost:5000/api");
            _deserializer = new JsonDeserializer();
        }

        [Fact]
        public void WhenQueryServerToGetAllBedModelInformationAssertNotNull()
        {
            _request = new RestRequest("Configuration/GetBedModelInformation", Method.GET) { RequestFormat = DataFormat.Json };
            var response = _client.Execute(_request);
            var result = _deserializer.Deserialize<Dictionary<int, BedModel>>(response);
            Assert.NotNull(result);
        }

        [Fact]
        public void WhenQueryServerToGetAllIcusAssertNotNull()
        {
            _request = new RestRequest("Configuration/GetIcuModelInformation", Method.GET) { RequestFormat = DataFormat.Json };
            var response = _client.Execute(_request);
            var result = _deserializer.Deserialize<Dictionary<string, IcuModel>>(response);
            Assert.NotNull(result);
        }

        [Fact]
        public void WhenQueryServerToAddNewBedAndRemoveAddedBedAssertNoException()
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
            var response = _client.Execute(_request);
            var result = _deserializer.Deserialize<object>(response);
            Assert.NotNull(result);
            RemoveBed(bedModel.BedId);
        }

        private void RemoveBed(int bedId)
        {
            _request = new RestRequest($"Configuration/RemoveBed/{bedId}", Method.DELETE) { RequestFormat = DataFormat.Json };
            var response = _client.Execute(_request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void WhenQueryServerToAddNewIcuAndRemoveAddedIcuAssertNoException()
        {
            var icuModel = new IcuModel()
            {
                IcuId = "Dummy",
                BedCount = 10
            };
            _request = new RestRequest("Configuration/PostIcuModelData", Method.POST) { RequestFormat = DataFormat.Json };
            _request.AddJsonBody(icuModel);
            var response = _client.Execute(_request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            RemoveIcu(icuModel.IcuId);
        }

        private void RemoveIcu(string icuId)
        {
            _request = new RestRequest($"Configuration/RemoveIcu/{icuId}", Method.DELETE) { RequestFormat = DataFormat.Json };
            var response = _client.Execute(_request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void WhenQueryServerToGetAllBedLayoutsAssertNoException()
        {
            _request = new RestRequest("Configuration/GetAllBedLayouts", Method.GET) { RequestFormat = DataFormat.Json };
            var response = _client.Execute(_request);
            //var result = Deserializer.Deserialize<List<string>>(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
