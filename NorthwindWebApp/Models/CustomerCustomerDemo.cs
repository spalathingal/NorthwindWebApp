using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindWebApp.Models;

// CustomerCustomerDemo model
[Table("customer_customer_demo")]
public class CustomerCustomerDemo
{
    [Key]
    [Column(Order = 1)] // Specifies the order of the composite key
    [ForeignKey("Customer")]
    [Required(ErrorMessage = "Customer ID is required")]
    public string CustomerId { get; set; }

    [Key]
    [Column(Order = 2)] // Specifies the order of the composite key
    [ForeignKey("CustomerDemographics")]
    [Required(ErrorMessage = "Customer Type ID is required")]
    public string CustomerTypeId { get; set; }
}
