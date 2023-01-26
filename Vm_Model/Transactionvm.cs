namespace BuzzyBox_Web_Api.Vm_Model
{
  public class Transactionvm
  {
    public int TransactionId { get; set; }
    public string Transactiontype { get; set; }
    public string Transactionamount { get; set; }
    public DateTime Transactiontime { get; set; }
    public DateTime Transactiondate { get; set; }

    public int TransactiontypeId { get; set; }
    public string Transactiontypename { get; set; }
  }
}
