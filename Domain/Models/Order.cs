using static System.Runtime.InteropServices.JavaScript.JSType;

public class Order
{
  public Order()
  {
    
  }
  public int id { get; set; }
  public int productid { get; set; }
  public int customerid { get; set; }
  public DateTime createdat { get; set; }
  public int productcount { get; set; }
  public decimal price { get; set; }
}