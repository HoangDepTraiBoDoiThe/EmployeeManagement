using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.models;

public class WorkingTimeSchedule
{
    [Key]
    public int WorkingTimeScheduleId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string? Description { get; set; }
    
    // Many-to-one ScheduleDay
    public int ScheduleDayId { get; set; }
    public ScheduleDay ScheduleDay { get; set; } = null!;
}