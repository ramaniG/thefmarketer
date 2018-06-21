using System.Threading.Tasks;
using Fmarketer.Business;
using Fmarketer.DataAccess.Repository;
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

        public MembershipController(CredentialRepository credential, UserRepository user, AdminRepository admin, ConsultantRepository consultant, SecurityTokenRepository token)
        {
            membershipBU = new MembershipBU(credential, user, admin, consultant, token);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAsync(GetUserDto dto)
        {
            return Ok(await membershipBU.GetUsersAsync(dto));
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