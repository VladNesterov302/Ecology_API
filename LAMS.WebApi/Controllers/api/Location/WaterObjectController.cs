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
    [RoutePrefix("api/waterobject")]
    public class WaterObjectController : ApiController
    {
        private readonly IWaterObjectService _service;

        public WaterObjectController(IWaterObjectService waterObjectService)
        {
            _service = waterObjectService;
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addwaterobject")]
        public async Task<IHttpActionResult> AddWaterObject([FromBody] WaterObjectBLL waterObject)
        {
            var _Id = await _service.AddWaterObject(waterObject);

            return Ok(_Id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getwaterobjects")]
        public async Task<IHttpActionResult> GetWaterObjects()
        {

            var waterObjects = await _service.GetWaterObjects();

            return Ok(waterObjects);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPut, Route("editwaterobject")]
        public async Task<IHttpActionResult> EditWaterObject([FromBody] WaterObjectBLL waterObject)
        {
            int _waterObject = await _service.EditWaterObject(waterObject);

            return Ok(_waterObject);
        }


    }
}