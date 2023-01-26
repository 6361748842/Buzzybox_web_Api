using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuzzyBox_Web_Api.Data;
using BuzzyBox_Web_Api.Models;
using BuzzyBox_Web_Api.Vm_Model;

namespace BuzzyBox_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodordersController : ControllerBase
    {
        private readonly DataContext _context;

        public FoodordersController(DataContext context)
        {
            _context = context;
        }

    // GET: api/Foodorders
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Foodordervm>>> GetFoodorders()
    {
      var vmfoodorderList = new List<Foodordervm>();
      var foodorderlist = _context.Foodorders.ToList();
      foreach (var foodorder in foodorderlist)
      {
        var isfoodorder = new Foodordervm();
        isfoodorder.FoodorderId = foodorder.FoodorderId;
        isfoodorder.Foodordercost = foodorder.Foodordercost;
        isfoodorder.Foodorderquntity = foodorder.Foodorderquntity;
        isfoodorder.FoodId = foodorder.FoodId;
        if (foodorder.FoodId != 0 && foodorder.FoodId != null)
        {
          isfoodorder.Foodname = _context.Foods.Find(foodorder.FoodId).Foodname;
          isfoodorder.Foodprice = _context.Foods.Find(foodorder.FoodId).Foodprice;
          isfoodorder.FoodUnit = _context.Foods.Find(foodorder.FoodId).FoodUnit;
        }
          vmfoodorderList.Add(isfoodorder);
      }
      return vmfoodorderList;
    }












    // GET: api/Foodorders/5
    [HttpGet("{id}")]
        public async Task<ActionResult<Foodordervm>> GetFoodorder(int id)
        {
                var vmfoodorderList = new List<Foodordervm>();
                 var foodorder = await _context.Foodorders.FindAsync(id);

            if(foodorder!=null)
            {
                  var isfoodorder = new Foodordervm();
                  isfoodorder.FoodorderId = foodorder.FoodorderId;
                  isfoodorder.Foodordercost = foodorder.Foodordercost;
                  isfoodorder.Foodorderquntity = foodorder.Foodorderquntity;
                  isfoodorder.FoodId = foodorder.FoodId;

               if (foodorder.FoodId != 0 && foodorder.FoodId != null)
               {
                  isfoodorder.Foodname = _context.Foods.Find(foodorder.FoodId).Foodname;
                 isfoodorder.Foodprice = _context.Foods.Find(foodorder.FoodId).Foodprice;
                  isfoodorder.FoodUnit = _context.Foods.Find(foodorder.FoodId).FoodUnit;
               }
                vmfoodorderList.Add(isfoodorder);

            }

            return Ok(vmfoodorderList);
        }

        // PUT: api/Foodorders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodorder(int id, Foodorder foodorder)
        {
            if (id != foodorder.FoodorderId)
            {
                return BadRequest();
            }

            _context.Entry(foodorder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodorderExists(id))
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

        // POST: api/Foodorders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Foodorder>> PostFoodorder(Foodorder foodorder)
        {
            _context.Foodorders.Add(foodorder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodorder", new { id = foodorder.FoodorderId }, foodorder);
        }

        // DELETE: api/Foodorders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodorder(int id)
        {
            var foodorder = await _context.Foodorders.FindAsync(id);
            if (foodorder == null)
            {
                return NotFound();
            }

            _context.Foodorders.Remove(foodorder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodorderExists(int id)
        {
            return _context.Foodorders.Any(e => e.FoodorderId == id);
        }
    }
}
