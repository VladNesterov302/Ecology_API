using Ecology.Logic.Common.Models.Statistic;
using Ecology.Logic.Common.Models.Water;
using Ecology.Logic.Common.Services.Water;
using Swagger.Net.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Ecology.WebApi.Controllers.api.Water
{
    [System.Web.Mvc.AllowAnonymous]
    [RoutePrefix("api/chemicaloxygen")]
    public class ChemicalOxygenController : ApiController
    {
        private readonly IChemicalOxygenService _service;

        public ChemicalOxygenController(IChemicalOxygenService chemicalOxygenService)
        {
            _service = chemicalOxygenService;
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addchemicaloxygen")]
        public async Task<IHttpActionResult> AddChemicalOxygen([FromBody] ChemicalOxygenBLL chemicalOxygen)
        {
            var _Id = await _service.AddChemicalOxygen(chemicalOxygen);

            return Ok(_Id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getchemicaloxygens")]
        public async Task<IHttpActionResult> GetChemicalOxygens()
        {

            var chemicalOxygen = await _service.GetChemicalOxygens();

            return Ok(chemicalOxygen);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPut, Route("editchemicaloxygen")]
        public async Task<IHttpActionResult> EditChemicalOxygen([FromBody] ChemicalOxygenBLL chemicalOxygen)
        {
            int _chemicalOxygen = await _service.EditChemicalOxygen(chemicalOxygen);

            return Ok(_chemicalOxygen);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("delchemicaloxygen")]
        public async Task<IHttpActionResult> DelChemicalOxygen([FromUri] int id)
        {

            var chemicalOxygen = await _service.DelChemicalOxygen(id);

            return Ok(chemicalOxygen);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getlevelchemicaloxygenstatistic")]
        public async Task<IHttpActionResult> GetLevelStatistic()
        {
            IEnumerable<LevelStatisticBLL> levelStatistics = await _service.GetLevelStatistic();
            if (levelStatistics == null)
            {
                return BadRequest("Ошибка в запросе");
            }

            return Ok(levelStatistics);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getwaterobjectchemicaloxygenstatistic")]
        public async Task<IHttpActionResult> GetWaterObjectStatistic([FromUri] int id)
        {
            IEnumerable<LevelStatisticBLL> levelStatistics = await _service.GetWaterObjectStatistic(id);
            if (levelStatistics == null)
            {
                return BadRequest("Ошибка в запросе");
            }

            return Ok(levelStatistics);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("smallpredictionchemicaloxygen")]
        public async Task<IHttpActionResult> SmallPrediction([FromUri] int id)
        {
            var dose = await _service.SmallPrediction(id);

            return Ok(dose);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("bigpredictionchemicaloxygen")]
        public async Task<IHttpActionResult> BigPrediction([FromUri] int id)
        {
            var dose = await _service.BigPrediction(id);

            return Ok(dose);
        }
    }
}