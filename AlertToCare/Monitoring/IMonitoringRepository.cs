using System.Collections.Generic;
using AlertToCare.Models;

namespace AlertToCare.Monitoring
{
    public interface IMonitoringRepository
    {
     List<PatientVital> GetMonitoringformation();
    }
}