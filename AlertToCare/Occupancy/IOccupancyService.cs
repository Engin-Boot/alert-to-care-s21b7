using System.Collections.Generic;
using AlertToCare.Models;

namespace AlertToCare.Occupancy
{
    public interface IOccupancyService
    {
        string AddNewPatient(PatientModel newPatient,string layout);
        List<PatientVital> Display();
        string CheckBedStatus(string bedId);
        string DischargePatient(string pid);
        List<PatientModel> GetPatientsDetails();
        List<BedModel> GetBedDetails();
        IEnumerable<PatientModel> GetPatientsDetailsInIcu(string icuId);
        IEnumerable<BedModel> GetBedDetailsForIcu(string icuId);
    }
}