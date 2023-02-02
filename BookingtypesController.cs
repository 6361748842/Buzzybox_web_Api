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
    public class BookingtypesController : ControllerBase
    {
        private readonly DataContext _context;

        public BookingtypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Bookingtypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bookingtype>>> GetBookingtypes()
        {
            return await _context.Bookingtypes.ToListAsync();
        }

        // GET: api/Bookingtypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bookingtype>> GetBookingtype(int id)
        {
            var bookingtype = await _context.Bookingtypes.FindAsync(id);

            if (bookingtype == null)
            {
                return NotFound();
            }

            return bookingtype;
        }

        // PUT: api/Bookingtypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingtype(int id, Bookingtype bookingtype)
        {
            if (id != bookingtype.BookingtypeId)
            {
                return BadRequest();
            }

            _context.Entry(bookingtype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingtypeExists(id))
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

        // POST: api/Bookingtypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bookingtype>> PostBookingtype(Bookingtype bookingtype)
        {
            _context.Bookingtypes.Add(bookingtype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingtype", new { id = bookingtype.BookingtypeId }, bookingtype);
        }

        // DELETE: api/Bookingtypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingtype(int id)
        {
            var bookingtype = await _context.Bookingtypes.FindAsync(id);
            if (bookingtype == null)
            {
                return NotFound();
            }

            _context.Bookingtypes.Remove(bookingtype);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingtypeExists(int id)
        {
            return _context.Bookingtypes.Any(e => e.BookingtypeId == id);
        }
    }
}
