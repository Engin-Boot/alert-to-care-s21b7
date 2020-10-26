//using Xunit;

//namespace AlertToCare_Tests.MonitoringTests
//{
//    public class MonitoringRepositoryTests2
//    {
//        private readonly AlertToCare.Monitoring.MonitoringRepository _monitoringRepository = new AlertToCare.Monitoring.MonitoringRepository();
//        private const double MinBpm = 70;
//        private const double MaxBpm = 150;
//        private const double MinRespRate = 30;
//        private const double MaxRespRate = 95;

//        [Fact]
//        public void CheckBpmTests()
//        {
//            const double bpm = 80;
//            var actual = _monitoringRepository.Check_BPM(bpm);
//            var expected= "Patient BPM " + bpm + " OK";
//            Assert.Equal(expected, actual);
//        }

//        [Fact]
//        public void CheckBpmTests2()
//        {
//            const double bpm = 50;
//            var actual = _monitoringRepository.Check_BPM(bpm);
//            var expected = "Patient BPM is " + bpm + " which is not in range between " + MinBpm + " and " + MaxBpm;
//            Assert.Equal(expected, actual);
//        }
//        [Fact]
//        public void CheckSpo2Tests()
//        {
//            const double spo2 = 95;
//            var actual = _monitoringRepository.Check_SPO2(spo2);
//            var expected= "Patient SPO2 is " + spo2 + " OK";
//            Assert.Equal(expected, actual);
//        }
//        [Fact]
//        public void CheckRespRateTests()
//        {
//            const double respRate = 50;
//            var actual = _monitoringRepository.Check_RespRate(respRate);
//            var expected= "Patient RespRate is " + respRate + " OK";
//            Assert.Equal(expected, actual);
//        }
//        [Fact]
//        public void CheckRespRateTests2()
//        {
//            const double respRate = 97;
//            var actual = _monitoringRepository.Check_RespRate(respRate);
//            var expected = "Patient RespRate is " + respRate + " which is not in range between " + MinRespRate + " and " + MaxRespRate;
//            Assert.Equal(expected, actual);
//        }
//    }
//}
