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
  public class BookingsController : ControllerBase
  {
    private readonly DataContext _context;

    public BookingsController(DataContext context)
    {
      _context = context; 
    }        

    // GET: api/Bookings
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bookingvm>>> GetBookings()
    {
      var vmBookingList = new List<Bookingvm>();
      var Bookinglist = await _context.Bookings.ToListAsync();
      foreach (var booking in Bookinglist)
      {
        var isbooking = new Bookingvm();
        isbooking.BookingId = booking.BookingId;
        //isbooking.Bookingtime = booking.Bookingtime;
        isbooking.Bookingstarttime = booking.Bookingstarttime;
        isbooking.Duration = booking.Duration;
        isbooking.Bookingdate = booking.Bookingdate;
        isbooking.BookingtypeId = booking.BookingtypeId;
        if (isbooking.BookingtypeId != 0 && isbooking.BookingtypeId != null)
        {
          isbooking.Bookingtypename = _context.Bookingtypes.Find(isbooking.BookingtypeId).Bookingtypename;

        }
        isbooking.UsersId = booking.UsersId;
        if (isbooking.UsersId != 0 && isbooking.UsersId != null)
        {
          isbooking.Username = _context.Users.Find(isbooking.UsersId).Username;
          isbooking.Phonenumber = _context.Users.Find(isbooking.UsersId).Phonenumber;
          isbooking.Email = _context.Users.Find(isbooking.UsersId).Email;
          isbooking.Password = _context.Users.Find(isbooking.UsersId).Password;

          isbooking.RoleId = _context.Users.Find(isbooking.UsersId).RoleId;
          if (isbooking.RoleId != 0 && isbooking.RoleId != null)
          {
            isbooking.RoleName = _context.Roles.Find(isbooking.RoleId).RoleName;
          }
            isbooking.FoodorderId = booking.FoodorderId;


          if (isbooking.FoodorderId != 0 && isbooking.FoodorderId != 0)
          {
            isbooking.Foodordercost = _context.Foodorders.Find(isbooking.FoodorderId).Foodordercost;

            isbooking.Foodorderquntity = _context.Foodorders.Find(isbooking.FoodorderId).Foodorderquntity;

            isbooking.FoodId = booking.FoodId;
            if (isbooking.FoodId != 0 && isbooking.FoodId != null)
            {
              isbooking.Foodprice = _context.Foods.Find(isbooking.FoodId).Foodprice;

              isbooking.Foodname = _context.Foods.Find(isbooking.FoodId).Foodname;

            }
            isbooking.TransactionId = booking.TransactionId;
            if (isbooking.TransactionId != 0 && isbooking.TransactionId != null)
            {
              isbooking.Transactiontype = _context.Transactions.Find(isbooking.TransactionId).Transactiontype;
              isbooking.Transactionamount = _context.Transactions.Find(isbooking.TransactionId).Transactionamount;
              isbooking.Transactiontime = _context.Transactions.Find(isbooking.TransactionId).Transactiontime;
              isbooking.Transactiondate = _context.Transactions.Find(isbooking.TransactionId).Transactiondate;
              isbooking.TransactiontypeId =_context.Transactions.Find(isbooking.TransactionId).TransactiontypeId;
              if (isbooking.TransactiontypeId != 0 && isbooking.TransactiontypeId != null)
              {
                isbooking.Transactiontypename = _context.Transactiontypes.Find(isbooking.TransactiontypeId).Transactiontypename;
                vmBookingList.Add(isbooking);

              }

            }

          }
        }
      }
      return (vmBookingList);
    }


    // GET: api/Bookings/By Useing User Id we get user History for this api
    [HttpGet("{userid}&&{flag}")]
    public async Task<ActionResult<IEnumerable<Bookingvm>>> GetBookings(int userid , int flag)
    {
      var vmBookingList = new List<Bookingvm>();
      var Bookinglist =  _context.Bookings.Where(x=>x.UsersId == userid ).ToList();
      foreach (var booking in Bookinglist)
      {
        var isbooking = new Bookingvm();
        isbooking.BookingId = booking.BookingId;
        //isbooking.Bookingtime = booking.Bookingtime;
        isbooking.Bookingstarttime = booking.Bookingstarttime;
        isbooking.Duration = booking.Duration;
        isbooking.Bookingdate = booking.Bookingdate;
        isbooking.BookingtypeId = booking.BookingtypeId;
        if (isbooking.BookingtypeId != 0 && isbooking.BookingtypeId != null)
        {
          isbooking.Bookingtypename = _context.Bookingtypes.Find(isbooking.BookingtypeId).Bookingtypename;

        }
        isbooking.UsersId = booking.UsersId;
        if (isbooking.UsersId != 0 && isbooking.UsersId != null)
        {
          isbooking.Username = _context.Users.Find(isbooking.UsersId).Username;
          isbooking.Phonenumber = _context.Users.Find(isbooking.UsersId).Phonenumber;
          isbooking.Email = _context.Users.Find(isbooking.UsersId).Email;
          isbooking.Password = _context.Users.Find(isbooking.UsersId).Password;

          isbooking.RoleId = _context.Users.Find(isbooking.UsersId).RoleId;
          if (isbooking.RoleId != 0 && isbooking.RoleId != null)
          {
            isbooking.RoleName = _context.Roles.Find(isbooking.RoleId).RoleName;
          }
            isbooking.FoodorderId = booking.FoodorderId;


          if (isbooking.FoodorderId != 0 && isbooking.FoodorderId != 0)
          {
            isbooking.Foodordercost = _context.Foodorders.Find(isbooking.FoodorderId).Foodordercost;

            isbooking.Foodorderquntity = _context.Foodorders.Find(isbooking.FoodorderId).Foodorderquntity;

            isbooking.FoodId = booking.FoodId;
            if (isbooking.FoodId != 0 && isbooking.FoodId != null)
            {
              isbooking.Foodprice = _context.Foods.Find(isbooking.FoodId).Foodprice;

              isbooking.Foodname = _context.Foods.Find(isbooking.FoodId).Foodname;

            }
            isbooking.TransactionId = booking.TransactionId;
            if (isbooking.TransactionId != 0 && isbooking.TransactionId != null)
            {
              isbooking.Transactiontype = _context.Transactions.Find(isbooking.TransactionId).Transactiontype;
              isbooking.Transactionamount = _context.Transactions.Find(isbooking.TransactionId).Transactionamount;
              isbooking.Transactiontime = _context.Transactions.Find(isbooking.TransactionId).Transactiontime;
              isbooking.Transactiondate = _context.Transactions.Find(isbooking.TransactionId).Transactiondate;
              isbooking.TransactiontypeId = _context.Transactions.Find(isbooking.TransactionId).TransactiontypeId;
              if (isbooking.TransactiontypeId != 0 && isbooking.TransactiontypeId != null)
              {
                isbooking.Transactiontypename = _context.Transactiontypes.Find(isbooking.TransactiontypeId).Transactiontypename;
                vmBookingList.Add(isbooking);

              }

            }

          }
        }
      }
      return (vmBookingList);
    }


    // GET: api/Bookings/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Bookingvm>> GetBooking(int id)
    {

      var vmBookingList = new List<Bookingvm>();
      var booking = await _context.Bookings.FindAsync(id);

      if (booking!= null)
      {
        var isbooking = new Bookingvm();
        isbooking.BookingId = booking.BookingId;
        isbooking.Bookingstarttime = booking.Bookingstarttime;
        isbooking.Duration = booking.Duration;
        isbooking.Bookingdate = booking.Bookingdate;
        isbooking.BookingtypeId = booking.BookingtypeId;
        if (isbooking.BookingtypeId != 0 && isbooking.BookingtypeId != null)
        {
          isbooking.Bookingtypename = _context.Bookingtypes.Find(isbooking.BookingtypeId).Bookingtypename;

        }
        isbooking.UsersId = booking.UsersId;
        if (isbooking.UsersId != 0 && isbooking.UsersId != null)
        {
          isbooking.Username = _context.Users.Find(isbooking.UsersId).Username;
          isbooking.Phonenumber = _context.Users.Find(isbooking.UsersId).Phonenumber;
          isbooking.Email = _context.Users.Find(isbooking.UsersId).Email;
          isbooking.Password = _context.Users.Find(isbooking.UsersId).Password;

          isbooking.RoleId = _context.Users.Find(isbooking.UsersId).RoleId;
          if (isbooking.RoleId != 0 && isbooking.RoleId != null)
          {
            isbooking.RoleName = _context.Roles.Find(isbooking.RoleId).RoleName;
            isbooking.FoodorderId = booking.FoodorderId;
          }


          if (isbooking.FoodorderId != 0 && isbooking.FoodorderId != 0)
          {
            isbooking.Foodordercost = _context.Foodorders.Find(isbooking.FoodorderId).Foodordercost;
            isbooking.Foodorderquntity = _context.Foodorders.Find(isbooking.FoodorderId).Foodorderquntity;
            isbooking.FoodId = booking.FoodId;
            if (isbooking.FoodId != 0 && isbooking.FoodId != null)
            {
              isbooking.Foodprice = _context.Foods.Find(isbooking.FoodId).Foodprice;
              isbooking.Foodname = _context.Foods.Find(isbooking.FoodId).Foodname;
            }
            isbooking.TransactionId = booking.TransactionId;
            if (isbooking.TransactionId != 0 && isbooking.TransactionId != null)
            {
              isbooking.Transactiontype = _context.Transactions.Find(isbooking.TransactionId).Transactiontype;
              isbooking.Transactionamount = _context.Transactions.Find(isbooking.TransactionId).Transactionamount;
              isbooking.Transactiontime = _context.Transactions.Find(isbooking.TransactionId).Transactiontime;
              isbooking.Transactiondate = _context.Transactions.Find(isbooking.TransactionId).Transactiondate;
              isbooking.TransactiontypeId = _context.Transactions.Find(isbooking.TransactionId).TransactiontypeId;
              if (isbooking.TransactiontypeId != 0 && isbooking.TransactiontypeId != null)
              {
                isbooking.Transactiontypename = _context.Transactiontypes.Find(isbooking.TransactiontypeId).Transactiontypename;
                vmBookingList.Add(isbooking);

              }
            
            }

          }

        }
       
      }
      return Ok(vmBookingList);




    }




    // PUT: api/Bookings/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBooking(int id, Booking booking)
    {
      if (id != booking.BookingId)
      {
        return BadRequest();
      }

      _context.Entry(booking).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!BookingExists(id))
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

    // POST: api/Bookings
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Booking>> PostBooking(Booking booking)
    {
      _context.Bookings.Add(booking);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetBooking", new { id = booking.BookingId }, booking);
    }

    // DELETE: api/Bookings/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBooking(int id)
    {
      var booking = await _context.Bookings.FindAsync(id);
      if (booking == null)
      {
        return NotFound();
      }

      _context.Bookings.Remove(booking);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool BookingExists(int id)
    {
      return _context.Bookings.Any(e => e.BookingId == id);
    }
  }
}

