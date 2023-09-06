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
    public class PurchaseStatusController : ControllerBase
    {
        private readonly PEREKYPContext _context;

        public PurchaseStatusController(PEREKYPContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseStatus>>> GetPurchaseStatuses()
        {
            return await _context.PurchaseStatuses.ToListAsync();
        }

        // GET: api/PurchaseStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseStatus>> GetPurchaseStatus(int? id)
        {
            var purchaseStatus = await _context.PurchaseStatuses.FindAsync(id);

            if (purchaseStatus == null)
            {
                return NotFound();
            }

            return purchaseStatus;
        }

        // PUT: api/PurchaseStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseStatus(int? id, PurchaseStatus purchaseStatus)
        {
            if (id != purchaseStatus.IdPurchaseStatus)
            {
                return BadRequest();
            }

            _context.Entry(purchaseStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseStatusExists(id))
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

        // POST: api/PurchaseStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchaseStatus>> PostPurchaseStatus(PurchaseStatus purchaseStatus)
        {
            _context.PurchaseStatuses.Add(purchaseStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchaseStatus", new { id = purchaseStatus.IdPurchaseStatus }, purchaseStatus);
        }

        // DELETE: api/PurchaseStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseStatus(int? id)
        {
            var purchaseStatus = await _context.PurchaseStatuses.FindAsync(id);
            if (purchaseStatus == null)
            {
                return NotFound();
            }

            _context.PurchaseStatuses.Remove(purchaseStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PurchaseStatusExists(int? id)
        {
            return _context.PurchaseStatuses.Any(e => e.IdPurchaseStatus == id);
        }
    }
}
