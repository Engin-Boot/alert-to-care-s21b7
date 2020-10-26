using System.Net;
using AlertToCare.Configuration;
using Xunit;
using AlertToCare.Models;

namespace AlertToCare_Tests.Configuration.Tests
{
   public  class ConfigurationTest
   {
       private readonly ConfigurationRepository _configRepo = new ConfigurationRepository();

       //private readonly RemovedBedThenUpdateIcu _updateBedCountInIcu = new RemovedBedThenUpdateIcu();


       private static readonly BedModel BedModel = new BedModel()
       {
           BedId = 3,
           IcuId = "ICU01",
           BedLayout = "LEFT CORNER",
           BedStatus = "False"
       };

      private static readonly IcuModel IcuModel = new IcuModel()
       {
          IcuId="I0001",
          BedCount = 10

       };

       [Fact]
       public void ShouldReturnBedConfigurationInformation()
       {
           var result = _configRepo.GetBedConfigurationInformation();
           Assert.NotNull(result);
       }

       [Fact]
       public void ShouldReturnIcuConfigurationInformation()
       {
           var result = _configRepo.GetIcuConfiguration();
           Assert.NotNull(result);
       }
        [Fact]
        public void AddNewBedConfigurationTest()
        {
            const string expected = "Bed Added Successfully";
            var actual= _configRepo.AddNewBedConfiguration(BedModel);
            Assert.Equal(expected,actual);


        }

        [Fact]
        public void AddNewIcuConfigurationTest()
        {
            const HttpStatusCode expected = HttpStatusCode.OK;
            var actual = _configRepo.AddNewIcuConfiguration(IcuModel);
            Assert.Equal(expected, actual);


        }

        [Fact]
        public void RemoveBedTest()
        {
            var expected = HttpStatusCode.OK;
            var actual = _configRepo.RemoveBed(BedModel.BedId);
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void UpdateBedCountInAfterBedRemovalTest()
        {
            const bool expected = true;
            //var actual = _updateBedCountInIcu.UpdateIcuAfterBedRemoval(IcuModel.IcuId);
            //Assert.Equal(expected, actual);

        }

    }
}
