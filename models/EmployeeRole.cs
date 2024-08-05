using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.models;

public class EmployeeRole
{
    [Key]
    public int Id { get; set; }

    [Required] 
    [StringLength(50, ErrorMessage = "50 characters maximum")]
    public string RoleName { get; set; } = null!;
    public string? RoleDescription { get; set; }

    [Required]
    public int EmployeeId { get; set; }
    [ForeignKey(nameof(EmployeeId))] 
    public Employee Employee { get; set; } = null!;
    
    // One to one EmployeeWage
    public EmployeeWage? EmployeeWage { get; set; }
}