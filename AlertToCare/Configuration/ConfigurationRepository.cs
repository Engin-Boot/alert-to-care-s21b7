using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCare.Models;

namespace AlertToCare.Configuration
{
    public class ConfigurationRepository :IConfigurationRepository
    {
        Occupancy.OccupancyService _occupancy = new Occupancy.OccupancyService();
       

       
        public IEnumerable<Models.BedModel> GetbedConfigurationInformation() { return _occupancy._bedList; }
        public IEnumerable<Models.IcuModel> GetIcuConfiguration() { return _occupancy._icuList; }

        public void AddNewbedConfiguration(Models.BedModel newbed)
        {
            _occupancy._bedList.Add(newbed);
        }

        public void AddNewIcuConfiguration(Models.IcuModel newIcu)
        {
            _occupancy._icuList.Add(newIcu);
        }

        public string RemoveBed(string bedId)
        {
            string tempIcuId=" ";
            try
            {
                foreach (BedModel bedTemp in _occupancy._bedList.ToList())
                {
                    if (bedTemp.BedId == bedId)
                    {
                        tempIcuId = bedTemp.ICUId;
                        _occupancy._bedList.Remove(bedTemp);
                        
                    }
                }
                foreach(IcuModel icuTemp in _occupancy._icuList.ToList())
                {
                    if(icuTemp.IcuId==tempIcuId)
                    {
                        icuTemp.BedCount -= 1;
                    }
                }
                return "bed removed";
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return "unable to remove";
            }
            
        }
        
    }
}
