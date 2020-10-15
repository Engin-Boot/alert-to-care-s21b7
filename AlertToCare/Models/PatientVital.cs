using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Models
{
    public class PatientVital
    {
        public string PId { get; set; }
        public double VitalBpm { get; set; }
        public double VitalSpo2 { get; set; }
        public double VitalResperate { get; set; }
    }
}
