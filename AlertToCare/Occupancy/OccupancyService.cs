using AlertToCare.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AlertToCare.DatabaseOperations;


namespace AlertToCare.Occupancy
{
    public class OccupancyService : IOccupancyService
    {
        //public OccupancyService GetInstanceOfOccupancyService()
        //{
        //    return this;
        //}

        //public OccupancyService()
        //{
        //    //InitPatientList();
        //    //InitIcuList();
        //    //InitBedList();
        //    //InitBedLayouts();
        //}

        //public Dictionary<string, PatientModel> PatientList; //will get data from class having accessing db
        //public Dictionary<int, BedModel> BedList;
        //public Dictionary<string, IcuModel> IcuList;
        ////public List<PatientVital> PatientVitalList;
        //public List<string> BedLayouts;



        public object AddNewPatient(PatientModel newPatient)
        {
            var filePath = DbOps.GetDbPath();
            var dbObj = new PatientDbOps(filePath);
            if (!dbObj.AddPatientToDb(newPatient).Equals(HttpStatusCode.OK)) return HttpStatusCode.InternalServerError;
            var bedStatusDbObj = new BedDbOps(DbOps.GetDbPath());
            return bedStatusDbObj.ChangeBedStatusToOccupied(newPatient.BedId);
        }

        public static object AddNewBed(BedModel newBed)
        {
            var filePath = DbOps.GetDbPath();
            var obj = new BedDbOps(filePath);
            return !obj.AddBedToDb(newBed).Equals(HttpStatusCode.OK) ? HttpStatusCode.InternalServerError : HttpStatusCode.OK;
            //BedList.Add(newBed.BedId, newBed);
        }

        //public List<PatientVital> Display()
        //{
        //    //return PatientVitalList;
        //}

        public bool IsBedFree(int bedId)
        {
            var filePath = DbOps.GetDbPath();
            var bedStatusObj = new BedDbOps(filePath);
            return bedStatusObj.IsBedFree(bedId);

            //foreach (var bedTemp in BedList.Where(bedTemp => bedTemp.Key == bedId))
            //{
            //    return bedTemp.Value.BedStatus;
            //}
            //return "Does Not Exist";
        }

        private IEnumerable<int> GetBedIdFromPid(string pid)
        {
            var patients = GetPatientsDetails();
            var bedId = from a in patients where a.Value.PId.Equals(pid)
                                  select a.Value.BedId;
            return bedId;

        }
        public object DischargePatient(string pid)
        {
            var filePath = DbOps.GetDbPath();
            var patientDbObj = new PatientDbOps(filePath);
            if (!patientDbObj.DeletePatientFromDatabase(pid).Equals(HttpStatusCode.OK))
                return HttpStatusCode.InternalServerError;
            var bedStatusObj = new BedDbOps(filePath);
            return bedStatusObj.ChangeBedStatusToVacant(GetBedIdFromPid(pid).ElementAt(0));

            //if (PatientList.ContainsKey(pid))
            //{
            //    PatientList.Remove(pid);
            //    return "Discharged";
            //}
            //else
            //{

            //}
            //foreach (var patientTemp in PatientList.ToList().Where(patientTemp => patientTemp.Key == pid))
            //{
            //    PatientList.Remove(patientTemp.Key);
            //    return "Patient Discharged";
            //}

            //return "Patient Not Found";

        }
        public Dictionary<string, PatientModel> GetPatientsDetails()
        {
            var filePath = DbOps.GetDbPath();
            var patientBbObj = new PatientDbOps(filePath);
            return patientBbObj.GetAllPatientsFromDb();
        }

        public Dictionary<int, BedModel> GetBedDetails()
        {
            var filePath = DbOps.GetDbPath();
            var bedsObj = new BedDbOps(filePath);
            return bedsObj.GetAllBedsFromDb();
        }

        //added
        public Dictionary<string, PatientModel> GetPatientsDetailsInIcu(string icuId)
        {
            //return patient => patient in _patientList.Where()
            //PatientModel patient;
            //var icuPatientList = from patient in PatientList
            //                     where patient.Value.IcuId == icuId
            //                     select patient;
            //return (Dictionary<string, PatientModel>)icuPatientList;
            var patients = GetPatientsDetails();
            var patientsInIcu = from patient in patients
                where patient.Value.IcuId.Equals(icuId)
                                select patient;
            return (Dictionary<string, PatientModel>) patientsInIcu;
        }

        //added
        public Dictionary<int, BedModel> GetBedDetailsForIcu(string icuId)
        {
            var bedList = GetBedDetails();
            var icuBedList = from bed in bedList
                             where bed.Value.IcuId == icuId
                             select bed;
            return (Dictionary<int, BedModel>)icuBedList;
        }

        //private void InitBedLayouts()
        //{
        //    var filePath = DbOps.GetDbPath();
        //    var bedLayoutObj = new BedLayoutDbOps(filePath);
        //    BedLayouts = bedLayoutObj.GetAllLayouts();
        //}

        //private void InitBedList()
        //{
        //    var filePath = DbOps.GetDbPath();
        //    var bedsObj = new BedDbOps(filePath);
        //    BedList = bedsObj.GetAllBedsFromDb();
        //}

        //private void InitIcuList()
        //{
        //    var filePath = DbOps.GetDbPath();
        //    var icuObj = new IcuDbOps(filePath);
        //    IcuList = icuObj.GetAllIcuFromDb();
        //}

        //private void InitPatientList()
        //{
        //    var filePath = DbOps.GetDbPath();
        //    var patientBbObj = new PatientDbOps(filePath);
        //    PatientList = patientBbObj.GetAllPatientsFromDb();
        //}

    }
}
