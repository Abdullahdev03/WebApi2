using Infrastucture.Services;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
  private ProductService _productService;
  public ProductController()
  {
    _productService = new ProductService();
  } 
  [HttpGet("GetCompany")]
    public List<GetProductDto> GetCompany()
    {
        var products = _productService.GetCompany();
        return products;
    }
    [HttpGet("GetNotCompany")]
    public List<GetProductDto> GetNotCompany()
    {
        var products = _productService.GetNotCompany();
        return products;
    }
  [HttpPost("Add")]
    public bool Add(Product product)
    {
      return _productService.AddProduct(product);
    }
  [HttpPut("Update")]
  public bool Update(Product product)
  {
    return _productService.UpdateProduct(product);
  }
  [HttpDelete("Delete")]
  public bool Delete(int id)
  {
    return _productService.DeleteProduct(id);
  }
}