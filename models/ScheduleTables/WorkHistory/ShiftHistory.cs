using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.models.ScheduleTables.WorkHistory;

public class ShiftHistory
{
    public string Id { get; set; }
    
    public DateTime Checkin { get; set; }
    public DateTime Checkout { get; set; }
    public DateTime BaseStartTime { get; set; }
    public DateTime BaseEndTime { get; set; }
    
    // Many-to-one BaseShiftSchedule
    public string ShiftScheduleId { get; set; }
    [ForeignKey(nameof(ShiftScheduleId))]
    public BaseShiftSchedule BaseShiftSchedule { get; set; } = null!;
    
    // One-to-many WorkingDayHistory
    public List<WorkingDayHistory> WorkingDayHistories { get; }
    
    // One-to-many WorkOverTime
    public List<WorkOverTime> WorkOverTimes { get; }
    
    // One-to-many ShiftPenalty
    public List<ShiftPenalty> ShiftPenalties { get; }
    
    // One-to-many ShiftBonus
    public List<ShiftBonus> ShiftBonuses { get; }
}