using System;
using System.Collections.Generic;
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
            IEnumerable <Models.PatientVital> patientVitalData= this._monitoring.GetMonitoringInformation();
            return Ok(patientVitalData);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GeAllPatientVitals()
        {
            List < Tuple<string, string, string, string> > vitalUpdateOfPatient= this._monitoring.CheckVitalOfAllPatients();
            return Ok(vitalUpdateOfPatient);
        }
        
    }
}