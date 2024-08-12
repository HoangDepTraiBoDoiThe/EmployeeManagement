using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.models.ScheduleTables.WorkHistory;

public class WorkingHistory
{
    [Key]
    public string Id { get; set; }
    
    [Required]
    public DateTime FromTime { get; set; }
    [Required]
    public DateOnly ToTime { get; set; }
    
    // Many-to-one BaseWorkSchedule
    public string BaseWorkScheduleId { get; set; }
    [ForeignKey(nameof(BaseWorkScheduleId))]
    public BaseWorkSchedule WorkSchedule { get; set; } = null!;
    
    // One-to-many OnLeaveHistory
    public List<OnLeaveHistory> OnLeaveHistories { get; } = null!;
    
    // One-to-many WorkingDayHistory
    public List<WorkingDayHistory> WorkingDayHistories { get; } = null!;
}