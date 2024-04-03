using Microsoft.AspNetCore.Mvc;
using NorthwindWebApp.Models;

namespace NorthwindWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly NorthwindDbContext _context;

        public ProductsController(NorthwindDbContext context)
        {
            _context = context;
        }

        // GET: api/products
        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                var products = _context.Products
                    .Join(_context.Categories,
                        product => product.CategoryId,
                        category => category.CategoryId,
                        (product, category) => new
                        {
                            product,
                            category
                        })
                    .Join(_context.Suppliers,
                        pc => pc.product.SupplierId,
                        supplier => supplier.SupplierId,
                        (pc, supplier) => new
                        {
                            ProductName = pc.product.ProductName,
                            UnitPrice = pc.product.UnitPrice,
                            QuantityPerUnit = pc.product.QuantityPerUnit,
                            CategoryName = pc.category.CategoryName,
                            CategoryDescription = pc.category.Description,
                            SupplierName = supplier.CompanyName,
                            pc.product.UnitsInStock
                        })
                    .ToList();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}