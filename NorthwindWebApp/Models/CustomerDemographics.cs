using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindWebApp.Models;

// CustomerDemographics model
[Table("customer_demographics")]
public class CustomerDemographics
{
    [Key]
    [Required(ErrorMessage = "Customer type ID is required")]
    public string CustomerTypeId { get; set; }

    [StringLength(100, ErrorMessage = "Customer description must be less than or equal to 100 characters")]
    public string CustomerDesc { get; set; }
}
