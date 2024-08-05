using System.ComponentModel.DataAnnotations;
using EmployeeManagement.models.JointTables;

namespace EmployeeManagement.models;

public class EmployeeRole
{
    [Key]
    public int Id { get; set; }

    [Required] 
    [StringLength(50, ErrorMessage = "50 characters maximum")]
    public string RoleName { get; set; } = null!;
    public string? RoleDescription { get; set; }

    // One-to-many EmployeeEmployeeRole
    public List<EmployeeEmployeeRole> EmployeeEmployeeRoles { get; } = [];
}