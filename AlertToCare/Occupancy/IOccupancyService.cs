using AlertToCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Occupancy
{
    public interface IOccupancyService
    {
        public string CheckBedStatus(string BedId);
        public string AddNewPatient(Models.PatientModel newPatient,string layout);
        public string DishchargePatient(string Pid);
        public List<PatientModel> GetPatientsDetails();
        public List<BedModel> GetBedDetails();
    }
}
