using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebLabsV05.DAL.Data;
using WebLabsV05.Entities;

namespace lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AutoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Autoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Auto>>> GetAutos(int? group)
        {
            return await _context.Autos
             .Where(d => !group.HasValue || d.AutoGroupId.Equals(group.Value))
             ?.ToListAsync();
        }

        // GET: api/Autoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Auto>> GetAuto(int id)
        {
            var auto = await _context.Autos.FindAsync(id);

            if (auto == null)
            {
                return NotFound();
            }

            return auto;
        }

        // PUT: api/Autoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuto(int id, Auto auto)
        {
            if (id != auto.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(auto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutoExists(id))
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

        // POST: api/Autoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Auto>> PostAuto(Auto auto)
        {
            _context.Autos.Add(auto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuto", new { id = auto.AutoId }, auto);
        }

        // DELETE: api/Autoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Auto>> DeleteAuto(int id)
        {
            var auto = await _context.Autos.FindAsync(id);
            if (auto == null)
            {
                return NotFound();
            }

            _context.Autos.Remove(auto);
            await _context.SaveChangesAsync();

            return auto;
        }

        private bool AutoExists(int id)
        {
            return _context.Autos.Any(e => e.AutoId == id);
        }
    }
}
