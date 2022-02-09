using Ecology.Logic.Common.Models.Radiation;
using Ecology.Logic.Common.Services.Radiation;
using Swagger.Net.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace LAMS.WebApi.Controllers.api
{
    [System.Web.Mvc.AllowAnonymous]
    [RoutePrefix("api/radiation")]
    public class RadiationController : ApiController
    {
        private readonly IRadiationService _service;

        public RadiationController(IRadiationService radiationService)
        {
            _service = radiationService;
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addradiation")]
        public async Task<IHttpActionResult> AddRadiation([FromBody] RadiationBLL radiation)
        {
            var _Id = await _service.AddRadiation(radiation);

            return Ok(_Id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getradiations")]
        public async Task<IHttpActionResult> GetRadiations()
        {

            var radiations = await _service.GetRadiations();

            return Ok(radiations);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPut, Route("editradiation")]
        public async Task<IHttpActionResult> EditRadiation([FromBody] RadiationBLL radiation)
        {
            int _radiation = await _service.EditRadiation(radiation);

            return Ok(_radiation);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("delradiation")]
        public async Task<IHttpActionResult> DelRadiation([FromUri] int id)
        {
           
            var radiation = await _service.DelRadiation(id);

            return Ok(radiation);
        }

    }
}