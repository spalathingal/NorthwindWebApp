using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindWebApp.Models;

// Territory model
[Table("territories")]
public class Territory
{
    [Key]
    [Required(ErrorMessage = "Territory ID is required")]
    public string TerritoryId { get; set; }

    [Required(ErrorMessage = "Territory description is required")]
    public string TerritoryDescription { get; set; }

    [Required(ErrorMessage = "Region ID is required")]
    [ForeignKey("Region")]
    public int RegionId { get; set; }

    public Region Region { get; set; }
}
