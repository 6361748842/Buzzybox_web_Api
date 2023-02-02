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
using NuGet.Versioning;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ceTe.DynamicPDF.LayoutEngine;

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
      var Bookinglist = await _context.Bookings.Where(x=>x.isapproved == true).ToListAsync();
      foreach (var booking in Bookinglist)
      {
        var isbooking = new Bookingvm();
        isbooking.BookingId = booking.BookingId;

        isbooking.Bookingdate = booking.Bookingdate;
        isbooking.Bookingcost=booking.Bookingcost;
        isbooking.Foodcost = booking.Foodcost;
        isbooking.BookingtypeId = booking.BookingtypeId;
        if (isbooking.BookingtypeId != 0 && isbooking.BookingtypeId != null)
        {
          isbooking.Bookingtypename = _context.Bookingtypes.Find(isbooking.BookingtypeId).Bookingtypename;
        }
        isbooking.TimestampId = booking.TimestampId;
        if (isbooking.TimestampId != 0 && isbooking.TimestampId != null)
        {
          isbooking.Timestamphours = _context.Timestamps.Find(isbooking.TimestampId).Timestamphours;


        }
        isbooking.DurationId = booking.DurationId;
        if (isbooking.DurationId != 0 && isbooking.DurationId != null)
        {
          isbooking.Durationhours = _context.Durations.Find(isbooking.DurationId).Durationhours;
        }

        double duration = Convert.ToDouble(isbooking.Durationhours);

        var startDateTime = DateTime.Parse(isbooking.Timestamphours);
        isbooking.Transactiontypeid = booking.Transactiontypeid;
        if (isbooking.Transactiontypeid != null && isbooking.Transactiontypeid != 0)
        {
          isbooking.TransactionTypeName = _context.Transactiontypes.Find(isbooking.Transactiontypeid).Transactiontypename;
        }
        isbooking.Endtimehours = Convert.ToString(startDateTime.AddHours(duration));
        DateTime currentTime = DateTime.Parse(isbooking.Endtimehours);
        var endtime = currentTime.ToString("hh:mmtt");

        var timestamplist = _context.Timestamps.Where(x => x.Timestamphours == endtime).ToList();
        var endid = timestamplist[0].TimestampId;

        var start = isbooking.TimestampId;
        var array = Enumerable.Range(start, endid - start + 1).ToArray();
        var slotid = string.Join(",", array);
        isbooking.slotid = slotid;



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
          isbooking.Grandtotal = _context.Bookings.Find(isbooking.BookingId).Grandtotal;
          isbooking.Paidamount = _context.Bookings.Find(isbooking.BookingId).Paidamount;
          isbooking.Dueamount = _context.Bookings.Find(isbooking.BookingId).Dueamount;
          isbooking.isapproved = _context.Bookings.Find(isbooking.BookingId).isapproved;
            


        }
          isbooking.CoupansId = booking.CoupansId;
          if(isbooking.CoupansId!= 0 && isbooking.CoupansId!=null)
          {
            isbooking.CoupansName = _context.Coupans.Find(isbooking.CoupansId).CoupansName;
            isbooking.Coupansprice = _context.Coupans.Find(isbooking.CoupansId).Coupansprice;
            isbooking.Coupanscode = _context.Coupans.Find(isbooking.CoupansId).Coupanscode;
            isbooking.Coupanexpariedate = _context.Coupans.Find(isbooking.CoupansId).Coupanexpariedate;
            isbooking.BusinessName = _context.Coupans.Find(isbooking.CoupansId).BusinessName;
            isbooking.BusinessContactName = _context.Coupans.Find(isbooking.CoupansId).BusinessContactName;
            isbooking.BusinessContactAddress = _context.Coupans.Find(isbooking.CoupansId).BusinessContactAddress;
            isbooking.BusinessContactNumber = _context.Coupans.Find(isbooking.CoupansId).BusinessContactNumber;
          }
       
        isbooking.FoodId = booking.FoodId;
        var foodlist = new List<Foodvm>();
        if (isbooking.FoodId!="" && isbooking.FoodId!= null)
        {
          foreach (var foodkey in isbooking.FoodId.Split(',').ToList()) 
          {
            if (foodkey != null)
            {

            var food = foodkey.Split("-").ToList();
            var Createdfoodid = Convert.ToInt32(food[0]);
            var quantity = Convert.ToInt32(food[1]);
           
            var Food = _context.Foods.Find(Convert.ToInt32(food[0]));
            

            if (Food != null)
            {
              var isFood = new Foodvm();
                isFood.FoodId = Food.FoodId;
                isFood.Foodprice = Food.Foodprice;
                isFood.Foodname = Food.Foodname;
                isFood.Foodquantity = Food.Foodquantity;
                foodlist.Add(isFood);

              }
            isbooking.Foodlists = foodlist;
            }
            
          }

        }


        vmBookingList.Add(isbooking);
      }
      return (vmBookingList);
    }



    // GET: api/Bookings
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Bookingvm>>> GetBookings(int id)
    {
      var vmBookingList = new List<Bookingvm>();
      var booking = await _context.Bookings.FindAsync(id);
     if(booking != null)
      {
        var isbooking = new Bookingvm();
        isbooking.BookingId = booking.BookingId;
        isbooking.Transactiontypeid = booking.Transactiontypeid;
          if(isbooking.Transactiontypeid!=null && isbooking.Transactiontypeid != 0)
        {
          isbooking.TransactionTypeName = _context.Transactiontypes.Find(isbooking.Transactiontypeid).Transactiontypename;
        }
        isbooking.Bookingdate = booking.Bookingdate;
        isbooking.Bookingcost = booking.Bookingcost;
        isbooking.Foodcost = booking.Foodcost;
        isbooking.BookingtypeId = booking.BookingtypeId;
        if (isbooking.BookingtypeId != 0 && isbooking.BookingtypeId != null)
        {
          isbooking.Bookingtypename = _context.Bookingtypes.Find(isbooking.BookingtypeId).Bookingtypename;
        }
        isbooking.TimestampId = booking.TimestampId;
        if (isbooking.TimestampId != 0 && isbooking.TimestampId != null)
        {
          isbooking.Timestamphours = _context.Timestamps.Find(isbooking.TimestampId).Timestamphours;


        }
        isbooking.DurationId = booking.DurationId;
        if (isbooking.DurationId != 0 && isbooking.DurationId != null)
        {
          isbooking.Durationhours = _context.Durations.Find(isbooking.DurationId).Durationhours;
        }

        double duration = Convert.ToDouble(isbooking.Durationhours);

        var startDateTime = DateTime.Parse(isbooking.Timestamphours);

        isbooking.Endtimehours = Convert.ToString(startDateTime.AddHours(duration));
        DateTime currentTime = DateTime.Parse(isbooking.Endtimehours);
        var endtime = currentTime.ToString("hh:mmtt");

        var timestamplist = _context.Timestamps.Where(x => x.Timestamphours == endtime).ToList();
        var endid = timestamplist[0].TimestampId;

        var start = isbooking.TimestampId;
        var array = Enumerable.Range(start, endid - start + 1).ToArray();
        var slotid = string.Join(",", array);
        isbooking.slotid = slotid;



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
          isbooking.Grandtotal = _context.Bookings.Find(isbooking.BookingId).Grandtotal;
          isbooking.Paidamount = _context.Bookings.Find(isbooking.BookingId).Paidamount;
          isbooking.Dueamount = _context.Bookings.Find(isbooking.BookingId).Dueamount;
          isbooking.isapproved = _context.Bookings.Find(isbooking.BookingId).isapproved;



        }
        isbooking.CoupansId = booking.CoupansId;
        if (isbooking.CoupansId != 0 && isbooking.CoupansId != null)
        {
          isbooking.CoupansName = _context.Coupans.Find(isbooking.CoupansId).CoupansName;
          isbooking.Coupansprice = _context.Coupans.Find(isbooking.CoupansId).Coupansprice;
          isbooking.Coupanscode = _context.Coupans.Find(isbooking.CoupansId).Coupanscode;
          isbooking.Coupanexpariedate = _context.Coupans.Find(isbooking.CoupansId).Coupanexpariedate;
          isbooking.BusinessName = _context.Coupans.Find(isbooking.CoupansId).BusinessName;
          isbooking.BusinessContactName = _context.Coupans.Find(isbooking.CoupansId).BusinessContactName;
          isbooking.BusinessContactAddress = _context.Coupans.Find(isbooking.CoupansId).BusinessContactAddress;
          isbooking.BusinessContactNumber = _context.Coupans.Find(isbooking.CoupansId).BusinessContactNumber;
        }

        isbooking.FoodId = booking.FoodId;
        var foodlist = new List<Foodvm>();
        if (isbooking.FoodId != "" && isbooking.FoodId != null)
        {
          foreach (var foodkey in isbooking.FoodId.Split(',').ToList())
          {
            if (foodkey != null)
            {

              var food = foodkey.Split("-").ToList();
              var Createdfoodid = Convert.ToInt32(food[0]);
              var quantity = Convert.ToInt32(food[1]);

              var Food = _context.Foods.Find(Convert.ToInt32(food[0]));


              if (Food != null)
              {
                var isFood = new Foodvm();
                isFood.FoodId = Food.FoodId;
                isFood.Foodprice = Food.Foodprice;
                isFood.Foodname = Food.Foodname;
                isFood.Foodquantity = Food.Foodquantity;
                foodlist.Add(isFood);

              }
              isbooking.Foodlists = foodlist;
            }

          }

        }


        vmBookingList.Add(isbooking);
     }
      return (vmBookingList);
    }










   
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
      var id = booking.BookingId;
      return CreatedAtAction(nameof(GetBookings), new { id = booking.BookingId }, booking);


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

