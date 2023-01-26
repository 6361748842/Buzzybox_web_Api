namespace BuzzyBox_Web_Api.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string? Bookingstarttime { get; set; }
        public string? Duration { get; set; }
         public DateTime Bookingdate { get; set; }
        public int BookingtypeId { get; set; }
      
        public int UsersId { get; set; }
    public int TimestampId { get; set; }
    public int FoodorderId { get; set; }
         public int FoodId { get; set; }
         public int TransactionId { get; set; }
         
    }
}
