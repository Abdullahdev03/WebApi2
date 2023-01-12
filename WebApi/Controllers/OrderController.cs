using Infrastucture.Services;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;
[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
  private OrderService _orderService;
  public OrderController()
  {
    _orderService = new OrderService();
  } 
  [HttpGet("GETALL")]
    public List<GetOrderDto> GetAll()
    {
        var orders = _orderService.GetAll();
        return orders;
    }
     [HttpGet("GETApple")]
    public List<GetOrderDto> GetApple()
    {
        var orders = _orderService.GetApple();
        return orders;
    } 
     [HttpGet("GETPrice")]
    public List<GetOrderDto> GetPrice()
    {
        var orders = _orderService.GetPrice();
        return orders;
    }
    [HttpGet("GETFull")]
    public List<GetOrderDto> GetFull()
    {
        var orders = _orderService.GetFull();
        return orders;
    } 
    [HttpGet("GETLeft")]
    public List<GetOrderDto> GetLeft()
    {
        var orders = _orderService.GetLeft();
        return orders;
    } 
    [HttpGet("GETRight")]
    public List<GetOrderDto> GetRight()
    {
        var orders = _orderService.GetRight();
        return orders;
    } 

  [HttpPost("Add")]
    public bool Add(Order order)
    {
      return _orderService.AddOrder(order);
    }
  [HttpPut("Update")]
  public bool Update(Order order)
  {
    return _orderService.UpdateOrder(order);
  }
  [HttpDelete("Delete")]
  public bool Delete(int id)
  {
    return _orderService.DeleteOrder(id);
  }
}