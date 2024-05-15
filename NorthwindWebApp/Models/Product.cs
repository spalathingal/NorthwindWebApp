using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindWebApp.Models;

// Product model
[Table("products")]
public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Product name is required")]
    public string ProductName { get; set; }

    [Required(ErrorMessage = "Supplier ID is required")]
    public int SupplierId { get; set; }

    [Required(ErrorMessage = "Category ID is required")]
    public int CategoryId { get; set; }

    public string QuantityPerUnit { get; set; }

    [Required(ErrorMessage = "Unit price is required")]
    public int UnitPrice { get; set; }

    [Required(ErrorMessage = "Units in stock is required")]
    public int UnitsInStock { get; set; }

    [Required(ErrorMessage = "Units on order is required")]
    public int UnitsOnOrder { get; set; }

    [Required(ErrorMessage = "Reorder level is required")]
    public int ReorderLevel { get; set; }

    public bool Discontinued { get; set; }
}
