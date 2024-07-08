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
    public class PVTsController : ControllerBase
    {
        private readonly EphProviderContext _context;

        public PVTsController(EphProviderContext context)
        {
            _context = context;
        }

        // GET: api/PVTs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PVT>>> GetPVT()
        {
            return await _context.PVT.ToListAsync();
        }

        // GET: api/PVTs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PVT>> GetPVT(int id)
        {
            var pVT = await _context.PVT.FindAsync(id);

            if (pVT == null)
            {
                return NotFound();
            }

            return pVT;
        }

        // PUT: api/PVTs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPVT(int id, PVT pVT)
        {
            if (id != pVT.Id)
            {
                return BadRequest();
            }

            _context.Entry(pVT).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PVTExists(id))
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

        // POST: api/PVTs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PVT>> PostPVT(PVT pVT)
        {
            _context.PVT.Add(pVT);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPVT", new { id = pVT.Id }, pVT);
        }

        // DELETE: api/PVTs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePVT(int id)
        {
            var pVT = await _context.PVT.FindAsync(id);
            if (pVT == null)
            {
                return NotFound();
            }

            _context.PVT.Remove(pVT);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PVTExists(int id)
        {
            return _context.PVT.Any(e => e.Id == id);
        }
    }
}
