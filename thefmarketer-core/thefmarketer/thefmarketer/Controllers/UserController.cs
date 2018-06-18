using Fmarketer.DataAccess.Repository;
using Fmarketer.Models.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thefmarketer.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserRepository userRepository;

        public UserController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<List<User>> GetAsync()
        {
            var users = await userRepository.GetAll();
            return users.ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var user = await userRepository.Get(new Guid(id));
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

            item.Id = new Guid();

            await userRepository.AddAsync(item);

            return Ok(item.Id);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] User item)
        {
            if (item == null || item.Id != new Guid(id))
            {
                return BadRequest();
            }

            userRepository.Update(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var user = await userRepository.Get(new Guid(id));
            if (user == null)
            {
                return NotFound();
            }
            userRepository.Remove(user);
            return NoContent();
        }
    }
}
