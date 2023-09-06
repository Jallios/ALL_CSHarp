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
    public class DiseaseCardsController : ControllerBase
    {
        private readonly ZooContext _context;

        public DiseaseCardsController(ZooContext context)
        {
            _context = context;
        }

        // GET: api/DiseaseCards
        [Authorize(Roles = "2")]
        [HttpGet]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<ActionResult<IEnumerable<DiseaseCard>>> GetDiseaseCards()
        {
          if (_context.DiseaseCards == null)
          {
              return NotFound();
          }
            return await _context.DiseaseCards.ToListAsync();
        }

        // GET: api/DiseaseCards/5
        [Authorize(Roles = "2")]
        [HttpGet("{id}")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<ActionResult<DiseaseCard>> GetDiseaseCard(int? id)
        {
          if (_context.DiseaseCards == null)
          {
              return NotFound();
          }
            var diseaseCard = await _context.DiseaseCards.FindAsync(id);

            if (diseaseCard == null)
            {
                return NotFound();
            }

            return diseaseCard;
        }

        // PUT: api/DiseaseCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<IActionResult> PutDiseaseCard(int? id, DiseaseCard diseaseCard)
        {
            if (id != diseaseCard.IdDisease)
            {
                return BadRequest();
            }

            _context.Entry(diseaseCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiseaseCardExists(id))
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

        // POST: api/DiseaseCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "2")]
        [HttpPost]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<ActionResult<DiseaseCard>> PostDiseaseCard(DiseaseCard diseaseCard)
        {
          if (_context.DiseaseCards == null)
          {
              return Problem("Entity set 'ZooContext.DiseaseCards'  is null.");
          }
            _context.DiseaseCards.Add(diseaseCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiseaseCard", new { id = diseaseCard.IdDisease }, diseaseCard);
        }

        // DELETE: api/DiseaseCards/5
        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<IActionResult> DeleteDiseaseCard(int? id)
        {
            if (_context.DiseaseCards == null)
            {
                return NotFound();
            }
            var diseaseCard = await _context.DiseaseCards.FindAsync(id);
            if (diseaseCard == null)
            {
                return NotFound();
            }

            _context.DiseaseCards.Remove(diseaseCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiseaseCardExists(int? id)
        {
            return (_context.DiseaseCards?.Any(e => e.IdDisease == id)).GetValueOrDefault();
        }
    }
}
