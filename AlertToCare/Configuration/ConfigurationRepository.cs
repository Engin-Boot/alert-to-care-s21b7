using System.Collections.Generic;
using AlertToCare.DatabaseOperations;
using AlertToCare.Models;
using AlertToCare.Occupancy;


namespace AlertToCare.Configuration
{
    public class ConfigurationRepository:IConfigurationRepository
    {
        private readonly OccupancyService _occupancy = new OccupancyService();
        //private readonly RemovedBedThenUpdateIcu _updateIcu = new RemovedBedThenUpdateIcu();

        public object GetAllBedLayouts(string dbPath)
        {
            var bedLayoutDbObj = new BedLayoutDbOps(dbPath);
            return bedLayoutDbObj.GetAllLayouts();
        }

        public object DeleteIcu(string icuId, string dbPath)
        {
            var icuDbObj = new IcuDbOps(dbPath);
            return icuDbObj.DeleteIcuFromDb(icuId);
        }

        public Dictionary<int, BedModel> GetBedConfigurationInformation(string dbPath)
        {
            return _occupancy.GetBedDetails(dbPath);
        }

        public Dictionary<string, IcuModel> GetIcuConfiguration(string dbPath)
        {
            var icuDbObj = new IcuDbOps(dbPath);
            return icuDbObj.GetAllIcuFromDb();
        }

        //return bool
           
        public object AddNewBedConfiguration(BedModel newBed, string dbPath)
        {
            //_occupancy.BedList.Add(newBed.BedId, newBed);
            //return "Bed Added Successfully";
            var bedDbObj = new BedDbOps(dbPath);
            return bedDbObj.AddBedToDb(newBed);
        }

        public object AddNewIcuConfiguration(IcuModel newIcu, string dbPath)
        {
            var icuDbObj = new IcuDbOps(dbPath);
            return icuDbObj.AddIcuToDb(newIcu);
        }


        public object RemoveBed(int bedId, string dbPath)
        {
            //string tempIcuId=" ";
            //try
            //{
            //    foreach (Models.BedModel bedTemp in _occupancy.BedList.ToList())
            //    {
            //        if (bedTemp.BedId == bedId)
            //        {
            //            tempIcuId = bedTemp.IcuId;
            //            _occupancy.BedList.Remove(bedTemp);
                        
            //        }
            //    }
            //    _updateIcu.UpdateIcuAfterBedRemoval(tempIcuId); 
            //    return "bed removed";
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine(e);
            //    return "unable to remove";
            //}
            var bedObj = new BedDbOps(dbPath);
            return bedObj.DeleteBedFromDb(bedId);
        }
        
    }
}
