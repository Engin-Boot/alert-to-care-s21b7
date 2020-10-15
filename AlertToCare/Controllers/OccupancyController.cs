using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlertToCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupancyController : ControllerBase
    {
        Occupancy.IOccupancyService _occupancyService;

        public OccupancyController(Occupancy.IOccupancyService occupancyService)
        {
            this._occupancyService = occupancyService;
        }

        // GET: api/<OccupancyController>
        [HttpGet]
        public IEnumerable<Models.PatientModel> Get()
        {
            return this._occupancyService.GetPatientsDetails();
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<Models.BedModel> GetBedDetails()
        {
            return this._occupancyService.GetBedDetails();
        }

        // GET api/<OccupancyController>/5
        [HttpGet("{BedId}")]
        public string Get(string BedId)
        {
            return this._occupancyService.CheckBedStatus(BedId);
        }

        // POST api/<OccupancyController>
        [HttpPost]
        public string Post([FromBody] Models.PatientModel newPatient,string layout)
        {
            return this._occupancyService.AddNewPatient(newPatient, layout);
        }

        // DELETE api/<OccupancyController>/5
        [HttpDelete("{PId}")]
        public string Delete(string PId)
        {
            return this._occupancyService.DishchargePatient(PId);
        }
        [HttpGet]
        [Route("[action]")]
        public IEnumerable<Models.PatientVital> check()
        {
            return this._occupancyService.Display();
        }
    }
}
