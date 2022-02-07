using FluentValidation;
using Ecology.Logic.Common.Models.Users;
using Ecology.Logic.Common.Services.Users;
using Ecology.WebApi.Models.Users;
using Swagger.Net.Annotations;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Ecology.WebApi.Controllers.api
{
    /// <summary>
    /// API controller управления пользователями.
    /// </summary>
    [System.Web.Mvc.AllowAnonymous]
    [RoutePrefix("api/userregistration")]
    public class RegistrationController : ApiController
    {
        private readonly IRegistrationService _service;

        public RegistrationController(IRegistrationService registrationService)
        {
            _service = registrationService;
        }

       
        [System.Web.Mvc.AllowAnonymous]
        [HttpPost, Route("register")]
        public async Task<IHttpActionResult> Register([FromBody] RegisterUser model)
        {

            var id = await _service.RegisterAsync(model.Email, model.UserName, model.Password);

            if (id == null)
            {
                // throws 409 conflict
                return Ok(0);
            }
            return Ok(id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("adduser")]
        public async Task<IHttpActionResult> Registration([FromBody] User user)
        {
            var _docId = await _service.Registration(user);

            return Ok(_docId);
        }


    }
}
