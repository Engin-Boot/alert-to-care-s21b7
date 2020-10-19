using Xunit;

namespace AlertToCare_Tests.MonitoringTests
{
    public class MonitoringRepositoryTests2
    {
        public readonly AlertToCare.Monitoring.MonitoringRepository MonitoringRepository = new AlertToCare.Monitoring.MonitoringRepository();
        public readonly double MinBpm = 70;
        public readonly double MaxBpm = 150;
        public readonly double MinRespRate = 30;
        public readonly double MaxRespRate = 95;

        [Fact]
        public void CheckBpmTests()
        {
            double bpm = 80;
            string actual = MonitoringRepository.Check_BPM(bpm);
            string expected= "Patient BPM " + bpm + " OK";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CheckBpmTests2()
        {
            double bpm = 50;
            string actual = MonitoringRepository.Check_BPM(bpm);
            string expected = "Patient BPM is " + bpm + " which is not in range between " + MinBpm + " and " + MaxBpm;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CheckSpo2Tests()
        {
            double spo2 = 95;
            string actual = MonitoringRepository.Check_SPO2(spo2);
            string expected= "Patient SPO2 is " + spo2 + " OK";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CheckRespRateTests()
        {
            double respRate = 50;
            string actual = MonitoringRepository.Check_RespRate(respRate);
            string expected= "Patient RespRate is " + respRate + " OK";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CheckRespRateTests2()
        {
            double respRate = 97;
            string actual = MonitoringRepository.Check_RespRate(respRate);
            string expected = "Patient RespRate is " + respRate + " which is not in range between " + MinRespRate + " and " + MaxRespRate;
            Assert.Equal(expected, actual);
        }
    }
}
