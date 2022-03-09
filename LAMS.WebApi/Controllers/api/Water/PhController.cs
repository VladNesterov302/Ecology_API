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
    [RoutePrefix("api/ph")]
    public class PhController : ApiController
    {
        private readonly IPhService _service;

        public PhController(IPhService phService)
        {
            _service = phService;
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addph")]
        public async Task<IHttpActionResult> AddPh([FromBody] PhBLL ph)
        {
            var _Id = await _service.AddPh(ph);

            return Ok(_Id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getphs")]
        public async Task<IHttpActionResult> GetPhs()
        {

            var phs = await _service.GetPhs();

            return Ok(phs);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPut, Route("editph")]
        public async Task<IHttpActionResult> EditPh([FromBody] PhBLL ph)
        {
            int _ph = await _service.EditPh(ph);

            return Ok(_ph);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("delph")]
        public async Task<IHttpActionResult> DelPh([FromUri] int id)
        {

            var ph = await _service.DelPh(id);

            return Ok(ph);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getlevelphstatistic")]
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
        [HttpGet, Route("getwaterobjectphstatistic")]
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
        [HttpGet, Route("smallpredictionph")]
        public async Task<IHttpActionResult> SmallPrediction([FromUri] int id)
        {
            var dose = await _service.SmallPrediction(id);

            return Ok(dose);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("bigpredictionph")]
        public async Task<IHttpActionResult> BigPrediction([FromUri] int id)
        {
            var dose = await _service.BigPrediction(id);

            return Ok(dose);
        }
    }
}