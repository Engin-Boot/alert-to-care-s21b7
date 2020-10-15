using AlertToCare.Models;
using System.Collections.Generic;

namespace AlertToCare.Occupancy
{
    public interface IOccupancyService
    {
         string CheckBedStatus(string bedId);
         string AddNewPatient(PatientModel newPatient,string layout);
         string DishchargePatient(string pid);
        List<PatientModel> GetPatientsDetails();
        List<BedModel> GetBedDetails();
        List<PatientVital> Display();
    }
}
