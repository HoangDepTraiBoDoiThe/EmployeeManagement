using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.models.ScheduleTables.WorkHistory;

public class WorkingHistory
{
    [Key]
    public int Id { get; set; }
    
    [DataType(DataType.Date)]
    public DateOnly FromDate { get; set; }
    [DataType(DataType.Date)]
    public DateOnly ToDate { get; set; }
    
    // Many-to-one BaseWorkSchedule
    public int BaseWorkScheduleId { get; set; }
    [ForeignKey(nameof(BaseWorkScheduleId))]
    public BaseWorkSchedule WorkSchedule { get; set; } = null!;
}