using System.Collections.Generic;
using AlertToCare.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlertToCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly Configuration.IConfigurationRepository _config;
        public ConfigurationController(Configuration.IConfigurationRepository config)
        {
            this._config = config;
        }
        // GET: api/Configuration
        //GET Bed Model
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetBedModelInformation()
        {
            IEnumerable<BedModel> bedData = this._config.GetBedConfigurationInformation();
            return Ok(bedData);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetIcuModelInformation()
        {
           IEnumerable<IcuModel> icuData =this._config.GetIcuConfiguration() ;
            return Ok(icuData);
        }
        #region getIcuById
        // GET: api/Configuration/5
        //[HttpGet("{id}", Name = "Get")]
        //[Route("[action]")]
        //public Models.IcuModel GetEachIcu(string id)
        //{
        //    Models.IcuModel icu = default(Models.IcuModel);
        //    foreach (Models.IcuModel icuTemp in _config.GetIcuConfiguration())
        //    {
        //        if (icuTemp.IcuId == id)
        //        {
        //            icu = icuTemp;
        //            break;
        //        }

        //    }
        //    return icu;
        //}
        #endregion
        #region getbedById

        //[HttpGet("{id}", Name = "Get")]

        //public Models.BedModel Get(string id)
        //{
        //    Models.BedModel bed = default(Models.BedModel);
        //    foreach (Models.BedModel bedTemp in _config.GetBedConfigurationInformation())
        //    {
        //        if (bedTemp.BedId == id)
        //        {
        //            bed = bedTemp;
        //            break;
        //        }

        //    }
        //    return bed;
        //}
        #endregion
        // POST: api/Configuration
        //post Bed Model
        [HttpPost]
        [Route("[action]")]
        public IActionResult PostBedModelData([FromBody] BedModel newBedModel)
        { 
            this._config.AddNewBedConfiguration(newBedModel);
            return Ok(200);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult PostIcuModelData([FromBody] IcuModel newIcuModel)
        {
            this._config.AddNewIcuConfiguration(newIcuModel);
            return Ok(200);
        }

        // DELETE: api/ApiWithActions/5
        //Delete Bed
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            string removeBed = this._config.RemoveBed(id);
            return Ok(removeBed);
        }
    }
}
