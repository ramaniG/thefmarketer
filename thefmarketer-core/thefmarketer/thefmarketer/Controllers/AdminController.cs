using System.Threading.Tasks;
using Fmarketer.Business;
using Fmarketer.DataAccess.Repository;
using Fmarketer.Models;
using Fmarketer.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Fmarketer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        AdminBU adminBU;
        UnitOfWork unit;

        public AdminController(UnitOfWork unit, SecurityTokenRepository securityToken, ConsultantRepository consultant, RequestRepository request, AdminRepository admin)
        {
            adminBU = new AdminBU(securityToken, consultant, request, admin);
            this.unit = unit;
        }

        [HttpPost("SearchConsultant")]
        public async Task<IActionResult> SearchConsultant([FromBody]SearchConsultantDto dto)
        {
            var output = await adminBU.SearchConsultantAsync(dto);
            await unit.Complete();
            return Ok(output);
        }

        [HttpPost("SearchRequest")]
        public async Task<IActionResult> SearchRequest([FromBody]SearchRequestDto dto)
        {
            var output = await adminBU.SearchRequestAsync(dto);
            await unit.Complete();
            return Ok(output);
        }

        [HttpPost("UpdateRequest")]
        public async Task<IActionResult> UpdateRequest([FromBody]UpdateRequestDto dto)
        {
            await adminBU.UpdateRequestAsync(dto);
            await unit.Complete();
            return Ok();
        }
    }
}