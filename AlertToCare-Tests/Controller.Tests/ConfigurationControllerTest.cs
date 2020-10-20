using AlertToCare.Configuration;
using AlertToCare.Controllers;
using Xunit;
using Moq;
using  AlertToCare.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlertToCare_Tests.Controller.Tests
{
   public class ConfigurationControllerTest
    {
        private readonly BedModel  _bedModel = new BedModel()
        {
            BedId = "b0001",
            IcuId = "I0001",
            BedLayout = "Left",
            BedStatus = "Free"
        };

        private readonly IcuModel _icuModel = new IcuModel()
        {
            IcuId = "I0001",
            BedCount = 10

        };

        private readonly ConfigurationController _configurationController;

       public ConfigurationControllerTest()
       {
           var configMock = new Mock<IConfigurationRepository>();
           _configurationController=new ConfigurationController(configMock.Object);
       }

        [Fact]
        public void BedModelDataTest()
        { 
            var bedModel = _configurationController.GetBedModelInformation();
            var bedModelStatusCode = bedModel as OkObjectResult;
            Assert.NotNull(bedModel);
            if (bedModelStatusCode != null)
                Assert.Equal(200, bedModelStatusCode.StatusCode);
        }


        [Fact]
        public void IcuModelDataTest()
        {
            var icuModel = _configurationController.GetIcuModelInformation();
            var icuModelStatusCode = icuModel as OkObjectResult;
            Assert.NotNull(icuModel);
            if (icuModelStatusCode != null) 
                Assert.Equal(200, icuModelStatusCode.StatusCode);
        }

        [Fact]
        public void PostBedModelDataTest()
        {
            var addBedModel = _configurationController.PostBedModelData(_bedModel);
            var addBedModelStatusCode = addBedModel as OkResult;
            if (addBedModelStatusCode != null) Assert.Equal(200, addBedModelStatusCode.StatusCode);
        }

        [Fact]
        public void PostIcuModelDataTest()
        {
            var addIcuModel = _configurationController.PostIcuModelData(_icuModel);
            var addIcuModelStatusCode = addIcuModel as OkResult;
            if (addIcuModelStatusCode != null)
                Assert.Equal(200, addIcuModelStatusCode.StatusCode);
        }


        [Fact]
        public void RemoveBedUpdateBedCountInIcuTest()
        {
            var removeBed = _configurationController.RemoveBedAndUpdateBedCountInIcu(_bedModel.BedId);
          var removeBedStatusCode =removeBed as OkObjectResult;
          if (removeBedStatusCode != null) Assert.Equal(200, removeBedStatusCode.StatusCode);
        }
    }
}
