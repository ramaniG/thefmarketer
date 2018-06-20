using Fmarketer.Business;
using Fmarketer.DataAccess.Repository;
using Fmarketer.Models.Dto;
using Fmarketer.Models.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thefmarketer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        UserBusiness userBusiness;

        public UserController(CredentialRepository credentialRepository, SecurityTokenRepository securityTokenRepository, ConsultantRepository consultantRepository)
        {
            userBusiness = new UserBusiness(credentialRepository, securityTokenRepository, consultantRepository);
        }

        [HttpGet("SearchConsultant")]
        public async Task<IActionResult> SearchConsultant(SearchConsultantDto dto)
        {
            return Ok(await userBusiness.SearchAsync(dto));
        }
    }
}
