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

        public object GetAllBEdLayouts()
        {
            var bedLayoutDbObj = new BedLayoutDbOps(DbOps.GetDbPath());
            return bedLayoutDbObj.GetAllLayouts();
        }

        public object DeleteIcu(string icuId)
        {
            var icuDbObj = new IcuDbOps(DbOps.GetDbPath());
            return icuDbObj.DeleteIcuFromDb(icuId);
        }

        public Dictionary<int, BedModel> GetBedConfigurationInformation()
        {
            return _occupancy.GetBedDetails(DbOps.GetDbPath());
        }

        public Dictionary<string, IcuModel> GetIcuConfiguration()
        {
            var filePath = DbOps.GetDbPath();
            var icuDbObj = new IcuDbOps(filePath);
            return icuDbObj.GetAllIcuFromDb();
        }

        //return bool
        public object AddNewBedConfiguration(BedModel newBed)
        {
            //_occupancy.BedList.Add(newBed.BedId, newBed);
            //return "Bed Added Successfully";
            var bedDbObj = new BedDbOps(DbOps.GetDbPath());
            return bedDbObj.AddBedToDb(newBed);
        }

        public object AddNewIcuConfiguration(IcuModel newIcu)
        {
            var icuDbObj = new IcuDbOps(DbOps.GetDbPath());
            return icuDbObj.AddIcuToDb(newIcu);
        }


        public object RemoveBed(int bedId)
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
            var bedObj = new BedDbOps(DbOps.GetDbPath());
            return bedObj.DeleteBedFromDb(bedId);
        }
        
    }
}
