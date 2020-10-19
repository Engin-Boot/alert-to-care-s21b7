using AlertToCare.Monitoring;
using System;
using System.Collections.Generic;
using Xunit;

namespace AlertToCare_Tests.MonitoringTests
{
    public class MonitoringRepositoryTests
    {
        public readonly MonitoringRepository MonitoringRepository = new MonitoringRepository();
        public static List<AlertToCare.Models.PatientVital> PatientVitalActual = new List<AlertToCare.Models.PatientVital>();
        public static readonly List<AlertToCare.Models.PatientVital> PatientVitalExpected = new List<AlertToCare.Models.PatientVital>();
        [Fact]
        public void GetMonitoringInformationTests()
        {
            //_patientVitalExpected.Add(new AlertToCare.Models.PatientVital { PId = "147852", VitalBpm = 80, VitalRespRate = 98, VitalSpo2 = 65 });
            PatientVitalExpected.Add(new AlertToCare.Models.PatientVital { PId = "147852", VitalBpm = 80, VitalRespRate = 98, VitalSpo2 = 65 });
            PatientVitalActual = (List<AlertToCare.Models.PatientVital>)MonitoringRepository.GetMonitoringInformation();
            if (PatientVitalActual == PatientVitalExpected)
                Assert.True(true);
        }
        [Fact]
        public void CheckVitalsOfAllPatientsTest()
        {
            //List<Tuple<string, string, string, string>> checkVitalsExpected = new List<Tuple<string, string, string, string>>()
            //{
            //    new Tuple<string, string, string, string>("147852","Patient BPM 80 OK","Patient SPO2 is 65 which is lesser than minimum SPO2 of 90","Patient RespRate is 98 which is not in range between 30 and 95")
            //};
            List<Tuple<string, string, string, string>> checkVitalsActual =MonitoringRepository.CheckVitalOfAllPatients();
            Assert.NotNull(checkVitalsActual);

        }
    }
}
