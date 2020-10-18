using System;
using System.Collections.Generic;
using System.Linq;


namespace AlertToCare.Configuration
{
    public class ConfigurationRepository:IConfigurationRepository
    {
        private readonly Occupancy.OccupancyService _occupancy = new Occupancy.OccupancyService();
        private readonly RemovedBedThenUpdateIcu _updateIcu = new RemovedBedThenUpdateIcu();

       
        public IEnumerable<Models.BedModel> GetBedConfigurationInformation() { return _occupancy.BedList; }
        public IEnumerable<Models.IcuModel> GetIcuConfiguration() { return _occupancy.IcuList; }

        public string AddNewBedConfiguration(Models.BedModel newBed)
        {
            _occupancy.BedList.Add(newBed);
            return "Bed Added Sucessfully";
        }

        public string AddNewIcuConfiguration(Models.IcuModel newIcu)
        {
            _occupancy.IcuList.Add(newIcu);
            return "Icu Added Sucessfully";
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
