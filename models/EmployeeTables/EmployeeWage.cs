using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeeManagement.Constants;
using EmployeeManagement.models.WageTables;

namespace EmployeeManagement.models.EmployeeTables;

public class EmployeeWage
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal BaseSalary { get; set; }
    [Required]
    public PayFrequency PayFrequency { get; set; }

    // Many to many MonthlyBonuses
    public List<MonthlyBonus> MonthlyBonuses { get; } = [];
    
    // One to one Employee role
    [Required]
    public int EmployeeRoleId { get; set; }
    [ForeignKey(nameof(EmployeeRoleId))] 
    public EmployeeRole EmployeeRole { get; set; } = null!;

    // Many-to-one PayRoll
    public List<PayRoll> PayRolls { get; } = [];
}