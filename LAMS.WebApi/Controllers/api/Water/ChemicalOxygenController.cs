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
    [RoutePrefix("api/chemicaloxygen")]
    public class ChemicalOxygenController : ApiController
    {
        private readonly IChemicalOxygenService _service;

        public ChemicalOxygenController(IChemicalOxygenService chemicalOxygenService)
        {
            _service = chemicalOxygenService;
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addchemicaloxygen")]
        public async Task<IHttpActionResult> AddChemicalOxygen([FromBody] ChemicalOxygenBLL chemicalOxygen)
        {
            var _Id = await _service.AddChemicalOxygen(chemicalOxygen);

            return Ok(_Id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getchemicaloxygens")]
        public async Task<IHttpActionResult> GetChemicalOxygens()
        {

            var chemicalOxygen = await _service.GetChemicalOxygens();

            return Ok(chemicalOxygen);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPut, Route("editchemicaloxygen")]
        public async Task<IHttpActionResult> EditChemicalOxygen([FromBody] ChemicalOxygenBLL chemicalOxygen)
        {
            int _chemicalOxygen = await _service.EditChemicalOxygen(chemicalOxygen);

            return Ok(_chemicalOxygen);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("delchemicaloxygen")]
        public async Task<IHttpActionResult> DelChemicalOxygen([FromUri] int id)
        {

            var chemicalOxygen = await _service.DelChemicalOxygen(id);

            return Ok(chemicalOxygen);
        }
    }
}