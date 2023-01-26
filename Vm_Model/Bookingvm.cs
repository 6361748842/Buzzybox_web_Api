namespace BuzzyBox_Web_Api.Vm_Model
{
  public class Bookingvm
  {
    public int BookingId { get; set; }
    public int? TimestampId { get; set; }
    public string? Timestamp  { get; set; }
    public int? DurationId { get; set; }
    public string? Durationhour { get; set; }
    public string? Bookingstarttime { get; set; }
    public string? Duration { get; set; }

    public DateTime Bookingdate { get; set; }

    public int BookingtypeId { get; set; }
    public string? Bookingtypename { get; set; }

    public int UsersId { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Phonenumber { get; set; }
    public string? Password { get; set; }

    public int RoleId { get; set; }
    public string? RoleName { get; set; }

    public int FoodorderId { get; set; }
    public string Foodordercost { get; set; }
    public int Foodorderquntity { get; set; }

    public int FoodId { get; set; }
    public string Foodname { get; set; }
    public string Foodprice { get; set; }


    public int TransactionId { get; set; }
    public string Transactiontype { get; set; }
    public string Transactionamount { get; set; }
    public DateTime Transactiontime { get; set; }
    public DateTime Transactiondate { get; set; }
        
       
    public int TransactiontypeId { get; set; }
    public string Transactiontypename { get; set; }

  }
}
