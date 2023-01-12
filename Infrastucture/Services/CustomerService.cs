using Dapper;
using Npgsql;
namespace Infrastucture.Services;

public class CustomerService
{
  
  private string _connectionString = "Server=127.0.0.1;Port=5432;Database=WebApi;User Id=postgres;Password=22385564;";
/* holi tamoom nee  Get Customer fakat*/
  public List<GetCustomerDto> GetCustomerCount()
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = "select c.id, c.firstname, o.productcount from customers c " + 
        $"join orders o on c.id = o.customerid ";
      var result = connection.Query<GetCustomerDto>(sql);
      return result.ToList();
    }
  }
    public bool AddCustomer(Customer customer)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"INSERT INTO customers (id, firstname)" +
      $" VALUES ('{customer.id}','{customer.firstname}')";
      var insert = connection.Execute(sql);
      if (insert > 0) return true;
      else return false;
    }
  }
    public bool UpdateCustomer(Customer customer)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"update customers set firstname =  '{customer.Equals}', where id = '{customer.id}'";
      var insert = connection.Execute(sql);
      if (insert > 0) return true;
      else return false;
    }
  }
    public bool DeleteCustomer(int id)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"delete from customers where id = '{id}'";
      var insert = connection.Execute(sql);
      if (insert > 0) return true;
      else return false;
    }
  }

}