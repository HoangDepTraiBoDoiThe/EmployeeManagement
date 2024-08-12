using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.models.ScheduleTables.WorkHistory;

public class WorkingDayHistory
{
    [Key] public string Id { get; set; }
    
    [Required]
    public DayOfWeek DayOfWeek { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateOnly DateTime { get; set; }
    
    // Many-to-one WorkingHistory
    public string WorkingHistoryId { get; set; }
    public WorkingHistory WorkingHistory { get; set; } = null!;
}