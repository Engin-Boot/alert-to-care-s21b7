using System.Collections.Generic;
using AlertToCare.Models;

namespace AlertToCare.Configuration
{
   public interface IConfigurationRepository
   {
        IEnumerable<BedModel> GetBedConfigurationInformation();
       string AddNewBedConfiguration(BedModel newBed);
        IEnumerable<IcuModel> GetIcuConfiguration();
       string AddNewIcuConfiguration(IcuModel newIcu);
        string RemoveBed(string bedId);
   }
}