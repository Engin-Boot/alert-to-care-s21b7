using System.Collections.Generic;
using AlertToCare.Models;

namespace AlertToCare.Configuration
{
   public interface IConfigurationRepository
    {
        IEnumerable<BedModel> GetBedConfigurationInformation();
        void AddNewBedConfiguration(BedModel newBed);
        IEnumerable<IcuModel> GetIcuConfiguration();
        void AddNewIcuConfiguration(IcuModel newIcu);
        string RemoveBed(string bedId);
        }
}