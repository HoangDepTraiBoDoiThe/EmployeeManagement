using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeeManagement.models.EmployeeTables;

namespace EmployeeManagement.models.JointTables;

public class EmployeeJob
{
    [Key] public string Id { get; set; } = Guid.NewGuid().ToString();
    
    // Many-to-one Employee
    public string EmployeeId { get; set; }
    [ForeignKey(nameof(EmployeeId))]
    public Employee Employee { get; set; } = null!;
    
    // Many-to-one Job
    public string EmployeeRoleId { get; set; }
    [ForeignKey(nameof(EmployeeRoleId))]
    public Job Job { get; set; } = null!;
}