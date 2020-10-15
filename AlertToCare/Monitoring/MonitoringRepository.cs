using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Monitoring
{
   
    public  class MonitoringRepository :IMonitoringRepository
    {
        Occupancy.OccupancyService _occupancyVital = new Occupancy.OccupancyService();
        List<Models.PatientVital> _patientVital = new List<Models.PatientVital>();
        public MonitoringRepository()
        {

        }
        
        #region vitalCheck
        float minBpm, maxBpm;
        float minSpo2;
        float minRespirate, MaxRespirate;
       
        public void VitalsRangeChecker(float _minBpm, float _maxBpm, float _minSpo2, float _minRespirate, float _maxRespirate)
        {
            minBpm = _minBpm;
            maxBpm = _maxBpm;
            minSpo2 = _minSpo2;
            minRespirate = _minRespirate;
            MaxRespirate = _maxRespirate;
        }

       public bool Check_BPM(float bpm)
        {
            if (bpm > maxBpm || bpm < minBpm)
            {
                return false;
            }
            return true;
        }
       public bool Check_SPO2(float spo2)
        {
            if (spo2 > minSpo2)
            {
                return true;
            }
            return false;
        }

       public bool Check_Resperate(float respirate)
        {
            if (respirate < minRespirate || respirate > MaxRespirate)
            {
                return false;
            }
            return true;
        }
     public  Tuple<bool,bool,bool> VitalsAreOk(float bpm, float spo2, float respRate)
        {
            bool checkBpm =Check_BPM(bpm);
            bool checkSpo2 = Check_SPO2(spo2);
            bool checkRespirate = Check_Resperate(respRate);
           return new Tuple<bool, bool,bool>(checkBpm,checkSpo2,checkRespirate);
        }

#endregion 
      
        public List<Models.PatientVital> GetMonitoringformation()
        {
            _patientVital = _occupancyVital._patientVitalList;
            return _patientVital;
        }
    }
}