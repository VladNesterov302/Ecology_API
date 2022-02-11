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
    [RoutePrefix("api/azot")]
    public class AzotController : ApiController
    {
        private readonly IAzotService _service;

        public AzotController(IAzotService azotService)
        {
            _service = azotService;
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addazot")]
        public async Task<IHttpActionResult> AddAzot([FromBody] AzotBLL azot)
        {
            var _Id = await _service.AddAzot(azot);

            return Ok(_Id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getazots")]
        public async Task<IHttpActionResult> GetAzots()
        {

            var azots = await _service.GetAzots();

            return Ok(azots);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPut, Route("editazot")]
        public async Task<IHttpActionResult> EditAzot([FromBody] AzotBLL azot)
        {
            int _azot = await _service.EditAzot(azot);

            return Ok(_azot);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("delazot")]
        public async Task<IHttpActionResult> DelAzot([FromUri] int id)
        {

            var azot = await _service.DelAzot(id);

            return Ok(azot);
        }
    }
}