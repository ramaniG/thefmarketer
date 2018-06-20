using Fmarketer.Business;
using Fmarketer.DataAccess.Repository;
using Fmarketer.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fmarketer.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private Authentication authentication;

        public AuthController(CredentialRepository credentialRepository, SecurityTokenRepository securityTokenRepository)
        {
            authentication = new Authentication(credentialRepository, securityTokenRepository);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginDto dto)
        {
            var user = await authentication.LoginByEmailAsync(dto);

            if (user == null)
            {
                BadRequest("Invalid credential passed");
            }

            return Ok(user);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> LogoutAsync([FromBody]LogoutDto dto)
        {
            await authentication.LogoutByEmailAsync(dto);
            return Ok();
        }
    }
}