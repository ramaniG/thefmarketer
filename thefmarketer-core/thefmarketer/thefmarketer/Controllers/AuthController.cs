using Fmarketer.Business;
using Fmarketer.DataAccess.Repository;
using Fmarketer.Models;
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
        private AuthenticationBU authentication;
        UnitOfWork unit;

        public AuthController(UnitOfWork unit, CredentialRepository credentialRepository, SecurityTokenRepository securityTokenRepository)
        {
            authentication = new AuthenticationBU(credentialRepository, securityTokenRepository);
            this.unit = unit;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginDto dto)
        {
            var user = await authentication.LoginByEmailAsync(dto);

            if (user == null)
            {
                BadRequest("Invalid credential passed");
            }

            await unit.Complete();
            return Ok(user);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> LogoutAsync([FromBody]LogoutDto dto)
        {
            await authentication.LogoutByEmailAsync(dto);
            await unit.Complete();
            return Ok();
        }
    }
}