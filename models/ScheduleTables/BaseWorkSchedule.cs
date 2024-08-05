using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeeManagement.models.JointTables;

namespace EmployeeManagement.models;

public class BaseWorkSchedule
{
    [Key]
    public int Id { get; set; }
    
    // One to many BaseWeakenSchedule
    public List<BaseWeakenSchedule> ScheduleDays { get; } = null!;
    
    // One-to-one EmployeeEmployeeRole
    public int EmployeeEmployeeRoleId { get; set; }
    [ForeignKey(nameof(EmployeeEmployeeRoleId))]
    public EmployeeEmployeeRole EmployeeEmployeeRole { get; set; } = null!;
}