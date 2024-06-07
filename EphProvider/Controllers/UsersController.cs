using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EphProvider.Data;
using EphProvider.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EphProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly EphProviderContext _context;

        public UsersController(EphProviderContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/Users/{username}
        [HttpGet("{username}")]
        [Authorize]
        public async Task<ActionResult<User>> GetUser(string username)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
            {
                return NotFound();
            }

            var currentUsername = User.Identity.Name;
            if (currentUsername != user.Username && !User.IsInRole("admin"))
            {
                return Forbid();
            }

            return user;
        }

        // PUT: api/Users/{username}
        [HttpPut("{username}")]
        [Authorize]
        public async Task<IActionResult> PutUser(string username, User user)
        {
            if (username != user.Username)
            {
                return BadRequest();
            }

            var currentUser = await _context.User.FirstOrDefaultAsync(u => u.Username == username);
            if (currentUser == null)
            {
                return NotFound();
            }

            // Check if the user is an admin or if they are updating their own profile
            var currentUsername = User.Identity.Name;
            if (currentUsername != currentUser.Username && !User.IsInRole("admin"))
            {
                return Forbid();
            }

            currentUser.Password = user.Password; // Update the allowed fields
            _context.Entry(currentUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(username))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { username = user.Username }, user);
        }

        // DELETE: api/Users/{username}
        [HttpDelete("{username}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> DeleteUser(string username)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(string username)
        {
            return _context.User.Any(e => e.Username == username);
        }
    }
}
