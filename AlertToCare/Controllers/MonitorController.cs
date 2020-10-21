using System;
using System.Collections.Generic;
using AlertToCare.Monitoring;
using Microsoft.AspNetCore.Mvc;

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

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            var patientVitalData= this._monitoring.GetMonitoringInformation();
            return Ok(patientVitalData);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GeAllPatientVitals()
        {   
            var vital = _monitoring.CheckVitalOfAllPatients();
            var vitalString = "PID:" + vital.PId + "\n" + "VitalBpm:" + vital.VitalBpmStatus + "\n" + "VitalSpo2:" + vital.VitalSPo2Status +
                              "\n" + "VitalRespRate:" + vital.VitalRespRateStatus;
            return Ok(vitalString);
        }
        
    }
}