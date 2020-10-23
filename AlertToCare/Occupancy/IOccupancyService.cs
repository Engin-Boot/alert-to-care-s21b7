using System.Collections.Generic;
using AlertToCare.Models;

namespace AlertToCare.Occupancy
{
    public interface IOccupancyService
    {
        object AddNewPatient(PatientModel newPatient);
        //List<PatientVital> Display();
        bool IsBedFree(int bedId);
        object DischargePatient(string pid);
        Dictionary<string, PatientModel> GetPatientsDetails();
        Dictionary<int, BedModel> GetBedDetails();
        Dictionary<string, PatientModel> GetPatientsDetailsInIcu(string icuId);
        Dictionary<int, BedModel> GetBedDetailsForIcu(string icuId);
    }
}