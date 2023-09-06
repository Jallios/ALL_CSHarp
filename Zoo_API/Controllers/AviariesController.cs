using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zoo_API.Models;

namespace Zoo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AviariesController : ControllerBase
    {
        private readonly ZooContext _context;

        public AviariesController(ZooContext context)
        {
            _context = context;
        }

        // GET: api/Aviaries
        [Authorize(Roles = "2")]
        [HttpGet]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<ActionResult<IEnumerable<Aviary>>> GetAviaries()
        {
          if (_context.Aviaries == null)
          {
              return NotFound();
          }
            return await _context.Aviaries.ToListAsync();
        }

        // GET: api/Aviaries/5
        [Authorize(Roles = "2")]
        [HttpGet("{id}")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<ActionResult<Aviary>> GetAviary(int? id)
        {
          if (_context.Aviaries == null)
          {
              return NotFound();
          }
            var aviary = await _context.Aviaries.FindAsync(id);

            if (aviary == null)
            {
                return NotFound();
            }

            return aviary;
        }

        // PUT: api/Aviaries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<IActionResult> PutAviary(int? id, Aviary aviary)
        {
            if (id != aviary.IdAviary)
            {
                return BadRequest();
            }

            _context.Entry(aviary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AviaryExists(id))
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

        // POST: api/Aviaries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "2")]
        [HttpPost]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<ActionResult<Aviary>> PostAviary(Aviary aviary)
        {
          if (_context.Aviaries == null)
          {
              return Problem("Entity set 'ZooContext.Aviaries'  is null.");
          }
            _context.Aviaries.Add(aviary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAviary", new { id = aviary.IdAviary }, aviary);
        }

        // DELETE: api/Aviaries/5
        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<IActionResult> DeleteAviary(int? id)
        {
            if (_context.Aviaries == null)
            {
                return NotFound();
            }
            var aviary = await _context.Aviaries.FindAsync(id);
            if (aviary == null)
            {
                return NotFound();
            }

            _context.Aviaries.Remove(aviary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AviaryExists(int? id)
        {
            return (_context.Aviaries?.Any(e => e.IdAviary == id)).GetValueOrDefault();
        }
    }
}
