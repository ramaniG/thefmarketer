using Fmarketer.Business;
using Fmarketer.DataAccess.Repository;
using Fmarketer.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fmarketer.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private Authentication _authentication;

        public AuthController(UserRepository userRepository)
        {
            _authentication = new Authentication(userRepository);
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody]LoginDto value)
        {
            var user = _authentication.Login(value);

            if (user == null)
            {
                BadRequest("Invalid credential passed");
            }

            return Ok(user);
        }

        [HttpPost("Logout")]
        public IActionResult Logout([FromBody]LoginDto value)
        {
            var user = _authentication.Login(value);

            if (user == null)
            {
                BadRequest("Invalid credential passed");
            }

            return Ok();
        }
    }
}