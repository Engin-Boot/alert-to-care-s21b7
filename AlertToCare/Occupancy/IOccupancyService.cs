using System.Collections.Generic;
using AlertToCare.Models;

namespace AlertToCare.Occupancy
{
    public interface IOccupancyService
    {
        object AddNewPatient(PatientModel newPatient, string dbPath);
        //List<PatientVital> Display();
        bool IsBedFree(int bedId,  string dbPath);
        object DischargePatient(string pid, string dbPath);
        Dictionary<string, PatientModel> GetPatientsDetails(string dbPath);
        Dictionary<int, BedModel> GetBedDetails(string dbPath);
        Dictionary<string, PatientModel> GetPatientsDetailsInIcu(string icuId, string dbPath);
        Dictionary<int, BedModel> GetBedDetailsForIcu(string icuId, string dbPath);
    }
}