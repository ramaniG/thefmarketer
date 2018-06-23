using Fmarketer.Business;
using Fmarketer.DataAccess.Repository;
using Fmarketer.Models;
using Fmarketer.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace thefmarketer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        UserBU userBU;

        public UserController(UnitOfWork unit, SecurityTokenRepository securityToken, ConsultantRepository consultant,
            RequestRepository request, ReviewRepository review, ChatRepository chat, UserRepository user)
        {
            userBU = new UserBU(unit, securityToken, consultant, request, review, chat, user);
        }

        [HttpPost("SearchConsultant")]
        public async Task<IActionResult> SearchConsultant([FromBody]SearchConsultantDto dto)
        {
            return Ok(await userBU.SearchConsultantAsync(dto));
        }

        [HttpPost("SearchRequest")]
        public async Task<IActionResult> SearchRequest([FromBody]SearchRequestDto dto)
        {
            return Ok(await userBU.SearchRequestAsync(dto));
        }

        [HttpPost("CreateRequest")]
        public async Task<IActionResult> CreateRequest([FromBody]CreateRequestDto dto)
        {
            await userBU.CreateRequestAsync(dto);
            return Ok();
        }

        [HttpPost("UpdateRequest")]
        public async Task<IActionResult> UpdateRequest([FromBody]UpdateRequestDto dto)
        {
            await userBU.UpdateRequestAsync(dto);
            return Ok();
        }

        [HttpPost("CompleteRequest")]
        public async Task<IActionResult> CompleteRequest([FromBody]CompleteRequestDto dto)
        {
            await userBU.CompleteRequestAsync(dto);
            return Ok();
        }

        [HttpPost("SendChat")]
        public async Task<IActionResult> SendChat([FromBody]SendChatDto dto)
        {
            await userBU.SendChatAsync(dto);
            return Ok();
        }
    }
}
