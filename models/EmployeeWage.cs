using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeeManagement.Constants;
using EmployeeManagement.models.JointTables;

namespace EmployeeManagement.models;

public class EmployeeWage
{
    [Key]
    public int WageId { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal BaseSalary { get; set; }
    [Required]
    public PayFrequency PayFrequency { get; set; }

    [Required]
    public int EmployeeId { get; set; }
    [ForeignKey(nameof(EmployeeId))]
    public Employee Employee { get; set; } = null!;

    public List<MonthlyBonus> MonthlyBonuses { get; } = [];
    
    public EmployeeWage()
    {
    }
    
    public EmployeeWage(int wageId, decimal baseSalary, PayFrequency payFrequency, int employeeId, Employee employee)
    {
        WageId = wageId;
        BaseSalary = baseSalary;
        PayFrequency = payFrequency;
        EmployeeId = employeeId;
        Employee = employee;
    }
}