using System.Collections.Generic;
using System.Net;
using AlertToCare.DatabaseOperations;
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
        public Dictionary<int, BedModel> GetBedModelInformation()
        {
            var bedData = this._config.GetBedConfigurationInformation(DbOps.GetDbPath());
            return bedData;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetIcuModelInformation()
        {
           var icuData =this._config.GetIcuConfiguration(DbOps.GetDbPath()) ;
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
            this._config.AddNewBedConfiguration(newBedModel, DbOps.GetDbPath());
            return Ok(200);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult PostIcuModelData([FromBody] IcuModel newIcuModel)
        {
           var statusCode = this._config.AddNewIcuConfiguration(newIcuModel, DbOps.GetDbPath());
           if (statusCode.Equals(HttpStatusCode.InternalServerError))
               return BadRequest();
           return Ok();
        }

        // DELETE: api/ApiWithActions/5
        //Delete Bed
        [HttpDelete("RemoveBed/{bedId}")]
        public IActionResult Delete(int bedId)
        {
            var removeBed = this._config.RemoveBed(bedId, DbOps.GetDbPath());
            return Ok(removeBed);
        }

        [HttpDelete]
        [Route("RemoveIcu/{icuId}")]
        public object DeleteIcu(string icuId)
        {
            var statusCode = this._config.DeleteIcu(icuId, DbOps.GetDbPath());
            if (statusCode.Equals(HttpStatusCode.InternalServerError))
                return BadRequest();
            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllBedLayouts()
        {
            var bedLayouts = this._config.GetAllBedLayouts(DbOps.GetDbPath());
            return Ok(bedLayouts);
        }
    }
}
