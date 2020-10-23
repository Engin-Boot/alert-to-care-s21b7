using System.Collections.Generic;
using AlertToCare.Models;

namespace AlertToCare.Configuration
{
    public interface IConfigurationRepository
    {
        Dictionary<int, BedModel> GetBedConfigurationInformation();
        object AddNewBedConfiguration(BedModel newBed);
        Dictionary<string, IcuModel> GetIcuConfiguration();
        object AddNewIcuConfiguration(IcuModel newIcu);
        object RemoveBed(int bedId);
        object GetAllBEdLayouts();
    }
}