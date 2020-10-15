using AlertToCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AlertToCare.Occupancy
{
    public class OccupancyService : IOccupancyService
    {
       public List<Models.PatientModel> _patientList = new List<PatientModel>();
       public List<Models.BedModel> _bedList = new List<BedModel>();
       public List<Models.IcuModel> _icuList = new List<IcuModel>();

       public List<Models.PatientVital> _patientVitalList = new List<Models.PatientVital>();

        public string AddNewPatient(PatientModel newPatient,string layout)
        {
                try
                {
                    _patientList.Add(newPatient);
                    _bedList.Add(new BedModel {BedId=newPatient.BedId,BedStatus="Occupied",BedLayout=layout,ICUId=newPatient.IcuId});
                     _patientVitalList.Add(new PatientVital { PId = newPatient.PId, VitalBpm = newPatient.VitalBpm, VitalSpo2 = newPatient.VitalSpo2, VitalResperate = newPatient.VitalResperate });
                    return "Patient Added Succesfully";
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    return "Unable to Add Patient";
                }
        }

        public List<PatientVital> Display()
        {
            return _patientVitalList;
        }

        public string CheckBedStatus(string BedId)
        {
            foreach(Models.BedModel _bedTemp in _bedList)
            {
                if (_bedTemp.BedId == BedId)
                    if (_bedTemp.BedStatus == "Occupied")
                        return "Occupied";
                    else
                        return "Free";
            }
            return "Does Not Exist";
        }
        public string DishchargePatient(string Pid)
        {
            string tempBedId;
            try
            {
                foreach (Models.PatientModel _patientTemp in _patientList.ToList())
                {

                    if (_patientTemp.PId == Pid)
                    {
                        tempBedId = _patientTemp.BedId;
                        _patientList.Remove(_patientTemp);
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
            return _bedList;
        }
    }
}
