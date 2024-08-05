using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.models;

public class EmployeeRole
{
    [Key]
    public int Id { get; set; }

    [Required] 
    [StringLength(50, ErrorMessage = "50 characters maximum")]
    public string RoleName { get; set; } = null!;
    public string? RoleDescription { get; set; }
    
    // Many-to-many Employee
    public List<Employee> Employees { get; } = [];
}