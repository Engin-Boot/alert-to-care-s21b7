using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCare.Models;

namespace AlertToCare.Configuration
{
    public class RemovedBedThenUpdateICU
    {
        Occupancy.OccupancyService _occupancy = new Occupancy.OccupancyService();
        public bool UpdateICUAfterBedRemoval(string tempIcuId)
        {
            try 
            { 
            foreach (IcuModel icuTemp in _occupancy._icuList.ToList())
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
