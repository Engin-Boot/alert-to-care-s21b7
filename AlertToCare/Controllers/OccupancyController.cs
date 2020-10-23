using AlertToCare.Models;
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

        // get the list of all patients in the hospital
        // GET: api/<OccupancyController>/GetAllPatients
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllPatients()
        {
            var patientModels= this._occupancyService.GetPatientsDetails();
            return Ok(patientModels);
        }

        // get the list of all patients in the particular ICU
        // GET: api/<OccupancyController>/icu1
        [HttpGet("{IcuId}")]
        public IActionResult Get(string icuId)
        {
            var patientModels = this._occupancyService.GetPatientsDetailsInIcu(icuId);
            return Ok(patientModels);
        }

        //Get all the beds in the all the icu of the hospital
        // GET: api/<OccupancyController>/GetBedDetails
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetBedDetails()
        {
          var bedModel =this._occupancyService.GetBedDetails();
            return Ok(bedModel);
        }

        //Get all the beds in particular icu of the hospital
        // GET: api/<OccupancyController>/GetBedDetails/icu1
        [HttpGet]
        [Route("GetBedDetails/{IcuId}")]
        public IActionResult GetBedDetailsForIcu(string icuId)
        {
            var bedModel = this._occupancyService.GetBedDetailsForIcu(icuId);
            return Ok(bedModel);
        }

        //get the status of particular bed
        // GET api/<OccupancyController>/GetBedStatus/bed1
        [HttpGet("GetBedStatus/{BedId}")]
        public IActionResult GetBedStatus(int bedId)
        {
            var bedStatus= this._occupancyService.IsBedFree(bedId);
            return Ok(bedStatus);
        }

        // POST api/<OccupancyController>
        [HttpPost]
        public IActionResult Post([FromBody] PatientModel newPatient)
        {
            if (newPatient.Equals(null)) return BadRequest();
           var patientModelData= this._occupancyService.AddNewPatient(newPatient);
           return Ok(patientModelData);

        }
        
        // DELETE api/<OccupancyController>/Discharge/patient5
        [HttpDelete("Discharge/{PId}")]
        public IActionResult Delete(string pId)
        {
            var dischargePatient= this._occupancyService.DischargePatient(pId);
            return Ok(dischargePatient);
        }
    }
}
