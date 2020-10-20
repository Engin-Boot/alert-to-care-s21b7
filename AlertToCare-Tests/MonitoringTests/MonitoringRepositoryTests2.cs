using Xunit;

namespace AlertToCare_Tests.MonitoringTests
{
    public class MonitoringRepositoryTests2
    {
        private readonly AlertToCare.Monitoring.MonitoringRepository _monitoringRepository = new AlertToCare.Monitoring.MonitoringRepository();
        private readonly double _minBpm = 70;
        private readonly double _maxBpm = 150;
        private readonly double _minRespRate = 30;
        private readonly double _maxRespRate = 95;

        [Fact]
        public void CheckBpmTests()
        {
            double bpm = 80;
            string actual = _monitoringRepository.Check_BPM(bpm);
            string expected= "Patient BPM " + bpm + " OK";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CheckBpmTests2()
        {
            double bpm = 50;
            string actual = _monitoringRepository.Check_BPM(bpm);
            string expected = "Patient BPM is " + bpm + " which is not in range between " + _minBpm + " and " + _maxBpm;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CheckSpo2Tests()
        {
            double spo2 = 95;
            string actual = _monitoringRepository.Check_SPO2(spo2);
            string expected= "Patient SPO2 is " + spo2 + " OK";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CheckRespRateTests()
        {
            double respRate = 50;
            string actual = _monitoringRepository.Check_RespRate(respRate);
            string expected= "Patient RespRate is " + respRate + " OK";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CheckRespRateTests2()
        {
            double respRate = 97;
            string actual = _monitoringRepository.Check_RespRate(respRate);
            string expected = "Patient RespRate is " + respRate + " which is not in range between " + _minRespRate + " and " + _maxRespRate;
            Assert.Equal(expected, actual);
        }
    }
}
