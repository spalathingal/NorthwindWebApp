using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindWebApp.Models;

// Supplier model
[Table("suppliers")]
public class Supplier
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SupplierId { get; set; }

    [Required(ErrorMessage = "Company name is required")]
    public string CompanyName { get; set; }

    [Required(ErrorMessage = "Contact name is required")]
    public string ContactName { get; set; }

    [Required(ErrorMessage = "Contact title is required")]
    public string ContactTitle { get; set; }

    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; }

    [Required(ErrorMessage = "City is required")]
    public string City { get; set; }

    public string Region { get; set; }

    [Required(ErrorMessage = "Postal code is required")]
    public string PostalCode { get; set; }

    [Required(ErrorMessage = "Country is required")]
    public string Country { get; set; }

    [Required(ErrorMessage = "Phone number is required")]
    [Phone(ErrorMessage = "Invalid phone number format")]
    public string Phone { get; set; }

    [Phone(ErrorMessage = "Invalid fax number format")]
    public string Fax { get; set; }

    [Url(ErrorMessage = "Invalid URL format")]
    public string Homepage { get; set; }
}
