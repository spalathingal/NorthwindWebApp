using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindWebApp.Models;

// Region model
[Table("regions")]
public class Region
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RegionId { get; set; }

    [Required(ErrorMessage = "Region description is required")]
    public string RegionDescription { get; set; }
}
