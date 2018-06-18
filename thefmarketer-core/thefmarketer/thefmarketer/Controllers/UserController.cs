using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using thefmarketer.Models;

namespace thefmarketer.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly MainDbContext _context;

        public UserController(MainDbContext context)
        {
            _context = context;

            if (_context.UserItems.Count() == 0)
            {
                _context.UserItems.Add(new User { FirstName = "Item1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<User> Get()
        {
            return _context.UserItems.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var item = _context.UserItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.UserItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] User item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var user = _context.UserItems.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Update(item);
            
            _context.UserItems.Update(user);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var user = _context.UserItems.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.UserItems.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
