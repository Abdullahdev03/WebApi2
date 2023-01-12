using Dapper;
using Npgsql;

public class ProductService
{
  private string _connectionString = "Server=127.0.0.1;Port=5432;Database=WebApi;User Id=postgres;Password=22385564;";

  public List<GetProductDto> GetCompany()
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      
      string sql =  "SELECT * from products p " +
        $"where p.company in ('Xiaomi', 'Samsung', 'Apple')";
      var result = connection.Query<GetProductDto>(sql);
      return result.ToList();
    }
  }
  public List<GetProductDto> GetNotCompany()
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      
      string sql =  "SELECT * from products p " +
        $"where p.company not in ('Xiaomi', 'Samsung', 'Apple')";
      var result = connection.Query<GetProductDto>(sql);
      return result.ToList();
    }
  }

  public bool AddProduct(Product product)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = "insert into products (id, productname, company, productcount, price)" + 
      $" values ('{product.id}', '{product.productname}','{product.company}','{product.productcount}','{product.price}') ";
      var insert = connection.Execute(sql);
      if (insert > 0) return true;
      else return false;
    }
  }
  public bool UpdateProduct(Product product)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"update products set productname = '{product.productname}',  ,company = '{product.company}', productcount = '{product.productcount}',price = '{product.price}' where id = '{product.id}'";
      var update = connection.Execute(sql);
      if (update > 0) return true;
      else return false;
    }
  }
  public bool DeleteProduct(int id)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"delete from products where id = '{id}'";
      var delete = connection.Execute(sql);
      if (delete > 0) return true;
      else return false;
    }
  }
}