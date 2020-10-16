using System;
using System.Collections.Generic;
using AlertToCare.Models;

namespace AlertToCare.Monitoring
{
    public interface IMonitoringRepository
    {
        IEnumerable<PatientVital> GetMonitoringInformation();
        List<Tuple<string, string, string, string>> CheckVitalOfAllPatients();
    }
}