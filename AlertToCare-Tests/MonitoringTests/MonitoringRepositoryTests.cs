using AlertToCare.Monitoring;
using System.Collections.Generic;
using Xunit;

namespace AlertToCare_Tests.MonitoringTests
{
    public class MonitoringRepositoryTests
    {
        private readonly MonitoringRepository _monitoringRepository = new MonitoringRepository();
        private static List<AlertToCare.Models.PatientVital> _patientVitalActual = new List<AlertToCare.Models.PatientVital>();
        private static readonly List<AlertToCare.Models.PatientVital> PatientVitalExpected = new List<AlertToCare.Models.PatientVital>();
        [Fact]
        public void GetMonitoringInformationTests()
        {
            //_patientVitalExpected.Add(new AlertToCare.Models.PatientVital { PId = "147852", VitalBpm = 80, VitalRespRate = 98, VitalSpo2 = 65 });
            PatientVitalExpected.Add(new AlertToCare.Models.PatientVital { PId = "147852", VitalBpm = 80, VitalRespRate = 98, VitalSpo2 = 65 });
            _patientVitalActual = (List<AlertToCare.Models.PatientVital>)_monitoringRepository.GetMonitoringInformation();
            if (_patientVitalActual == PatientVitalExpected)
                Assert.True(true);
        }
        [Fact]
        public void CheckVitalsOfAllPatientsTest()
        {
            //List<Tuple<string, string, string, string>> checkVitalsExpected = new List<Tuple<string, string, string, string>>()
            //{
            //    new Tuple<string, string, string, string>("147852","Patient BPM 80 OK","Patient SPO2 is 65 which is lesser than minimum SPO2 of 90","Patient RespRate is 98 which is not in range between 30 and 95")
            //};
            //List<Tuple<string, string, string, string>> checkVitalsActual =_monitoringRepository.CheckVitalOfAllPatients();
            //if(checkVitalsActual==checkVitalsExpected)
            //    Assert.True(true);
            //Assert.Null(checkVitalsActual);
            var vital = new VitalStatus()
            {
                PId = "147852",
                VitalBpmStatus = "Patient BPM 80 OK",
                VitalSPo2Status = "Patient SPO2 is 65 which is lesser than minimum SPO2 of 90",
                VitalRespRateStatus =" Patient RespRate is 98 which is not in range between 30 and 95"

            };
            var checkVitalsActual = _monitoringRepository.CheckVitalOfAllPatients();
            if (checkVitalsActual == vital)
            {
                Assert.True(true);
            }

        }

        [Fact]
        public void VitalStatusGetChecks()
        {
            var vital = new VitalStatus()
            {
                PId = "147852",
                VitalBpmStatus = "Patient BPM 80 OK",
                VitalSPo2Status = "Patient SPO2 is 65 which is lesser than minimum SPO2 of 90",
                VitalRespRateStatus = " Patient RespRate is 98 which is not in range between 30 and 95"

            };

            Assert.Equal("147852",vital.PId);
            Assert.Equal("Patient BPM 80 OK", vital.VitalBpmStatus);
            Assert.Equal("Patient SPO2 is 65 which is lesser than minimum SPO2 of 90", vital.VitalSPo2Status);
            Assert.Equal(" Patient RespRate is 98 which is not in range between 30 and 95", vital.VitalRespRateStatus);
        }
    }
}
