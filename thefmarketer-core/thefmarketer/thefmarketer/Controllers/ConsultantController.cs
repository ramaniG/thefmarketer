using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fmarketer.DataAccess.Repository;
using Fmarketer.Models.Model;
using Microsoft.AspNetCore.Mvc;

namespace Fmarketer.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Consultant")]
    public class ConsultantController : Controller
    {
        private readonly ConsultantRepository repository;

        public ConsultantController(ConsultantRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<List<Consultant>> GetAsync()
        {
            var users = await repository.GetAll();
            return users.ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var user = await repository.Get(new Guid(id));
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Consultant item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            item.Id = Guid.NewGuid();

            await repository.AddAsync(item);

            return Ok(item.Id);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Consultant item)
        {
            if (item == null || item.Id != new Guid(id))
            {
                return BadRequest();
            }

            repository.Update(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var user = await repository.Get(new Guid(id));
            if (user == null)
            {
                return NotFound();
            }
            repository.Remove(user);
            return NoContent();
        }
    }
}
