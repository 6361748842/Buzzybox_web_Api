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
    public class TimestampsController : ControllerBase
    {
        private readonly DataContext _context;

        public TimestampsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Timestamps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Timestamp>>> GetTimestamps()
        {
            return await _context.Timestamps.ToListAsync();
        }

        // GET: api/Timestamps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Timestamp>> GetTimestamp(int id)
        {
            var timestamp = await _context.Timestamps.FindAsync(id);

            if (timestamp == null)
            {
                return NotFound();
            }

            return timestamp;
        }

        // PUT: api/Timestamps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimestamp(int id, Timestamp timestamp)
        {
            if (id != timestamp.TimestampId)
            {
                return BadRequest();
            }

            _context.Entry(timestamp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimestampExists(id))
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

        // POST: api/Timestamps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Timestamp>> PostTimestamp(Timestamp timestamp)
        {
            _context.Timestamps.Add(timestamp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimestamp", new { id = timestamp.TimestampId }, timestamp);
        }

        // DELETE: api/Timestamps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimestamp(int id)
        {
            var timestamp = await _context.Timestamps.FindAsync(id);
            if (timestamp == null)
            {
                return NotFound();
            }

            _context.Timestamps.Remove(timestamp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TimestampExists(int id)
        {
            return _context.Timestamps.Any(e => e.TimestampId == id);
        }
    }
}
