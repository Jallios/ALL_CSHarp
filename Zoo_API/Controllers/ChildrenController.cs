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
    public class ChildrenController : ControllerBase
    {
        private readonly ZooContext _context;

        public ChildrenController(ZooContext context)
        {
            _context = context;
        }

        // GET: api/Children
        [Authorize(Roles = "2")]
        [HttpGet]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<ActionResult<IEnumerable<Child>>> GetChildren()
        {
          if (_context.Children == null)
          {
              return NotFound();
          }
            return await _context.Children.ToListAsync();
        }

        // GET: api/Children/5
        [Authorize(Roles = "2")]
        [HttpGet("{id}")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<ActionResult<Child>> GetChild(int? id)
        {
          if (_context.Children == null)
          {
              return NotFound();
          }
            var child = await _context.Children.FindAsync(id);

            if (child == null)
            {
                return NotFound();
            }

            return child;
        }

        // PUT: api/Children/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<IActionResult> PutChild(int? id, Child child)
        {
            if (id != child.IdChild)
            {
                return BadRequest();
            }

            _context.Entry(child).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChildExists(id))
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

        // POST: api/Children
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "2")]
        [HttpPost]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<ActionResult<Child>> PostChild(Child child)
        {
          if (_context.Children == null)
          {
              return Problem("Entity set 'ZooContext.Children'  is null.");
          }
            _context.Children.Add(child);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChild", new { id = child.IdChild }, child);
        }

        // DELETE: api/Children/5
        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<IActionResult> DeleteChild(int? id)
        {
            if (_context.Children == null)
            {
                return NotFound();
            }
            var child = await _context.Children.FindAsync(id);
            if (child == null)
            {
                return NotFound();
            }

            _context.Children.Remove(child);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChildExists(int? id)
        {
            return (_context.Children?.Any(e => e.IdChild == id)).GetValueOrDefault();
        }
    }
}
