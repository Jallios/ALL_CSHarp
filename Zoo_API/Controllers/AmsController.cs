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
    public class AmsController : ControllerBase
    {
        private readonly ZooContext _context;

        public AmsController(ZooContext context)
        {
            _context = context;
        }

        // GET: api/Ams
        [Authorize(Roles = "2")]
        [HttpGet]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<ActionResult<IEnumerable<Am>>> GetAms(string? employee, int? type)
        {
            if (employee == "" && type == 0)
            {
                return await _context.Ams.Include(x => x.employee).Include(x => x.component).Include(x => x.typeOfwork).Include(x => x.animal).ToListAsync();
            }
            if (string.IsNullOrEmpty(employee) && type == null)
            {
                return await _context.Ams.Include(x => x.employee).Include(x => x.component).Include(x => x.typeOfwork).Include(x => x.animal).ToListAsync();
            }
            else if (string.IsNullOrEmpty(employee) && type != null)
            {
                return await _context.Ams.Where(x => x.TypeOfWorkId == type).Include(x => x.employee).Include(x => x.component).Include(x => x.typeOfwork).Include(x => x.animal).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(employee) && type == null)
            {
                return await _context.Ams.Where(x => x.employee.Login.Contains(employee)).Include(x => x.employee).Include(x => x.component).Include(x => x.typeOfwork).Include(x => x.animal).ToListAsync();
            }
            else
            {
                return await _context.Ams.Where(x => x.TypeOfWorkId == type && x.employee.Login.Contains(employee)).Include(x => x.employee).Include(x => x.component).Include(x => x.typeOfwork).Include(x => x.animal).ToListAsync();
            }
        }

        // GET: api/Ams/5
        [Authorize(Roles = "2")]
        [HttpGet("{id}")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<ActionResult<Am>> GetAm(int? id)
        {
          if (_context.Ams == null)
          {
              return NotFound();
          }
            var am = await _context.Ams.FindAsync(id);

            if (am == null)
            {
                return NotFound();
            }

            return am;
        }

        // PUT: api/Ams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<IActionResult> PutAm(int? id, Am am)
        {
            if (id != am.IdAm)
            {
                return BadRequest();
            }

            _context.Entry(am).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmExists(id))
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

        // POST: api/Ams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "2")]
        [HttpPost]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<ActionResult<Am>> PostAm(Am am)
        {
          if (_context.Ams == null)
          {
              return Problem("Entity set 'ZooContext.Ams'  is null.");
          }
            _context.Ams.Add(am);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAm", new { id = am.IdAm }, am);
        }

        // DELETE: api/Ams/5
        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<IActionResult> DeleteAm(int? id)
        {
            if (_context.Ams == null)
            {
                return NotFound();
            }
            var am = await _context.Ams.FindAsync(id);
            if (am == null)
            {
                return NotFound();
            }

            _context.Ams.Remove(am);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AmExists(int? id)
        {
            return (_context.Ams?.Any(e => e.IdAm == id)).GetValueOrDefault();
        }
    }
}
