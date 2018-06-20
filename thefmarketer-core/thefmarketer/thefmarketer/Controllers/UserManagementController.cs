using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fmarketer.Business;
using Fmarketer.DataAccess.Repository;
using Fmarketer.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fmarketer.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : Controller
    {
        UserManagement usermanagement;

        public UserManagementController(CredentialRepository credential, UserRepository user, AdminRepository admin, ConsultantRepository consultant, SecurityTokenRepository token)
        {
            usermanagement = new UserManagement(credential, user, admin, consultant, token);
        }

        [HttpGet()]
        public async Task<IActionResult> AddAsync([FromBody]GetUserDto dto)
        {
            return Ok(await usermanagement.GetUsersAsync(dto));
        }


        [HttpPost()]
        public async Task<IActionResult> AddAsync([FromBody]AddUserDto dto)
        {
            return Ok(await usermanagement.AddUserAsync(dto));
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateAsync([FromBody]UpdateUserDto dto)
        {
            await usermanagement.UpdateUserAsync(dto);
            return Ok();
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteAsync([FromBody]DeleteUserDto dto)
        {
            await usermanagement.DeleteUserAsync(dto);
            return Ok();
        }
    }
}