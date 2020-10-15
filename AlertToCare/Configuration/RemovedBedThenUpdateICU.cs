using System;
using System.Linq;
using AlertToCare.Models;

namespace AlertToCare.Configuration
{
    public class RemovedBedThenUpdateIcu
    {
        private readonly Occupancy.OccupancyService _occupancy = new Occupancy.OccupancyService();
        public bool UpdateIcuAfterBedRemoval(string tempIcuId)
        {
            try 
            { 
                foreach (IcuModel icuTemp in _occupancy.IcuList.ToList())
                {
                    if (icuTemp.IcuId == tempIcuId)
                    {
                        icuTemp.BedCount -= 1;
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
