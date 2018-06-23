using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fmarketer.Business;
using Fmarketer.DataAccess.Repository;
using Fmarketer.Models;
using Fmarketer.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fmarketer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        AdminBU adminBU;

        public AdminController(UnitOfWork unit, SecurityTokenRepository securityToken, ConsultantRepository consultant, RequestRepository request, AdminRepository admin)
        {
            adminBU = new AdminBU(unit, securityToken, consultant, request, admin);
        }

        [HttpPost("SearchConsultant")]
        public async Task<IActionResult> SearchConsultant([FromBody]SearchConsultantDto dto)
        {
            return Ok(await adminBU.SearchConsultantAsync(dto));
        }

        [HttpPost("SearchRequest")]
        public async Task<IActionResult> SearchRequest([FromBody]SearchRequestDto dto)
        {
            return Ok(await adminBU.SearchRequestAsync(dto));
        }

        [HttpPost("UpdateRequest")]
        public async Task<IActionResult> UpdateRequest([FromBody]UpdateRequestDto dto)
        {
            await adminBU.UpdateRequestAsync(dto);
            return Ok();
        }
    }
}