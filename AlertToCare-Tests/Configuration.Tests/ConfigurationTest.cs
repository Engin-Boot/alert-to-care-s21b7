using AlertToCare.Configuration;
using Xunit;
using AlertToCare.Models;

namespace AlertToCare_Tests.Configuration.Tests
{
   public  class ConfigurationTest
   {
       private readonly ConfigurationRepository _configRepo = new ConfigurationRepository();

       private readonly RemovedBedThenUpdateIcu _updateBedCountInIcu = new RemovedBedThenUpdateIcu();


       private static readonly BedModel BedModel = new BedModel()
       {
           BedId = "b0001",
           IcuId = "I0001",
           BedLayout = "Left",
           BedStatus = "Free"
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
            string expected = "Bed Added Successfully";
            string actual= _configRepo.AddNewBedConfiguration(BedModel);
            Assert.Equal(expected,actual);


        }

        [Fact]
        public void AddNewIcuConfigurationTest()
        {
            string expected = "Icu Added Successfully";
            string actual = _configRepo.AddNewIcuConfiguration(IcuModel);
            Assert.Equal(expected, actual);


        }

        [Fact]
        public void RemoveBedTest()
        {
            string expectedString = "bed removed";
            string actualString = _configRepo.RemoveBed(BedModel.BedId);
            Assert.Equal(expectedString,actualString);

        }

        [Fact]
        public void UpdateBedCountInAfterBedRemovalTest()
        {
            bool expected= true;
            bool actual = _updateBedCountInIcu.UpdateIcuAfterBedRemoval(IcuModel.IcuId);
            Assert.Equal(expected, actual);

        }

    }
}
