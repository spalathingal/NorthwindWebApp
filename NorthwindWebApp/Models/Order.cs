using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindWebApp.Models;

// Order model
[Table("orders")]
public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }

    [Required(ErrorMessage = "Customer ID is required")]
    [StringLength(5, ErrorMessage = "Customer ID must be exactly 5 characters")]
    public string CustomerId { get; set; }

    [Required(ErrorMessage = "Employee ID is required")]
    public int EmployeeId { get; set; }

    [Required(ErrorMessage = "Order date is required")]
    public DateTime OrderDate { get; set; }

    [Required(ErrorMessage = "Required date is required")]
    public DateTime RequiredDate { get; set; }

    [Required(ErrorMessage = "Shipped date is required")]
    public DateTime? ShippedDate { get; set; }

    [Required(ErrorMessage = "Ship via is required")]
    public int ShipVia { get; set; }

    [Required(ErrorMessage = "Freight is required")]
    public int Freight { get; set; }

    [Required(ErrorMessage = "Ship name is required")]
    public string ShipName { get; set; }

    [Required(ErrorMessage = "Ship address is required")]
    public string ShipAddress { get; set; }

    [Required(ErrorMessage = "Ship city is required")]
    public string ShipCity { get; set; }

    [Required(ErrorMessage = "Ship region is required")]
    public string ShipRegion { get; set; }

    [Required(ErrorMessage = "Ship postal code is required")]
    public string ShipPostalCode { get; set; }

    [Required(ErrorMessage = "Ship country is required")]
    public string ShipCountry { get; set; }
}
