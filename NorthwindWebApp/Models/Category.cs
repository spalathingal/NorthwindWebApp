using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindWebApp.Models;
// Category model
[Table("categories")]
public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Category name is required")]
    [StringLength(100, ErrorMessage = "Category name must be between 1 and 100 characters", MinimumLength = 1)]
    public string CategoryName { get; set; }

    [StringLength(500, ErrorMessage = "Description must be less than 500 characters")]
    public string Description { get; set; }

    // Assuming Image maps to byte array
    public byte[] Picture { get; set; }
}
