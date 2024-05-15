using NorthwindWebApp.Context;
using NorthwindWebApp.DTOs;

namespace NorthwindWebApp.Services;

public class ProductsService
{
    private readonly NorthwindDbContext _context;

    public ProductsService(NorthwindDbContext context)
    {
        _context = context;
    }

    public List<ProductDTO> GetProducts()
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
                    (pc, supplier) => new ProductDTO
                    {
                        ProductName = pc.product.ProductName,
                        UnitPrice = pc.product.UnitPrice,
                        QuantityPerUnit = pc.product.QuantityPerUnit,
                        CategoryName = pc.category.CategoryName,
                        CategoryDescription = pc.category.Description,
                        SupplierName = supplier.CompanyName,
                        UnitsInStock = pc.product.UnitsInStock
                    })
                .ToList();

            return products;
        }
        catch (Exception ex)
        {
            // You can log the exception here
            throw new Exception($"Error fetching products: {ex.Message}");
        }
    }
}