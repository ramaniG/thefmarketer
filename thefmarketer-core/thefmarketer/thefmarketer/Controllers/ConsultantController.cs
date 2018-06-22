using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fmarketer.Business;
using Fmarketer.DataAccess.Repository;
using Fmarketer.Models.Dto;
using Fmarketer.Models.Model;
using Microsoft.AspNetCore.Mvc;

namespace Fmarketer.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Consultant")]
    public class ConsultantController : Controller
    {
        ConsultantBU consultantBU;

        public ConsultantController(SecurityTokenRepository securityToken, ConsultantRepository consultant, ConsultantCoverageRepository coverage, 
            ConsultantServiceRepository service, RequestRepository request, ChatRepository chat)
        {
            consultantBU = new ConsultantBU(securityToken, consultant, coverage, service, request, chat);
        }

        [HttpPost("SearchRequest")]
        public async Task<IActionResult> SearchRequest([FromBody]SearchRequestDto dto)
        {
            return Ok(await consultantBU.SearchRequestAsync(dto));
        }

        [HttpPost("State")]
        public async Task<IActionResult> AddState([FromBody]AddStateDto dto)
        {
            await consultantBU.AddStateAsync(dto);
            return Ok();
        }

        [HttpPost("Service")]
        public async Task<IActionResult> AddService([FromBody]AddServiceDto dto)
        {
            await consultantBU.AddServiceAsync(dto);
            return Ok();
        }

        [HttpPut("State")]
        public async Task<IActionResult> UpdateState([FromBody]UpdateStateDto dto)
        {
            await consultantBU.UpdateStateAsync(dto);
            return Ok();
        }

        [HttpPut("Service")]
        public async Task<IActionResult> UpdateService([FromBody]UpdateServiceDto dto)
        {
            await consultantBU.UpdateServiceAsync(dto);
            return Ok();
        }

        [HttpPost("SendChat")]
        public async Task<IActionResult> SendChat([FromBody]SendChatDto dto)
        {
            await consultantBU.SendChatAsync(dto);
            return Ok();
        }
    }
}
