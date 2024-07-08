using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EphProvider.Data;
using EphProvider.Models;

namespace EphProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalileosController : ControllerBase
    {
        private readonly EphProviderContext _context;

        public GalileosController(EphProviderContext context)
        {
            _context = context;
        }

        // GET: api/Galileos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Galileo>>> GetGalileo()
        {
            return await _context.Galileo.ToListAsync();
        }

        // GET: api/Galileos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Galileo>> GetGalileo(int id)
        {
            var galileo = await _context.Galileo.FindAsync(id);

            if (galileo == null)
            {
                return NotFound();
            }

            return galileo;
        }

        // PUT: api/Galileos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGalileo(int id, Galileo galileo)
        {
            if (id != galileo.Id)
            {
                return BadRequest();
            }

            _context.Entry(galileo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GalileoExists(id))
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

        // POST: api/Galileos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Galileo>> PostGalileo(Galileo galileo)
        {
            _context.Galileo.Add(galileo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGalileo", new { id = galileo.Id }, galileo);
        }

        // DELETE: api/Galileos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGalileo(int id)
        {
            var galileo = await _context.Galileo.FindAsync(id);
            if (galileo == null)
            {
                return NotFound();
            }

            _context.Galileo.Remove(galileo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GalileoExists(int id)
        {
            return _context.Galileo.Any(e => e.Id == id);
        }
    }
}
