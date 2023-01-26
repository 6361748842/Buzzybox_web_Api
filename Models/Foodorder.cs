namespace BuzzyBox_Web_Api.Models
{
  public class Foodorder
  {
    public int FoodorderId { get; set; }
    public string Foodordercost { get; set; }
    public int Foodorderquntity { get; set; }

    public int FoodId { get; set; }
    
    //public string Foodname { get; set; }
    //public string Foodprice { get; set; }
  }
}
