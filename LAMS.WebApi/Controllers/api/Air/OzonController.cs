using Ecology.Logic.Common.Models.Air;
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
    [RoutePrefix("api/ozon")]
    public class OzonController : ApiController
    {
        private readonly IOzonService _service;

        public OzonController(IOzonService ozonService)
        {
            _service = ozonService;
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addozon")]
        public async Task<IHttpActionResult> AddOzon([FromBody] OzonBLL ozon)
        {
            var _Id = await _service.AddOzon(ozon);

            return Ok(_Id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getozons")]
        public async Task<IHttpActionResult> GetOzons()
        {

            var ozons = await _service.GetOzons();

            return Ok(ozons);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPut, Route("editozon")]
        public async Task<IHttpActionResult> EditOzon([FromBody] OzonBLL ozon)
        {
            int _ozon = await _service.EditOzon(ozon);

            return Ok(_ozon);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("delozon")]
        public async Task<IHttpActionResult> DelOzon([FromUri] int id)
        {

            var azot = await _service.DelOzon(id);

            return Ok(azot);
        }
    }
}