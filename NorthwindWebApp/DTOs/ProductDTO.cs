namespace NorthwindWebApp.DTOs;
public class ProductDTO
{
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public string QuantityPerUnit { get; set; }
    public string CategoryName { get; set; }
    public string CategoryDescription { get; set; }
    public string SupplierName { get; set; }
    public int UnitsInStock { get; set; }
}