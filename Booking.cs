namespace BuzzyBox_Web_Api.Models
{
    public class Booking
    {
           public int BookingId { get; set; }
           public DateTime? Bookingdate { get; set; }
           public string Bookingcost { get; set; }

           public  string Foodcost { get; set; } 
           public int? BookingtypeId { get; set; }
           public int? UsersId { get; set; }
           public string? FoodId { get; set; }
           public int? Transactiontypeid { get; set; }
           public Boolean? isapproved { get; set; }
           public string? Grandtotal { get; set; }
           public string? Paidamount { get; set; }
           public string? Dueamount { get; set; }
           public int? CoupansId { get; set; } 
           public int TimestampId { get; set; }
           public int DurationId { get; set; }

           public int RoleId { get; set; }

    }
}
