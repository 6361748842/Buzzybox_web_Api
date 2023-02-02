namespace BuzzyBox_Web_Api.Models
{
  public class Transaction
  {
    public int TransactionId { get; set; }
    public string Transactiontype { get; set; }
    public string Transactionamount { get; set; }
    public DateTime Transactiontime { get; set; }
    public DateTime Transactiondate { get; set; }

    public int TransactiontypeId { get; set; }
  }
}
