using System.IO;
using System.Net;
using System.Reflection;
using AlertToCare.Configuration;
using Xunit;
using AlertToCare.Models;

namespace AlertToCare_Tests.Configuration.Tests
{
   public  class ConfigurationTest
   {
       private static string GetDbPathForTesting()
       {
           var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
           var dbPath = Path.GetFullPath(Path.Combine(path ?? string.Empty, @"..\..\..\Hospital.db"));
           return dbPath;
       }
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
          IcuId="I0002",
          BedCount = 10
       };

      

      [Fact]
       public void ReturnAllBeds()
       {
           var result = _configRepo.GetBedConfigurationInformation(GetDbPathForTesting());
           Assert.NotNull(result);
       }
        [Fact]
       public void GetAllBedLayouts()
       {
           var result = _configRepo.GetAllBedLayouts(GetDbPathForTesting());
           Assert.NotNull(result);
       }

       [Fact]
       public void GetAllIcus()
       {
           var result = _configRepo.GetIcuConfiguration(GetDbPathForTesting());
           Assert.NotNull(result);
       }
        [Fact]
        public void AddNewBedConfigurationTest()
        {
            const HttpStatusCode expected = HttpStatusCode.OK;
            Assert.Equal(expected, _configRepo.AddNewBedConfiguration(BedModel, GetDbPathForTesting()));
            _configRepo.RemoveBed(BedModel.BedId, GetDbPathForTesting());
        }

        [Fact]
        public void AddNewIcuConfigurationTest()
        {
            const HttpStatusCode expected = HttpStatusCode.OK;
            var actual = _configRepo.AddNewIcuConfiguration(IcuModel, GetDbPathForTesting());
            Assert.Equal(expected, actual);

            var ret = _configRepo.DeleteIcu("I0002", GetDbPathForTesting());
            Assert.Equal(HttpStatusCode.OK , ret);
        }

        [Fact]
        public void RemoveBedTest()
        {
            const HttpStatusCode expected = HttpStatusCode.OK;
            var actual = _configRepo.RemoveBed(BedModel.BedId, GetDbPathForTesting());
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void UpdateBedCountInAfterBedRemovalTest()
        {
            //var actual = _updateBedCountInIcu.UpdateIcuAfterBedRemoval(IcuModel.IcuId);
            //Assert.Equal(expected, actual);

        }

    }
}
