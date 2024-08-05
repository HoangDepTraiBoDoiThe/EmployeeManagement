using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeeManagement.models.EmployeeTables;

namespace EmployeeManagement.models.WageTables;

public class MonthlyBonus
{
    [Key]
    public int MonthlyBonusId { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal BonusAmount { get; set; }
    public string? BonusReason {get; set;}

    // Many-to-many EmployeeWage
    public List<EmployeeWage> EmployeeWages { get; } = [];
}