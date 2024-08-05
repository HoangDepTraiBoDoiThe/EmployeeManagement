using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeeManagement.Constants;

namespace EmployeeManagement.models;

public class ScheduleDay
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public Weeken WeekenDay { get; set; }
    
    // Many-to-one WorkSchedule
    public int WorkScheduleId { get; set; }
    [ForeignKey(nameof(WorkScheduleId))]
    public WorkSchedule WorkSchedule { get; set; } = null!;
    
    // One-to-many WorkingTimeSchedule
    public List<WorkingTimeSchedule> WorkingTimeSchedules { get; } = null!;
}