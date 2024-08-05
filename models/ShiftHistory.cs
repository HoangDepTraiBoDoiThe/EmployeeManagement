using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.models;

public class ShiftHistory
{
    public int Id { get; set; }
    public DateTime Checkin { get; set; }
    public DateTime Checkout { get; set; }
    
    // Many-to-one ShiftSchedule
    public int ShiftScheduleId { get; set; }
    [ForeignKey(nameof(ShiftScheduleId))]
    public ShiftSchedule ShiftSchedule { get; set; } = null!;
}