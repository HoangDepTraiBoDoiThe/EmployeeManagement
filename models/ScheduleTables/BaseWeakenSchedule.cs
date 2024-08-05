using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeeManagement.Constants;

namespace EmployeeManagement.models;

public class BaseWeakenSchedule
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public Weeken WeekenDay { get; set; }
    
    // Many-to-one BaseWorkSchedule
    public int WorkScheduleId { get; set; }
    [ForeignKey(nameof(WorkScheduleId))]
    public BaseWorkSchedule BaseWorkSchedule { get; set; } = null!;
    
    // One-to-many BaseShiftSchedule
    public List<BaseShiftSchedule> WorkingTimeSchedules { get; } = null!;
}