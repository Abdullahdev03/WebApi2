using Dapper;
using Npgsql;
namespace Infrastucture.Services;

public class OrderService
{
  
  private string _connectionString = "Server=127.0.0.1;Port=5432;Database=WebApi;User Id=postgres;Password=22385564;";

  public List<GetOrderDto> GetAll()
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = 
      $" select "+
      $" o.id, "+ 
      $" p.id as Productid, "+ 
      $" c.id as Customerid, "+
      $" o.createdat as CreatedDate, "+ 
      $" o.productCount  as Productcount, "+
      $" o.price as Price, "+
      $" p.productName as Productname, "+ 
      $" c.firstname from orders o "+
      $" join customers c on c.id = o.customerid "+ 
      $" join products p on o.productid = p.id";
      var result = connection.Query<GetOrderDto>(sql);
      return result.ToList();
    }
  }
  public List<GetOrderDto> GetApple()
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $" select o.id, o.productid, o.customerid, "+
      $" o.createdat,p.productname, p.productcount, p.price "+
      $" from orders o join products p  on p.id = o.productid "+
      $" where p.company  = 'Apple' ";
      var result = connection.Query<GetOrderDto>(sql);
      return result.ToList();
    }
  }

  public List<GetOrderDto> GetPrice(){
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = 
      $"select "+ 
      $" o.id ,"+
      $" p.id as ProductId , "+
      $" c.id as CustomerId , "+
      $" o.createdat as CreatedDate , "+
      $" o.productcount as ProductCount , "+
      $" sum(o.price*o.productcount) as Price ,"+ 
      $" p.productname as ProductName , "+
      $" c.firstname "+
      $" from orders o "+
      $" join customers c on c.id = o.customerid "+
      $" join products p on o.productid = p.id "+
      $" GROUP by o.productid,o.id,p.id,c.id,o.createdat,o.productcount,o.price,p.productname,c.firstname "+
      $" HAVING sum(o.price)*o.productcount>1000 ";
      var result = connection.Query<GetOrderDto>(sql);
      return result.ToList();
    }
  }
  public List<GetOrderDto> GetLeft(){
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = "select * from customers c left join orders o on c.id = o.customerid ";
      var result = connection.Query<GetOrderDto>(sql);
      return result.ToList();
    }
  }
    public List<GetOrderDto> GetFull(){
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = "select * from customers c full outer join orders o on c.id = o.customerid ";
      var result = connection.Query<GetOrderDto>(sql);
      return result.ToList();
    }
  }
    public List<GetOrderDto> GetRight(){
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = "select * from customers c full outer join orders o on c.id = o.customerid ";
      var result = connection.Query<GetOrderDto>(sql);
      return result.ToList();
    }
  }


/*546546468*/
    public bool AddOrder(Order order)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"INSERT INTO orders (id, productid, customerid, createdat, productcount, price)" +
      $" VALUES ('{order.id}','{order.productid}', '{order.customerid}','{order.createdat}','{order.productcount}', '{order.price}')";
      var insert = connection.Execute(sql);
      if (insert > 0) return true;
      else return false;
    }
  }
    public bool UpdateOrder(Order order)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"update orders set productid =  '{order.productid}', customerid = '{order.customerid}', createdat = '{order.createdat}', productcount = '{order.productcount}', price = '{order.price}' where id = '{order.id}'";
      var insert = connection.Execute(sql);
      if (insert > 0) return true;
      else return false;
    }
  }
    public bool DeleteOrder(int id)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"delete from orders where id = '{id}'";
      var insert = connection.Execute(sql);
      if (insert > 0) return true;
      else return false;
    }
  }

}