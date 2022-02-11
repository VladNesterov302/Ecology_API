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
    [RoutePrefix("api/sera")]
    public class SeraController : ApiController
    {
        private readonly ISeraService _service;

        public SeraController(ISeraService seraService)
        {
            _service = seraService;
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addsera")]
        public async Task<IHttpActionResult> AddSera([FromBody] SeraBLL sera)
        {
            var _Id = await _service.AddSera(sera);

            return Ok(_Id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getseras")]
        public async Task<IHttpActionResult> GetSeras()
        {

            var seras = await _service.GetSeras();

            return Ok(seras);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPut, Route("editsera")]
        public async Task<IHttpActionResult> EditSera([FromBody] SeraBLL sera)
        {
            int _sera = await _service.EditSera(sera);

            return Ok(_sera);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("delsera")]
        public async Task<IHttpActionResult> DelSera([FromUri] int id)
        {

            var sera = await _service.DelSera(id);

            return Ok(sera);
        }
    }
}