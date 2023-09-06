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
    public class EmployeeConcatsController : ControllerBase
    {
        private readonly ZooContext _context;

        public EmployeeConcatsController(ZooContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeConcats
        [Authorize(Roles = "2")]
        [HttpGet]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<ActionResult<IEnumerable<EmployeeConcat>>> GetEmployeeConcats()
        {
          if (_context.EmployeeConcats == null)
          {
              return NotFound();
          }
            return await _context.EmployeeConcats.ToListAsync();
        }

        // GET: api/EmployeeConcats/5
        [Authorize(Roles = "2")]
        [HttpGet("{id}")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<ActionResult<EmployeeConcat>> GetEmployeeConcat(int? id)
        {
          if (_context.EmployeeConcats == null)
          {
              return NotFound();
          }
            var employeeConcat = await _context.EmployeeConcats.FindAsync(id);

            if (employeeConcat == null)
            {
                return NotFound();
            }

            return employeeConcat;
        }

        // PUT: api/EmployeeConcats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<IActionResult> PutEmployeeConcat(int? id, EmployeeConcat employeeConcat)
        {
            if (id != employeeConcat.IdConcat)
            {
                return BadRequest();
            }

            _context.Entry(employeeConcat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeConcatExists(id))
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

        // POST: api/EmployeeConcats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "2")]
        [HttpPost]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<ActionResult<EmployeeConcat>> PostEmployeeConcat(EmployeeConcat employeeConcat)
        {
          if (_context.EmployeeConcats == null)
          {
              return Problem("Entity set 'ZooContext.EmployeeConcats'  is null.");
          }
            _context.EmployeeConcats.Add(employeeConcat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeConcat", new { id = employeeConcat.IdConcat }, employeeConcat);
        }

        // DELETE: api/EmployeeConcats/5
        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<IActionResult> DeleteEmployeeConcat(int? id)
        {
            if (_context.EmployeeConcats == null)
            {
                return NotFound();
            }
            var employeeConcat = await _context.EmployeeConcats.FindAsync(id);
            if (employeeConcat == null)
            {
                return NotFound();
            }

            _context.EmployeeConcats.Remove(employeeConcat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeConcatExists(int? id)
        {
            return (_context.EmployeeConcats?.Any(e => e.IdConcat == id)).GetValueOrDefault();
        }
    }
}
