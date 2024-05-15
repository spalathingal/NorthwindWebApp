using Microsoft.AspNetCore.Mvc;
using NorthwindWebApp.Services;

namespace NorthwindWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductsService _productsService;

    public ProductsController(ProductsService productsService)
    {
        _productsService = productsService;
    }

    // GET: api/products
    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = _productsService.GetProducts();
        return Ok(products);
    }
}