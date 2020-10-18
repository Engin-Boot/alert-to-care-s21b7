using AlertToCare.Configuration;
using Xunit;
using AlertToCare.Models;

namespace AlertToCare_Tests.Configuration.Tests
{
   public  class ConfigurationTest
   {
       private readonly ConfigurationRepository _configRepo = new ConfigurationRepository();

       private readonly RemovedBedThenUpdateIcu _updatebedCountInIcu = new RemovedBedThenUpdateIcu();
      

        private BedModel _bedModel = new BedModel()
       {
           BedId = "b0001",
           IcuId = "I0001",
           BedLayout = "Left",
           BedStatus = "Free"
       };

       private IcuModel _icuModel = new IcuModel()
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
            string expected = "Bed Added Sucessfully";
            string actual= _configRepo.AddNewBedConfiguration(_bedModel);
            Assert.Equal(expected,actual);


        }

        [Fact]
        public void AddNewIcuConfigurationTest()
        {
            string expected = "Icu Added Sucessfully";
            string actual = _configRepo.AddNewIcuConfiguration(_icuModel);
            Assert.Equal(expected, actual);


        }

        [Fact]
        public void RemoveBedTest()
        {
            string expectedString = "bed removed";
            string actualString = _configRepo.RemoveBed(_bedModel.BedId);
            Assert.Equal(expectedString,actualString);

        }

        [Fact]
        public void UpdateBedCountInAfterBedRemovalTest()
        {
            bool expected= true;
            bool actual = _updatebedCountInIcu.UpdateIcuAfterBedRemoval(_icuModel.IcuId);
            Assert.Equal(expected, actual);

        }

    }
}
