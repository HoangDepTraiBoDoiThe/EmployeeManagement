using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.models;

public class ShiftSchedule
{
    [Key]
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string? Description { get; set; }
    
    // One to many ShiftHistory
    public List<ShiftHistory> ShiftHistories { get; } = null!;
    
    // Many-to-one ScheduleDay
    public int ScheduleDayId { get; set; }
    public ScheduleDay ScheduleDay { get; set; } = null!;
}