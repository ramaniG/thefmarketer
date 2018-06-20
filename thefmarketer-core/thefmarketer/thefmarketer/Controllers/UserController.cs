using Fmarketer.DataAccess.Repository;
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
        private readonly UserRepository repository;

        public UserController(UserRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<List<User>> GetAsync()
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
        public async Task<IActionResult> CreateAsync([FromBody] User item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            item.Id = Guid.NewGuid();

            var output = await repository.AddAsync(item);

            return Ok(output);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] User item)
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
