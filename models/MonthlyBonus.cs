using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.models;

public class MonthlyBonus
{
    [Key]
    public int MonthlyBonusId { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal BonusAmount { get; set; }
    public string? BonusReason {get; set;}

    public List<EmployeeWage> EmployeeWages { get; } = null!;
}