using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindWebApp.Models;

// Employee model
[Table("employees")]
public class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(50, ErrorMessage = "Last name must be between 1 and 50 characters", MinimumLength = 1)]
    public string LastName { get; set; }

    [Required(ErrorMessage = "First name is required")]
    [StringLength(50, ErrorMessage = "First name must be between 1 and 50 characters", MinimumLength = 1)]
    public string FirstName { get; set; }

    [StringLength(50, ErrorMessage = "Title must be less than or equal to 50 characters")]
    public string Title { get; set; }

    [StringLength(50, ErrorMessage = "Title of courtesy must be less than or equal to 50 characters")]
    public string TitleOfCourtesy { get; set; }

    [Required(ErrorMessage = "Birth date is required")]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "Hire date is required")]
    public DateTime HireDate { get; set; }

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

    [StringLength(20, ErrorMessage = "Home phone must be less than or equal to 20 characters")]
    public string HomePhone { get; set; }

    [StringLength(10, ErrorMessage = "Extension must be less than or equal to 10 characters")]
    public string Extension { get; set; }

    // Assuming Image maps to byte array
    public byte[] Photo { get; set; }

    [StringLength(1000, ErrorMessage = "Notes must be less than or equal to 1000 characters")]
    public string Notes { get; set; }

    [ForeignKey("EmployeeId")] // Specifies foreign key relationship
    public int ReportsTo { get; set; }

    [StringLength(255, ErrorMessage = "Photo path must be less than or equal to 255 characters")]
    public string PhotoPath { get; set; }
}
