public class GetProductDto
{
  public GetProductDto()
  {
    
  }
  public int id { get; set; }
  public int productid { get; set; }
  public int customerid { get; set; }
  public DateTime createdDate { get; set; }
  public int productCount { get; set; }
  public decimal price { get; set; }
  public string productName { get; set; }
  public string firstName { get; set; }
  public string company { get; set; }
}