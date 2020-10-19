using System;
using System.Collections.Generic;
using System.Linq;


namespace AlertToCare.Configuration
{
    public class ConfigurationRepository:IConfigurationRepository
    {
       // public readonly Occupancy.OccupancyService _occupancy = new Occupancy.OccupancyService();
        private readonly RemovedBedThenUpdateIcu _updateIcu = new RemovedBedThenUpdateIcu();

       
        public IEnumerable<Models.BedModel> GetBedConfigurationInformation() { return Occupancy.OccupancyService.BedList; }
        public IEnumerable<Models.IcuModel> GetIcuConfiguration() { return Occupancy.OccupancyService.IcuList; }

        public string AddNewBedConfiguration(Models.BedModel newBed)
        {
            Occupancy.OccupancyService.BedList.Add(newBed);
            return "Bed Added Successfully";
        }

        public string AddNewIcuConfiguration(Models.IcuModel newIcu)
        {
            Occupancy.OccupancyService.IcuList.Add(newIcu);
            return "Icu Added Successfully";
        }

        public string RemoveBed(string bedId)
        {
            string tempIcuId=" ";
            try
            {
                foreach (Models.BedModel bedTemp in Occupancy.OccupancyService.BedList.ToList())
                {
                    if (bedTemp.BedId == bedId)
                    {
                        tempIcuId = bedTemp.IcuId;
                        Occupancy.OccupancyService.BedList.Remove(bedTemp);
                        
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
