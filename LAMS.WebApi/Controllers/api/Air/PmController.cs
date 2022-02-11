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
    }
}