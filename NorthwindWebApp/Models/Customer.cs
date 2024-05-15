using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NorthwindWebApp.Models;
// Customer model
[Table("customers")]
public class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ensures database generated
    public string CustomerId { get; set; }

    [Required(ErrorMessage = "Company name is required")]
    [StringLength(100, ErrorMessage = "Company name must be between 1 and 100 characters", MinimumLength = 1)]
    public string CompanyName { get; set; }

    [StringLength(50, ErrorMessage = "Contact name must be less than or equal to 50 characters")]
    public string ContactName { get; set; }

    [StringLength(50, ErrorMessage = "Contact title must be less than or equal to 50 characters")]
    public string ContactTitle { get; set; }

    [Required(ErrorMessage = "Address is required")]
    [StringLength(100, ErrorMessage = "Address must be between 1 and 100 characters", MinimumLength = 1)]
    public string Address { get; set; }

    [Required(ErrorMessage = "City is required")]
    [StringLength(50, ErrorMessage = "City must be between 1 and 50 characters", MinimumLength = 1)]
    public string City { get; set; }

    [StringLength(50, ErrorMessage = "Region must be less than or equal to 50 characters")]
    public string Region { get; set; }

    [Required(ErrorMessage = "Postal code is required")]
    [StringLength(20, ErrorMessage = "Postal code must be between 1 and 20 characters", MinimumLength = 1)]
    public string PostalCode { get; set; }

    [Required(ErrorMessage = "Country is required")]
    [StringLength(50, ErrorMessage = "Country must be between 1 and 50 characters", MinimumLength = 1)]
    public string Country { get; set; }

    [StringLength(20, ErrorMessage = "Phone must be less than or equal to 20 characters")]
    public string Phone { get; set; }

    [StringLength(20, ErrorMessage = "Fax must be less than or equal to 20 characters")]
    public string Fax { get; set; }
}
