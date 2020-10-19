using AlertToCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AlertToCare.Occupancy
{
    public class OccupancyService : IOccupancyService
    {
        private  readonly List<PatientModel> _patientList = new List<PatientModel>();
        public static readonly List<BedModel> BedList = new List<BedModel>();
        public static readonly List<IcuModel> IcuList = new List<IcuModel>();
        public static readonly List<PatientVital> PatientVitalList = new List<PatientVital>();

        public string AddNewPatient(PatientModel newPatient,string layout)
        {
                try
                {
                    _patientList.Add(newPatient);
                    BedList.Add(new BedModel {BedId=newPatient.BedId,BedStatus="Occupied",BedLayout=layout,IcuId=newPatient.IcuId});
                    PatientVitalList.Add(new PatientVital { PId = newPatient.PId, VitalBpm = newPatient.VitalBpm, VitalSpo2 = newPatient.VitalSpo2, VitalRespRate = newPatient.VitalRespRate});
                    return "Patient Added Successful";
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    return "Unable to Add Patient";
                }
        }

        public List<PatientVital> Display()
        {
            return PatientVitalList;
        }

        public string CheckBedStatus(string bedId)
        {
            foreach(var bedTemp in BedList)
            {
                if (bedTemp.BedId == bedId)
                    if (bedTemp.BedStatus == "Occupied")
                        return "Occupied";
                    else
                        return "Free";
            }
            return "Does Not Exist";
        }
        public string DischargePatient(string pid)
        {
            try
            {
                foreach (var patientTemp in _patientList.ToList())
                {

                    if (patientTemp.PId == pid)
                    {
                        _patientList.Remove(patientTemp);
                    }
                }
                return "Patient Discharged";
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return "Patient Not Found";
            }
        }
        public List<PatientModel> GetPatientsDetails()
        {
            return _patientList;
        }

        public List<BedModel> GetBedDetails()
        {
            return BedList;
        }
    }
}
