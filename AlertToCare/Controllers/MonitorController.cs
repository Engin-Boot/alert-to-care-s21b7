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
        public IEnumerable<Models.PatientVital> Get()
        {
            return this._monitoring.GetMonitoringInformation();
        }
        [HttpGet]
        [Route("[action]")]
        public List<Tuple<string, string, string, string>> GeAllPatientVitals()
        {
            return this._monitoring.CheckVitalOfAllPatients();
        }
        //public string Post([FromBody] Models.PatientVital 
        //{
        //    return this._occupancyService.AddNewPatient(newPatient, layout);
        //}
    }
}