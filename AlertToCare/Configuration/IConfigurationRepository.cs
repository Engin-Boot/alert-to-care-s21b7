using System.Collections.Generic;
using AlertToCare.Models;

namespace AlertToCare.Configuration
{
    public interface IConfigurationRepository
    {
        Dictionary<int, BedModel> GetBedConfigurationInformation(string dbPath);
        object AddNewBedConfiguration(BedModel newBed, string dbPath);
        Dictionary<string, IcuModel> GetIcuConfiguration(string dbPath);
        object AddNewIcuConfiguration(IcuModel newIcu, string dbPath);
        object RemoveBed(int bedId, string dbPath);
        object GetAllBedLayouts(string dbPath);
        object DeleteIcu(string icuId, string dbPath);
    }
}