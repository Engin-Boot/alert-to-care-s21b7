using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlertToCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorController : ControllerBase
    {
        Monitoring.IMonitoringRepository _monitoring;

        public MonitorController(Monitoring.IMonitoringRepository monitoring)
        {
            this._monitoring = monitoring;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<Models.PatientVital> Get()
        {
            return this._monitoring.GetMonitoringformation();
        }
        //public string Post([FromBody] Models.PatientVital 
        //{
        //    return this._occupancyService.AddNewPatient(newPatient, layout);
        //}
    }
}