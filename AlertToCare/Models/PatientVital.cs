using System.Diagnostics.CodeAnalysis;

namespace AlertToCare.Models
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class PatientVital
    {
        public string PId { get;  set; }
        public double VitalBpm { get;  set; }
        public double VitalSpo2 { get; set; }
        public double VitalRespRate { get;  set; }
    }
}
