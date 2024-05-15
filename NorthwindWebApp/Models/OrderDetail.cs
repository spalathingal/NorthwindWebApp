using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindWebApp.Models;

// OrderDetail model
[Table("order details")]
public class OrderDetail
{
    [Key]
    [Column(Order = 1)] // Composite primary key with OrderId
    [ForeignKey("Order")]
    public int OrderId { get; set; }

    [Key]
    [Column(Order = 2)] // Composite primary key with ProductId
    [ForeignKey("Product")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Unit price is required")]
    public int UnitPrice { get; set; }

    [Required(ErrorMessage = "Quantity is required")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Discount is required")]
    public int Discount { get; set; }

    public virtual Order Order { get; set; } // Navigation property
    public virtual Product Product { get; set; } // Navigation property
}
