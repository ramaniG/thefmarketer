using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fmarketer.Business;
using Fmarketer.DataAccess.Repository;
using Fmarketer.Models;
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
        UnitOfWork unit;

        public ConsultantController(UnitOfWork unit, SecurityTokenRepository securityToken, ConsultantRepository consultant, ConsultantCoverageRepository coverage, 
            ConsultantServiceRepository service, RequestRepository request, ChatRepository chat)
        {
            consultantBU = new ConsultantBU(securityToken, consultant, coverage, service, request, chat);
            this.unit = unit;

        }

        [HttpPost("SearchRequest")]
        public async Task<IActionResult> SearchRequest([FromBody]SearchRequestDto dto)
        {
            var output = await consultantBU.SearchRequestAsync(dto);
            await unit.Complete();
            return Ok(output);
        }

        [HttpPost("State")]
        public async Task<IActionResult> AddState([FromBody]AddStateDto dto)
        {
            await consultantBU.AddStateAsync(dto);
            await unit.Complete();
            return Ok();
        }

        [HttpPost("Service")]
        public async Task<IActionResult> AddService([FromBody]AddServiceDto dto)
        {
            await consultantBU.AddServiceAsync(dto);
            await unit.Complete();
            return Ok();
        }

        [HttpPut("State")]
        public async Task<IActionResult> UpdateState([FromBody]UpdateStateDto dto)
        {
            await consultantBU.UpdateStateAsync(dto);
            await unit.Complete();
            return Ok();
        }

        [HttpPut("Service")]
        public async Task<IActionResult> UpdateService([FromBody]UpdateServiceDto dto)
        {
            await consultantBU.UpdateServiceAsync(dto);
            await unit.Complete();
            return Ok();
        }

        [HttpPost("Chat")]
        public async Task<IActionResult> SendChat([FromBody]SendChatDto dto)
        {
            await consultantBU.SendChatAsync(dto);
            await unit.Complete();
            return Ok();
        }
    }
}
