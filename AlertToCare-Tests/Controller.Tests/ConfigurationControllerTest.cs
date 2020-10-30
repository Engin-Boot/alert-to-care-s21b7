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
            //BedId = "b0001",
            IcuId = "I0001",
            BedLayout = "Left",
            BedStatus = "Free"
        };

        //public IcuModel Model { get; }

        private readonly ConfigurationController _configurationController;

       public ConfigurationControllerTest(/*IcuModel icuModel*/)
       {
           //Model = icuModel;
           var configMock = new Mock<IConfigurationRepository>();
           _configurationController=new ConfigurationController(configMock.Object);
       }

        [Fact]
        public void BedModelDataTest()
        { 
            //var bedModel = _configurationController.GetBedModelInformation();
            ////var bedModelStatusCode = bedModel as OkObjectResult;
            //Assert.NotNull(bedModel);
            //if (bedModelStatusCode != null)
            //    Assert.Equal(200, bedModelStatusCode.StatusCode);
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
            //var addBedModel = _configurationController.PostBedModelData(_bedModel);
            //var addBedModelStatusCode = addBedModel as OkResult;

            var addBedModel = _configurationController.PostBedModelData(_bedModel);
            if (addBedModel is OkResult addBedModelStatusCode) 
                Assert.Equal(200, addBedModelStatusCode.StatusCode);
        }

        //[Fact]
        //public void PostIcuModelDataTest()
        //{
        //    //var addIcuModel = _configurationController.PostIcuModelData(_icuModel);
        //    //var addIcuModelStatusCode = addIcuModel as OkResult;
        //    var addIcuModel = _configurationController.PostIcuModelData(_icuModel);
        //    if (addIcuModel is OkResult addIcuModelStatusCode)
        //        Assert.Equal(200, addIcuModelStatusCode.StatusCode);
        //}


        [Fact]
        public void RemoveBedUpdateBedCountInIcuTest()
        { 
            //var removeBed = _configurationController.RemoveBedAndUpdateBedCountInIcu(_bedModel.BedId);
            //var removeBedStatusCode =removeBed as OkObjectResult;
            var removeBed = _configurationController.Delete(_bedModel.BedId);
            if (removeBed is OkObjectResult removeBedStatusCode) Assert.Equal(200, removeBedStatusCode.StatusCode);
        }
    }
}
