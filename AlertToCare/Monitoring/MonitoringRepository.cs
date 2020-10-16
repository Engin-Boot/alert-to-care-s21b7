using System;
using System.Collections.Generic;

namespace AlertToCare.Monitoring
{
    public  class MonitoringRepository :IMonitoringRepository
    {
        private readonly Occupancy.OccupancyService _occupancyVital = new Occupancy.OccupancyService();
        List<Models.PatientVital> _patientVital = new List<Models.PatientVital>();

     //   #region vitalCheck

//        private float _minBpm, _maxBpm;
//        private float _minSpo2;
//        private float _minRespRate, _maxRespRate;
       
//        public void VitalsRangeChecker(float minBpm, float maxBpm, float minSpo2, float minRespRate, float maxRespRate)
//        {
//            this._minBpm = minBpm;
//            this._maxBpm = maxBpm;
//            this._minSpo2 = minSpo2;
//            this._minRespRate = minRespRate;
//            this._maxRespRate = maxRespRate;
//        }

//       private bool Check_BPM(float bpm)
//        {
//            if (bpm > _maxBpm || bpm < _minBpm)
//            {
//                return false;
//            }
//            return true;
//        }
//        private bool Check_SPO2(float spo2)
//        {
//            if (spo2 > _minSpo2)
//            {
//                return true;
//            }
//            return false;
//        }

//        private bool Check_RespRate(float respRate)
//        {
//            if (respRate < _minRespRate || respRate > _maxRespRate)
//            {
//                return false;
//            }
//            return true;
//        }
//     public  Tuple<bool,bool,bool> VitalsAreOk(float bpm, float spo2, float respRate)
//        {
//            bool checkBpm =Check_BPM(bpm);
//            bool checkSpo2 = Check_SPO2(spo2);
//            bool checkRespiration = Check_RespRate(respRate);
//           return new Tuple<bool, bool,bool>(checkBpm,checkSpo2,checkRespiration);
//        }

//#endregion 
      
        public IEnumerable<Models.PatientVital> GetMonitoringInformation()
        {
            _patientVital = _occupancyVital.PatientVitalList;
            return _patientVital;
        }
    }
}