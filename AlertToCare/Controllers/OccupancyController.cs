using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlertToCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupancyController : ControllerBase
    {
        private readonly Occupancy.IOccupancyService _occupancyService;

        public OccupancyController(Occupancy.IOccupancyService occupancyService)
        {
            this._occupancyService = occupancyService;
        }

        // GET: api/<OccupancyController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Models.PatientModel> patientModels= this._occupancyService.GetPatientsDetails();
            return Ok(patientModels);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetBedDetails()
        {
          IEnumerable<Models.BedModel> bedModel =this._occupancyService.GetBedDetails();
            return Ok(bedModel);
        }

        // GET api/<OccupancyController>/5
        [HttpGet("{BedId}")]
        public IActionResult Get(string bedId)
        {
            string bedStatus= this._occupancyService.CheckBedStatus(bedId);
            return Ok(bedStatus);
        }

        // POST api/<OccupancyController>
        [HttpPost("{layout}")]
        public IActionResult Post([FromBody] Models.PatientModel newPatient,string layout)
        {
           string patientModelData= this._occupancyService.AddNewPatient(newPatient, layout);
           return Ok(patientModelData);

        }

        // DELETE api/<OccupancyController>/5
        [HttpDelete("{PId}")]
        public IActionResult Delete(string pId)
        {
            string dischargePatient= this._occupancyService.DischargePatient(pId);
            return Ok(dischargePatient);
        }
    }
}
