using System;
using System.Collections.Generic;
using System.Linq;
using AlertToCare.Occupancy;


namespace AlertToCare.Configuration
{
    public class ConfigurationRepository:IConfigurationRepository
    {
        private readonly OccupancyService _occupancy = new OccupancyService();
        private readonly RemovedBedThenUpdateIcu _updateIcu = new RemovedBedThenUpdateIcu();

       
        public IEnumerable<Models.BedModel> GetBedConfigurationInformation() { return _occupancy.BedList; }
        public IEnumerable<Models.IcuModel> GetIcuConfiguration() { return OccupancyService.IcuList; }

        public string AddNewBedConfiguration(Models.BedModel newBed)
        {
            _occupancy.BedList.Add(newBed);
            return "Bed Added Successfully";
        }

        public string AddNewIcuConfiguration(Models.IcuModel newIcu)
        {
            OccupancyService.IcuList.Add(newIcu);
            return "Icu Added Successfully";
        }

        public string RemoveBed(string bedId)
        {
            string tempIcuId=" ";
            try
            {
                foreach (Models.BedModel bedTemp in _occupancy.BedList.ToList())
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
