using AlertToCare.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AlertToCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorController : ControllerBase
    {
        private readonly Monitoring.IMonitoringRepository _monitoring;

        public MonitorController(Monitoring.IMonitoringRepository monitoring)
        {
            this._monitoring = monitoring;
        }

        [HttpGet]
        [Route("[action]")]
        public Dictionary<string, PatientVital> GeAllPatientVitals()
        {   
            var vitals = _monitoring.CheckVitalOfAllPatients();
            return vitals;
        }
        
    }
}