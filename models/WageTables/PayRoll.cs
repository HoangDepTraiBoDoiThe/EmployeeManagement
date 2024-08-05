using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.models;

public class PayRoll
{
    [Key] 
    public int Id;
    [Required] 
    public DateTime PayDate { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    [Required] public decimal TotalEarnings { get; set; }
    
    // Many-to-one EmployeeWage
    public int EmployeeWageId { get; set; }
    [ForeignKey(nameof(EmployeeWageId))] 
    public EmployeeWage EmployeeWage { get; set; } = null!;
}