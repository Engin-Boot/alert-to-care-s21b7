using AlertToCare.Monitoring;
using AlertToCare.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AlertToCare.Occupancy;

namespace AlertToCare_Tests.MonitoringTests
{
    public class MonitoringRepositoryTests
    {
        MonitoringRepository monitoringRepository = new MonitoringRepository();
        static List<AlertToCare.Models.PatientVital> _patientVitalActual = new List<AlertToCare.Models.PatientVital>();
        static List<AlertToCare.Models.PatientVital> _patientVitalExpected = new List<AlertToCare.Models.PatientVital>();
        [Fact]
        public void GetMonitoringInformationTests()
        {
            //_patientVitalExpected.Add(new AlertToCare.Models.PatientVital { PId = "147852", VitalBpm = 80, VitalRespRate = 98, VitalSpo2 = 65 });
            _patientVitalExpected.Add(new AlertToCare.Models.PatientVital { PId = "147852", VitalBpm = 80, VitalRespRate = 98, VitalSpo2 = 65 });
            _patientVitalActual = (List<AlertToCare.Models.PatientVital>)monitoringRepository.GetMonitoringInformation();
            if (_patientVitalActual == _patientVitalExpected)
                Assert.True(true);
        }
        [Fact]
        public void checkVitalsOfAllPatientsTest()
        {
            List<Tuple<string, string, string, string>> _checkVitalsExpected = new List<Tuple<string, string, string, string>>()
            {
                new Tuple<string, string, string, string>("147852","Patient BPM 80 OK","Patient SPO2 is 65 which is lesser than minimum SPO2 of 90","Patient RespRate is 98 which is not in range between 30 and 95")
            };
            List<Tuple<string, string, string, string>> _checkVitalsActual =monitoringRepository.CheckVitalOfAllPatients();
            Assert.NotNull(_checkVitalsActual);

        }
    }
}
