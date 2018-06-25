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
        UnitOfWork unit;

        public MembershipController(UnitOfWork unit, CredentialRepository credential, UserRepository user, AdminRepository admin, ConsultantRepository consultant, SecurityTokenRepository token)
        {
            membershipBU = new MembershipBU(credential, user, admin, consultant, token);
            this.unit = unit;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAsync()
        {
            var token = Helper.GetTokenFromRequest(HttpContext.Request);
            var output = await membershipBU.GetUsersAsync(new GetUserDto(token));
            await unit.Complete();
            return Ok(output);
        }


        [HttpPost()]
        public async Task<IActionResult> AddAsync([FromBody]AddUserDto dto)
        {
            var output = await membershipBU.AddUserAsync(dto);
            await unit.Complete();
            return Ok(output);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateAsync([FromBody]UpdateUserDto dto)
        {
            await membershipBU.UpdateUserAsync(dto);
            await unit.Complete();
            return Ok();
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteAsync([FromBody]DeleteUserDto dto)
        {
            await membershipBU.DeleteUserAsync(dto);
            await unit.Complete();
            return Ok();
        }
    }
}