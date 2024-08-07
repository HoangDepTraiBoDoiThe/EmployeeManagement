using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.models.WageTables;

public class PayRoll
{
    [Key]
    public int Id { get; set; }
    
    [Required] 
    public DateTime PayDate { get; set; }
    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalEarnings { get; set; }
    
    // Many-to-one EmployeeWage
    public int EmployeeWageId { get; set; }
    [ForeignKey(nameof(EmployeeWageId))] 
    public EmployeeWage EmployeeWage { get; set; } = null!;
}