using System.Collections.Generic;
using AlertToCare.Models;

namespace AlertToCare.Monitoring
{
    public interface IMonitoringRepository
    {
        IEnumerable<PatientVital> GetMonitoringInformation();
    }
}