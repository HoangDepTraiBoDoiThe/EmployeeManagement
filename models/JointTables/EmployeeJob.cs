using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeeManagement.models.EmployeeTables;

namespace EmployeeManagement.models.JointTables;

public class EmployeeJob
{
    [Key]
    public int Id { get; set; }
    
    // Many-to-one Employee
    public int EmployeeId { get; set; }
    [ForeignKey(nameof(EmployeeId))]
    public Employee Employee { get; set; } = null!;
    
    // Many-to-one Job
    public int EmployeeRoleId { get; set; }
    [ForeignKey(nameof(EmployeeRoleId))]
    public Job Job { get; set; } = null!;
}