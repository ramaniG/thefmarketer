using System.Threading.Tasks;
using Fmarketer.Base;
using Fmarketer.Business;
using Fmarketer.DataAccess.Repository;
using Fmarketer.Models;
using Fmarketer.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Fmarketer.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController : Controller
    {
        MembershipBU membershipBU;

        public MembershipController(UnitOfWork unit, CredentialRepository credential, UserRepository user, AdminRepository admin, ConsultantRepository consultant, SecurityTokenRepository token)
        {
            membershipBU = new MembershipBU(unit, credential, user, admin, consultant, token);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAsync()
        {
            var token = Helper.GetTokenFromRequest(HttpContext.Request);
            return Ok(await membershipBU.GetUsersAsync(new GetUserDto(token)));
        }


        [HttpPost()]
        public async Task<IActionResult> AddAsync([FromBody]AddUserDto dto)
        {
            return Ok(await membershipBU.AddUserAsync(dto));
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateAsync([FromBody]UpdateUserDto dto)
        {
            await membershipBU.UpdateUserAsync(dto);
            return Ok();
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteAsync([FromBody]DeleteUserDto dto)
        {
            await membershipBU.DeleteUserAsync(dto);
            return Ok();
        }
    }
}