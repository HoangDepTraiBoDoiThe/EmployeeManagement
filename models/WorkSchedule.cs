using System.ComponentModel.DataAnnotations;
using EmployeeManagement.models.JointTables;

namespace EmployeeManagement.models;

public class WorkSchedule
{
    [Key]
    public int Id { get; set; }
    
    // One to many ScheduleDay
    public List<ScheduleDay> ScheduleDays { get; } = null!;
    
    // One-to-one EmployeeEmployeeRole
    public int EmployeeRoleId { get; set; }
    public int EmployeeId { get; set; }
    public EmployeeEmployeeRole EmployeeEmployeeRole { get; set; } = null!;
}