using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuzzyBox_Web_Api.Data;
using BuzzyBox_Web_Api.Models;

namespace BuzzyBox_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoupansController : ControllerBase
    {
        private readonly DataContext _context;

        public CoupansController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Coupans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coupans>>> GetCoupans()
        {
            return await _context.Coupans.ToListAsync();
        }

        // GET: api/Coupans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coupans>> GetCoupans(int id)
        {
            var coupans = await _context.Coupans.FindAsync(id);

            if (coupans == null)
            {
                return NotFound();
            }

            return coupans;
        }

        // PUT: api/Coupans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoupans(int id, Coupans coupans)
        {
            if (id != coupans.CoupansId)
            {
                return BadRequest();
            }

            _context.Entry(coupans).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoupansExists(id))
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

        // POST: api/Coupans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Coupans>> PostCoupans(Coupans coupans)
        {
            _context.Coupans.Add(coupans);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoupans", new { id = coupans.CoupansId }, coupans);
        }

        // DELETE: api/Coupans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoupans(int id)
        {
            var coupans = await _context.Coupans.FindAsync(id);
            if (coupans == null)
            {
                return NotFound();
            }

            _context.Coupans.Remove(coupans);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoupansExists(int id)
        {
            return _context.Coupans.Any(e => e.CoupansId == id);
        }
    }
}
