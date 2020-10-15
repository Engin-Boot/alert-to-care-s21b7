using System.Collections.Generic;
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
        [HttpGet]
        public IEnumerable<Models.BedModel> Get()
        {
            return this._config.GetBedConfigurationInformation();
        }
        [HttpGet]
        [Route("[action]")]
        public IEnumerable<Models.IcuModel> GetIcu()
        {
            return this._config.GetIcuConfiguration();
        }

        // GET: api/Configuration/5
        [HttpGet("{id}", Name = "Get")]
        [Route("[action]")]
        public Models.IcuModel GetEachIcu(string id)
        {
            Models.IcuModel icu = default(Models.IcuModel);
            foreach (Models.IcuModel icuTemp in _config.GetIcuConfiguration())
            {
                if (icuTemp.IcuId == id)
                {
                    icu = icuTemp;
                    break;
                }

            }
            return icu;
        }

        [HttpGet("{id}", Name = "Get")]
       
        public Models.BedModel Get(string id)
        {
            Models.BedModel bed = default(Models.BedModel);
            foreach (Models.BedModel bedTemp in _config.GetBedConfigurationInformation())
            {
                if (bedTemp.BedId == id)
                {
                    bed = bedTemp;
                    break;
                }

            }
            return bed;
        }
        // POST: api/Configuration
        [HttpPost]
        public void Post([FromBody] Models.BedModel newBedModel)
        {
            this._config.AddNewBedConfiguration(newBedModel);
        }

        [HttpPost]
        [Route("[action]")]
        public void PostIcu([FromBody] Models.IcuModel newIcuModel)
        {
            this._config.AddNewIcuConfiguration(newIcuModel);
        }

        // PUT: api/Configuration/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(string id)
        {
            return this._config.RemoveBed(id);
        }
    }
}
