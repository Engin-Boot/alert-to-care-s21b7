using System;
using System.Collections.Generic;
using Xunit;

namespace AlertToCare_Tests.MonitoringTests
{
    public class MonitoringRepositoryTests3
    {
        private readonly AlertToCare.Monitoring.MonitoringRepository _monitoringRepository = new AlertToCare.Monitoring.MonitoringRepository();
        [Fact]
        public void VitalsAreOkTests()
        {
            List<Tuple<string, string, string>> checkVitalsExpected = new List<Tuple<string, string, string>>()
            {
                new Tuple<string, string, string>("Patient BPM 80 OK","Patient SPO2 is 65 which is lesser than minimum SPO2 of 90","Patient RespRate is 98 which is not in range between 30 and 95")
            };
            List<Tuple<string, string, string>> checkVitalsActual= new List<Tuple<string, string, string>>();
            var status = _monitoringRepository.VitalsAreOk(80, 65, 98);
            checkVitalsActual.Add(new Tuple<string, string, string>(status.Item1, status.Item2, status.Item3));
            Assert.Equal(checkVitalsExpected, checkVitalsActual);
        }
    }
}
