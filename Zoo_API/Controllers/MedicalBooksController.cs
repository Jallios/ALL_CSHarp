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
    public class MedicalBooksController : ControllerBase
    {
        private readonly ZooContext _context;

        public MedicalBooksController(ZooContext context)
        {
            _context = context;
        }

        // GET: api/MedicalBooks
        [Authorize(Roles = "2")]
        [HttpGet]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<ActionResult<IEnumerable<MedicalBook>>> GetMedicalBooks()
        {
          if (_context.MedicalBooks == null)
          {
              return NotFound();
          }
            return await _context.MedicalBooks.ToListAsync();
        }

        // GET: api/MedicalBooks/5
        [Authorize(Roles = "2")]
        [HttpGet("{id}")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<ActionResult<MedicalBook>> GetMedicalBook(int? id)
        {
          if (_context.MedicalBooks == null)
          {
              return NotFound();
          }
            var medicalBook = await _context.MedicalBooks.FindAsync(id);

            if (medicalBook == null)
            {
                return NotFound();
            }

            return medicalBook;
        }

        // PUT: api/MedicalBooks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicalBook(int? id, MedicalBook medicalBook)
        {
            if (id != medicalBook.IdMedicalBook)
            {
                return BadRequest();
            }

            _context.Entry(medicalBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalBookExists(id))
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

        // POST: api/MedicalBooks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "2")]
        [HttpPost]
        public async Task<ActionResult<MedicalBook>> PostMedicalBook(MedicalBook medicalBook)
        {
          if (_context.MedicalBooks == null)
          {
              return Problem("Entity set 'ZooContext.MedicalBooks'  is null.");
          }
            _context.MedicalBooks.Add(medicalBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicalBook", new { id = medicalBook.IdMedicalBook }, medicalBook);
        }

        // DELETE: api/MedicalBooks/5
        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalBook(int? id)
        {
            if (_context.MedicalBooks == null)
            {
                return NotFound();
            }
            var medicalBook = await _context.MedicalBooks.FindAsync(id);
            if (medicalBook == null)
            {
                return NotFound();
            }

            _context.MedicalBooks.Remove(medicalBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicalBookExists(int? id)
        {
            return (_context.MedicalBooks?.Any(e => e.IdMedicalBook == id)).GetValueOrDefault();
        }
    }
}
