using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Models
{
    public class PatientModel
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string VitalBpm { get; set; }
        public string VitalSpo2 { get; set; }
        public string VitalResperate { get; set; }
    }
}
