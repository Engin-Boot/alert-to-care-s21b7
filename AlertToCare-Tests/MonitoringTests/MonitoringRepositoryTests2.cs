using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AlertToCare_Tests.MonitoringTests
{
    public class MonitoringRepositoryTests2
    {
        AlertToCare.Monitoring.MonitoringRepository monitoringRepository = new AlertToCare.Monitoring.MonitoringRepository();
        private double _minBpm = 70, _maxBpm = 150;
        private double _minRespRate = 30, _maxRespRate = 95;
        [Fact]
        public void CheckBPMTests()
        {
            double bpm = 80;
            string actual = monitoringRepository.Check_BPM(bpm);
            string expected= "Patient BPM " + bpm + " OK";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CheckBPMTests2()
        {
            double bpm = 50;
            string actual = monitoringRepository.Check_BPM(bpm);
            string expected = "Patient BPM is " + bpm + " which is not in range between " + _minBpm + " and " + _maxBpm;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CheckSpo2Tests()
        {
            double spo2 = 95;
            string actual = monitoringRepository.Check_SPO2(spo2);
            string expected= "Patient SPO2 is " + spo2 + " OK";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CheckRespRateTests()
        {
            double respRate = 50;
            string actual = monitoringRepository.Check_RespRate(respRate);
            string expected= "Patient RespRate is " + respRate + " OK";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CheckRespRateTests2()
        {
            double respRate = 97;
            string actual = monitoringRepository.Check_RespRate(respRate);
            string expected = "Patient RespRate is " + respRate + " which is not in range between " + _minRespRate + " and " + _maxRespRate;
            Assert.Equal(expected, actual);
        }
    }
}
