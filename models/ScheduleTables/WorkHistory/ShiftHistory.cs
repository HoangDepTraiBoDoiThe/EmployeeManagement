using System.ComponentModel.DataAnnotations.Schema;
using EmployeeManagement.models.ScheduleTables;

namespace EmployeeManagement.models;

public class ShiftHistory
{
    public int Id { get; set; }
    public DateTime Checkin { get; set; }
    public DateTime Checkout { get; set; }
    
    // Many-to-one BaseShiftSchedule
    public int ShiftScheduleId { get; set; }
    [ForeignKey(nameof(ShiftScheduleId))]
    public BaseShiftSchedule BaseShiftSchedule { get; set; } = null!;
    
    // One-to-many WorkOverTime
    public List<WorkOverTime> WorkOverTimes { get; }
    
    // One-to-many ShiftPenalty
    public List<ShiftPenalty> ShiftPenalties { get; }
    
    // One-to-many ShiftBonus
    public List<ShiftBonus> ShiftBonuses { get; }
}