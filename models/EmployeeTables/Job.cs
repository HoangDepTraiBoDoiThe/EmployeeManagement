using System.ComponentModel.DataAnnotations;
using EmployeeManagement.models.JointTables;

namespace EmployeeManagement.models.EmployeeTables;

public class Job
{
    [Key]
    public int Id { get; set; }

    [Required] 
    [StringLength(50, ErrorMessage = "50 characters maximum")]
    public string RoleName { get; set; } = null!;
    public string? RoleDescription { get; set; }

    // Many-to-many Employees
    public List<Employee> Employees { get; } = [];
}