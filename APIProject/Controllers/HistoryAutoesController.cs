using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIProject.Models;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryAutoesController : ControllerBase
    {
        private readonly PEREKYPContext _context;

        public HistoryAutoesController(PEREKYPContext context)
        {
            _context = context;
        }

        // GET: api/HistoryAutoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoryAuto>>> GetHistoryAutos()
        {
            return await _context.HistoryAutos.ToListAsync();
        }

        // GET: api/HistoryAutoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoryAuto>> GetHistoryAuto(int? id)
        {
            var historyAuto = await _context.HistoryAutos.FindAsync(id);

            if (historyAuto == null)
            {
                return NotFound();
            }

            return historyAuto;
        }

        // PUT: api/HistoryAutoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoryAuto(int? id, HistoryAuto historyAuto)
        {
            if (id != historyAuto.IdHistoryAuto)
            {
                return BadRequest();
            }

            _context.Entry(historyAuto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoryAutoExists(id))
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

        // POST: api/HistoryAutoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistoryAuto>> PostHistoryAuto(HistoryAuto historyAuto)
        {
            _context.HistoryAutos.Add(historyAuto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistoryAuto", new { id = historyAuto.IdHistoryAuto }, historyAuto);
        }

        // DELETE: api/HistoryAutoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistoryAuto(int? id)
        {
            var historyAuto = await _context.HistoryAutos.FindAsync(id);
            if (historyAuto == null)
            {
                return NotFound();
            }

            _context.HistoryAutos.Remove(historyAuto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistoryAutoExists(int? id)
        {
            return _context.HistoryAutos.Any(e => e.IdHistoryAuto == id);
        }
    }
}
