using Infrastucture.Services;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;
[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
  private CustomerService  _customerService;
  public CustomerController()
  {
    _customerService = new CustomerService();
  }
  [HttpGet("customer")]
  public List<GetCustomerDto> GetCustomerCount()
  {
    var customer = _customerService.GetCustomerCount();
    return customer;
  }


  
  [HttpPost("Add")]
  public bool Add(Customer customer)
  {
    return _customerService.AddCustomer(customer);
  }
  [HttpPut("Update")]
  public bool Update(Customer customer)
  {
    return _customerService.UpdateCustomer(customer);
  }
  [HttpDelete("Delete")]
  public bool Delete(int id)
  {
    return _customerService.DeleteCustomer(id);
  }
}