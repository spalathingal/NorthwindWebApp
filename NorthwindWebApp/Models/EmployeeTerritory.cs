using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindWebApp.Models;

// EmployeeTerritory model
[Table("employee_territories")]
public class EmployeeTerritory
{
    [Key]
    [Column(Order = 1)] // Specifies the order of the composite key
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }

    [Key]
    [Column(Order = 2)] // Specifies the order of the composite key
    [StringLength(20, ErrorMessage = "Territory ID must be less than or equal to 20 characters")]
    [ForeignKey("Territory")]
    public string TerritoryId { get; set; }

    public virtual Employee Employee { get; set; } // Navigation property
    public virtual Territory Territory { get; set; } // Navigation property
}
