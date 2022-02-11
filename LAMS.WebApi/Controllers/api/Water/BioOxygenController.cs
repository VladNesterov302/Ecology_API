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
    [RoutePrefix("api/biooxygen")]
    public class BioOxygenController : ApiController
    {
        private readonly IBioOxygenService _service;

        public BioOxygenController(IBioOxygenService bioOxygenService)
        {
            _service = bioOxygenService;
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addbiooxygen")]
        public async Task<IHttpActionResult> AddBioOxygen([FromBody] BioOxygenBLL bioOxygen)
        {
            var _Id = await _service.AddBioOxygen(bioOxygen);

            return Ok(_Id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getbiooxygens")]
        public async Task<IHttpActionResult> GetBioOxygens()
        {

            var bio = await _service.GetBioOxygens();

            return Ok(bio);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPut, Route("editbiooxygen")]
        public async Task<IHttpActionResult> EditBioOxygen([FromBody] BioOxygenBLL bioOxygen)
        {
            int _bio = await _service.EditBioOxygen(bioOxygen);

            return Ok(_bio);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("delbiooxygen")]
        public async Task<IHttpActionResult> DelBioOxygen([FromUri] int id)
        {

            var bio = await _service.DelBioOxygen(id);

            return Ok(bio);
        }
    }
}