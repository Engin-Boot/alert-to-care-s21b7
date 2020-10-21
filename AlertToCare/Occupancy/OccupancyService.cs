using AlertToCare.Models;
using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;


namespace AlertToCare.Occupancy
{
    public class OccupancyService : IOccupancyService
    {
        public  readonly List<PatientModel> _patientList = new List<PatientModel>();//will get data from class having accessing db
        public  readonly List<BedModel> BedList = new List<BedModel>();
        public  static readonly List<IcuModel> IcuList = new List<IcuModel>();
        public static readonly List<PatientVital> PatientVitalList = new List<PatientVital>();

        public string AddNewPatient(PatientModel newPatient,string layout)
        {
            _patientList.Add(newPatient);
            BedList.Add(new BedModel { BedId = newPatient.BedId, BedStatus = "Occupied", BedLayout = layout, IcuId = newPatient.IcuId });
            PatientVitalList.Add(new PatientVital { PId = newPatient.PId, VitalBpm = newPatient.VitalBpm, VitalSpo2 = newPatient.VitalSpo2, VitalRespRate = newPatient.VitalRespRate });
            return "Patient Added Successful";
        }

        public List<PatientVital> Display()
        {
            return PatientVitalList;
        }

        public string CheckBedStatus(string bedId)
        {
            foreach (var bedTemp in BedList.Where(bedTemp => bedTemp.BedId == bedId))
            {
                return bedTemp.BedStatus == "Occupied" ? "Occupied" : "Free";
            }

            return "Does Not Exist";
        }
        public string DischargePatient(string pid)
        {
            
                foreach (var patientTemp in _patientList.ToList().Where(patientTemp => patientTemp.PId == pid))
                {
                    _patientList.Remove(patientTemp);
                    return "Patient Discharged";
                }

                return "Patient Not Found";
            
        }
        public List<PatientModel> GetPatientsDetails()
        {
            return _patientList;
        }

        public List<BedModel> GetBedDetails()
        {
            return BedList;
        }

        //added
        public IEnumerable<PatientModel> GetPatientsDetailsInIcu(string icuId)
        {
            //return patient => patient in _patientList.Where()
            //PatientModel patient;
            var icuPatientList = from patient in _patientList
                where patient.IcuId == icuId
                select patient;
            return icuPatientList;
        }

        //added
        public IEnumerable<BedModel> GetBedDetailsForIcu(string icuId)
        {
            var icuBedList = from bed in BedList
                where bed.IcuId == icuId
                select bed;
            return icuBedList;
        }
    }
}
