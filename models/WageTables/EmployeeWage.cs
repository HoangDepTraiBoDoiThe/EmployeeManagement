using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeeManagement.Constants;
using EmployeeManagement.models.ScheduleTables.WorkHistory;

namespace EmployeeManagement.models.WageTables;

public class EmployeeWage
{
    [Key]
    public string Id { get; set; }
 
    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal BaseSalary { get; set; }
    [Required]
    public PayFrequency PayFrequency { get; set; }
    
    // One-to-one WorkingHistory
    public string WorkingHistoryId { get; set; }
    [ForeignKey(nameof(WorkingHistoryId))]
    public WorkingHistory WorkingHistory { get; set; } = null!;
    
    // One-to-many PayRoll
    public List<PayRoll> PayRolls { get; } = null!;
    
    // Many-to-many MonthlyBonuses
    public List<MonthlyBonus> MonthlyBonuses { get; } = [];
}