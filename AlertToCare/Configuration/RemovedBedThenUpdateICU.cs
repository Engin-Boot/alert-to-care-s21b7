using System;
using System.Linq;
using AlertToCare.Occupancy;


namespace AlertToCare.Configuration
{
    public class RemovedBedThenUpdateIcu
    {
      // private readonly OccupancyService _occupancy = new Occupancy.OccupancyService();
        public bool UpdateIcuAfterBedRemoval(string tempIcuId)
        {
             
                foreach (Models.IcuModel icuTemp in OccupancyService.IcuList.ToList())
                {
                    if (icuTemp.IcuId == tempIcuId)
                    {
                        icuTemp.BedCount -= 1;
                        return true;
                    }
                }
                return false; 
        }
    }
}
