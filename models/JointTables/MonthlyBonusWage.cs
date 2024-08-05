using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.models.JointTables;

public class MonthlyBonusWage
{
    public int EmployeeWageId { get; set; }
    public int MonthlyBonusId { get; set; }
    [ForeignKey(nameof(EmployeeWageId))]
    public List<EmployeeWage> EmployeeWages { get; set; } = null!;
    [ForeignKey(nameof(MonthlyBonusId))]
    public List<MonthlyBonus> MonthlyBonuses { get; set; } = null!;
}