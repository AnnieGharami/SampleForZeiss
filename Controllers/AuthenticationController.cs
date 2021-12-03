using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Platform.ApplicationServices.AuthService;

namespace Platform.ApplicationServices.Controllers
{
    /// <summary>
    /// <para>Annie - 26-FEB-2020</para>
    /// <para>defines and handles authentication</para>
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        public AuthenticationController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost, Route("request")]
        public ActionResult RequestToken([FromBody] AuthenticateModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string token;
            if (_authService.IsAuthenticated(user, out token))
            {

                return Ok(token);
            }
            return BadRequest("Invalid Request");

        }
    }
}