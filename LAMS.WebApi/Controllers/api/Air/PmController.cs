using Ecology.Logic.Common.Models.Air;
using Ecology.Logic.Common.Models.Statistic;
using Ecology.Logic.Common.Services.Air;
using Swagger.Net.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Ecology.WebApi.Controllers.api.Air
{
    [System.Web.Mvc.AllowAnonymous]
    [RoutePrefix("api/pm")]
    public class PmController : ApiController
    {
        private readonly IPmService _service;

        public PmController(IPmService pmService)
        {
            _service = pmService;
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addpm")]
        public async Task<IHttpActionResult> AddPm([FromBody] PmBLL pm)
        {
            var _Id = await _service.AddPm(pm);

            return Ok(_Id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getpms")]
        public async Task<IHttpActionResult> GetPms()
        {

            var pms = await _service.GetPms();

            return Ok(pms);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPut, Route("editpm")]
        public async Task<IHttpActionResult> EditPm([FromBody] PmBLL pm)
        {
            int _pm = await _service.EditPm(pm);

            return Ok(_pm);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("delpm")]
        public async Task<IHttpActionResult> DelPm([FromUri] int id)
        {

            var pm = await _service.DelPm(id);

            return Ok(pm);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getlevelpmstatistic")]
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
        [HttpGet, Route("getlevelpm10statistic")]
        public async Task<IHttpActionResult> GetLevel10Statistic()
        {
            IEnumerable<LevelStatisticBLL> levelStatistics = await _service.GetLevel10Statistic();
            if (levelStatistics == null)
            {
                return BadRequest("Ошибка в запросе");
            }

            return Ok(levelStatistics);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getcitypmstatistic")]
        public async Task<IHttpActionResult> GetCityStatistic([FromUri] int id)
        {
            IEnumerable<LevelStatisticBLL> levelStatistics = await _service.GetCityStatistic(id);
            if (levelStatistics == null)
            {
                return BadRequest("Ошибка в запросе");
            }

            return Ok(levelStatistics);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getcitypm10statistic")]
        public async Task<IHttpActionResult> GetCity10Statistic([FromUri] int id)
        {
            IEnumerable<LevelStatisticBLL> levelStatistics = await _service.GetCity10Statistic(id);
            if (levelStatistics == null)
            {
                return BadRequest("Ошибка в запросе");
            }

            return Ok(levelStatistics);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("smallpredictionpm")]
        public async Task<IHttpActionResult> SmallPrediction([FromUri] int id)
        {
            var dose = await _service.SmallPrediction(id);

            return Ok(dose);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("bigpredictionpm")]
        public async Task<IHttpActionResult> BigPrediction([FromUri] int id)
        {
            var dose = await _service.BigPrediction(id);

            return Ok(dose);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("smallpredictionpm10")]
        public async Task<IHttpActionResult> SmallPrediction10([FromUri] int id)
        {
            var dose = await _service.SmallPrediction10(id);

            return Ok(dose);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("bigpredictionpm10")]
        public async Task<IHttpActionResult> BigPrediction10([FromUri] int id)
        {
            var dose = await _service.BigPrediction10(id);

            return Ok(dose);
        }
    }
}