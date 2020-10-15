using AlertToCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Occupancy
{
    public interface IOccupancyService
    {
         string CheckBedStatus(string BedId);
         string AddNewPatient(Models.PatientModel newPatient,string layout);
         string DishchargePatient(string Pid);
        List<PatientModel> GetPatientsDetails();
        List<BedModel> GetBedDetails();
        List<PatientVital> Display();
    }
}
