using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.models.WageTables;

public class MonthlyBonus
{
    [Key]
    public string MonthlyBonusId { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal BonusAmount { get; set; }
    [MaxLength(100)]
    public string? BonusReason {get; set;}

    // Many-to-many EmployeeWage
    public List<EmployeeWage> EmployeeWages { get; } = [];
}