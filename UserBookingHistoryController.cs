using BuzzyBox_Web_Api.Data;
using BuzzyBox_Web_Api.Models;
using BuzzyBox_Web_Api.Vm_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuzzyBox_Web_Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserBookingHistoryController : ControllerBase
  {
    private readonly DataContext _context;


    public UserBookingHistoryController(DataContext context)
    {
      _context = context;
    }
    // GET: api/UserBookingHistory/By Useing userId we get Booking History for this api
    [HttpGet("{userid}&&{flag}")]
    public async Task<ActionResult<IEnumerable<Bookingvm>>> GetBookingHistory(int userid, int flag)
    {
      var vmBookingList = new List<Bookingvm>();
      var Bookinglist = _context.Bookings.Where(x => x.UsersId == userid).ToList();
      foreach (var bookings in Bookinglist)
      {
        var isbooking = new Bookingvm();
        isbooking.BookingId = bookings.BookingId;

        isbooking.Bookingdate = bookings.Bookingdate;
        isbooking.BookingtypeId = bookings.BookingtypeId;
        if (isbooking.BookingtypeId != 0 && isbooking.BookingtypeId != null)
        {
          isbooking.Bookingtypename = _context.Bookingtypes.Find(isbooking.BookingtypeId).Bookingtypename;
        }
        isbooking.TimestampId = bookings.TimestampId;
        if (isbooking.TimestampId != 0 && isbooking.TimestampId != null)
        {
          isbooking.Timestamphours = _context.Timestamps.Find(isbooking.TimestampId).Timestamphours;
        }

        isbooking.DurationId = bookings.DurationId;
        if (isbooking.DurationId != 0 && isbooking.DurationId != null)
        {
          isbooking.Durationhours = _context.Durations.Find(isbooking.DurationId).Durationhours;
        }
        //Finding endtime , slotid, storing into the array by passsing timestamphours and duration (important)

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



        isbooking.UsersId = bookings.UsersId;
        if (isbooking.UsersId != 0 && isbooking.UsersId != null)
        {
         isbooking.Username = _context.Users.Find(isbooking.UsersId).Username;
        }
        vmBookingList.Add(isbooking);
      }
      
      return (vmBookingList);
    }



    // GET: api/UserBookingHistory/By Useing BookingId we get Booking History for this api
    [HttpGet("{BookingId}")]
    public async Task<ActionResult<IEnumerable<Bookingvm>>> GetBookingsDetalis(int BookingId)
    {
      var vmBookingList = new List<Bookingvm>();
      var Bookinglist = _context.Bookings.Where(x => x.BookingId == BookingId).ToList();
      foreach (var booking in Bookinglist)
      {
        var isbooking = new Bookingvm();
        isbooking.BookingId = booking.BookingId;

        isbooking.Bookingdate = booking.Bookingdate;
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
        }
        vmBookingList.Add(isbooking);

      }
      return (vmBookingList);
    }


    //// GET: api/UserBookingHistory/By Useing BookingId we get Booking History for this api
    //[HttpGet("{Bookingdate}")]
    //public async Task<ActionResult<IEnumerable<Bookingvm>>> GetBookingsDetalis(int Bookingdate, int flag)
    //{
    //  var vmBookingList = new List<Bookingvm>();
    //  var Bookinglist = _context.Bookings.Where(x => x.Bookingdate == Bookingdate).ToList();
    //  foreach (var booking in Bookinglist)
    //  {
    //    var isbooking = new Bookingvm();
    //    isbooking.BookingId = booking.BookingId;

    //    isbooking.Bookingdate = booking.Bookingdate;
    //    isbooking.BookingtypeId = booking.BookingtypeId;
    //    if (isbooking.BookingtypeId != 0 && isbooking.BookingtypeId != null)
    //    {
    //      isbooking.Bookingtypename = _context.Bookingtypes.Find(isbooking.BookingtypeId).Bookingtypename;

    //    }
    //    isbooking.TimestampId = booking.TimestampId;
    //    if (isbooking.TimestampId != 0 && isbooking.TimestampId != null)
    //    {
    //      isbooking.Timestamphours = _context.Timestamps.Find(isbooking.TimestampId).Timestamphours;
    //    }
    //    isbooking.DurationId = booking.DurationId;
    //    if (isbooking.DurationId != 0 && isbooking.DurationId != null)
    //    {
    //      isbooking.Durationhours = _context.Durations.Find(isbooking.DurationId).Durationhours;
    //    }

    //    //Finding endtime , slotid, storing into the array by passsing timestamphours and duration (important)

    //    double duration = Convert.ToDouble(isbooking.Durationhours);

    //    var startDateTime = DateTime.Parse(isbooking.Timestamphours);

    //    isbooking.Endtimehours = Convert.ToString(startDateTime.AddHours(duration));
    //    DateTime currentTime = DateTime.Parse(isbooking.Endtimehours);
    //    var endtime = currentTime.ToString("hh:mmtt");

    //    var timestamplist = _context.Timestamps.Where(x => x.Timestamphours == endtime).ToList();
    //    var endid = timestamplist[0].TimestampId;

    //    var start = isbooking.TimestampId;
    //    var array = Enumerable.Range(start, endid - start + 1).ToArray();
    //    var slotid = string.Join(",", array);
    //    isbooking.slotid = slotid;







    //    isbooking.UsersId = booking.UsersId;
    //    if (isbooking.UsersId != 0 && isbooking.UsersId != null)
    //    {
    //      isbooking.Username = _context.Users.Find(isbooking.UsersId).Username;
    //      isbooking.Phonenumber = _context.Users.Find(isbooking.UsersId).Phonenumber;
    //      isbooking.Email = _context.Users.Find(isbooking.UsersId).Email;
    //      isbooking.Password = _context.Users.Find(isbooking.UsersId).Password;

    //      isbooking.RoleId = _context.Users.Find(isbooking.UsersId).RoleId;
    //      if (isbooking.RoleId != 0 && isbooking.RoleId != null)
    //      {
    //        isbooking.RoleName = _context.Roles.Find(isbooking.RoleId).RoleName;
    //      }
    //      isbooking.FoodorderId = booking.FoodorderId;


    //      if (isbooking.FoodorderId != 0 && isbooking.FoodorderId != 0)
    //      {
    //        isbooking.Foodordercost = _context.Foodorders.Find(isbooking.FoodorderId).Foodordercost;

    //        isbooking.Foodorderquntity = _context.Foodorders.Find(isbooking.FoodorderId).Foodorderquntity;

    //        isbooking.FoodId = booking.FoodId;
    //        if (isbooking.FoodId != 0 && isbooking.FoodId != null)
    //        {
    //          isbooking.Foodprice = _context.Foods.Find(isbooking.FoodId).Foodprice;

    //          isbooking.Foodname = _context.Foods.Find(isbooking.FoodId).Foodname;

    //        }
    //        isbooking.TransactionId = booking.TransactionId;
    //        if (isbooking.TransactionId != 0 && isbooking.TransactionId != null)
    //        {
    //          isbooking.Transactiontype = _context.Transactions.Find(isbooking.TransactionId).Transactiontype;
    //          isbooking.Transactionamount = _context.Transactions.Find(isbooking.TransactionId).Transactionamount;
    //          isbooking.Transactiontime = _context.Transactions.Find(isbooking.TransactionId).Transactiontime;
    //          isbooking.Transactiondate = _context.Transactions.Find(isbooking.TransactionId).Transactiondate;
    //          isbooking.TransactiontypeId = _context.Transactions.Find(isbooking.TransactionId).TransactiontypeId;
    //          if (isbooking.TransactiontypeId != 0 && isbooking.TransactiontypeId != null)
    //          {
    //            isbooking.Transactiontypename = _context.Transactiontypes.Find(isbooking.TransactiontypeId).Transactiontypename;

    //          }

    //        }

    //      }
    //    }
    //    vmBookingList.Add(isbooking);

    //  }
    //  return (vmBookingList);
    //}




  }
}
