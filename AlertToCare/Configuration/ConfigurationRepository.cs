using System;
using System.Collections.Generic;
using System.Linq;
using AlertToCare.Models;

namespace AlertToCare.Configuration
{
    public class ConfigurationRepository :IConfigurationRepository
    {
        private readonly Occupancy.OccupancyService _occupancy = new Occupancy.OccupancyService();
        private readonly RemovedBedThenUpdateIcu _updateIcu = new RemovedBedThenUpdateIcu();

       
        public IEnumerable<BedModel> GetBedConfigurationInformation() { return _occupancy.BedList; }
        public IEnumerable<IcuModel> GetIcuConfiguration() { return _occupancy.IcuList; }

        public void AddNewBedConfiguration(BedModel newBed)
        {
            _occupancy.BedList.Add(newBed);
        }

        public void AddNewIcuConfiguration(IcuModel newIcu)
        {
            _occupancy.IcuList.Add(newIcu);
        }

        public string RemoveBed(string bedId)
        {
            string tempIcuId=" ";
            try
            {
                foreach (BedModel bedTemp in _occupancy.BedList.ToList())
                {
                    if (bedTemp.BedId == bedId)
                    {
                        tempIcuId = bedTemp.IcuId;
                        _occupancy.BedList.Remove(bedTemp);
                        
                    }
                }
                _updateIcu.UpdateIcuAfterBedRemoval(tempIcuId); 
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
