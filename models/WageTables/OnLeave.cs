using System.ComponentModel.DataAnnotations;
using EmployeeManagement.models.EmployeeTables;

namespace EmployeeManagement.models.WageTables;

public class OnLeave
{
    [Key]
    public int OnLeaveId { get; set; }
    
    [Required]
    public bool IsApproved { get; set; }
    [Required]
    public DateTime LeaveStartDate { get; set; }
    public DateTime LeaveEndDate { get; set; }
    public string? LeaveReason { get; set; }
    public bool WillBePunish { get; set; }
    
    // Many-to-one Employee
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;
}