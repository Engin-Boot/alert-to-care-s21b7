using System;
using System.Collections.Generic;
using System.Linq;


namespace AlertToCare.Monitoring
{
    public class MonitoringRepository : IMonitoringRepository
    {
        public readonly Alerter.IAlerter Alerter = new Alerter.EmailAlert();

        private readonly List<Models.PatientVital> _patientVital = new List<Models.PatientVital>();
        //Occupancy.OccupancyService _occupancyService = new Occupancy.OccupancyService();
        #region vitalCheck

        private double _minBpm = 70, _maxBpm = 150;
        private double _minSpo2 = 90;
        private double _minRespRate = 30, _maxRespRate = 95;
      

        public string Check_BPM(double bpm)
        {
            if (bpm > _maxBpm || bpm < _minBpm)
            {
                return "Patient BPM is " + bpm + " which is not in range between " + _minBpm + " and " + _maxBpm;
            }
            return "Patient BPM " + bpm + " OK";
        }
        public string Check_SPO2(double spo2)
        {
            if (spo2 > _minSpo2)
            {
                return "Patient SPO2 is " + spo2 + " OK";
            }
            return "Patient SPO2 is " + spo2 + " which is lesser than minimum SPO2 of " + _minSpo2;
        }
        public string Check_RespRate(double respRate)
        {
            if (respRate < _minRespRate || respRate > _maxRespRate)
            {
                return "Patient RespRate is " + respRate + " which is not in range between " + _minRespRate + " and " + _maxRespRate;
            }
            return "Patient RespRate is " + respRate + " OK";
        }
        public Tuple<string, string, string> VitalsAreOk(double bpm, double spo2, double respRate)
        {
            var bpmStatus = Check_BPM(bpm);
            var spo2Status = Check_SPO2(spo2);
            var respirationStatus = Check_RespRate(respRate);
            return new Tuple<string, string, string>(bpmStatus, spo2Status, respirationStatus);
        }

        #endregion

        public IEnumerable<Models.PatientVital> GetMonitoringInformation()
        {
            //_patientVital = OccupancyService.PatientVitalList;
            return _patientVital;
        }
        //public List<Tuple<string,string,string,string>> CheckVitalOfAllPatients()
        //{
        //    foreach (Models.PatientVital patientTemp in _patientVital.ToList())
        //    {
        //        var status = (VitalsAreOk(patientTemp.VitalBpm, patientTemp.VitalSpo2, patientTemp.VitalRespRate));

        //        _checkVitals.Add(new Tuple<string, string, string, string>(patientTemp.PId, status.Item1, status.Item2, status.Item3));
        //        Alerter.Alert("Patient Vital Status \nPatient Id:"+patientTemp.PId+"\n"+status.Item1+"\n"+status.Item2+"\n"+status.Item3);
        //    }

        //    return _checkVitals;
        //}
        readonly VitalStatus _vitalStatus = new VitalStatus();
        public VitalStatus CheckVitalOfAllPatients()
        {
            
            foreach (var patientTemp in _patientVital.ToList())
            {
                var (item1, item2, item3) = (VitalsAreOk(patientTemp.VitalBpm, patientTemp.VitalSpo2, patientTemp.VitalRespRate));
               
                _vitalStatus.PId = patientTemp.PId;
                _vitalStatus.VitalBpmStatus = item1;
                _vitalStatus.VitalSPo2Status = item2;
                _vitalStatus.VitalRespRateStatus =item3;
            }

            return _vitalStatus;
        }

    }
}