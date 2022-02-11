using Ecology.Logic.Common.Models.Location;
using Ecology.Logic.Common.Services.Location;
using Swagger.Net.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Ecology.WebApi.Controllers.api
{
    [System.Web.Mvc.AllowAnonymous]
    [RoutePrefix("api/city")]
    public class CityController : ApiController
    {
        private readonly ICityService _service;

        public CityController(ICityService cityService)
        {
            _service = cityService;
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addcity")]
        public async Task<IHttpActionResult> AddCity([FromBody] CityBLL city)
        {
            var _Id = await _service.AddCity(city);

            return Ok(_Id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getcities")]
        public async Task<IHttpActionResult> GetCities()
        {

            var cities = await _service.GetCities();

            return Ok(cities);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPut, Route("editcity")]
        public async Task<IHttpActionResult> EditCity([FromBody] CityBLL city)
        {
            int _city = await _service.EditCity(city);

            return Ok(_city);
        }

    }
}